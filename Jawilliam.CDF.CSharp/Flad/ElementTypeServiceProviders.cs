
using Jawilliam.CDF.Approach.Flad;
using Jawilliam.CDF.Domain;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Provides language-aware services regarding <see cref="SyntaxToken"/>.
    /// </summary>
    public partial class SyntaxTokenServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SyntaxTokenServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) { }
    
    	/// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            if (original == null || modified == null)
                return false;
        
            if (!string.IsNullOrWhiteSpace(original.ValueText) && !string.IsNullOrWhiteSpace(modified.ValueText) && original.ValueText == modified.ValueText)
                return true;
        
            return false;
        }
    }
    
    partial class LanguageServiceProvider
    {
    	/// <summary>
        /// Determines if two typed elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
        /// <typeparam name="TModified">Type of the original version.</typeparam>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(IEqualityCondition<,>), "ExactlyEqual", out object result))
                return (bool)result;
        
            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as IEqualityCondition<TOriginal, TModified>;
            return serviceProvider?.ExactlyEqual(original, modified) ?? false;
        }
    
        /// <summary>
        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="equal">logic of equality.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        protected virtual bool ExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified, Func<T, T, bool> equal) where T : SyntaxNode
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
        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
        {
            return this.ExactlyEqual(original, modified, this.ExactlyEqual);
        }
    
        /// <summary>
        /// Determines if two <see cref="SyntaxList{TNode}"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="equal">logic of equality.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        protected virtual bool ExactlyEqual<T>(SyntaxList<T> original, SyntaxList<T> modified, Func<T, T, bool> equal) where T : SyntaxNode
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
        /// Determines if two <see cref="SyntaxList{TNode}"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual<T>(SyntaxList<T> original, SyntaxList<T> modified) where T : SyntaxNode
        {
            return this.ExactlyEqual(original, modified, this.ExactlyEqual);
        }
    
        /// <summary>
        /// Determines if two <see cref="SyntaxTokenList"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="equal">logic of equality.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SyntaxTokenList original, SyntaxTokenList modified)
        {
            if (original == null || modified == null)
                return false;
    
            if (original.Count != modified.Count)
                return false;
    
            for (int i = 0; i < original.Count; i++)
            {
                if (!this.ExactlyEqual(original[i], modified[i]))
                    return false;
            }
            return true;
        }
    
    	/// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            return this.SyntaxTokenServiceProvider.ExactlyEqual(original, modified);
        }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeArgument"/>.
    /// </summary>
    public partial class AttributeArgumentServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameEquals";
    			yield return "NameColon";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> is not executed and <see cref="ExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.NameEquals == null && modified.NameEquals == null) || (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.ExactlyEqual(original.NameEquals, modified.NameEquals))) &&
                ((original.NameColon == null && modified.NameColon == null) || (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.ExactlyEqual(original.NameColon, modified.NameColon))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameEquals"/>.
    /// </summary>
    public partial class NameEqualsServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameEqualsServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/> is not executed and <see cref="ExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
        partial void ExactlyEqualAfter(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameEqualsSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(NameEqualsSyntax original, NameEqualsSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="NameEqualsSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(NameEqualsSyntax original, NameEqualsSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameterList"/>.
    /// </summary>
    public partial class TypeParameterListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Parameters";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeParameterListSyntax original, TypeParameterListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanToken, modified.LessThanToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.GreaterThanToken, modified.GreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeParameterListSyntax original, TypeParameterListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameter"/>.
    /// </summary>
    public partial class TypeParameterServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "VarianceKeyword";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeParameterSyntax original, TypeParameterSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                ((original.VarianceKeyword == null && modified.VarianceKeyword == null) || (original.VarianceKeyword != null && modified.VarianceKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.VarianceKeyword, modified.VarianceKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeParameterSyntax original, TypeParameterSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseList"/>.
    /// </summary>
    public partial class BaseListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "Types";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BaseListSyntax, BaseListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BaseListSyntax, BaseListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BaseListSyntax, BaseListSyntax)"/> is not executed and <see cref="ExactlyEqual(BaseListSyntax, BaseListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BaseListSyntax original, BaseListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BaseListSyntax, BaseListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BaseListSyntax, BaseListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BaseListSyntax original, BaseListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BaseListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BaseListSyntax, BaseListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BaseListSyntax original, BaseListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Types, modified.Types)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BaseListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BaseListSyntax original, BaseListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameterConstraintClause"/>.
    /// </summary>
    public partial class TypeParameterConstraintClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterConstraintClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "Name";
    			yield return "ColonToken";
    			yield return "Constraints";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.WhereKeyword, modified.WhereKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Constraints, modified.Constraints)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExplicitInterfaceSpecifier"/>.
    /// </summary>
    public partial class ExplicitInterfaceSpecifierServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExplicitInterfaceSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "DotToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> is not executed and <see cref="ExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DotToken, modified.DotToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorInitializer"/>.
    /// </summary>
    public partial class ConstructorInitializerServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorInitializerServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "ThisOrBaseKeyword";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/> is not executed and <see cref="ExactlyEqual(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConstructorInitializerSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ThisOrBaseKeyword, modified.ThisOrBaseKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConstructorInitializerSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrowExpressionClause"/>.
    /// </summary>
    public partial class ArrowExpressionClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrowExpressionClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArrowToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArrowExpressionClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ArrowToken, modified.ArrowToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArrowExpressionClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AccessorList"/>.
    /// </summary>
    public partial class AccessorListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AccessorListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Accessors";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AccessorListSyntax, AccessorListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AccessorListSyntax, AccessorListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AccessorListSyntax, AccessorListSyntax)"/> is not executed and <see cref="ExactlyEqual(AccessorListSyntax, AccessorListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AccessorListSyntax original, AccessorListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AccessorListSyntax, AccessorListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AccessorListSyntax, AccessorListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AccessorListSyntax original, AccessorListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AccessorListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AccessorListSyntax, AccessorListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AccessorListSyntax original, AccessorListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Accessors, modified.Accessors)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AccessorListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AccessorListSyntax original, AccessorListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AccessorDeclaration"/>.
    /// </summary>
    public partial class AccessorDeclarationServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AccessorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AccessorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AccessorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Parameter"/>.
    /// </summary>
    public partial class ParameterServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "Default";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/> is not executed and <see cref="ExactlyEqual(ParameterSyntax, ParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ParameterSyntax original, ParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ParameterSyntax original, ParameterSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ParameterSyntax original, ParameterSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.Default == null && modified.Default == null) || (original.Default != null && modified.Default != null && this.LanguageServiceProvider.ExactlyEqual(original.Default, modified.Default))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ParameterSyntax original, ParameterSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefParameter"/>.
    /// </summary>
    public partial class CrefParameterServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefOrOutKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/> is not executed and <see cref="ExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CrefParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CrefParameterSyntax original, CrefParameterSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.RefOrOutKeyword == null && modified.RefOrOutKeyword == null) || (original.RefOrOutKeyword != null && modified.RefOrOutKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.RefOrOutKeyword, modified.RefOrOutKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CrefParameterSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CrefParameterSyntax original, CrefParameterSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElementStartTag"/>.
    /// </summary>
    public partial class XmlElementStartTagServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementStartTagServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Name";
    			yield return "Attributes";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanToken, modified.LessThanToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Attributes, modified.Attributes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.GreaterThanToken, modified.GreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElementEndTag"/>.
    /// </summary>
    public partial class XmlElementEndTagServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementEndTagServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanSlashToken";
    			yield return "Name";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanSlashToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanSlashToken, modified.LessThanSlashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.GreaterThanToken, modified.GreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlName"/>.
    /// </summary>
    public partial class XmlNameServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Prefix";
    			yield return "LocalName";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlNameSyntax original, XmlNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlNameSyntax original, XmlNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlNameSyntax original, XmlNameSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.Prefix == null && modified.Prefix == null) || (original.Prefix != null && modified.Prefix != null && this.LanguageServiceProvider.ExactlyEqual(original.Prefix, modified.Prefix))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.LocalName, modified.LocalName)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlNameSyntax original, XmlNameSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlPrefix"/>.
    /// </summary>
    public partial class XmlPrefixServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlPrefixServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Prefix";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlPrefixSyntax original, XmlPrefixSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Prefix, modified.Prefix)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlPrefixSyntax original, XmlPrefixSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeArgumentList"/>.
    /// </summary>
    public partial class TypeArgumentListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Arguments";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeArgumentListSyntax, TypeArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanToken, modified.LessThanToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Arguments, modified.Arguments)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.GreaterThanToken, modified.GreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayRankSpecifier"/>.
    /// </summary>
    public partial class ArrayRankSpecifierServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayRankSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Sizes";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/> is not executed and <see cref="ExactlyEqual(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArrayRankSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Sizes, modified.Sizes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArrayRankSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleElement"/>.
    /// </summary>
    public partial class TupleElementServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/> is not executed and <see cref="ExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TupleElementSyntax original, TupleElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TupleElementSyntax original, TupleElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TupleElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TupleElementSyntax original, TupleElementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.Identifier == null && modified.Identifier == null) || (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TupleElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TupleElementSyntax original, TupleElementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Argument"/>.
    /// </summary>
    public partial class ArgumentServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameColon";
    			yield return "RefOrOutKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/> is not executed and <see cref="ExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArgumentSyntax original, ArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArgumentSyntax original, ArgumentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArgumentSyntax original, ArgumentSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.NameColon == null && modified.NameColon == null) || (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.ExactlyEqual(original.NameColon, modified.NameColon))) &&
                ((original.RefOrOutKeyword == null && modified.RefOrOutKeyword == null) || (original.RefOrOutKeyword != null && modified.RefOrOutKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.RefOrOutKeyword, modified.RefOrOutKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArgumentSyntax original, ArgumentSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameColon"/>.
    /// </summary>
    public partial class NameColonServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameColonServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/> is not executed and <see cref="ExactlyEqual(NameColonSyntax, NameColonSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(NameColonSyntax original, NameColonSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</param>
        partial void ExactlyEqualAfter(NameColonSyntax original, NameColonSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameColonSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(NameColonSyntax original, NameColonSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="NameColonSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(NameColonSyntax original, NameColonSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousObjectMemberDeclarator"/>.
    /// </summary>
    public partial class AnonymousObjectMemberDeclaratorServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousObjectMemberDeclaratorServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameEquals";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> is not executed and <see cref="ExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.NameEquals == null && modified.NameEquals == null) || (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.ExactlyEqual(original.NameEquals, modified.NameEquals))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryBody"/>.
    /// </summary>
    public partial class QueryBodyServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryBodyServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Clauses";
    			yield return "SelectOrGroup";
    			yield return "Continuation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/> is not executed and <see cref="ExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(QueryBodySyntax original, QueryBodySyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</param>
        partial void ExactlyEqualAfter(QueryBodySyntax original, QueryBodySyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryBodySyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(QueryBodySyntax original, QueryBodySyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Clauses, modified.Clauses)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SelectOrGroup, modified.SelectOrGroup)) &&
                ((original.Continuation == null && modified.Continuation == null) || (original.Continuation != null && modified.Continuation != null && this.LanguageServiceProvider.ExactlyEqual(original.Continuation, modified.Continuation))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="QueryBodySyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(QueryBodySyntax original, QueryBodySyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="JoinIntoClause"/>.
    /// </summary>
    public partial class JoinIntoClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public JoinIntoClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IntoKeyword";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IntoKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.IntoKeyword, modified.IntoKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Ordering"/>.
    /// </summary>
    public partial class OrderingServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OrderingServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "AscendingOrDescendingKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AscendingOrDescendingKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OrderingSyntax, OrderingSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OrderingSyntax, OrderingSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OrderingSyntax, OrderingSyntax)"/> is not executed and <see cref="ExactlyEqual(OrderingSyntax, OrderingSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OrderingSyntax original, OrderingSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OrderingSyntax, OrderingSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OrderingSyntax, OrderingSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OrderingSyntax original, OrderingSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OrderingSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OrderingSyntax, OrderingSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OrderingSyntax original, OrderingSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                ((original.AscendingOrDescendingKeyword == null && modified.AscendingOrDescendingKeyword == null) || (original.AscendingOrDescendingKeyword != null && modified.AscendingOrDescendingKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.AscendingOrDescendingKeyword, modified.AscendingOrDescendingKeyword))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OrderingSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OrderingSyntax original, OrderingSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryContinuation"/>.
    /// </summary>
    public partial class QueryContinuationServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryContinuationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IntoKeyword";
    			yield return "Identifier";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IntoKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/> is not executed and <see cref="ExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(QueryContinuationSyntax original, QueryContinuationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.IntoKeyword, modified.IntoKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(QueryContinuationSyntax original, QueryContinuationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhenClause"/>.
    /// </summary>
    public partial class WhenClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhenClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "Condition";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhenKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(WhenClauseSyntax, WhenClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhenClauseSyntax, WhenClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(WhenClauseSyntax, WhenClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(WhenClauseSyntax, WhenClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(WhenClauseSyntax original, WhenClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(WhenClauseSyntax, WhenClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhenClauseSyntax, WhenClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(WhenClauseSyntax original, WhenClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="WhenClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(WhenClauseSyntax, WhenClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(WhenClauseSyntax original, WhenClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.WhenKeyword, modified.WhenKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="WhenClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(WhenClauseSyntax original, WhenClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolationAlignmentClause"/>.
    /// </summary>
    public partial class InterpolationAlignmentClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationAlignmentClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "CommaToken";
    			yield return "Value";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "CommaToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterpolationAlignmentClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.CommaToken, modified.CommaToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Value, modified.Value)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterpolationAlignmentClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolationFormatClause"/>.
    /// </summary>
    public partial class InterpolationFormatClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationFormatClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "FormatStringToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterpolationFormatClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.FormatStringToken, modified.FormatStringToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterpolationFormatClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="VariableDeclaration"/>.
    /// </summary>
    public partial class VariableDeclarationServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public VariableDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Variables";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Variables, modified.Variables)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="VariableDeclarator"/>.
    /// </summary>
    public partial class VariableDeclaratorServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public VariableDeclaratorServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ArgumentList";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> is not executed and <see cref="ExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
        partial void ExactlyEqualAfter(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList))) &&
                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EqualsValueClause"/>.
    /// </summary>
    public partial class EqualsValueClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EqualsValueClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "EqualsToken";
    			yield return "Value";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EqualsValueClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Value, modified.Value)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EqualsValueClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElseClause"/>.
    /// </summary>
    public partial class ElseClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElseClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElseKeyword";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ElseKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ElseClauseSyntax, ElseClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElseClauseSyntax, ElseClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ElseClauseSyntax, ElseClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(ElseClauseSyntax, ElseClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ElseClauseSyntax original, ElseClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ElseClauseSyntax, ElseClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElseClauseSyntax, ElseClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ElseClauseSyntax original, ElseClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ElseClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ElseClauseSyntax, ElseClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ElseClauseSyntax original, ElseClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ElseKeyword, modified.ElseKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ElseClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ElseClauseSyntax original, ElseClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SwitchSection"/>.
    /// </summary>
    public partial class SwitchSectionServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SwitchSectionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Labels";
    			yield return "Statements";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/> is not executed and <see cref="ExactlyEqual(SwitchSectionSyntax, SwitchSectionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SwitchSectionSyntax original, SwitchSectionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SwitchSectionSyntax original, SwitchSectionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SwitchSectionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SwitchSectionSyntax original, SwitchSectionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Labels, modified.Labels)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statements, modified.Statements)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SwitchSectionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SwitchSectionSyntax original, SwitchSectionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchClause"/>.
    /// </summary>
    public partial class CatchClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "CatchKeyword";
    			yield return "Declaration";
    			yield return "Filter";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "CatchKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CatchClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CatchClauseSyntax original, CatchClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.CatchKeyword, modified.CatchKeyword)) &&
                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration))) &&
                ((original.Filter == null && modified.Filter == null) || (original.Filter != null && modified.Filter != null && this.LanguageServiceProvider.ExactlyEqual(original.Filter, modified.Filter))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Block, modified.Block)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CatchClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CatchClauseSyntax original, CatchClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchDeclaration"/>.
    /// </summary>
    public partial class CatchDeclarationServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.Identifier == null && modified.Identifier == null) || (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchFilterClause"/>.
    /// </summary>
    public partial class CatchFilterClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchFilterClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "OpenParenToken";
    			yield return "FilterExpression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CatchFilterClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.WhenKeyword, modified.WhenKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.FilterExpression, modified.FilterExpression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CatchFilterClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="FinallyClause"/>.
    /// </summary>
    public partial class FinallyClauseServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FinallyClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FinallyKeyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FinallyKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(FinallyClauseSyntax, FinallyClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(FinallyClauseSyntax original, FinallyClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(FinallyClauseSyntax original, FinallyClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FinallyClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(FinallyClauseSyntax original, FinallyClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.FinallyKeyword, modified.FinallyKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Block, modified.Block)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="FinallyClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(FinallyClauseSyntax original, FinallyClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CompilationUnit"/>.
    /// </summary>
    public partial class CompilationUnitServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CompilationUnitServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Externs";
    			yield return "Usings";
    			yield return "AttributeLists";
    			yield return "Members";
    			yield return "EndOfFileToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EndOfFileToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/> is not executed and <see cref="ExactlyEqual(CompilationUnitSyntax, CompilationUnitSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CompilationUnitSyntax original, CompilationUnitSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CompilationUnitSyntax original, CompilationUnitSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CompilationUnitSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CompilationUnitSyntax original, CompilationUnitSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Externs, modified.Externs)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Usings, modified.Usings)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfFileToken, modified.EndOfFileToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CompilationUnitSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CompilationUnitSyntax original, CompilationUnitSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExternAliasDirective"/>.
    /// </summary>
    public partial class ExternAliasDirectiveServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExternAliasDirectiveServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ExternKeyword";
    			yield return "AliasKeyword";
    			yield return "Identifier";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ExternKeyword";
    			yield return "AliasKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> is not executed and <see cref="ExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ExternKeyword, modified.ExternKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.AliasKeyword, modified.AliasKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="UsingDirective"/>.
    /// </summary>
    public partial class UsingDirectiveServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UsingDirectiveServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "StaticKeyword";
    			yield return "Alias";
    			yield return "Name";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> is not executed and <see cref="ExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
        partial void ExactlyEqualAfter(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.UsingKeyword, modified.UsingKeyword)) &&
                ((original.StaticKeyword == null && modified.StaticKeyword == null) || (original.StaticKeyword != null && modified.StaticKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.StaticKeyword, modified.StaticKeyword))) &&
                ((original.Alias == null && modified.Alias == null) || (original.Alias != null && modified.Alias != null && this.LanguageServiceProvider.ExactlyEqual(original.Alias, modified.Alias))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeList"/>.
    /// </summary>
    public partial class AttributeListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Target";
    			yield return "Attributes";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/> is not executed and <see cref="ExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AttributeListSyntax original, AttributeListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AttributeListSyntax original, AttributeListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AttributeListSyntax original, AttributeListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                ((original.Target == null && modified.Target == null) || (original.Target != null && modified.Target != null && this.LanguageServiceProvider.ExactlyEqual(original.Target, modified.Target))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Attributes, modified.Attributes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AttributeListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AttributeListSyntax original, AttributeListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeTargetSpecifier"/>.
    /// </summary>
    public partial class AttributeTargetSpecifierServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeTargetSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> is not executed and <see cref="ExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Attribute"/>.
    /// </summary>
    public partial class AttributeServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/> is not executed and <see cref="ExactlyEqual(AttributeSyntax, AttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AttributeSyntax original, AttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AttributeSyntax original, AttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AttributeSyntax original, AttributeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AttributeSyntax original, AttributeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeArgumentList"/>.
    /// </summary>
    public partial class AttributeArgumentListServiceProvider : ElementTypeServiceProvider //ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/> is not executed and <see cref="ExactlyEqual(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Arguments, modified.Arguments)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AttributeArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DelegateDeclaration"/>.
    /// </summary>
    public partial class DelegateDeclarationServiceProvider : ElementTypeServiceProvider //MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DelegateDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "DelegateKeyword";
    			yield return "ReturnType";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DelegateKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DelegateKeyword, modified.DelegateKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReturnType, modified.ReturnType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EnumMemberDeclaration"/>.
    /// </summary>
    public partial class EnumMemberDeclarationServiceProvider : ElementTypeServiceProvider //MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EnumMemberDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Identifier";
    			yield return "EqualsValue";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.EqualsValue == null && modified.EqualsValue == null) || (original.EqualsValue != null && modified.EqualsValue != null && this.LanguageServiceProvider.ExactlyEqual(original.EqualsValue, modified.EqualsValue))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IncompleteMember"/>.
    /// </summary>
    public partial class IncompleteMemberServiceProvider : ElementTypeServiceProvider //MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IncompleteMemberServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/> is not executed and <see cref="ExactlyEqual(IncompleteMemberSyntax, IncompleteMemberSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IncompleteMemberSyntax original, IncompleteMemberSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IncompleteMemberSyntax original, IncompleteMemberSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IncompleteMemberSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IncompleteMemberSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="GlobalStatement"/>.
    /// </summary>
    public partial class GlobalStatementServiceProvider : ElementTypeServiceProvider //MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GlobalStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(GlobalStatementSyntax, GlobalStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(GlobalStatementSyntax original, GlobalStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(GlobalStatementSyntax original, GlobalStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="GlobalStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(GlobalStatementSyntax original, GlobalStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="GlobalStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(GlobalStatementSyntax original, GlobalStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="NamespaceDeclaration"/>.
    /// </summary>
    public partial class NamespaceDeclarationServiceProvider : ElementTypeServiceProvider //MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NamespaceDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NamespaceKeyword";
    			yield return "Name";
    			yield return "OpenBraceToken";
    			yield return "Externs";
    			yield return "Usings";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NamespaceKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NamespaceKeyword, modified.NamespaceKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Externs, modified.Externs)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Usings, modified.Usings)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EnumDeclaration"/>.
    /// </summary>
    public partial class EnumDeclarationServiceProvider : ElementTypeServiceProvider //BaseTypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EnumDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EnumKeyword";
    			yield return "Identifier";
    			yield return "BaseList";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EnumKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EnumKeyword, modified.EnumKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.ExactlyEqual(original.BaseList, modified.BaseList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ClassDeclaration"/>.
    /// </summary>
    public partial class ClassDeclarationServiceProvider : ElementTypeServiceProvider //TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ClassDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.ExactlyEqual(original.BaseList, modified.BaseList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="StructDeclaration"/>.
    /// </summary>
    public partial class StructDeclarationServiceProvider : ElementTypeServiceProvider //TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StructDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(StructDeclarationSyntax original, StructDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.ExactlyEqual(original.BaseList, modified.BaseList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(StructDeclarationSyntax original, StructDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterfaceDeclaration"/>.
    /// </summary>
    public partial class InterfaceDeclarationServiceProvider : ElementTypeServiceProvider //TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterfaceDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.ExactlyEqual(original.BaseList, modified.BaseList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Members, modified.Members)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="FieldDeclaration"/>.
    /// </summary>
    public partial class FieldDeclarationServiceProvider : ElementTypeServiceProvider //BaseFieldDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FieldDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EventFieldDeclaration"/>.
    /// </summary>
    public partial class EventFieldDeclarationServiceProvider : ElementTypeServiceProvider //BaseFieldDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EventFieldDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EventKeyword";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EventKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EventKeyword, modified.EventKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="MethodDeclaration"/>.
    /// </summary>
    public partial class MethodDeclarationServiceProvider : ElementTypeServiceProvider //BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MethodDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReturnType, modified.ReturnType)) &&
                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.ExactlyEqual(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="OperatorDeclaration"/>.
    /// </summary>
    public partial class OperatorDeclarationServiceProvider : ElementTypeServiceProvider //BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OperatorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "OperatorKeyword";
    			yield return "OperatorToken";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReturnType, modified.ReturnType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorKeyword, modified.OperatorKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConversionOperatorDeclaration"/>.
    /// </summary>
    public partial class ConversionOperatorDeclarationServiceProvider : ElementTypeServiceProvider //BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConversionOperatorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ImplicitOrExplicitKeyword";
    			yield return "OperatorKeyword";
    			yield return "Type";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ImplicitOrExplicitKeyword, modified.ImplicitOrExplicitKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorKeyword, modified.OperatorKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorDeclaration"/>.
    /// </summary>
    public partial class ConstructorDeclarationServiceProvider : ElementTypeServiceProvider //BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Identifier";
    			yield return "ParameterList";
    			yield return "Initializer";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer))) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DestructorDeclaration"/>.
    /// </summary>
    public partial class DestructorDeclarationServiceProvider : ElementTypeServiceProvider //BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DestructorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "TildeToken";
    			yield return "Identifier";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "TildeToken";
    			yield return "ParameterList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TildeToken, modified.TildeToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PropertyDeclaration"/>.
    /// </summary>
    public partial class PropertyDeclarationServiceProvider : ElementTypeServiceProvider //BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PropertyDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "AccessorList";
    			yield return "ExpressionBody";
    			yield return "Initializer";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.ExactlyEqual(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.AccessorList == null && modified.AccessorList == null) || (original.AccessorList != null && modified.AccessorList != null && this.LanguageServiceProvider.ExactlyEqual(original.AccessorList, modified.AccessorList))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EventDeclaration"/>.
    /// </summary>
    public partial class EventDeclarationServiceProvider : ElementTypeServiceProvider //BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EventDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EventKeyword";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "AccessorList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EventKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EventDeclarationSyntax original, EventDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EventKeyword, modified.EventKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.ExactlyEqual(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.AccessorList, modified.AccessorList)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EventDeclarationSyntax original, EventDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IndexerDeclaration"/>.
    /// </summary>
    public partial class IndexerDeclarationServiceProvider : ElementTypeServiceProvider //BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IndexerDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "ThisKeyword";
    			yield return "ParameterList";
    			yield return "AccessorList";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThisKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> is not executed and <see cref="ExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AttributeLists, modified.AttributeLists)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.ExactlyEqual(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ThisKeyword, modified.ThisKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                ((original.AccessorList == null && modified.AccessorList == null) || (original.AccessorList != null && modified.AccessorList != null && this.LanguageServiceProvider.ExactlyEqual(original.AccessorList, modified.AccessorList))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SimpleBaseType"/>.
    /// </summary>
    public partial class SimpleBaseTypeServiceProvider : ElementTypeServiceProvider //BaseTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SimpleBaseTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SimpleBaseTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SimpleBaseTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorConstraint"/>.
    /// </summary>
    public partial class ConstructorConstraintServiceProvider : ElementTypeServiceProvider //TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/> is not executed and <see cref="ExactlyEqual(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConstructorConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NewKeyword, modified.NewKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConstructorConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ClassOrStructConstraint"/>.
    /// </summary>
    public partial class ClassOrStructConstraintServiceProvider : ElementTypeServiceProvider //TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ClassOrStructConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ClassOrStructKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/> is not executed and <see cref="ExactlyEqual(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ClassOrStructConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.ClassOrStructKeyword, modified.ClassOrStructKeyword))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ClassOrStructConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeConstraint"/>.
    /// </summary>
    public partial class TypeConstraintServiceProvider : ElementTypeServiceProvider //TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeConstraintSyntax, TypeConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeConstraintSyntax original, TypeConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeConstraintSyntax original, TypeConstraintSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeConstraintSyntax original, TypeConstraintSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeConstraintSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeConstraintSyntax original, TypeConstraintSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParameterList"/>.
    /// </summary>
    public partial class ParameterListServiceProvider : ElementTypeServiceProvider //BaseParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Parameters";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/> is not executed and <see cref="ExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ParameterListSyntax original, ParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ParameterListSyntax original, ParameterListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ParameterListSyntax original, ParameterListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ParameterListSyntax original, ParameterListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BracketedParameterList"/>.
    /// </summary>
    public partial class BracketedParameterListServiceProvider : ElementTypeServiceProvider //BaseParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BracketedParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Parameters";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> is not executed and <see cref="ExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SkippedTokensTrivia"/>.
    /// </summary>
    public partial class SkippedTokensTriviaServiceProvider : ElementTypeServiceProvider //StructuredTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SkippedTokensTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Tokens";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SkippedTokensTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Tokens, modified.Tokens))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SkippedTokensTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DocumentationCommentTrivia"/>.
    /// </summary>
    public partial class DocumentationCommentTriviaServiceProvider : ElementTypeServiceProvider //StructuredTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DocumentationCommentTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Content";
    			yield return "EndOfComment";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EndOfComment";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DocumentationCommentTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Content, modified.Content)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfComment, modified.EndOfComment)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DocumentationCommentTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EndIfDirectiveTrivia"/>.
    /// </summary>
    public partial class EndIfDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EndIfDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndIfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndIfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EndIfDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndIfKeyword, modified.EndIfKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EndIfDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="RegionDirectiveTrivia"/>.
    /// </summary>
    public partial class RegionDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RegionDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "RegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "RegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="RegionDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.RegionKeyword, modified.RegionKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="RegionDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EndRegionDirectiveTrivia"/>.
    /// </summary>
    public partial class EndRegionDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EndRegionDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndRegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndRegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EndRegionDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndRegionKeyword, modified.EndRegionKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EndRegionDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ErrorDirectiveTrivia"/>.
    /// </summary>
    public partial class ErrorDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ErrorDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ErrorKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ErrorKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ErrorDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ErrorKeyword, modified.ErrorKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ErrorDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="WarningDirectiveTrivia"/>.
    /// </summary>
    public partial class WarningDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WarningDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="WarningDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WarningKeyword, modified.WarningKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="WarningDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BadDirectiveTrivia"/>.
    /// </summary>
    public partial class BadDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BadDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "Identifier";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefineDirectiveTrivia"/>.
    /// </summary>
    public partial class DefineDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefineDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "DefineKeyword";
    			yield return "Name";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "DefineKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DefineKeyword, modified.DefineKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="UndefDirectiveTrivia"/>.
    /// </summary>
    public partial class UndefDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UndefDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "UndefKeyword";
    			yield return "Name";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "UndefKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.UndefKeyword, modified.UndefKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LineDirectiveTrivia"/>.
    /// </summary>
    public partial class LineDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LineDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LineKeyword";
    			yield return "Line";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LineKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LineDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.LineKeyword, modified.LineKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Line, modified.Line)) &&
                ((original.File == null && modified.File == null) || (original.File != null && modified.File != null && this.LanguageServiceProvider.ExactlyEqual(original.File, modified.File))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LineDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PragmaWarningDirectiveTrivia"/>.
    /// </summary>
    public partial class PragmaWarningDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PragmaWarningDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "WarningKeyword";
    			yield return "DisableOrRestoreKeyword";
    			yield return "ErrorCodes";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PragmaWarningDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.PragmaKeyword, modified.PragmaKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WarningKeyword, modified.WarningKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DisableOrRestoreKeyword, modified.DisableOrRestoreKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ErrorCodes, modified.ErrorCodes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PragmaWarningDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PragmaChecksumDirectiveTrivia"/>.
    /// </summary>
    public partial class PragmaChecksumDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PragmaChecksumDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "ChecksumKeyword";
    			yield return "File";
    			yield return "Guid";
    			yield return "Bytes";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "ChecksumKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PragmaChecksumDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.PragmaKeyword, modified.PragmaKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ChecksumKeyword, modified.ChecksumKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.File, modified.File)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Guid, modified.Guid)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Bytes, modified.Bytes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PragmaChecksumDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ReferenceDirectiveTrivia"/>.
    /// </summary>
    public partial class ReferenceDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ReferenceDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ReferenceKeyword";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ReferenceKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ReferenceDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReferenceKeyword, modified.ReferenceKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.File, modified.File)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ReferenceDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LoadDirectiveTrivia"/>.
    /// </summary>
    public partial class LoadDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LoadDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LoadKeyword";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LoadKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LoadDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.LoadKeyword, modified.LoadKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.File, modified.File)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LoadDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ShebangDirectiveTrivia"/>.
    /// </summary>
    public partial class ShebangDirectiveTriviaServiceProvider : ElementTypeServiceProvider //DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ShebangDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ExclamationToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ExclamationToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ShebangDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ExclamationToken, modified.ExclamationToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ShebangDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElseDirectiveTrivia"/>.
    /// </summary>
    public partial class ElseDirectiveTriviaServiceProvider : ElementTypeServiceProvider //BranchingDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElseDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElseKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElseKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ElseDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ElseKeyword, modified.ElseKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ElseDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IfDirectiveTrivia"/>.
    /// </summary>
    public partial class IfDirectiveTriviaServiceProvider : ElementTypeServiceProvider //ConditionalDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IfDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "IfKeyword";
    			yield return "Condition";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "IfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IfDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.IfKeyword, modified.IfKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IfDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElifDirectiveTrivia"/>.
    /// </summary>
    public partial class ElifDirectiveTriviaServiceProvider : ElementTypeServiceProvider //ConditionalDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElifDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElifKeyword";
    			yield return "Condition";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElifKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/> is not executed and <see cref="ExactlyEqual(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ElifDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.HashToken, modified.HashToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ElifKeyword, modified.ElifKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ElifDirectiveTriviaSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeCref"/>.
    /// </summary>
    public partial class TypeCrefServiceProvider : ElementTypeServiceProvider //CrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeCrefSyntax, TypeCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeCrefSyntax, TypeCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeCrefSyntax, TypeCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeCrefSyntax, TypeCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeCrefSyntax original, TypeCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeCrefSyntax, TypeCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeCrefSyntax, TypeCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeCrefSyntax original, TypeCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeCrefSyntax, TypeCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeCrefSyntax original, TypeCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeCrefSyntax original, TypeCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="QualifiedCref"/>.
    /// </summary>
    public partial class QualifiedCrefServiceProvider : ElementTypeServiceProvider //CrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QualifiedCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Container";
    			yield return "DotToken";
    			yield return "Member";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(QualifiedCrefSyntax, QualifiedCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(QualifiedCrefSyntax original, QualifiedCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(QualifiedCrefSyntax original, QualifiedCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QualifiedCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Container, modified.Container)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DotToken, modified.DotToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Member, modified.Member)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="QualifiedCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameMemberCref"/>.
    /// </summary>
    public partial class NameMemberCrefServiceProvider : ElementTypeServiceProvider //MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IndexerMemberCref"/>.
    /// </summary>
    public partial class IndexerMemberCrefServiceProvider : ElementTypeServiceProvider //MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IndexerMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThisKeyword";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThisKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ThisKeyword, modified.ThisKeyword)) &&
                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="OperatorMemberCref"/>.
    /// </summary>
    public partial class OperatorMemberCrefServiceProvider : ElementTypeServiceProvider //MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OperatorMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    			yield return "OperatorToken";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OperatorKeyword, modified.OperatorKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConversionOperatorMemberCref"/>.
    /// </summary>
    public partial class ConversionOperatorMemberCrefServiceProvider : ElementTypeServiceProvider //MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConversionOperatorMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ImplicitOrExplicitKeyword";
    			yield return "OperatorKeyword";
    			yield return "Type";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> is not executed and <see cref="ExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ImplicitOrExplicitKeyword, modified.ImplicitOrExplicitKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorKeyword, modified.OperatorKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefParameterList"/>.
    /// </summary>
    public partial class CrefParameterListServiceProvider : ElementTypeServiceProvider //BaseCrefParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Parameters";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/> is not executed and <see cref="ExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CrefParameterListSyntax original, CrefParameterListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CrefParameterListSyntax original, CrefParameterListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefBracketedParameterList"/>.
    /// </summary>
    public partial class CrefBracketedParameterListServiceProvider : ElementTypeServiceProvider //BaseCrefParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefBracketedParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Parameters";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> is not executed and <see cref="ExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameters, modified.Parameters)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElement"/>.
    /// </summary>
    public partial class XmlElementServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartTag";
    			yield return "Content";
    			yield return "EndTag";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlElementSyntax original, XmlElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlElementSyntax original, XmlElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlElementSyntax original, XmlElementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.StartTag, modified.StartTag)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Content, modified.Content)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndTag, modified.EndTag)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlElementSyntax original, XmlElementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlEmptyElement"/>.
    /// </summary>
    public partial class XmlEmptyElementServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlEmptyElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Name";
    			yield return "Attributes";
    			yield return "SlashGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "SlashGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanToken, modified.LessThanToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Attributes, modified.Attributes)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SlashGreaterThanToken, modified.SlashGreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlText"/>.
    /// </summary>
    public partial class XmlTextServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlTextServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TextTokens";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlTextSyntax, XmlTextSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlTextSyntax, XmlTextSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlTextSyntax, XmlTextSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlTextSyntax, XmlTextSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlTextSyntax original, XmlTextSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlTextSyntax, XmlTextSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlTextSyntax, XmlTextSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlTextSyntax original, XmlTextSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlTextSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlTextSyntax, XmlTextSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlTextSyntax original, XmlTextSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.TextTokens, modified.TextTokens))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlTextSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlTextSyntax original, XmlTextSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlCDataSection"/>.
    /// </summary>
    public partial class XmlCDataSectionServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCDataSectionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartCDataToken";
    			yield return "TextTokens";
    			yield return "EndCDataToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StartCDataToken";
    			yield return "EndCDataToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlCDataSectionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.StartCDataToken, modified.StartCDataToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TextTokens, modified.TextTokens)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndCDataToken, modified.EndCDataToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlCDataSectionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlProcessingInstruction"/>.
    /// </summary>
    public partial class XmlProcessingInstructionServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlProcessingInstructionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartProcessingInstructionToken";
    			yield return "Name";
    			yield return "TextTokens";
    			yield return "EndProcessingInstructionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StartProcessingInstructionToken";
    			yield return "EndProcessingInstructionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.StartProcessingInstructionToken, modified.StartProcessingInstructionToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TextTokens, modified.TextTokens)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndProcessingInstructionToken, modified.EndProcessingInstructionToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlComment"/>.
    /// </summary>
    public partial class XmlCommentServiceProvider : ElementTypeServiceProvider //XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCommentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanExclamationMinusMinusToken";
    			yield return "TextTokens";
    			yield return "MinusMinusGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanExclamationMinusMinusToken";
    			yield return "MinusMinusGreaterThanToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlCommentSyntax, XmlCommentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCommentSyntax, XmlCommentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlCommentSyntax, XmlCommentSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlCommentSyntax, XmlCommentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlCommentSyntax original, XmlCommentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlCommentSyntax, XmlCommentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCommentSyntax, XmlCommentSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlCommentSyntax original, XmlCommentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlCommentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlCommentSyntax, XmlCommentSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlCommentSyntax original, XmlCommentSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LessThanExclamationMinusMinusToken, modified.LessThanExclamationMinusMinusToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TextTokens, modified.TextTokens)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.MinusMinusGreaterThanToken, modified.MinusMinusGreaterThanToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlCommentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlCommentSyntax original, XmlCommentSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlTextAttribute"/>.
    /// </summary>
    public partial class XmlTextAttributeServiceProvider : ElementTypeServiceProvider //XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlTextAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "TextTokens";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.StartQuoteToken, modified.StartQuoteToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TextTokens, modified.TextTokens)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndQuoteToken, modified.EndQuoteToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlCrefAttribute"/>.
    /// </summary>
    public partial class XmlCrefAttributeServiceProvider : ElementTypeServiceProvider //XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCrefAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "Cref";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.StartQuoteToken, modified.StartQuoteToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Cref, modified.Cref)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndQuoteToken, modified.EndQuoteToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlNameAttribute"/>.
    /// </summary>
    public partial class XmlNameAttributeServiceProvider : ElementTypeServiceProvider //XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlNameAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "Identifier";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> is not executed and <see cref="ExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.StartQuoteToken, modified.StartQuoteToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EndQuoteToken, modified.EndQuoteToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedExpression"/>.
    /// </summary>
    public partial class ParenthesizedExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParenthesizedExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ParenthesizedExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleExpression"/>.
    /// </summary>
    public partial class TupleExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(TupleExpressionSyntax, TupleExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TupleExpressionSyntax original, TupleExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TupleExpressionSyntax original, TupleExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TupleExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TupleExpressionSyntax original, TupleExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Arguments, modified.Arguments)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TupleExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TupleExpressionSyntax original, TupleExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PrefixUnaryExpression"/>.
    /// </summary>
    public partial class PrefixUnaryExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PrefixUnaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorToken";
    			yield return "Operand";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PrefixUnaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Operand, modified.Operand)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PrefixUnaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AwaitExpression"/>.
    /// </summary>
    public partial class AwaitExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AwaitExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AwaitKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AwaitKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(AwaitExpressionSyntax, AwaitExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AwaitExpressionSyntax original, AwaitExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AwaitExpressionSyntax original, AwaitExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AwaitExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.AwaitKeyword, modified.AwaitKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AwaitExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PostfixUnaryExpression"/>.
    /// </summary>
    public partial class PostfixUnaryExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PostfixUnaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Operand";
    			yield return "OperatorToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PostfixUnaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Operand, modified.Operand)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PostfixUnaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberAccessExpression"/>.
    /// </summary>
    public partial class MemberAccessExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "OperatorToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConditionalAccessExpression"/>.
    /// </summary>
    public partial class ConditionalAccessExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConditionalAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "OperatorToken";
    			yield return "WhenNotNull";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConditionalAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WhenNotNull, modified.WhenNotNull)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConditionalAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberBindingExpression"/>.
    /// </summary>
    public partial class MemberBindingExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberBindingExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElementBindingExpression"/>.
    /// </summary>
    public partial class ElementBindingExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElementBindingExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ElementBindingExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ElementBindingExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ImplicitElementAccess"/>.
    /// </summary>
    public partial class ImplicitElementAccessServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ImplicitElementAccessServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/> is not executed and <see cref="ExactlyEqual(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ImplicitElementAccessSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ImplicitElementAccessSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BinaryExpression"/>.
    /// </summary>
    public partial class BinaryExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BinaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "OperatorToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(BinaryExpressionSyntax, BinaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BinaryExpressionSyntax original, BinaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BinaryExpressionSyntax original, BinaryExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BinaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Left, modified.Left)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Right, modified.Right)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BinaryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AssignmentExpression"/>.
    /// </summary>
    public partial class AssignmentExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AssignmentExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "OperatorToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AssignmentExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Left, modified.Left)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OperatorToken, modified.OperatorToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Right, modified.Right)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AssignmentExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConditionalExpression"/>.
    /// </summary>
    public partial class ConditionalExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConditionalExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Condition";
    			yield return "QuestionToken";
    			yield return "WhenTrue";
    			yield return "ColonToken";
    			yield return "WhenFalse";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "QuestionToken";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConditionalExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.QuestionToken, modified.QuestionToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WhenTrue, modified.WhenTrue)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WhenFalse, modified.WhenFalse)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConditionalExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LiteralExpression"/>.
    /// </summary>
    public partial class LiteralExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LiteralExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(LiteralExpressionSyntax, LiteralExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LiteralExpressionSyntax original, LiteralExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LiteralExpressionSyntax original, LiteralExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LiteralExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Token, modified.Token))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LiteralExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="MakeRefExpression"/>.
    /// </summary>
    public partial class MakeRefExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MakeRefExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MakeRefExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="MakeRefExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefTypeExpression"/>.
    /// </summary>
    public partial class RefTypeExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefTypeExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="RefTypeExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="RefTypeExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefValueExpression"/>.
    /// </summary>
    public partial class RefValueExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefValueExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "Comma";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Comma";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(RefValueExpressionSyntax, RefValueExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(RefValueExpressionSyntax original, RefValueExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(RefValueExpressionSyntax original, RefValueExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="RefValueExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Comma, modified.Comma)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="RefValueExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CheckedExpression"/>.
    /// </summary>
    public partial class CheckedExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CheckedExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(CheckedExpressionSyntax, CheckedExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CheckedExpressionSyntax original, CheckedExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CheckedExpressionSyntax original, CheckedExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CheckedExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CheckedExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefaultExpression"/>.
    /// </summary>
    public partial class DefaultExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefaultExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(DefaultExpressionSyntax, DefaultExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DefaultExpressionSyntax original, DefaultExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DefaultExpressionSyntax original, DefaultExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DefaultExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DefaultExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeOfExpression"/>.
    /// </summary>
    public partial class TypeOfExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeOfExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeOfExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TypeOfExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SizeOfExpression"/>.
    /// </summary>
    public partial class SizeOfExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SizeOfExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SizeOfExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SizeOfExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InvocationExpression"/>.
    /// </summary>
    public partial class InvocationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InvocationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(InvocationExpressionSyntax, InvocationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InvocationExpressionSyntax original, InvocationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InvocationExpressionSyntax original, InvocationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InvocationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InvocationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElementAccessExpression"/>.
    /// </summary>
    public partial class ElementAccessExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElementAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ElementAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ElementAccessExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DeclarationExpression"/>.
    /// </summary>
    public partial class DeclarationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DeclarationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Designation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DeclarationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Designation, modified.Designation)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DeclarationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CastExpression"/>.
    /// </summary>
    public partial class CastExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CastExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CastExpressionSyntax, CastExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CastExpressionSyntax, CastExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CastExpressionSyntax, CastExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(CastExpressionSyntax, CastExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CastExpressionSyntax original, CastExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CastExpressionSyntax, CastExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CastExpressionSyntax, CastExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CastExpressionSyntax original, CastExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CastExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CastExpressionSyntax, CastExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CastExpressionSyntax original, CastExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CastExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CastExpressionSyntax original, CastExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefExpression"/>.
    /// </summary>
    public partial class RefExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "RefKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(RefExpressionSyntax, RefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefExpressionSyntax, RefExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(RefExpressionSyntax, RefExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(RefExpressionSyntax, RefExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(RefExpressionSyntax original, RefExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(RefExpressionSyntax, RefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefExpressionSyntax, RefExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(RefExpressionSyntax original, RefExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="RefExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(RefExpressionSyntax, RefExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(RefExpressionSyntax original, RefExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.RefKeyword, modified.RefKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="RefExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(RefExpressionSyntax original, RefExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InitializerExpression"/>.
    /// </summary>
    public partial class InitializerExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InitializerExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Expressions";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(InitializerExpressionSyntax, InitializerExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InitializerExpressionSyntax original, InitializerExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InitializerExpressionSyntax original, InitializerExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InitializerExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expressions, modified.Expressions)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InitializerExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ObjectCreationExpression"/>.
    /// </summary>
    public partial class ObjectCreationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ObjectCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "Type";
    			yield return "ArgumentList";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ObjectCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NewKeyword, modified.NewKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.ExactlyEqual(original.ArgumentList, modified.ArgumentList))) &&
                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ObjectCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousObjectCreationExpression"/>.
    /// </summary>
    public partial class AnonymousObjectCreationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousObjectCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBraceToken";
    			yield return "Initializers";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AnonymousObjectCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NewKeyword, modified.NewKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Initializers, modified.Initializers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AnonymousObjectCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayCreationExpression"/>.
    /// </summary>
    public partial class ArrayCreationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "Type";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NewKeyword, modified.NewKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ImplicitArrayCreationExpression"/>.
    /// </summary>
    public partial class ImplicitArrayCreationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ImplicitArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBracketToken";
    			yield return "Commas";
    			yield return "CloseBracketToken";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ImplicitArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.NewKeyword, modified.NewKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Commas, modified.Commas)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Initializer, modified.Initializer)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ImplicitArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="StackAllocArrayCreationExpression"/>.
    /// </summary>
    public partial class StackAllocArrayCreationExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StackAllocArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StackAllocKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StackAllocKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="StackAllocArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.StackAllocKeyword, modified.StackAllocKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="StackAllocArrayCreationExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryExpression"/>.
    /// </summary>
    public partial class QueryExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FromClause";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(QueryExpressionSyntax original, QueryExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.FromClause, modified.FromClause)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(QueryExpressionSyntax original, QueryExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="OmittedArraySizeExpression"/>.
    /// </summary>
    public partial class OmittedArraySizeExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OmittedArraySizeExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OmittedArraySizeExpressionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OmittedArraySizeExpressionToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OmittedArraySizeExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.OmittedArraySizeExpressionToken, modified.OmittedArraySizeExpressionToken))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OmittedArraySizeExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolatedStringExpression"/>.
    /// </summary>
    public partial class InterpolatedStringExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolatedStringExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StringStartToken";
    			yield return "Contents";
    			yield return "StringEndToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StringStartToken";
    			yield return "StringEndToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterpolatedStringExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.StringStartToken, modified.StringStartToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Contents, modified.Contents)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.StringEndToken, modified.StringEndToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterpolatedStringExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IsPatternExpression"/>.
    /// </summary>
    public partial class IsPatternExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IsPatternExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "IsKeyword";
    			yield return "Pattern";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IsKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IsPatternExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.IsKeyword, modified.IsKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Pattern, modified.Pattern)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IsPatternExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThrowExpression"/>.
    /// </summary>
    public partial class ThrowExpressionServiceProvider : ElementTypeServiceProvider //ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThrowExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ThrowExpressionSyntax, ThrowExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ThrowExpressionSyntax original, ThrowExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ThrowExpressionSyntax original, ThrowExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ThrowExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ThrowKeyword, modified.ThrowKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ThrowExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PredefinedType"/>.
    /// </summary>
    public partial class PredefinedTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PredefinedTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(PredefinedTypeSyntax, PredefinedTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PredefinedTypeSyntax original, PredefinedTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PredefinedTypeSyntax original, PredefinedTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayType"/>.
    /// </summary>
    public partial class ArrayTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "RankSpecifiers";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(ArrayTypeSyntax, ArrayTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArrayTypeSyntax original, ArrayTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArrayTypeSyntax original, ArrayTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArrayTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArrayTypeSyntax original, ArrayTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ElementType, modified.ElementType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.RankSpecifiers, modified.RankSpecifiers)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArrayTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArrayTypeSyntax original, ArrayTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="PointerType"/>.
    /// </summary>
    public partial class PointerTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PointerTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "AsteriskToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AsteriskToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(PointerTypeSyntax, PointerTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PointerTypeSyntax, PointerTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(PointerTypeSyntax, PointerTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(PointerTypeSyntax, PointerTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(PointerTypeSyntax original, PointerTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(PointerTypeSyntax, PointerTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(PointerTypeSyntax, PointerTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(PointerTypeSyntax original, PointerTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PointerTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(PointerTypeSyntax, PointerTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(PointerTypeSyntax original, PointerTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ElementType, modified.ElementType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.AsteriskToken, modified.AsteriskToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="PointerTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(PointerTypeSyntax original, PointerTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="NullableType"/>.
    /// </summary>
    public partial class NullableTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NullableTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "QuestionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "QuestionToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(NullableTypeSyntax, NullableTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NullableTypeSyntax, NullableTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(NullableTypeSyntax, NullableTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(NullableTypeSyntax, NullableTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(NullableTypeSyntax original, NullableTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(NullableTypeSyntax, NullableTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(NullableTypeSyntax, NullableTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(NullableTypeSyntax original, NullableTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NullableTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(NullableTypeSyntax, NullableTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(NullableTypeSyntax original, NullableTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ElementType, modified.ElementType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.QuestionToken, modified.QuestionToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="NullableTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(NullableTypeSyntax original, NullableTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleType"/>.
    /// </summary>
    public partial class TupleTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Elements";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TupleTypeSyntax, TupleTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleTypeSyntax, TupleTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TupleTypeSyntax, TupleTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(TupleTypeSyntax, TupleTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TupleTypeSyntax original, TupleTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TupleTypeSyntax, TupleTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TupleTypeSyntax, TupleTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TupleTypeSyntax original, TupleTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TupleTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TupleTypeSyntax, TupleTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TupleTypeSyntax original, TupleTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Elements, modified.Elements)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TupleTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TupleTypeSyntax original, TupleTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="OmittedTypeArgument"/>.
    /// </summary>
    public partial class OmittedTypeArgumentServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OmittedTypeArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OmittedTypeArgumentToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OmittedTypeArgumentToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/> is not executed and <see cref="ExactlyEqual(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OmittedTypeArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.OmittedTypeArgumentToken, modified.OmittedTypeArgumentToken))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OmittedTypeArgumentSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefType"/>.
    /// </summary>
    public partial class RefTypeServiceProvider : ElementTypeServiceProvider //TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "ReadOnlyKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "ReadOnlyKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(RefTypeSyntax, RefTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefTypeSyntax, RefTypeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(RefTypeSyntax, RefTypeSyntax)"/> is not executed and <see cref="ExactlyEqual(RefTypeSyntax, RefTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(RefTypeSyntax original, RefTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(RefTypeSyntax, RefTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(RefTypeSyntax, RefTypeSyntax)"/>.</param>
        partial void ExactlyEqualAfter(RefTypeSyntax original, RefTypeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="RefTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(RefTypeSyntax, RefTypeSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(RefTypeSyntax original, RefTypeSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.RefKeyword, modified.RefKeyword)) &&
                ((original.ReadOnlyKeyword == null && modified.ReadOnlyKeyword == null) || (original.ReadOnlyKeyword != null && modified.ReadOnlyKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.ReadOnlyKeyword, modified.ReadOnlyKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="RefTypeSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(RefTypeSyntax original, RefTypeSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="QualifiedName"/>.
    /// </summary>
    public partial class QualifiedNameServiceProvider : ElementTypeServiceProvider //NameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QualifiedNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "DotToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/> is not executed and <see cref="ExactlyEqual(QualifiedNameSyntax, QualifiedNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(QualifiedNameSyntax original, QualifiedNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</param>
        partial void ExactlyEqualAfter(QualifiedNameSyntax original, QualifiedNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QualifiedNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(QualifiedNameSyntax original, QualifiedNameSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Left, modified.Left)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DotToken, modified.DotToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Right, modified.Right)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="QualifiedNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(QualifiedNameSyntax original, QualifiedNameSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AliasQualifiedName"/>.
    /// </summary>
    public partial class AliasQualifiedNameServiceProvider : ElementTypeServiceProvider //NameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AliasQualifiedNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Alias";
    			yield return "ColonColonToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> is not executed and <see cref="ExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Alias, modified.Alias)) &&
                ((original.ColonColonToken == null && modified.ColonColonToken == null) || (original.ColonColonToken != null && modified.ColonColonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.ColonColonToken, modified.ColonColonToken))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Name, modified.Name)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IdentifierName"/>.
    /// </summary>
    public partial class IdentifierNameServiceProvider : ElementTypeServiceProvider //SimpleNameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IdentifierNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/> is not executed and <see cref="ExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IdentifierNameSyntax original, IdentifierNameSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IdentifierNameSyntax original, IdentifierNameSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="GenericName"/>.
    /// </summary>
    public partial class GenericNameServiceProvider : ElementTypeServiceProvider //SimpleNameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GenericNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "TypeArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/> is not executed and <see cref="ExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(GenericNameSyntax original, GenericNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</param>
        partial void ExactlyEqualAfter(GenericNameSyntax original, GenericNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="GenericNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(GenericNameSyntax original, GenericNameSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.TypeArgumentList, modified.TypeArgumentList)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="GenericNameSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(GenericNameSyntax original, GenericNameSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThisExpression"/>.
    /// </summary>
    public partial class ThisExpressionServiceProvider : ElementTypeServiceProvider //InstanceExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThisExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ThisExpressionSyntax, ThisExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ThisExpressionSyntax original, ThisExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ThisExpressionSyntax original, ThisExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ThisExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ThisExpressionSyntax original, ThisExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Token, modified.Token))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ThisExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ThisExpressionSyntax original, ThisExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseExpression"/>.
    /// </summary>
    public partial class BaseExpressionServiceProvider : ElementTypeServiceProvider //InstanceExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(BaseExpressionSyntax, BaseExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BaseExpressionSyntax original, BaseExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BaseExpressionSyntax original, BaseExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BaseExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BaseExpressionSyntax original, BaseExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Token, modified.Token))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BaseExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BaseExpressionSyntax original, BaseExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousMethodExpression"/>.
    /// </summary>
    public partial class AnonymousMethodExpressionServiceProvider : ElementTypeServiceProvider //AnonymousFunctionExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousMethodExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "DelegateKeyword";
    			yield return "ParameterList";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DelegateKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.AsyncKeyword, modified.AsyncKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.DelegateKeyword, modified.DelegateKeyword)) &&
                ((original.ParameterList == null && modified.ParameterList == null) || (original.ParameterList != null && modified.ParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SimpleLambdaExpression"/>.
    /// </summary>
    public partial class SimpleLambdaExpressionServiceProvider : ElementTypeServiceProvider //LambdaExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SimpleLambdaExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "Parameter";
    			yield return "ArrowToken";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.AsyncKeyword, modified.AsyncKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Parameter, modified.Parameter)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ArrowToken, modified.ArrowToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedLambdaExpression"/>.
    /// </summary>
    public partial class ParenthesizedLambdaExpressionServiceProvider : ElementTypeServiceProvider //LambdaExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedLambdaExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "ParameterList";
    			yield return "ArrowToken";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> is not executed and <see cref="ExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.AsyncKeyword, modified.AsyncKeyword))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ArrowToken, modified.ArrowToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArgumentList"/>.
    /// </summary>
    public partial class ArgumentListServiceProvider : ElementTypeServiceProvider //BaseArgumentListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ArgumentListSyntax, ArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArgumentListSyntax, ArgumentListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ArgumentListSyntax, ArgumentListSyntax)"/> is not executed and <see cref="ExactlyEqual(ArgumentListSyntax, ArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ArgumentListSyntax original, ArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ArgumentListSyntax, ArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ArgumentListSyntax, ArgumentListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ArgumentListSyntax original, ArgumentListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ArgumentListSyntax, ArgumentListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ArgumentListSyntax original, ArgumentListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Arguments, modified.Arguments)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ArgumentListSyntax original, ArgumentListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BracketedArgumentList"/>.
    /// </summary>
    public partial class BracketedArgumentListServiceProvider : ElementTypeServiceProvider //BaseArgumentListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BracketedArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Arguments";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/> is not executed and <see cref="ExactlyEqual(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BracketedArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBracketToken, modified.OpenBracketToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Arguments, modified.Arguments)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBracketToken, modified.CloseBracketToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BracketedArgumentListSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="FromClause"/>.
    /// </summary>
    public partial class FromClauseServiceProvider : ElementTypeServiceProvider //QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FromClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FromKeyword";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FromKeyword";
    			yield return "InKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(FromClauseSyntax original, FromClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(FromClauseSyntax original, FromClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FromClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(FromClauseSyntax original, FromClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.FromKeyword, modified.FromKeyword)) &&
                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.InKeyword, modified.InKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="FromClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(FromClauseSyntax original, FromClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LetClause"/>.
    /// </summary>
    public partial class LetClauseServiceProvider : ElementTypeServiceProvider //QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LetClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LetKeyword";
    			yield return "Identifier";
    			yield return "EqualsToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LetKeyword";
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LetClauseSyntax original, LetClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LetClauseSyntax original, LetClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LetClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LetClauseSyntax original, LetClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LetKeyword, modified.LetKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsToken, modified.EqualsToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LetClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LetClauseSyntax original, LetClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="JoinClause"/>.
    /// </summary>
    public partial class JoinClauseServiceProvider : ElementTypeServiceProvider //QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public JoinClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "JoinKeyword";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "InExpression";
    			yield return "OnKeyword";
    			yield return "LeftExpression";
    			yield return "EqualsKeyword";
    			yield return "RightExpression";
    			yield return "Into";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "JoinKeyword";
    			yield return "InKeyword";
    			yield return "OnKeyword";
    			yield return "EqualsKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="JoinClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(JoinClauseSyntax original, JoinClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.JoinKeyword, modified.JoinKeyword)) &&
                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.InKeyword, modified.InKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.InExpression, modified.InExpression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OnKeyword, modified.OnKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.LeftExpression, modified.LeftExpression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.EqualsKeyword, modified.EqualsKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.RightExpression, modified.RightExpression)) &&
                ((original.Into == null && modified.Into == null) || (original.Into != null && modified.Into != null && this.LanguageServiceProvider.ExactlyEqual(original.Into, modified.Into))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="JoinClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(JoinClauseSyntax original, JoinClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhereClause"/>.
    /// </summary>
    public partial class WhereClauseServiceProvider : ElementTypeServiceProvider //QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhereClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "Condition";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhereKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(WhereClauseSyntax, WhereClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhereClauseSyntax, WhereClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(WhereClauseSyntax, WhereClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(WhereClauseSyntax, WhereClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(WhereClauseSyntax original, WhereClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(WhereClauseSyntax, WhereClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhereClauseSyntax, WhereClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(WhereClauseSyntax original, WhereClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="WhereClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(WhereClauseSyntax, WhereClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(WhereClauseSyntax original, WhereClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.WhereKeyword, modified.WhereKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="WhereClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(WhereClauseSyntax original, WhereClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="OrderByClause"/>.
    /// </summary>
    public partial class OrderByClauseServiceProvider : ElementTypeServiceProvider //QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OrderByClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OrderByKeyword";
    			yield return "Orderings";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OrderByKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(OrderByClauseSyntax, OrderByClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(OrderByClauseSyntax original, OrderByClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(OrderByClauseSyntax original, OrderByClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OrderByClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(OrderByClauseSyntax original, OrderByClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OrderByKeyword, modified.OrderByKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Orderings, modified.Orderings)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="OrderByClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(OrderByClauseSyntax original, OrderByClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SelectClause"/>.
    /// </summary>
    public partial class SelectClauseServiceProvider : ElementTypeServiceProvider //SelectOrGroupClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SelectClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SelectKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SelectKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SelectClauseSyntax, SelectClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SelectClauseSyntax, SelectClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SelectClauseSyntax, SelectClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(SelectClauseSyntax, SelectClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SelectClauseSyntax original, SelectClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SelectClauseSyntax, SelectClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SelectClauseSyntax, SelectClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SelectClauseSyntax original, SelectClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SelectClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SelectClauseSyntax, SelectClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SelectClauseSyntax original, SelectClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.SelectKeyword, modified.SelectKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SelectClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SelectClauseSyntax original, SelectClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="GroupClause"/>.
    /// </summary>
    public partial class GroupClauseServiceProvider : ElementTypeServiceProvider //SelectOrGroupClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GroupClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "GroupKeyword";
    			yield return "GroupExpression";
    			yield return "ByKeyword";
    			yield return "ByExpression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "GroupKeyword";
    			yield return "ByKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(GroupClauseSyntax, GroupClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GroupClauseSyntax, GroupClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(GroupClauseSyntax, GroupClauseSyntax)"/> is not executed and <see cref="ExactlyEqual(GroupClauseSyntax, GroupClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(GroupClauseSyntax original, GroupClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(GroupClauseSyntax, GroupClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GroupClauseSyntax, GroupClauseSyntax)"/>.</param>
        partial void ExactlyEqualAfter(GroupClauseSyntax original, GroupClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="GroupClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(GroupClauseSyntax, GroupClauseSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(GroupClauseSyntax original, GroupClauseSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.GroupKeyword, modified.GroupKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.GroupExpression, modified.GroupExpression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ByKeyword, modified.ByKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ByExpression, modified.ByExpression)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="GroupClauseSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(GroupClauseSyntax original, GroupClauseSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DeclarationPattern"/>.
    /// </summary>
    public partial class DeclarationPatternServiceProvider : ElementTypeServiceProvider //PatternServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DeclarationPatternServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Designation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/> is not executed and <see cref="ExactlyEqual(DeclarationPatternSyntax, DeclarationPatternSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DeclarationPatternSyntax original, DeclarationPatternSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DeclarationPatternSyntax original, DeclarationPatternSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DeclarationPatternSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Designation, modified.Designation)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DeclarationPatternSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstantPattern"/>.
    /// </summary>
    public partial class ConstantPatternServiceProvider : ElementTypeServiceProvider //PatternServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstantPatternServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/> is not executed and <see cref="ExactlyEqual(ConstantPatternSyntax, ConstantPatternSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ConstantPatternSyntax original, ConstantPatternSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ConstantPatternSyntax original, ConstantPatternSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConstantPatternSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ConstantPatternSyntax original, ConstantPatternSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ConstantPatternSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ConstantPatternSyntax original, ConstantPatternSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolatedStringText"/>.
    /// </summary>
    public partial class InterpolatedStringTextServiceProvider : ElementTypeServiceProvider //InterpolatedStringContentServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolatedStringTextServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TextToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/> is not executed and <see cref="ExactlyEqual(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterpolatedStringTextSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.TextToken, modified.TextToken))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterpolatedStringTextSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Interpolation"/>.
    /// </summary>
    public partial class InterpolationServiceProvider : ElementTypeServiceProvider //InterpolatedStringContentServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Expression";
    			yield return "AlignmentClause";
    			yield return "FormatClause";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(InterpolationSyntax, InterpolationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationSyntax, InterpolationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(InterpolationSyntax, InterpolationSyntax)"/> is not executed and <see cref="ExactlyEqual(InterpolationSyntax, InterpolationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(InterpolationSyntax original, InterpolationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(InterpolationSyntax, InterpolationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(InterpolationSyntax, InterpolationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(InterpolationSyntax original, InterpolationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterpolationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(InterpolationSyntax, InterpolationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(InterpolationSyntax original, InterpolationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                ((original.AlignmentClause == null && modified.AlignmentClause == null) || (original.AlignmentClause != null && modified.AlignmentClause != null && this.LanguageServiceProvider.ExactlyEqual(original.AlignmentClause, modified.AlignmentClause))) &&
                ((original.FormatClause == null && modified.FormatClause == null) || (original.FormatClause != null && modified.FormatClause != null && this.LanguageServiceProvider.ExactlyEqual(original.FormatClause, modified.FormatClause))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="InterpolationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(InterpolationSyntax original, InterpolationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="Block"/>.
    /// </summary>
    public partial class BlockServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BlockServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Statements";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BlockSyntax, BlockSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BlockSyntax, BlockSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BlockSyntax, BlockSyntax)"/> is not executed and <see cref="ExactlyEqual(BlockSyntax, BlockSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BlockSyntax original, BlockSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BlockSyntax, BlockSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BlockSyntax, BlockSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BlockSyntax original, BlockSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BlockSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BlockSyntax, BlockSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BlockSyntax original, BlockSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statements, modified.Statements)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BlockSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BlockSyntax original, BlockSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LocalFunctionStatement"/>.
    /// </summary>
    public partial class LocalFunctionStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LocalFunctionStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReturnType, modified.ReturnType)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.ExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ParameterList, modified.ParameterList)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ConstraintClauses, modified.ConstraintClauses)) &&
                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.ExactlyEqual(original.Body, modified.Body))) &&
                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.ExactlyEqual(original.ExpressionBody, modified.ExpressionBody))) &&
                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LocalDeclarationStatement"/>.
    /// </summary>
    public partial class LocalDeclarationStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LocalDeclarationStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Modifiers, modified.Modifiers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExpressionStatement"/>.
    /// </summary>
    public partial class ExpressionStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExpressionStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ExpressionStatementSyntax, ExpressionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ExpressionStatementSyntax original, ExpressionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ExpressionStatementSyntax original, ExpressionStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ExpressionStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ExpressionStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="EmptyStatement"/>.
    /// </summary>
    public partial class EmptyStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EmptyStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(EmptyStatementSyntax, EmptyStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(EmptyStatementSyntax original, EmptyStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(EmptyStatementSyntax original, EmptyStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EmptyStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(EmptyStatementSyntax original, EmptyStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="EmptyStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(EmptyStatementSyntax original, EmptyStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LabeledStatement"/>.
    /// </summary>
    public partial class LabeledStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LabeledStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ColonToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LabeledStatementSyntax original, LabeledStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LabeledStatementSyntax original, LabeledStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="GotoStatement"/>.
    /// </summary>
    public partial class GotoStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GotoStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "GotoKeyword";
    			yield return "CaseOrDefaultKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "GotoKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(GotoStatementSyntax, GotoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GotoStatementSyntax, GotoStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(GotoStatementSyntax, GotoStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(GotoStatementSyntax, GotoStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(GotoStatementSyntax original, GotoStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(GotoStatementSyntax, GotoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(GotoStatementSyntax, GotoStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(GotoStatementSyntax original, GotoStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="GotoStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(GotoStatementSyntax, GotoStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(GotoStatementSyntax original, GotoStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.GotoKeyword, modified.GotoKeyword)) &&
                ((original.CaseOrDefaultKeyword == null && modified.CaseOrDefaultKeyword == null) || (original.CaseOrDefaultKeyword != null && modified.CaseOrDefaultKeyword != null && this.LanguageServiceProvider.ExactlyEqual(original.CaseOrDefaultKeyword, modified.CaseOrDefaultKeyword))) &&
                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="GotoStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(GotoStatementSyntax original, GotoStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="BreakStatement"/>.
    /// </summary>
    public partial class BreakStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BreakStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "BreakKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "BreakKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(BreakStatementSyntax, BreakStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BreakStatementSyntax, BreakStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(BreakStatementSyntax, BreakStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(BreakStatementSyntax, BreakStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(BreakStatementSyntax original, BreakStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(BreakStatementSyntax, BreakStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(BreakStatementSyntax, BreakStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(BreakStatementSyntax original, BreakStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BreakStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(BreakStatementSyntax, BreakStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(BreakStatementSyntax original, BreakStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.BreakKeyword, modified.BreakKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="BreakStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(BreakStatementSyntax original, BreakStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ContinueStatement"/>.
    /// </summary>
    public partial class ContinueStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ContinueStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ContinueKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ContinueKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ContinueStatementSyntax, ContinueStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ContinueStatementSyntax original, ContinueStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ContinueStatementSyntax original, ContinueStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ContinueStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ContinueStatementSyntax original, ContinueStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ContinueKeyword, modified.ContinueKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ContinueStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ContinueStatementSyntax original, ContinueStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ReturnStatement"/>.
    /// </summary>
    public partial class ReturnStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ReturnStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ReturnKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ReturnKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ReturnStatementSyntax, ReturnStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ReturnStatementSyntax original, ReturnStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ReturnStatementSyntax original, ReturnStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ReturnStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ReturnStatementSyntax original, ReturnStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ReturnKeyword, modified.ReturnKeyword)) &&
                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ReturnStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ReturnStatementSyntax original, ReturnStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThrowStatement"/>.
    /// </summary>
    public partial class ThrowStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThrowStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ThrowStatementSyntax, ThrowStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ThrowStatementSyntax original, ThrowStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ThrowStatementSyntax original, ThrowStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ThrowStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ThrowStatementSyntax original, ThrowStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ThrowKeyword, modified.ThrowKeyword)) &&
                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ThrowStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ThrowStatementSyntax original, ThrowStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="YieldStatement"/>.
    /// </summary>
    public partial class YieldStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public YieldStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "YieldKeyword";
    			yield return "ReturnOrBreakKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "YieldKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(YieldStatementSyntax, YieldStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(YieldStatementSyntax, YieldStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(YieldStatementSyntax, YieldStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(YieldStatementSyntax, YieldStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(YieldStatementSyntax original, YieldStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(YieldStatementSyntax, YieldStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(YieldStatementSyntax, YieldStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(YieldStatementSyntax original, YieldStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="YieldStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(YieldStatementSyntax, YieldStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(YieldStatementSyntax original, YieldStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.YieldKeyword, modified.YieldKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ReturnOrBreakKeyword, modified.ReturnOrBreakKeyword)) &&
                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="YieldStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(YieldStatementSyntax original, YieldStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhileStatement"/>.
    /// </summary>
    public partial class WhileStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhileStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(WhileStatementSyntax, WhileStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhileStatementSyntax, WhileStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(WhileStatementSyntax, WhileStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(WhileStatementSyntax, WhileStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(WhileStatementSyntax original, WhileStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(WhileStatementSyntax, WhileStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(WhileStatementSyntax, WhileStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(WhileStatementSyntax original, WhileStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="WhileStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(WhileStatementSyntax, WhileStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(WhileStatementSyntax original, WhileStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.WhileKeyword, modified.WhileKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="WhileStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(WhileStatementSyntax original, WhileStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DoStatement"/>.
    /// </summary>
    public partial class DoStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DoStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "DoKeyword";
    			yield return "Statement";
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DoKeyword";
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DoStatementSyntax, DoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DoStatementSyntax, DoStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DoStatementSyntax, DoStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(DoStatementSyntax, DoStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DoStatementSyntax original, DoStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DoStatementSyntax, DoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DoStatementSyntax, DoStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DoStatementSyntax original, DoStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DoStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DoStatementSyntax, DoStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DoStatementSyntax original, DoStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.DoKeyword, modified.DoKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.WhileKeyword, modified.WhileKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SemicolonToken, modified.SemicolonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DoStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DoStatementSyntax original, DoStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForStatement"/>.
    /// </summary>
    public partial class ForStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "Initializers";
    			yield return "FirstSemicolonToken";
    			yield return "Condition";
    			yield return "SecondSemicolonToken";
    			yield return "Incrementors";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForKeyword";
    			yield return "OpenParenToken";
    			yield return "FirstSemicolonToken";
    			yield return "SecondSemicolonToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ForStatementSyntax original, ForStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ForStatementSyntax original, ForStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ForStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ForStatementSyntax original, ForStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ForKeyword, modified.ForKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Initializers, modified.Initializers)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.FirstSemicolonToken, modified.FirstSemicolonToken)) &&
                ((original.Condition == null && modified.Condition == null) || (original.Condition != null && modified.Condition != null && this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.SecondSemicolonToken, modified.SecondSemicolonToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Incrementors, modified.Incrementors)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ForStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ForStatementSyntax original, ForStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="UsingStatement"/>.
    /// </summary>
    public partial class UsingStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UsingStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UsingStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(UsingStatementSyntax original, UsingStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.UsingKeyword, modified.UsingKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration))) &&
                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="UsingStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(UsingStatementSyntax original, UsingStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="FixedStatement"/>.
    /// </summary>
    public partial class FixedStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FixedStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FixedKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FixedKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FixedStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(FixedStatementSyntax original, FixedStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.FixedKeyword, modified.FixedKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Declaration, modified.Declaration)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="FixedStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(FixedStatementSyntax original, FixedStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CheckedStatement"/>.
    /// </summary>
    public partial class CheckedStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CheckedStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(CheckedStatementSyntax, CheckedStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CheckedStatementSyntax original, CheckedStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CheckedStatementSyntax original, CheckedStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CheckedStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CheckedStatementSyntax original, CheckedStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Block, modified.Block)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CheckedStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CheckedStatementSyntax original, CheckedStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="UnsafeStatement"/>.
    /// </summary>
    public partial class UnsafeStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UnsafeStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UnsafeKeyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UnsafeKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(UnsafeStatementSyntax, UnsafeStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(UnsafeStatementSyntax original, UnsafeStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(UnsafeStatementSyntax original, UnsafeStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UnsafeStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.UnsafeKeyword, modified.UnsafeKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Block, modified.Block)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="UnsafeStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="LockStatement"/>.
    /// </summary>
    public partial class LockStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LockStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LockKeyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LockKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(LockStatementSyntax, LockStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LockStatementSyntax, LockStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(LockStatementSyntax, LockStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(LockStatementSyntax, LockStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(LockStatementSyntax original, LockStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(LockStatementSyntax, LockStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(LockStatementSyntax, LockStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(LockStatementSyntax original, LockStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LockStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(LockStatementSyntax, LockStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(LockStatementSyntax original, LockStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.LockKeyword, modified.LockKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="LockStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(LockStatementSyntax original, LockStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="IfStatement"/>.
    /// </summary>
    public partial class IfStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IfStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IfKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "Statement";
    			yield return "Else";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IfKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(IfStatementSyntax, IfStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IfStatementSyntax, IfStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(IfStatementSyntax, IfStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(IfStatementSyntax, IfStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(IfStatementSyntax original, IfStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(IfStatementSyntax, IfStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(IfStatementSyntax, IfStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(IfStatementSyntax original, IfStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IfStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IfStatementSyntax, IfStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(IfStatementSyntax original, IfStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.IfKeyword, modified.IfKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Condition, modified.Condition)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)) &&
                ((original.Else == null && modified.Else == null) || (original.Else != null && modified.Else != null && this.LanguageServiceProvider.ExactlyEqual(original.Else, modified.Else))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="IfStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(IfStatementSyntax original, IfStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SwitchStatement"/>.
    /// </summary>
    public partial class SwitchStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SwitchStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SwitchKeyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "OpenBraceToken";
    			yield return "Sections";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SwitchKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(SwitchStatementSyntax, SwitchStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SwitchStatementSyntax original, SwitchStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SwitchStatementSyntax original, SwitchStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SwitchStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SwitchStatementSyntax original, SwitchStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.SwitchKeyword, modified.SwitchKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenBraceToken, modified.OpenBraceToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Sections, modified.Sections)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseBraceToken, modified.CloseBraceToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SwitchStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SwitchStatementSyntax original, SwitchStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="TryStatement"/>.
    /// </summary>
    public partial class TryStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TryStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TryKeyword";
    			yield return "Block";
    			yield return "Catches";
    			yield return "Finally";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "TryKeyword";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(TryStatementSyntax, TryStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TryStatementSyntax, TryStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(TryStatementSyntax, TryStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(TryStatementSyntax, TryStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(TryStatementSyntax original, TryStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(TryStatementSyntax, TryStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(TryStatementSyntax, TryStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(TryStatementSyntax original, TryStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TryStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(TryStatementSyntax, TryStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(TryStatementSyntax original, TryStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.TryKeyword, modified.TryKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Block, modified.Block)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Catches, modified.Catches)) &&
                ((original.Finally == null && modified.Finally == null) || (original.Finally != null && modified.Finally != null && this.LanguageServiceProvider.ExactlyEqual(original.Finally, modified.Finally))))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="TryStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(TryStatementSyntax original, TryStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForEachStatement"/>.
    /// </summary>
    public partial class ForEachStatementServiceProvider : ElementTypeServiceProvider //StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForEachStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ForEachStatementSyntax original, ForEachStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ForEachKeyword, modified.ForEachKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Type, modified.Type)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.InKeyword, modified.InKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ForEachStatementSyntax original, ForEachStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForEachVariableStatement"/>.
    /// </summary>
    public partial class ForEachVariableStatementServiceProvider : ElementTypeServiceProvider //CommonForEachStatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForEachVariableStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "Variable";
    			yield return "InKeyword";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> is not executed and <see cref="ExactlyEqual(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ForEachVariableStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.ForEachKeyword, modified.ForEachKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Variable, modified.Variable)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.InKeyword, modified.InKeyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Expression, modified.Expression)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Statement, modified.Statement)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ForEachVariableStatementSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="SingleVariableDesignation"/>.
    /// </summary>
    public partial class SingleVariableDesignationServiceProvider : ElementTypeServiceProvider //VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SingleVariableDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> is not executed and <see cref="ExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.Identifier, modified.Identifier))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DiscardDesignation"/>.
    /// </summary>
    public partial class DiscardDesignationServiceProvider : ElementTypeServiceProvider //VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DiscardDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UnderscoreToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UnderscoreToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/> is not executed and <see cref="ExactlyEqual(DiscardDesignationSyntax, DiscardDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DiscardDesignationSyntax original, DiscardDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DiscardDesignationSyntax original, DiscardDesignationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DiscardDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ExactlyEqual(original.UnderscoreToken, modified.UnderscoreToken))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DiscardDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedVariableDesignation"/>.
    /// </summary>
    public partial class ParenthesizedVariableDesignationServiceProvider : ElementTypeServiceProvider //VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedVariableDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Variables";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/> is not executed and <see cref="ExactlyEqual(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</param>
        partial void ExactlyEqualAfter(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParenthesizedVariableDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.OpenParenToken, modified.OpenParenToken)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Variables, modified.Variables)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.CloseParenToken, modified.CloseParenToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="ParenthesizedVariableDesignationSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CasePatternSwitchLabel"/>.
    /// </summary>
    public partial class CasePatternSwitchLabelServiceProvider : ElementTypeServiceProvider //SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CasePatternSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Pattern";
    			yield return "WhenClause";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/> is not executed and <see cref="ExactlyEqual(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CasePatternSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Pattern, modified.Pattern)) &&
                ((original.WhenClause == null && modified.WhenClause == null) || (original.WhenClause != null && modified.WhenClause != null && this.LanguageServiceProvider.ExactlyEqual(original.WhenClause, modified.WhenClause))) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CasePatternSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="CaseSwitchLabel"/>.
    /// </summary>
    public partial class CaseSwitchLabelServiceProvider : ElementTypeServiceProvider //SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CaseSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Value";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/> is not executed and <see cref="ExactlyEqual(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</param>
        partial void ExactlyEqualAfter(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CaseSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.Value, modified.Value)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="CaseSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefaultSwitchLabel"/>.
    /// </summary>
    public partial class DefaultSwitchLabelServiceProvider : ElementTypeServiceProvider //SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefaultSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) {}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="ExactlyEqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="ExactlyEqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/> is not executed and <see cref="ExactlyEqual(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void ExactlyEqualBefore(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="ExactlyEqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="ExactlyEqual(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</param>
        partial void ExactlyEqualAfter(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DefaultSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</remarks>
        protected virtual bool ExactlyEqualCore(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
    	{
    		if(original == null || modified == null) 
    			return false;
    
            if ((this.LanguageServiceProvider.ExactlyEqual(original.Keyword, modified.Keyword)) &&
                (this.LanguageServiceProvider.ExactlyEqual(original.ColonToken, modified.ColonToken)))
    			return true;
    
    	    return false;
    	}	
    
    	/// <summary>
        /// Determines if two <see cref="DefaultSwitchLabelSyntax"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqual(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
    	{
        	bool result = false, ignoreCore = false;
        	ExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.ExactlyEqualCore(original, modified);
        	ExactlyEqualAfter(original, modified, ref result);
        	return result;
         }
    }
    
}
// Generated helper templates
// Generated items
