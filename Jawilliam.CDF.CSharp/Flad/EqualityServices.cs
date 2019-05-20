
//using Jawilliam.CDF.Approach.Flad;
//using Jawilliam.CDF.Domain;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Linq;

//namespace Jawilliam.CDF.CSharp.Flad
//{
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SyntaxToken"/>.
//    /// </summary>
//    partial class SyntaxTokenServiceProvider
//    {
//    	/// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SyntaxToken original, SyntaxToken modified)
//        {
//            if (original == null || modified == null)
//                return false;
        
//            if (!string.IsNullOrWhiteSpace(original.ValueText) && !string.IsNullOrWhiteSpace(modified.ValueText) && original.ValueText == modified.ValueText)
//                return true;
        
//            return false;
//        }
//    }
    
//    partial class LanguageServiceProvider
//    {
//    	/// <summary>
//        /// Determines if two typed elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
//        /// <typeparam name="TModified">Type of the original version.</typeparam>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
//        {
//            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(IEqualityCondition<,>), "Equal", out object result))
//                return (bool)result;
        
//            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as IEqualityCondition<TOriginal, TModified>;
//            return serviceProvider?.Equal(original, modified) ?? false;
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="equal">logic of equality.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        protected virtual bool Equal<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified, Func<T, T, bool> equal) where T : SyntaxNode
//        {
//            if (original == null || modified == null)
//                return false;
    
//            if (original.Count != modified.Count)
//                return false;
    
//            for (int i = 0; i < original.Count; i++)
//            {
//                if (!equal(original[i], modified[i]))
//                    return false;
//            }
//            return true;
//        }	
    
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
//        {
//            return this.Equal(original, modified, this.Equal);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="equal">logic of equality.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        protected virtual bool Equal<T>(SyntaxList<T> original, SyntaxList<T> modified, Func<T, T, bool> equal) where T : SyntaxNode
//        {
//            if (original == null || modified == null)
//                return false;
    
//            if (original.Count != modified.Count)
//                return false;
    
//            for (int i = 0; i < original.Count; i++)
//            {
//                if (!equal(original[i], modified[i]))
//                    return false;
//            }
//            return true;
//        }	
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal<T>(SyntaxList<T> original, SyntaxList<T> modified) where T : SyntaxNode
//        {
//            return this.Equal(original, modified, this.Equal);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxTokenList"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="equal">logic of equality.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SyntaxTokenList original, SyntaxTokenList modified)
//        {
//            if (original == null || modified == null)
//                return false;
    
//            if (original.Count != modified.Count)
//                return false;
    
//            for (int i = 0; i < original.Count; i++)
//            {
//                if (!this.Equal(original[i], modified[i]))
//                    return false;
//            }
//            return true;
//        }
    
//    	/// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SyntaxToken original, SyntaxToken modified)
//        {
//            return this.SyntaxTokenServiceProvider.Equal(original, modified);
//        }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AttributeArgument"/>.
//    /// </summary>
//    partial class AttributeArgumentServiceProvider : IEqualityCondition<AttributeArgumentSyntax, AttributeArgumentSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> is not executed and <see cref="Equal(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
//        partial void EqualAfter(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.NameEquals == null && modified.NameEquals == null) || (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.Equal(original.NameEquals, modified.NameEquals))) &&
//                ((original.NameColon == null && modified.NameColon == null) || (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.Equal(original.NameColon, modified.NameColon))) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="NameEquals"/>.
//    /// </summary>
//    partial class NameEqualsServiceProvider : IEqualityCondition<NameEqualsSyntax, NameEqualsSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(NameEqualsSyntax, NameEqualsSyntax)"/> is not executed and <see cref="Equal(NameEqualsSyntax, NameEqualsSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
//        partial void EqualAfter(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NameEqualsSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(NameEqualsSyntax, NameEqualsSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(NameEqualsSyntax original, NameEqualsSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="NameEqualsSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(NameEqualsSyntax original, NameEqualsSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeParameterList"/>.
//    /// </summary>
//    partial class TypeParameterListServiceProvider : IEqualityCondition<TypeParameterListSyntax, TypeParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/> is not executed and <see cref="Equal(TypeParameterListSyntax, TypeParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
//        partial void EqualAfter(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeParameterListSyntax original, TypeParameterListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanToken, modified.LessThanToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters)) &&
//                (this.LanguageServiceProvider.Equal(original.GreaterThanToken, modified.GreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeParameterListSyntax original, TypeParameterListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeParameter"/>.
//    /// </summary>
//    partial class TypeParameterServiceProvider : IEqualityCondition<TypeParameterSyntax, TypeParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeParameterSyntax, TypeParameterSyntax)"/> is not executed and <see cref="Equal(TypeParameterSyntax, TypeParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
//        partial void EqualAfter(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeParameterSyntax, TypeParameterSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeParameterSyntax original, TypeParameterSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                ((original.VarianceKeyword == null && modified.VarianceKeyword == null) || (original.VarianceKeyword != null && modified.VarianceKeyword != null && this.LanguageServiceProvider.Equal(original.VarianceKeyword, modified.VarianceKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeParameterSyntax original, TypeParameterSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BaseList"/>.
//    /// </summary>
//    partial class BaseListServiceProvider : IEqualityCondition<BaseListSyntax, BaseListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BaseListSyntax, BaseListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BaseListSyntax, BaseListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BaseListSyntax, BaseListSyntax)"/> is not executed and <see cref="Equal(BaseListSyntax, BaseListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BaseListSyntax original, BaseListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BaseListSyntax, BaseListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BaseListSyntax, BaseListSyntax)"/>.</param>
//        partial void EqualAfter(BaseListSyntax original, BaseListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BaseListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BaseListSyntax, BaseListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BaseListSyntax original, BaseListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Types, modified.Types)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BaseListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BaseListSyntax original, BaseListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeParameterConstraintClause"/>.
//    /// </summary>
//    partial class TypeParameterConstraintClauseServiceProvider : IEqualityCondition<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> is not executed and <see cref="Equal(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
//        partial void EqualAfter(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.WhereKeyword, modified.WhereKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Constraints, modified.Constraints)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ExplicitInterfaceSpecifier"/>.
//    /// </summary>
//    partial class ExplicitInterfaceSpecifierServiceProvider : IEqualityCondition<ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> is not executed and <see cref="Equal(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
//        partial void EqualAfter(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.DotToken, modified.DotToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConstructorInitializer"/>.
//    /// </summary>
//    partial class ConstructorInitializerServiceProvider : IEqualityCondition<ConstructorInitializerSyntax, ConstructorInitializerSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/> is not executed and <see cref="Equal(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</param>
//        partial void EqualAfter(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorInitializerSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ThisOrBaseKeyword, modified.ThisOrBaseKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConstructorInitializerSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ArrowExpressionClause"/>.
//    /// </summary>
//    partial class ArrowExpressionClauseServiceProvider : IEqualityCondition<ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/> is not executed and <see cref="Equal(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</param>
//        partial void EqualAfter(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArrowExpressionClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ArrowToken, modified.ArrowToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArrowExpressionClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AccessorList"/>.
//    /// </summary>
//    partial class AccessorListServiceProvider : IEqualityCondition<AccessorListSyntax, AccessorListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AccessorListSyntax, AccessorListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AccessorListSyntax, AccessorListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AccessorListSyntax, AccessorListSyntax)"/> is not executed and <see cref="Equal(AccessorListSyntax, AccessorListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AccessorListSyntax original, AccessorListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AccessorListSyntax, AccessorListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AccessorListSyntax, AccessorListSyntax)"/>.</param>
//        partial void EqualAfter(AccessorListSyntax original, AccessorListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AccessorListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AccessorListSyntax, AccessorListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AccessorListSyntax original, AccessorListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Accessors, modified.Accessors)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AccessorListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AccessorListSyntax original, AccessorListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AccessorDeclaration"/>.
//    /// </summary>
//    partial class AccessorDeclarationServiceProvider : IEqualityCondition<AccessorDeclarationSyntax, AccessorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/> is not executed and <see cref="Equal(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AccessorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AccessorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Parameter"/>.
//    /// </summary>
//    partial class ParameterServiceProvider : IEqualityCondition<ParameterSyntax, ParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParameterSyntax, ParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ParameterSyntax, ParameterSyntax)"/> is not executed and <see cref="Equal(ParameterSyntax, ParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ParameterSyntax original, ParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParameterSyntax, ParameterSyntax)"/>.</param>
//        partial void EqualAfter(ParameterSyntax original, ParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ParameterSyntax, ParameterSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ParameterSyntax original, ParameterSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.Equal(original.Type, modified.Type))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.Default == null && modified.Default == null) || (original.Default != null && modified.Default != null && this.LanguageServiceProvider.Equal(original.Default, modified.Default))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ParameterSyntax original, ParameterSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CrefParameter"/>.
//    /// </summary>
//    partial class CrefParameterServiceProvider : IEqualityCondition<CrefParameterSyntax, CrefParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CrefParameterSyntax, CrefParameterSyntax)"/> is not executed and <see cref="Equal(CrefParameterSyntax, CrefParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        partial void EqualAfter(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CrefParameterSyntax, CrefParameterSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CrefParameterSyntax original, CrefParameterSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.RefOrOutKeyword == null && modified.RefOrOutKeyword == null) || (original.RefOrOutKeyword != null && modified.RefOrOutKeyword != null && this.LanguageServiceProvider.Equal(original.RefOrOutKeyword, modified.RefOrOutKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CrefParameterSyntax original, CrefParameterSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlElementStartTag"/>.
//    /// </summary>
//    partial class XmlElementStartTagServiceProvider : IEqualityCondition<XmlElementStartTagSyntax, XmlElementStartTagSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> is not executed and <see cref="Equal(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
//        partial void EqualAfter(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanToken, modified.LessThanToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.Attributes, modified.Attributes)) &&
//                (this.LanguageServiceProvider.Equal(original.GreaterThanToken, modified.GreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlElementEndTag"/>.
//    /// </summary>
//    partial class XmlElementEndTagServiceProvider : IEqualityCondition<XmlElementEndTagSyntax, XmlElementEndTagSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> is not executed and <see cref="Equal(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
//        partial void EqualAfter(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanSlashToken, modified.LessThanSlashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.GreaterThanToken, modified.GreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlName"/>.
//    /// </summary>
//    partial class XmlNameServiceProvider : IEqualityCondition<XmlNameSyntax, XmlNameSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlNameSyntax, XmlNameSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlNameSyntax, XmlNameSyntax)"/> is not executed and <see cref="Equal(XmlNameSyntax, XmlNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlNameSyntax original, XmlNameSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlNameSyntax, XmlNameSyntax)"/>.</param>
//        partial void EqualAfter(XmlNameSyntax original, XmlNameSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlNameSyntax, XmlNameSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlNameSyntax original, XmlNameSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.Prefix == null && modified.Prefix == null) || (original.Prefix != null && modified.Prefix != null && this.LanguageServiceProvider.Equal(original.Prefix, modified.Prefix))) &&
//                (this.LanguageServiceProvider.Equal(original.LocalName, modified.LocalName)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlNameSyntax original, XmlNameSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlPrefix"/>.
//    /// </summary>
//    partial class XmlPrefixServiceProvider : IEqualityCondition<XmlPrefixSyntax, XmlPrefixSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/> is not executed and <see cref="Equal(XmlPrefixSyntax, XmlPrefixSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
//        partial void EqualAfter(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlPrefixSyntax original, XmlPrefixSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Prefix, modified.Prefix)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlPrefixSyntax original, XmlPrefixSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeArgumentList"/>.
//    /// </summary>
//    partial class TypeArgumentListServiceProvider : IEqualityCondition<TypeArgumentListSyntax, TypeArgumentListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/> is not executed and <see cref="Equal(TypeArgumentListSyntax, TypeArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</param>
//        partial void EqualAfter(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanToken, modified.LessThanToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Arguments, modified.Arguments)) &&
//                (this.LanguageServiceProvider.Equal(original.GreaterThanToken, modified.GreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ArrayRankSpecifier"/>.
//    /// </summary>
//    partial class ArrayRankSpecifierServiceProvider : IEqualityCondition<ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/> is not executed and <see cref="Equal(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</param>
//        partial void EqualAfter(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArrayRankSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Sizes, modified.Sizes)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArrayRankSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TupleElement"/>.
//    /// </summary>
//    partial class TupleElementServiceProvider : IEqualityCondition<TupleElementSyntax, TupleElementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleElementSyntax, TupleElementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TupleElementSyntax, TupleElementSyntax)"/> is not executed and <see cref="Equal(TupleElementSyntax, TupleElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TupleElementSyntax original, TupleElementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleElementSyntax, TupleElementSyntax)"/>.</param>
//        partial void EqualAfter(TupleElementSyntax original, TupleElementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TupleElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TupleElementSyntax, TupleElementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TupleElementSyntax original, TupleElementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.Identifier == null && modified.Identifier == null) || (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TupleElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TupleElementSyntax original, TupleElementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Argument"/>.
//    /// </summary>
//    partial class ArgumentServiceProvider : IEqualityCondition<ArgumentSyntax, ArgumentSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArgumentSyntax, ArgumentSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArgumentSyntax, ArgumentSyntax)"/> is not executed and <see cref="Equal(ArgumentSyntax, ArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArgumentSyntax original, ArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArgumentSyntax, ArgumentSyntax)"/>.</param>
//        partial void EqualAfter(ArgumentSyntax original, ArgumentSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArgumentSyntax, ArgumentSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArgumentSyntax original, ArgumentSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.NameColon == null && modified.NameColon == null) || (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.Equal(original.NameColon, modified.NameColon))) &&
//                ((original.RefOrOutKeyword == null && modified.RefOrOutKeyword == null) || (original.RefOrOutKeyword != null && modified.RefOrOutKeyword != null && this.LanguageServiceProvider.Equal(original.RefOrOutKeyword, modified.RefOrOutKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArgumentSyntax original, ArgumentSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="NameColon"/>.
//    /// </summary>
//    partial class NameColonServiceProvider : IEqualityCondition<NameColonSyntax, NameColonSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(NameColonSyntax, NameColonSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameColonSyntax, NameColonSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(NameColonSyntax, NameColonSyntax)"/> is not executed and <see cref="Equal(NameColonSyntax, NameColonSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(NameColonSyntax original, NameColonSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(NameColonSyntax, NameColonSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameColonSyntax, NameColonSyntax)"/>.</param>
//        partial void EqualAfter(NameColonSyntax original, NameColonSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NameColonSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(NameColonSyntax, NameColonSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(NameColonSyntax original, NameColonSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="NameColonSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(NameColonSyntax original, NameColonSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AnonymousObjectMemberDeclarator"/>.
//    /// </summary>
//    partial class AnonymousObjectMemberDeclaratorServiceProvider : IEqualityCondition<AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> is not executed and <see cref="Equal(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
//        partial void EqualAfter(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.NameEquals == null && modified.NameEquals == null) || (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.Equal(original.NameEquals, modified.NameEquals))) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="QueryBody"/>.
//    /// </summary>
//    partial class QueryBodyServiceProvider : IEqualityCondition<QueryBodySyntax, QueryBodySyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryBodySyntax, QueryBodySyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(QueryBodySyntax, QueryBodySyntax)"/> is not executed and <see cref="Equal(QueryBodySyntax, QueryBodySyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(QueryBodySyntax original, QueryBodySyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryBodySyntax, QueryBodySyntax)"/>.</param>
//        partial void EqualAfter(QueryBodySyntax original, QueryBodySyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="QueryBodySyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(QueryBodySyntax, QueryBodySyntax)"/>.</remarks>
//        protected virtual bool EqualCore(QueryBodySyntax original, QueryBodySyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Clauses, modified.Clauses)) &&
//                (this.LanguageServiceProvider.Equal(original.SelectOrGroup, modified.SelectOrGroup)) &&
//                ((original.Continuation == null && modified.Continuation == null) || (original.Continuation != null && modified.Continuation != null && this.LanguageServiceProvider.Equal(original.Continuation, modified.Continuation))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="QueryBodySyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(QueryBodySyntax original, QueryBodySyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="JoinIntoClause"/>.
//    /// </summary>
//    partial class JoinIntoClauseServiceProvider : IEqualityCondition<JoinIntoClauseSyntax, JoinIntoClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> is not executed and <see cref="Equal(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
//        partial void EqualAfter(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.IntoKeyword, modified.IntoKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Ordering"/>.
//    /// </summary>
//    partial class OrderingServiceProvider : IEqualityCondition<OrderingSyntax, OrderingSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OrderingSyntax, OrderingSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OrderingSyntax, OrderingSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OrderingSyntax, OrderingSyntax)"/> is not executed and <see cref="Equal(OrderingSyntax, OrderingSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OrderingSyntax original, OrderingSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OrderingSyntax, OrderingSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OrderingSyntax, OrderingSyntax)"/>.</param>
//        partial void EqualAfter(OrderingSyntax original, OrderingSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OrderingSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OrderingSyntax, OrderingSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OrderingSyntax original, OrderingSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                ((original.AscendingOrDescendingKeyword == null && modified.AscendingOrDescendingKeyword == null) || (original.AscendingOrDescendingKeyword != null && modified.AscendingOrDescendingKeyword != null && this.LanguageServiceProvider.Equal(original.AscendingOrDescendingKeyword, modified.AscendingOrDescendingKeyword))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OrderingSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OrderingSyntax original, OrderingSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="QueryContinuation"/>.
//    /// </summary>
//    partial class QueryContinuationServiceProvider : IEqualityCondition<QueryContinuationSyntax, QueryContinuationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/> is not executed and <see cref="Equal(QueryContinuationSyntax, QueryContinuationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
//        partial void EqualAfter(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(QueryContinuationSyntax original, QueryContinuationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.IntoKeyword, modified.IntoKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.Body, modified.Body)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(QueryContinuationSyntax original, QueryContinuationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="WhenClause"/>.
//    /// </summary>
//    partial class WhenClauseServiceProvider : IEqualityCondition<WhenClauseSyntax, WhenClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(WhenClauseSyntax, WhenClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhenClauseSyntax, WhenClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(WhenClauseSyntax, WhenClauseSyntax)"/> is not executed and <see cref="Equal(WhenClauseSyntax, WhenClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(WhenClauseSyntax original, WhenClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(WhenClauseSyntax, WhenClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhenClauseSyntax, WhenClauseSyntax)"/>.</param>
//        partial void EqualAfter(WhenClauseSyntax original, WhenClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="WhenClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(WhenClauseSyntax, WhenClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(WhenClauseSyntax original, WhenClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.WhenKeyword, modified.WhenKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="WhenClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(WhenClauseSyntax original, WhenClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InterpolationAlignmentClause"/>.
//    /// </summary>
//    partial class InterpolationAlignmentClauseServiceProvider : IEqualityCondition<InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/> is not executed and <see cref="Equal(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</param>
//        partial void EqualAfter(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterpolationAlignmentClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.CommaToken, modified.CommaToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Value, modified.Value)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterpolationAlignmentClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InterpolationFormatClause"/>.
//    /// </summary>
//    partial class InterpolationFormatClauseServiceProvider : IEqualityCondition<InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/> is not executed and <see cref="Equal(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</param>
//        partial void EqualAfter(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterpolationFormatClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.FormatStringToken, modified.FormatStringToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterpolationFormatClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="VariableDeclaration"/>.
//    /// </summary>
//    partial class VariableDeclarationServiceProvider : IEqualityCondition<VariableDeclarationSyntax, VariableDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> is not executed and <see cref="Equal(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.Variables, modified.Variables)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="VariableDeclarator"/>.
//    /// </summary>
//    partial class VariableDeclaratorServiceProvider : IEqualityCondition<VariableDeclaratorSyntax, VariableDeclaratorSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> is not executed and <see cref="Equal(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
//        partial void EqualAfter(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList))) &&
//                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EqualsValueClause"/>.
//    /// </summary>
//    partial class EqualsValueClauseServiceProvider : IEqualityCondition<EqualsValueClauseSyntax, EqualsValueClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/> is not executed and <see cref="Equal(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</param>
//        partial void EqualAfter(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EqualsValueClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Value, modified.Value)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EqualsValueClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ElseClause"/>.
//    /// </summary>
//    partial class ElseClauseServiceProvider : IEqualityCondition<ElseClauseSyntax, ElseClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ElseClauseSyntax, ElseClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElseClauseSyntax, ElseClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ElseClauseSyntax, ElseClauseSyntax)"/> is not executed and <see cref="Equal(ElseClauseSyntax, ElseClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ElseClauseSyntax original, ElseClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ElseClauseSyntax, ElseClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElseClauseSyntax, ElseClauseSyntax)"/>.</param>
//        partial void EqualAfter(ElseClauseSyntax original, ElseClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ElseClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ElseClauseSyntax, ElseClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ElseClauseSyntax original, ElseClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ElseKeyword, modified.ElseKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ElseClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ElseClauseSyntax original, ElseClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SwitchSection"/>.
//    /// </summary>
//    partial class SwitchSectionServiceProvider : IEqualityCondition<SwitchSectionSyntax, SwitchSectionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/> is not executed and <see cref="Equal(SwitchSectionSyntax, SwitchSectionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SwitchSectionSyntax original, SwitchSectionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SwitchSectionSyntax, SwitchSectionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</param>
//        partial void EqualAfter(SwitchSectionSyntax original, SwitchSectionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SwitchSectionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SwitchSectionSyntax, SwitchSectionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SwitchSectionSyntax original, SwitchSectionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Labels, modified.Labels)) &&
//                (this.LanguageServiceProvider.Equal(original.Statements, modified.Statements)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SwitchSectionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SwitchSectionSyntax original, SwitchSectionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CatchClause"/>.
//    /// </summary>
//    partial class CatchClauseServiceProvider : IEqualityCondition<CatchClauseSyntax, CatchClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CatchClauseSyntax, CatchClauseSyntax)"/> is not executed and <see cref="Equal(CatchClauseSyntax, CatchClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
//        partial void EqualAfter(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CatchClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CatchClauseSyntax, CatchClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CatchClauseSyntax original, CatchClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.CatchKeyword, modified.CatchKeyword)) &&
//                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration))) &&
//                ((original.Filter == null && modified.Filter == null) || (original.Filter != null && modified.Filter != null && this.LanguageServiceProvider.Equal(original.Filter, modified.Filter))) &&
//                (this.LanguageServiceProvider.Equal(original.Block, modified.Block)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CatchClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CatchClauseSyntax original, CatchClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CatchDeclaration"/>.
//    /// </summary>
//    partial class CatchDeclarationServiceProvider : IEqualityCondition<CatchDeclarationSyntax, CatchDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> is not executed and <see cref="Equal(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.Identifier == null && modified.Identifier == null) || (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier))) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CatchFilterClause"/>.
//    /// </summary>
//    partial class CatchFilterClauseServiceProvider : IEqualityCondition<CatchFilterClauseSyntax, CatchFilterClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/> is not executed and <see cref="Equal(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</param>
//        partial void EqualAfter(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CatchFilterClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.WhenKeyword, modified.WhenKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.FilterExpression, modified.FilterExpression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CatchFilterClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="FinallyClause"/>.
//    /// </summary>
//    partial class FinallyClauseServiceProvider : IEqualityCondition<FinallyClauseSyntax, FinallyClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/> is not executed and <see cref="Equal(FinallyClauseSyntax, FinallyClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(FinallyClauseSyntax original, FinallyClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(FinallyClauseSyntax, FinallyClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</param>
//        partial void EqualAfter(FinallyClauseSyntax original, FinallyClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="FinallyClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(FinallyClauseSyntax, FinallyClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(FinallyClauseSyntax original, FinallyClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.FinallyKeyword, modified.FinallyKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Block, modified.Block)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="FinallyClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(FinallyClauseSyntax original, FinallyClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CompilationUnit"/>.
//    /// </summary>
//    partial class CompilationUnitServiceProvider : IEqualityCondition<CompilationUnitSyntax, CompilationUnitSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/> is not executed and <see cref="Equal(CompilationUnitSyntax, CompilationUnitSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CompilationUnitSyntax original, CompilationUnitSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CompilationUnitSyntax, CompilationUnitSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</param>
//        partial void EqualAfter(CompilationUnitSyntax original, CompilationUnitSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CompilationUnitSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CompilationUnitSyntax, CompilationUnitSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CompilationUnitSyntax original, CompilationUnitSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Externs, modified.Externs)) &&
//                (this.LanguageServiceProvider.Equal(original.Usings, modified.Usings)) &&
//                (this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfFileToken, modified.EndOfFileToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CompilationUnitSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CompilationUnitSyntax original, CompilationUnitSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ExternAliasDirective"/>.
//    /// </summary>
//    partial class ExternAliasDirectiveServiceProvider : IEqualityCondition<ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> is not executed and <see cref="Equal(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
//        partial void EqualAfter(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ExternKeyword, modified.ExternKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.AliasKeyword, modified.AliasKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="UsingDirective"/>.
//    /// </summary>
//    partial class UsingDirectiveServiceProvider : IEqualityCondition<UsingDirectiveSyntax, UsingDirectiveSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> is not executed and <see cref="Equal(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
//        partial void EqualAfter(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.UsingKeyword, modified.UsingKeyword)) &&
//                ((original.StaticKeyword == null && modified.StaticKeyword == null) || (original.StaticKeyword != null && modified.StaticKeyword != null && this.LanguageServiceProvider.Equal(original.StaticKeyword, modified.StaticKeyword))) &&
//                ((original.Alias == null && modified.Alias == null) || (original.Alias != null && modified.Alias != null && this.LanguageServiceProvider.Equal(original.Alias, modified.Alias))) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AttributeList"/>.
//    /// </summary>
//    partial class AttributeListServiceProvider : IEqualityCondition<AttributeListSyntax, AttributeListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeListSyntax, AttributeListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AttributeListSyntax, AttributeListSyntax)"/> is not executed and <see cref="Equal(AttributeListSyntax, AttributeListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AttributeListSyntax original, AttributeListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeListSyntax, AttributeListSyntax)"/>.</param>
//        partial void EqualAfter(AttributeListSyntax original, AttributeListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AttributeListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AttributeListSyntax, AttributeListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AttributeListSyntax original, AttributeListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                ((original.Target == null && modified.Target == null) || (original.Target != null && modified.Target != null && this.LanguageServiceProvider.Equal(original.Target, modified.Target))) &&
//                (this.LanguageServiceProvider.Equal(original.Attributes, modified.Attributes)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AttributeListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AttributeListSyntax original, AttributeListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AttributeTargetSpecifier"/>.
//    /// </summary>
//    partial class AttributeTargetSpecifierServiceProvider : IEqualityCondition<AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> is not executed and <see cref="Equal(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
//        partial void EqualAfter(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Attribute"/>.
//    /// </summary>
//    partial class AttributeServiceProvider : IEqualityCondition<AttributeSyntax, AttributeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AttributeSyntax, AttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeSyntax, AttributeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AttributeSyntax, AttributeSyntax)"/> is not executed and <see cref="Equal(AttributeSyntax, AttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AttributeSyntax original, AttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AttributeSyntax, AttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeSyntax, AttributeSyntax)"/>.</param>
//        partial void EqualAfter(AttributeSyntax original, AttributeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AttributeSyntax, AttributeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AttributeSyntax original, AttributeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AttributeSyntax original, AttributeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AttributeArgumentList"/>.
//    /// </summary>
//    partial class AttributeArgumentListServiceProvider : IEqualityCondition<AttributeArgumentListSyntax, AttributeArgumentListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/> is not executed and <see cref="Equal(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</param>
//        partial void EqualAfter(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AttributeArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Arguments, modified.Arguments)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AttributeArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DelegateDeclaration"/>.
//    /// </summary>
//    partial class DelegateDeclarationServiceProvider : IEqualityCondition<DelegateDeclarationSyntax, DelegateDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> is not executed and <see cref="Equal(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.DelegateKeyword, modified.DelegateKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ReturnType, modified.ReturnType)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EnumMemberDeclaration"/>.
//    /// </summary>
//    partial class EnumMemberDeclarationServiceProvider : IEqualityCondition<EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> is not executed and <see cref="Equal(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.EqualsValue == null && modified.EqualsValue == null) || (original.EqualsValue != null && modified.EqualsValue != null && this.LanguageServiceProvider.Equal(original.EqualsValue, modified.EqualsValue))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IncompleteMember"/>.
//    /// </summary>
//    partial class IncompleteMemberServiceProvider : IEqualityCondition<IncompleteMemberSyntax, IncompleteMemberSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/> is not executed and <see cref="Equal(IncompleteMemberSyntax, IncompleteMemberSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IncompleteMemberSyntax original, IncompleteMemberSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</param>
//        partial void EqualAfter(IncompleteMemberSyntax original, IncompleteMemberSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IncompleteMemberSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.Equal(original.Type, modified.Type))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IncompleteMemberSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="GlobalStatement"/>.
//    /// </summary>
//    partial class GlobalStatementServiceProvider : IEqualityCondition<GlobalStatementSyntax, GlobalStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/> is not executed and <see cref="Equal(GlobalStatementSyntax, GlobalStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(GlobalStatementSyntax original, GlobalStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(GlobalStatementSyntax, GlobalStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</param>
//        partial void EqualAfter(GlobalStatementSyntax original, GlobalStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="GlobalStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(GlobalStatementSyntax, GlobalStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(GlobalStatementSyntax original, GlobalStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="GlobalStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(GlobalStatementSyntax original, GlobalStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="NamespaceDeclaration"/>.
//    /// </summary>
//    partial class NamespaceDeclarationServiceProvider : IEqualityCondition<NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> is not executed and <see cref="Equal(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NamespaceKeyword, modified.NamespaceKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Externs, modified.Externs)) &&
//                (this.LanguageServiceProvider.Equal(original.Usings, modified.Usings)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EnumDeclaration"/>.
//    /// </summary>
//    partial class EnumDeclarationServiceProvider : IEqualityCondition<EnumDeclarationSyntax, EnumDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> is not executed and <see cref="Equal(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.EnumKeyword, modified.EnumKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.Equal(original.BaseList, modified.BaseList))) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ClassDeclaration"/>.
//    /// </summary>
//    partial class ClassDeclarationServiceProvider : IEqualityCondition<ClassDeclarationSyntax, ClassDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> is not executed and <see cref="Equal(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.Equal(original.BaseList, modified.BaseList))) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="StructDeclaration"/>.
//    /// </summary>
//    partial class StructDeclarationServiceProvider : IEqualityCondition<StructDeclarationSyntax, StructDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/> is not executed and <see cref="Equal(StructDeclarationSyntax, StructDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.Equal(original.BaseList, modified.BaseList))) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InterfaceDeclaration"/>.
//    /// </summary>
//    partial class InterfaceDeclarationServiceProvider : IEqualityCondition<InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> is not executed and <see cref="Equal(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                ((original.BaseList == null && modified.BaseList == null) || (original.BaseList != null && modified.BaseList != null && this.LanguageServiceProvider.Equal(original.BaseList, modified.BaseList))) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Members, modified.Members)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="FieldDeclaration"/>.
//    /// </summary>
//    partial class FieldDeclarationServiceProvider : IEqualityCondition<FieldDeclarationSyntax, FieldDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> is not executed and <see cref="Equal(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EventFieldDeclaration"/>.
//    /// </summary>
//    partial class EventFieldDeclarationServiceProvider : IEqualityCondition<EventFieldDeclarationSyntax, EventFieldDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> is not executed and <see cref="Equal(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.EventKeyword, modified.EventKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="MethodDeclaration"/>.
//    /// </summary>
//    partial class MethodDeclarationServiceProvider : IEqualityCondition<MethodDeclarationSyntax, MethodDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> is not executed and <see cref="Equal(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.ReturnType, modified.ReturnType)) &&
//                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.Equal(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="OperatorDeclaration"/>.
//    /// </summary>
//    partial class OperatorDeclarationServiceProvider : IEqualityCondition<OperatorDeclarationSyntax, OperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> is not executed and <see cref="Equal(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.ReturnType, modified.ReturnType)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorKeyword, modified.OperatorKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConversionOperatorDeclaration"/>.
//    /// </summary>
//    partial class ConversionOperatorDeclarationServiceProvider : IEqualityCondition<ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> is not executed and <see cref="Equal(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.ImplicitOrExplicitKeyword, modified.ImplicitOrExplicitKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorKeyword, modified.OperatorKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConstructorDeclaration"/>.
//    /// </summary>
//    partial class ConstructorDeclarationServiceProvider : IEqualityCondition<ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> is not executed and <see cref="Equal(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer))) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DestructorDeclaration"/>.
//    /// </summary>
//    partial class DestructorDeclarationServiceProvider : IEqualityCondition<DestructorDeclarationSyntax, DestructorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> is not executed and <see cref="Equal(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.TildeToken, modified.TildeToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PropertyDeclaration"/>.
//    /// </summary>
//    partial class PropertyDeclarationServiceProvider : IEqualityCondition<PropertyDeclarationSyntax, PropertyDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> is not executed and <see cref="Equal(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.Equal(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.AccessorList == null && modified.AccessorList == null) || (original.AccessorList != null && modified.AccessorList != null && this.LanguageServiceProvider.Equal(original.AccessorList, modified.AccessorList))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EventDeclaration"/>.
//    /// </summary>
//    partial class EventDeclarationServiceProvider : IEqualityCondition<EventDeclarationSyntax, EventDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/> is not executed and <see cref="Equal(EventDeclarationSyntax, EventDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EventDeclarationSyntax original, EventDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.EventKeyword, modified.EventKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.Equal(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.AccessorList, modified.AccessorList)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EventDeclarationSyntax original, EventDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IndexerDeclaration"/>.
//    /// </summary>
//    partial class IndexerDeclarationServiceProvider : IEqualityCondition<IndexerDeclarationSyntax, IndexerDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> is not executed and <see cref="Equal(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        partial void EqualAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AttributeLists, modified.AttributeLists)) &&
//                (this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.Equal(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier))) &&
//                (this.LanguageServiceProvider.Equal(original.ThisKeyword, modified.ThisKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                ((original.AccessorList == null && modified.AccessorList == null) || (original.AccessorList != null && modified.AccessorList != null && this.LanguageServiceProvider.Equal(original.AccessorList, modified.AccessorList))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SimpleBaseType"/>.
//    /// </summary>
//    partial class SimpleBaseTypeServiceProvider : IEqualityCondition<SimpleBaseTypeSyntax, SimpleBaseTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/> is not executed and <see cref="Equal(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</param>
//        partial void EqualAfter(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SimpleBaseTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Type, modified.Type))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SimpleBaseTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConstructorConstraint"/>.
//    /// </summary>
//    partial class ConstructorConstraintServiceProvider : IEqualityCondition<ConstructorConstraintSyntax, ConstructorConstraintSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/> is not executed and <see cref="Equal(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</param>
//        partial void EqualAfter(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NewKeyword, modified.NewKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConstructorConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ClassOrStructConstraint"/>.
//    /// </summary>
//    partial class ClassOrStructConstraintServiceProvider : IEqualityCondition<ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/> is not executed and <see cref="Equal(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</param>
//        partial void EqualAfter(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ClassOrStructConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.ClassOrStructKeyword, modified.ClassOrStructKeyword))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ClassOrStructConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeConstraint"/>.
//    /// </summary>
//    partial class TypeConstraintServiceProvider : IEqualityCondition<TypeConstraintSyntax, TypeConstraintSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/> is not executed and <see cref="Equal(TypeConstraintSyntax, TypeConstraintSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeConstraintSyntax original, TypeConstraintSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeConstraintSyntax, TypeConstraintSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</param>
//        partial void EqualAfter(TypeConstraintSyntax original, TypeConstraintSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeConstraintSyntax, TypeConstraintSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeConstraintSyntax original, TypeConstraintSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Type, modified.Type))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeConstraintSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeConstraintSyntax original, TypeConstraintSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ParameterList"/>.
//    /// </summary>
//    partial class ParameterListServiceProvider : IEqualityCondition<ParameterListSyntax, ParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ParameterListSyntax, ParameterListSyntax)"/> is not executed and <see cref="Equal(ParameterListSyntax, ParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ParameterListSyntax original, ParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        partial void EqualAfter(ParameterListSyntax original, ParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ParameterListSyntax, ParameterListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ParameterListSyntax original, ParameterListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ParameterListSyntax original, ParameterListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BracketedParameterList"/>.
//    /// </summary>
//    partial class BracketedParameterListServiceProvider : IEqualityCondition<BracketedParameterListSyntax, BracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> is not executed and <see cref="Equal(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        partial void EqualAfter(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SkippedTokensTrivia"/>.
//    /// </summary>
//    partial class SkippedTokensTriviaServiceProvider : IEqualityCondition<SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/> is not executed and <see cref="Equal(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</param>
//        partial void EqualAfter(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SkippedTokensTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Tokens, modified.Tokens))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SkippedTokensTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DocumentationCommentTrivia"/>.
//    /// </summary>
//    partial class DocumentationCommentTriviaServiceProvider : IEqualityCondition<DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/> is not executed and <see cref="Equal(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</param>
//        partial void EqualAfter(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DocumentationCommentTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Content, modified.Content)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfComment, modified.EndOfComment)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DocumentationCommentTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EndIfDirectiveTrivia"/>.
//    /// </summary>
//    partial class EndIfDirectiveTriviaServiceProvider : IEqualityCondition<EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EndIfDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.EndIfKeyword, modified.EndIfKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EndIfDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="RegionDirectiveTrivia"/>.
//    /// </summary>
//    partial class RegionDirectiveTriviaServiceProvider : IEqualityCondition<RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="RegionDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.RegionKeyword, modified.RegionKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="RegionDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EndRegionDirectiveTrivia"/>.
//    /// </summary>
//    partial class EndRegionDirectiveTriviaServiceProvider : IEqualityCondition<EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EndRegionDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.EndRegionKeyword, modified.EndRegionKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EndRegionDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ErrorDirectiveTrivia"/>.
//    /// </summary>
//    partial class ErrorDirectiveTriviaServiceProvider : IEqualityCondition<ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ErrorDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ErrorKeyword, modified.ErrorKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ErrorDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="WarningDirectiveTrivia"/>.
//    /// </summary>
//    partial class WarningDirectiveTriviaServiceProvider : IEqualityCondition<WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="WarningDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.WarningKeyword, modified.WarningKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="WarningDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BadDirectiveTrivia"/>.
//    /// </summary>
//    partial class BadDirectiveTriviaServiceProvider : IEqualityCondition<BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DefineDirectiveTrivia"/>.
//    /// </summary>
//    partial class DefineDirectiveTriviaServiceProvider : IEqualityCondition<DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.DefineKeyword, modified.DefineKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="UndefDirectiveTrivia"/>.
//    /// </summary>
//    partial class UndefDirectiveTriviaServiceProvider : IEqualityCondition<UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.UndefKeyword, modified.UndefKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LineDirectiveTrivia"/>.
//    /// </summary>
//    partial class LineDirectiveTriviaServiceProvider : IEqualityCondition<LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LineDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.LineKeyword, modified.LineKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Line, modified.Line)) &&
//                ((original.File == null && modified.File == null) || (original.File != null && modified.File != null && this.LanguageServiceProvider.Equal(original.File, modified.File))) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LineDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PragmaWarningDirectiveTrivia"/>.
//    /// </summary>
//    partial class PragmaWarningDirectiveTriviaServiceProvider : IEqualityCondition<PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PragmaWarningDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.PragmaKeyword, modified.PragmaKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.WarningKeyword, modified.WarningKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.DisableOrRestoreKeyword, modified.DisableOrRestoreKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ErrorCodes, modified.ErrorCodes)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PragmaWarningDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PragmaChecksumDirectiveTrivia"/>.
//    /// </summary>
//    partial class PragmaChecksumDirectiveTriviaServiceProvider : IEqualityCondition<PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PragmaChecksumDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.PragmaKeyword, modified.PragmaKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ChecksumKeyword, modified.ChecksumKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.File, modified.File)) &&
//                (this.LanguageServiceProvider.Equal(original.Guid, modified.Guid)) &&
//                (this.LanguageServiceProvider.Equal(original.Bytes, modified.Bytes)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PragmaChecksumDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ReferenceDirectiveTrivia"/>.
//    /// </summary>
//    partial class ReferenceDirectiveTriviaServiceProvider : IEqualityCondition<ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ReferenceDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ReferenceKeyword, modified.ReferenceKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.File, modified.File)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ReferenceDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LoadDirectiveTrivia"/>.
//    /// </summary>
//    partial class LoadDirectiveTriviaServiceProvider : IEqualityCondition<LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LoadDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.LoadKeyword, modified.LoadKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.File, modified.File)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LoadDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ShebangDirectiveTrivia"/>.
//    /// </summary>
//    partial class ShebangDirectiveTriviaServiceProvider : IEqualityCondition<ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ShebangDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ExclamationToken, modified.ExclamationToken)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ShebangDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ElseDirectiveTrivia"/>.
//    /// </summary>
//    partial class ElseDirectiveTriviaServiceProvider : IEqualityCondition<ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ElseDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ElseKeyword, modified.ElseKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ElseDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IfDirectiveTrivia"/>.
//    /// </summary>
//    partial class IfDirectiveTriviaServiceProvider : IEqualityCondition<IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IfDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.IfKeyword, modified.IfKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IfDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ElifDirectiveTrivia"/>.
//    /// </summary>
//    partial class ElifDirectiveTriviaServiceProvider : IEqualityCondition<ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/> is not executed and <see cref="Equal(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</param>
//        partial void EqualAfter(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ElifDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.HashToken, modified.HashToken)) &&
//                (this.LanguageServiceProvider.Equal(original.ElifKeyword, modified.ElifKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.EndOfDirectiveToken, modified.EndOfDirectiveToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ElifDirectiveTriviaSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeCref"/>.
//    /// </summary>
//    partial class TypeCrefServiceProvider : IEqualityCondition<TypeCrefSyntax, TypeCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeCrefSyntax, TypeCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeCrefSyntax, TypeCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeCrefSyntax, TypeCrefSyntax)"/> is not executed and <see cref="Equal(TypeCrefSyntax, TypeCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeCrefSyntax original, TypeCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeCrefSyntax, TypeCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeCrefSyntax, TypeCrefSyntax)"/>.</param>
//        partial void EqualAfter(TypeCrefSyntax original, TypeCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeCrefSyntax, TypeCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeCrefSyntax original, TypeCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Type, modified.Type))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeCrefSyntax original, TypeCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="QualifiedCref"/>.
//    /// </summary>
//    partial class QualifiedCrefServiceProvider : IEqualityCondition<QualifiedCrefSyntax, QualifiedCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/> is not executed and <see cref="Equal(QualifiedCrefSyntax, QualifiedCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(QualifiedCrefSyntax original, QualifiedCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</param>
//        partial void EqualAfter(QualifiedCrefSyntax original, QualifiedCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="QualifiedCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Container, modified.Container)) &&
//                (this.LanguageServiceProvider.Equal(original.DotToken, modified.DotToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Member, modified.Member)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="QualifiedCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="NameMemberCref"/>.
//    /// </summary>
//    partial class NameMemberCrefServiceProvider : IEqualityCondition<NameMemberCrefSyntax, NameMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> is not executed and <see cref="Equal(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        partial void EqualAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IndexerMemberCref"/>.
//    /// </summary>
//    partial class IndexerMemberCrefServiceProvider : IEqualityCondition<IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> is not executed and <see cref="Equal(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        partial void EqualAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ThisKeyword, modified.ThisKeyword)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="OperatorMemberCref"/>.
//    /// </summary>
//    partial class OperatorMemberCrefServiceProvider : IEqualityCondition<OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> is not executed and <see cref="Equal(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        partial void EqualAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OperatorKeyword, modified.OperatorKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConversionOperatorMemberCref"/>.
//    /// </summary>
//    partial class ConversionOperatorMemberCrefServiceProvider : IEqualityCondition<ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> is not executed and <see cref="Equal(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        partial void EqualAfter(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ImplicitOrExplicitKeyword, modified.ImplicitOrExplicitKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorKeyword, modified.OperatorKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CrefParameterList"/>.
//    /// </summary>
//    partial class CrefParameterListServiceProvider : IEqualityCondition<CrefParameterListSyntax, CrefParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/> is not executed and <see cref="Equal(CrefParameterListSyntax, CrefParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        partial void EqualAfter(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CrefBracketedParameterList"/>.
//    /// </summary>
//    partial class CrefBracketedParameterListServiceProvider : IEqualityCondition<CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> is not executed and <see cref="Equal(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        partial void EqualAfter(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Parameters, modified.Parameters)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlElement"/>.
//    /// </summary>
//    partial class XmlElementServiceProvider : IEqualityCondition<XmlElementSyntax, XmlElementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementSyntax, XmlElementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlElementSyntax, XmlElementSyntax)"/> is not executed and <see cref="Equal(XmlElementSyntax, XmlElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlElementSyntax original, XmlElementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlElementSyntax, XmlElementSyntax)"/>.</param>
//        partial void EqualAfter(XmlElementSyntax original, XmlElementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlElementSyntax, XmlElementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlElementSyntax original, XmlElementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.StartTag, modified.StartTag)) &&
//                (this.LanguageServiceProvider.Equal(original.Content, modified.Content)) &&
//                (this.LanguageServiceProvider.Equal(original.EndTag, modified.EndTag)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlElementSyntax original, XmlElementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlEmptyElement"/>.
//    /// </summary>
//    partial class XmlEmptyElementServiceProvider : IEqualityCondition<XmlEmptyElementSyntax, XmlEmptyElementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> is not executed and <see cref="Equal(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
//        partial void EqualAfter(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanToken, modified.LessThanToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.Attributes, modified.Attributes)) &&
//                (this.LanguageServiceProvider.Equal(original.SlashGreaterThanToken, modified.SlashGreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlText"/>.
//    /// </summary>
//    partial class XmlTextServiceProvider : IEqualityCondition<XmlTextSyntax, XmlTextSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlTextSyntax, XmlTextSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlTextSyntax, XmlTextSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlTextSyntax, XmlTextSyntax)"/> is not executed and <see cref="Equal(XmlTextSyntax, XmlTextSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlTextSyntax original, XmlTextSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlTextSyntax, XmlTextSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlTextSyntax, XmlTextSyntax)"/>.</param>
//        partial void EqualAfter(XmlTextSyntax original, XmlTextSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlTextSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlTextSyntax, XmlTextSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlTextSyntax original, XmlTextSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.TextTokens, modified.TextTokens))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlTextSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlTextSyntax original, XmlTextSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlCDataSection"/>.
//    /// </summary>
//    partial class XmlCDataSectionServiceProvider : IEqualityCondition<XmlCDataSectionSyntax, XmlCDataSectionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/> is not executed and <see cref="Equal(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</param>
//        partial void EqualAfter(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlCDataSectionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.StartCDataToken, modified.StartCDataToken)) &&
//                (this.LanguageServiceProvider.Equal(original.TextTokens, modified.TextTokens)) &&
//                (this.LanguageServiceProvider.Equal(original.EndCDataToken, modified.EndCDataToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlCDataSectionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlProcessingInstruction"/>.
//    /// </summary>
//    partial class XmlProcessingInstructionServiceProvider : IEqualityCondition<XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> is not executed and <see cref="Equal(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
//        partial void EqualAfter(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.StartProcessingInstructionToken, modified.StartProcessingInstructionToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.TextTokens, modified.TextTokens)) &&
//                (this.LanguageServiceProvider.Equal(original.EndProcessingInstructionToken, modified.EndProcessingInstructionToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlComment"/>.
//    /// </summary>
//    partial class XmlCommentServiceProvider : IEqualityCondition<XmlCommentSyntax, XmlCommentSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlCommentSyntax, XmlCommentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCommentSyntax, XmlCommentSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlCommentSyntax, XmlCommentSyntax)"/> is not executed and <see cref="Equal(XmlCommentSyntax, XmlCommentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlCommentSyntax original, XmlCommentSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlCommentSyntax, XmlCommentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCommentSyntax, XmlCommentSyntax)"/>.</param>
//        partial void EqualAfter(XmlCommentSyntax original, XmlCommentSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlCommentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlCommentSyntax, XmlCommentSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlCommentSyntax original, XmlCommentSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LessThanExclamationMinusMinusToken, modified.LessThanExclamationMinusMinusToken)) &&
//                (this.LanguageServiceProvider.Equal(original.TextTokens, modified.TextTokens)) &&
//                (this.LanguageServiceProvider.Equal(original.MinusMinusGreaterThanToken, modified.MinusMinusGreaterThanToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlCommentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlCommentSyntax original, XmlCommentSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlTextAttribute"/>.
//    /// </summary>
//    partial class XmlTextAttributeServiceProvider : IEqualityCondition<XmlTextAttributeSyntax, XmlTextAttributeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> is not executed and <see cref="Equal(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
//        partial void EqualAfter(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)) &&
//                (this.LanguageServiceProvider.Equal(original.StartQuoteToken, modified.StartQuoteToken)) &&
//                (this.LanguageServiceProvider.Equal(original.TextTokens, modified.TextTokens)) &&
//                (this.LanguageServiceProvider.Equal(original.EndQuoteToken, modified.EndQuoteToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlCrefAttribute"/>.
//    /// </summary>
//    partial class XmlCrefAttributeServiceProvider : IEqualityCondition<XmlCrefAttributeSyntax, XmlCrefAttributeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> is not executed and <see cref="Equal(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
//        partial void EqualAfter(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)) &&
//                (this.LanguageServiceProvider.Equal(original.StartQuoteToken, modified.StartQuoteToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Cref, modified.Cref)) &&
//                (this.LanguageServiceProvider.Equal(original.EndQuoteToken, modified.EndQuoteToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="XmlNameAttribute"/>.
//    /// </summary>
//    partial class XmlNameAttributeServiceProvider : IEqualityCondition<XmlNameAttributeSyntax, XmlNameAttributeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> is not executed and <see cref="Equal(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
//        partial void EqualAfter(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Name, modified.Name)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)) &&
//                (this.LanguageServiceProvider.Equal(original.StartQuoteToken, modified.StartQuoteToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.EndQuoteToken, modified.EndQuoteToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ParenthesizedExpression"/>.
//    /// </summary>
//    partial class ParenthesizedExpressionServiceProvider : IEqualityCondition<ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/> is not executed and <see cref="Equal(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ParenthesizedExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TupleExpression"/>.
//    /// </summary>
//    partial class TupleExpressionServiceProvider : IEqualityCondition<TupleExpressionSyntax, TupleExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/> is not executed and <see cref="Equal(TupleExpressionSyntax, TupleExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TupleExpressionSyntax original, TupleExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TupleExpressionSyntax, TupleExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</param>
//        partial void EqualAfter(TupleExpressionSyntax original, TupleExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TupleExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TupleExpressionSyntax, TupleExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TupleExpressionSyntax original, TupleExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Arguments, modified.Arguments)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TupleExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TupleExpressionSyntax original, TupleExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PrefixUnaryExpression"/>.
//    /// </summary>
//    partial class PrefixUnaryExpressionServiceProvider : IEqualityCondition<PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/> is not executed and <see cref="Equal(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</param>
//        partial void EqualAfter(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PrefixUnaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Operand, modified.Operand)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PrefixUnaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AwaitExpression"/>.
//    /// </summary>
//    partial class AwaitExpressionServiceProvider : IEqualityCondition<AwaitExpressionSyntax, AwaitExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/> is not executed and <see cref="Equal(AwaitExpressionSyntax, AwaitExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AwaitExpressionSyntax original, AwaitExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</param>
//        partial void EqualAfter(AwaitExpressionSyntax original, AwaitExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AwaitExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.AwaitKeyword, modified.AwaitKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AwaitExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PostfixUnaryExpression"/>.
//    /// </summary>
//    partial class PostfixUnaryExpressionServiceProvider : IEqualityCondition<PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/> is not executed and <see cref="Equal(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</param>
//        partial void EqualAfter(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PostfixUnaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Operand, modified.Operand)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PostfixUnaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="MemberAccessExpression"/>.
//    /// </summary>
//    partial class MemberAccessExpressionServiceProvider : IEqualityCondition<MemberAccessExpressionSyntax, MemberAccessExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> is not executed and <see cref="Equal(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
//        partial void EqualAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConditionalAccessExpression"/>.
//    /// </summary>
//    partial class ConditionalAccessExpressionServiceProvider : IEqualityCondition<ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/> is not executed and <see cref="Equal(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConditionalAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.WhenNotNull, modified.WhenNotNull)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConditionalAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="MemberBindingExpression"/>.
//    /// </summary>
//    partial class MemberBindingExpressionServiceProvider : IEqualityCondition<MemberBindingExpressionSyntax, MemberBindingExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> is not executed and <see cref="Equal(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
//        partial void EqualAfter(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ElementBindingExpression"/>.
//    /// </summary>
//    partial class ElementBindingExpressionServiceProvider : IEqualityCondition<ElementBindingExpressionSyntax, ElementBindingExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/> is not executed and <see cref="Equal(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ElementBindingExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ElementBindingExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ImplicitElementAccess"/>.
//    /// </summary>
//    partial class ImplicitElementAccessServiceProvider : IEqualityCondition<ImplicitElementAccessSyntax, ImplicitElementAccessSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/> is not executed and <see cref="Equal(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</param>
//        partial void EqualAfter(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ImplicitElementAccessSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ImplicitElementAccessSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BinaryExpression"/>.
//    /// </summary>
//    partial class BinaryExpressionServiceProvider : IEqualityCondition<BinaryExpressionSyntax, BinaryExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/> is not executed and <see cref="Equal(BinaryExpressionSyntax, BinaryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BinaryExpressionSyntax original, BinaryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</param>
//        partial void EqualAfter(BinaryExpressionSyntax original, BinaryExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BinaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Left, modified.Left)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Right, modified.Right)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BinaryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AssignmentExpression"/>.
//    /// </summary>
//    partial class AssignmentExpressionServiceProvider : IEqualityCondition<AssignmentExpressionSyntax, AssignmentExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/> is not executed and <see cref="Equal(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</param>
//        partial void EqualAfter(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AssignmentExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Left, modified.Left)) &&
//                (this.LanguageServiceProvider.Equal(original.OperatorToken, modified.OperatorToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Right, modified.Right)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AssignmentExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConditionalExpression"/>.
//    /// </summary>
//    partial class ConditionalExpressionServiceProvider : IEqualityCondition<ConditionalExpressionSyntax, ConditionalExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/> is not executed and <see cref="Equal(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConditionalExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.QuestionToken, modified.QuestionToken)) &&
//                (this.LanguageServiceProvider.Equal(original.WhenTrue, modified.WhenTrue)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.WhenFalse, modified.WhenFalse)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConditionalExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LiteralExpression"/>.
//    /// </summary>
//    partial class LiteralExpressionServiceProvider : IEqualityCondition<LiteralExpressionSyntax, LiteralExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/> is not executed and <see cref="Equal(LiteralExpressionSyntax, LiteralExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LiteralExpressionSyntax original, LiteralExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</param>
//        partial void EqualAfter(LiteralExpressionSyntax original, LiteralExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LiteralExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Token, modified.Token))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LiteralExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="MakeRefExpression"/>.
//    /// </summary>
//    partial class MakeRefExpressionServiceProvider : IEqualityCondition<MakeRefExpressionSyntax, MakeRefExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/> is not executed and <see cref="Equal(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</param>
//        partial void EqualAfter(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MakeRefExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="MakeRefExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="RefTypeExpression"/>.
//    /// </summary>
//    partial class RefTypeExpressionServiceProvider : IEqualityCondition<RefTypeExpressionSyntax, RefTypeExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/> is not executed and <see cref="Equal(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</param>
//        partial void EqualAfter(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="RefTypeExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="RefTypeExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="RefValueExpression"/>.
//    /// </summary>
//    partial class RefValueExpressionServiceProvider : IEqualityCondition<RefValueExpressionSyntax, RefValueExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/> is not executed and <see cref="Equal(RefValueExpressionSyntax, RefValueExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(RefValueExpressionSyntax original, RefValueExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</param>
//        partial void EqualAfter(RefValueExpressionSyntax original, RefValueExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="RefValueExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.Comma, modified.Comma)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="RefValueExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CheckedExpression"/>.
//    /// </summary>
//    partial class CheckedExpressionServiceProvider : IEqualityCondition<CheckedExpressionSyntax, CheckedExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/> is not executed and <see cref="Equal(CheckedExpressionSyntax, CheckedExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CheckedExpressionSyntax original, CheckedExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</param>
//        partial void EqualAfter(CheckedExpressionSyntax original, CheckedExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CheckedExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CheckedExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DefaultExpression"/>.
//    /// </summary>
//    partial class DefaultExpressionServiceProvider : IEqualityCondition<DefaultExpressionSyntax, DefaultExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/> is not executed and <see cref="Equal(DefaultExpressionSyntax, DefaultExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DefaultExpressionSyntax original, DefaultExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</param>
//        partial void EqualAfter(DefaultExpressionSyntax original, DefaultExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DefaultExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DefaultExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TypeOfExpression"/>.
//    /// </summary>
//    partial class TypeOfExpressionServiceProvider : IEqualityCondition<TypeOfExpressionSyntax, TypeOfExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/> is not executed and <see cref="Equal(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</param>
//        partial void EqualAfter(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeOfExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TypeOfExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SizeOfExpression"/>.
//    /// </summary>
//    partial class SizeOfExpressionServiceProvider : IEqualityCondition<SizeOfExpressionSyntax, SizeOfExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/> is not executed and <see cref="Equal(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</param>
//        partial void EqualAfter(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SizeOfExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SizeOfExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InvocationExpression"/>.
//    /// </summary>
//    partial class InvocationExpressionServiceProvider : IEqualityCondition<InvocationExpressionSyntax, InvocationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/> is not executed and <see cref="Equal(InvocationExpressionSyntax, InvocationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InvocationExpressionSyntax original, InvocationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(InvocationExpressionSyntax original, InvocationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InvocationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InvocationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ElementAccessExpression"/>.
//    /// </summary>
//    partial class ElementAccessExpressionServiceProvider : IEqualityCondition<ElementAccessExpressionSyntax, ElementAccessExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/> is not executed and <see cref="Equal(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ElementAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ElementAccessExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DeclarationExpression"/>.
//    /// </summary>
//    partial class DeclarationExpressionServiceProvider : IEqualityCondition<DeclarationExpressionSyntax, DeclarationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/> is not executed and <see cref="Equal(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DeclarationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.Designation, modified.Designation)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DeclarationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CastExpression"/>.
//    /// </summary>
//    partial class CastExpressionServiceProvider : IEqualityCondition<CastExpressionSyntax, CastExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CastExpressionSyntax, CastExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CastExpressionSyntax, CastExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CastExpressionSyntax, CastExpressionSyntax)"/> is not executed and <see cref="Equal(CastExpressionSyntax, CastExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CastExpressionSyntax original, CastExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CastExpressionSyntax, CastExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CastExpressionSyntax, CastExpressionSyntax)"/>.</param>
//        partial void EqualAfter(CastExpressionSyntax original, CastExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CastExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CastExpressionSyntax, CastExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CastExpressionSyntax original, CastExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CastExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CastExpressionSyntax original, CastExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="RefExpression"/>.
//    /// </summary>
//    partial class RefExpressionServiceProvider : IEqualityCondition<RefExpressionSyntax, RefExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(RefExpressionSyntax, RefExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefExpressionSyntax, RefExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(RefExpressionSyntax, RefExpressionSyntax)"/> is not executed and <see cref="Equal(RefExpressionSyntax, RefExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(RefExpressionSyntax original, RefExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(RefExpressionSyntax, RefExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefExpressionSyntax, RefExpressionSyntax)"/>.</param>
//        partial void EqualAfter(RefExpressionSyntax original, RefExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="RefExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(RefExpressionSyntax, RefExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(RefExpressionSyntax original, RefExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.RefKeyword, modified.RefKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="RefExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(RefExpressionSyntax original, RefExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InitializerExpression"/>.
//    /// </summary>
//    partial class InitializerExpressionServiceProvider : IEqualityCondition<InitializerExpressionSyntax, InitializerExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/> is not executed and <see cref="Equal(InitializerExpressionSyntax, InitializerExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InitializerExpressionSyntax original, InitializerExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</param>
//        partial void EqualAfter(InitializerExpressionSyntax original, InitializerExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InitializerExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expressions, modified.Expressions)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InitializerExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ObjectCreationExpression"/>.
//    /// </summary>
//    partial class ObjectCreationExpressionServiceProvider : IEqualityCondition<ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/> is not executed and <see cref="Equal(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ObjectCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NewKeyword, modified.NewKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.ArgumentList == null && modified.ArgumentList == null) || (original.ArgumentList != null && modified.ArgumentList != null && this.LanguageServiceProvider.Equal(original.ArgumentList, modified.ArgumentList))) &&
//                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ObjectCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AnonymousObjectCreationExpression"/>.
//    /// </summary>
//    partial class AnonymousObjectCreationExpressionServiceProvider : IEqualityCondition<AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/> is not executed and <see cref="Equal(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousObjectCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NewKeyword, modified.NewKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Initializers, modified.Initializers)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AnonymousObjectCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ArrayCreationExpression"/>.
//    /// </summary>
//    partial class ArrayCreationExpressionServiceProvider : IEqualityCondition<ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/> is not executed and <see cref="Equal(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NewKeyword, modified.NewKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                ((original.Initializer == null && modified.Initializer == null) || (original.Initializer != null && modified.Initializer != null && this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ImplicitArrayCreationExpression"/>.
//    /// </summary>
//    partial class ImplicitArrayCreationExpressionServiceProvider : IEqualityCondition<ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/> is not executed and <see cref="Equal(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ImplicitArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.NewKeyword, modified.NewKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Commas, modified.Commas)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Initializer, modified.Initializer)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ImplicitArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="StackAllocArrayCreationExpression"/>.
//    /// </summary>
//    partial class StackAllocArrayCreationExpressionServiceProvider : IEqualityCondition<StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/> is not executed and <see cref="Equal(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</param>
//        partial void EqualAfter(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="StackAllocArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.StackAllocKeyword, modified.StackAllocKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="StackAllocArrayCreationExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="QueryExpression"/>.
//    /// </summary>
//    partial class QueryExpressionServiceProvider : IEqualityCondition<QueryExpressionSyntax, QueryExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/> is not executed and <see cref="Equal(QueryExpressionSyntax, QueryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
//        partial void EqualAfter(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(QueryExpressionSyntax original, QueryExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.FromClause, modified.FromClause)) &&
//                (this.LanguageServiceProvider.Equal(original.Body, modified.Body)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(QueryExpressionSyntax original, QueryExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="OmittedArraySizeExpression"/>.
//    /// </summary>
//    partial class OmittedArraySizeExpressionServiceProvider : IEqualityCondition<OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/> is not executed and <see cref="Equal(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</param>
//        partial void EqualAfter(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OmittedArraySizeExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.OmittedArraySizeExpressionToken, modified.OmittedArraySizeExpressionToken))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OmittedArraySizeExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InterpolatedStringExpression"/>.
//    /// </summary>
//    partial class InterpolatedStringExpressionServiceProvider : IEqualityCondition<InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/> is not executed and <see cref="Equal(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</param>
//        partial void EqualAfter(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterpolatedStringExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.StringStartToken, modified.StringStartToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Contents, modified.Contents)) &&
//                (this.LanguageServiceProvider.Equal(original.StringEndToken, modified.StringEndToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterpolatedStringExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IsPatternExpression"/>.
//    /// </summary>
//    partial class IsPatternExpressionServiceProvider : IEqualityCondition<IsPatternExpressionSyntax, IsPatternExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/> is not executed and <see cref="Equal(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</param>
//        partial void EqualAfter(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IsPatternExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.IsKeyword, modified.IsKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Pattern, modified.Pattern)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IsPatternExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ThrowExpression"/>.
//    /// </summary>
//    partial class ThrowExpressionServiceProvider : IEqualityCondition<ThrowExpressionSyntax, ThrowExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/> is not executed and <see cref="Equal(ThrowExpressionSyntax, ThrowExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ThrowExpressionSyntax original, ThrowExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ThrowExpressionSyntax original, ThrowExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ThrowExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ThrowKeyword, modified.ThrowKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ThrowExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PredefinedType"/>.
//    /// </summary>
//    partial class PredefinedTypeServiceProvider : IEqualityCondition<PredefinedTypeSyntax, PredefinedTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/> is not executed and <see cref="Equal(PredefinedTypeSyntax, PredefinedTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PredefinedTypeSyntax original, PredefinedTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</param>
//        partial void EqualAfter(PredefinedTypeSyntax original, PredefinedTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ArrayType"/>.
//    /// </summary>
//    partial class ArrayTypeServiceProvider : IEqualityCondition<ArrayTypeSyntax, ArrayTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/> is not executed and <see cref="Equal(ArrayTypeSyntax, ArrayTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArrayTypeSyntax original, ArrayTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArrayTypeSyntax, ArrayTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</param>
//        partial void EqualAfter(ArrayTypeSyntax original, ArrayTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArrayTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArrayTypeSyntax, ArrayTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArrayTypeSyntax original, ArrayTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ElementType, modified.ElementType)) &&
//                (this.LanguageServiceProvider.Equal(original.RankSpecifiers, modified.RankSpecifiers)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArrayTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArrayTypeSyntax original, ArrayTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="PointerType"/>.
//    /// </summary>
//    partial class PointerTypeServiceProvider : IEqualityCondition<PointerTypeSyntax, PointerTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(PointerTypeSyntax, PointerTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PointerTypeSyntax, PointerTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(PointerTypeSyntax, PointerTypeSyntax)"/> is not executed and <see cref="Equal(PointerTypeSyntax, PointerTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(PointerTypeSyntax original, PointerTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(PointerTypeSyntax, PointerTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(PointerTypeSyntax, PointerTypeSyntax)"/>.</param>
//        partial void EqualAfter(PointerTypeSyntax original, PointerTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="PointerTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(PointerTypeSyntax, PointerTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(PointerTypeSyntax original, PointerTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ElementType, modified.ElementType)) &&
//                (this.LanguageServiceProvider.Equal(original.AsteriskToken, modified.AsteriskToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="PointerTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(PointerTypeSyntax original, PointerTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="NullableType"/>.
//    /// </summary>
//    partial class NullableTypeServiceProvider : IEqualityCondition<NullableTypeSyntax, NullableTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(NullableTypeSyntax, NullableTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NullableTypeSyntax, NullableTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(NullableTypeSyntax, NullableTypeSyntax)"/> is not executed and <see cref="Equal(NullableTypeSyntax, NullableTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(NullableTypeSyntax original, NullableTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(NullableTypeSyntax, NullableTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(NullableTypeSyntax, NullableTypeSyntax)"/>.</param>
//        partial void EqualAfter(NullableTypeSyntax original, NullableTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NullableTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(NullableTypeSyntax, NullableTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(NullableTypeSyntax original, NullableTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ElementType, modified.ElementType)) &&
//                (this.LanguageServiceProvider.Equal(original.QuestionToken, modified.QuestionToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="NullableTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(NullableTypeSyntax original, NullableTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TupleType"/>.
//    /// </summary>
//    partial class TupleTypeServiceProvider : IEqualityCondition<TupleTypeSyntax, TupleTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TupleTypeSyntax, TupleTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleTypeSyntax, TupleTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TupleTypeSyntax, TupleTypeSyntax)"/> is not executed and <see cref="Equal(TupleTypeSyntax, TupleTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TupleTypeSyntax original, TupleTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TupleTypeSyntax, TupleTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TupleTypeSyntax, TupleTypeSyntax)"/>.</param>
//        partial void EqualAfter(TupleTypeSyntax original, TupleTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TupleTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TupleTypeSyntax, TupleTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TupleTypeSyntax original, TupleTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Elements, modified.Elements)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TupleTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TupleTypeSyntax original, TupleTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="OmittedTypeArgument"/>.
//    /// </summary>
//    partial class OmittedTypeArgumentServiceProvider : IEqualityCondition<OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/> is not executed and <see cref="Equal(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</param>
//        partial void EqualAfter(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OmittedTypeArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.OmittedTypeArgumentToken, modified.OmittedTypeArgumentToken))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OmittedTypeArgumentSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="RefType"/>.
//    /// </summary>
//    partial class RefTypeServiceProvider : IEqualityCondition<RefTypeSyntax, RefTypeSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(RefTypeSyntax, RefTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefTypeSyntax, RefTypeSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(RefTypeSyntax, RefTypeSyntax)"/> is not executed and <see cref="Equal(RefTypeSyntax, RefTypeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(RefTypeSyntax original, RefTypeSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(RefTypeSyntax, RefTypeSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(RefTypeSyntax, RefTypeSyntax)"/>.</param>
//        partial void EqualAfter(RefTypeSyntax original, RefTypeSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="RefTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(RefTypeSyntax, RefTypeSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(RefTypeSyntax original, RefTypeSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.RefKeyword, modified.RefKeyword)) &&
//                ((original.ReadOnlyKeyword == null && modified.ReadOnlyKeyword == null) || (original.ReadOnlyKeyword != null && modified.ReadOnlyKeyword != null && this.LanguageServiceProvider.Equal(original.ReadOnlyKeyword, modified.ReadOnlyKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="RefTypeSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(RefTypeSyntax original, RefTypeSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="QualifiedName"/>.
//    /// </summary>
//    partial class QualifiedNameServiceProvider : IEqualityCondition<QualifiedNameSyntax, QualifiedNameSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/> is not executed and <see cref="Equal(QualifiedNameSyntax, QualifiedNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(QualifiedNameSyntax original, QualifiedNameSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(QualifiedNameSyntax, QualifiedNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</param>
//        partial void EqualAfter(QualifiedNameSyntax original, QualifiedNameSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="QualifiedNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(QualifiedNameSyntax, QualifiedNameSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(QualifiedNameSyntax original, QualifiedNameSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Left, modified.Left)) &&
//                (this.LanguageServiceProvider.Equal(original.DotToken, modified.DotToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Right, modified.Right)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="QualifiedNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(QualifiedNameSyntax original, QualifiedNameSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AliasQualifiedName"/>.
//    /// </summary>
//    partial class AliasQualifiedNameServiceProvider : IEqualityCondition<AliasQualifiedNameSyntax, AliasQualifiedNameSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> is not executed and <see cref="Equal(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
//        partial void EqualAfter(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Alias, modified.Alias)) &&
//                ((original.ColonColonToken == null && modified.ColonColonToken == null) || (original.ColonColonToken != null && modified.ColonColonToken != null && this.LanguageServiceProvider.Equal(original.ColonColonToken, modified.ColonColonToken))) &&
//                (this.LanguageServiceProvider.Equal(original.Name, modified.Name)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IdentifierName"/>.
//    /// </summary>
//    partial class IdentifierNameServiceProvider : IEqualityCondition<IdentifierNameSyntax, IdentifierNameSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/> is not executed and <see cref="Equal(IdentifierNameSyntax, IdentifierNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
//        partial void EqualAfter(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IdentifierNameSyntax original, IdentifierNameSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IdentifierNameSyntax original, IdentifierNameSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="GenericName"/>.
//    /// </summary>
//    partial class GenericNameServiceProvider : IEqualityCondition<GenericNameSyntax, GenericNameSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GenericNameSyntax, GenericNameSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(GenericNameSyntax, GenericNameSyntax)"/> is not executed and <see cref="Equal(GenericNameSyntax, GenericNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(GenericNameSyntax original, GenericNameSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GenericNameSyntax, GenericNameSyntax)"/>.</param>
//        partial void EqualAfter(GenericNameSyntax original, GenericNameSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="GenericNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(GenericNameSyntax, GenericNameSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(GenericNameSyntax original, GenericNameSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.TypeArgumentList, modified.TypeArgumentList)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="GenericNameSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(GenericNameSyntax original, GenericNameSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ThisExpression"/>.
//    /// </summary>
//    partial class ThisExpressionServiceProvider : IEqualityCondition<ThisExpressionSyntax, ThisExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/> is not executed and <see cref="Equal(ThisExpressionSyntax, ThisExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ThisExpressionSyntax original, ThisExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ThisExpressionSyntax, ThisExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ThisExpressionSyntax original, ThisExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ThisExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ThisExpressionSyntax, ThisExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ThisExpressionSyntax original, ThisExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Token, modified.Token))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ThisExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ThisExpressionSyntax original, ThisExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BaseExpression"/>.
//    /// </summary>
//    partial class BaseExpressionServiceProvider : IEqualityCondition<BaseExpressionSyntax, BaseExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/> is not executed and <see cref="Equal(BaseExpressionSyntax, BaseExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BaseExpressionSyntax original, BaseExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BaseExpressionSyntax, BaseExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</param>
//        partial void EqualAfter(BaseExpressionSyntax original, BaseExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BaseExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BaseExpressionSyntax, BaseExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BaseExpressionSyntax original, BaseExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Token, modified.Token))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BaseExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BaseExpressionSyntax original, BaseExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="AnonymousMethodExpression"/>.
//    /// </summary>
//    partial class AnonymousMethodExpressionServiceProvider : IEqualityCondition<AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> is not executed and <see cref="Equal(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        partial void EqualAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.Equal(original.AsyncKeyword, modified.AsyncKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.DelegateKeyword, modified.DelegateKeyword)) &&
//                ((original.ParameterList == null && modified.ParameterList == null) || (original.ParameterList != null && modified.ParameterList != null && this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList))) &&
//                (this.LanguageServiceProvider.Equal(original.Body, modified.Body)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SimpleLambdaExpression"/>.
//    /// </summary>
//    partial class SimpleLambdaExpressionServiceProvider : IEqualityCondition<SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> is not executed and <see cref="Equal(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
//        partial void EqualAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.Equal(original.AsyncKeyword, modified.AsyncKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.Parameter, modified.Parameter)) &&
//                (this.LanguageServiceProvider.Equal(original.ArrowToken, modified.ArrowToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Body, modified.Body)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ParenthesizedLambdaExpression"/>.
//    /// </summary>
//    partial class ParenthesizedLambdaExpressionServiceProvider : IEqualityCondition<ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> is not executed and <see cref="Equal(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        partial void EqualAfter(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.AsyncKeyword == null && modified.AsyncKeyword == null) || (original.AsyncKeyword != null && modified.AsyncKeyword != null && this.LanguageServiceProvider.Equal(original.AsyncKeyword, modified.AsyncKeyword))) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                (this.LanguageServiceProvider.Equal(original.ArrowToken, modified.ArrowToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Body, modified.Body)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ArgumentList"/>.
//    /// </summary>
//    partial class ArgumentListServiceProvider : IEqualityCondition<ArgumentListSyntax, ArgumentListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ArgumentListSyntax, ArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArgumentListSyntax, ArgumentListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ArgumentListSyntax, ArgumentListSyntax)"/> is not executed and <see cref="Equal(ArgumentListSyntax, ArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ArgumentListSyntax original, ArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ArgumentListSyntax, ArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ArgumentListSyntax, ArgumentListSyntax)"/>.</param>
//        partial void EqualAfter(ArgumentListSyntax original, ArgumentListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ArgumentListSyntax, ArgumentListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ArgumentListSyntax original, ArgumentListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Arguments, modified.Arguments)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ArgumentListSyntax original, ArgumentListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BracketedArgumentList"/>.
//    /// </summary>
//    partial class BracketedArgumentListServiceProvider : IEqualityCondition<BracketedArgumentListSyntax, BracketedArgumentListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/> is not executed and <see cref="Equal(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</param>
//        partial void EqualAfter(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BracketedArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBracketToken, modified.OpenBracketToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Arguments, modified.Arguments)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBracketToken, modified.CloseBracketToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BracketedArgumentListSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="FromClause"/>.
//    /// </summary>
//    partial class FromClauseServiceProvider : IEqualityCondition<FromClauseSyntax, FromClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FromClauseSyntax, FromClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(FromClauseSyntax, FromClauseSyntax)"/> is not executed and <see cref="Equal(FromClauseSyntax, FromClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(FromClauseSyntax original, FromClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FromClauseSyntax, FromClauseSyntax)"/>.</param>
//        partial void EqualAfter(FromClauseSyntax original, FromClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="FromClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(FromClauseSyntax, FromClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(FromClauseSyntax original, FromClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.FromKeyword, modified.FromKeyword)) &&
//                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.Equal(original.Type, modified.Type))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.InKeyword, modified.InKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="FromClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(FromClauseSyntax original, FromClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LetClause"/>.
//    /// </summary>
//    partial class LetClauseServiceProvider : IEqualityCondition<LetClauseSyntax, LetClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LetClauseSyntax, LetClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LetClauseSyntax, LetClauseSyntax)"/> is not executed and <see cref="Equal(LetClauseSyntax, LetClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LetClauseSyntax original, LetClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LetClauseSyntax, LetClauseSyntax)"/>.</param>
//        partial void EqualAfter(LetClauseSyntax original, LetClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LetClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LetClauseSyntax, LetClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LetClauseSyntax original, LetClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LetKeyword, modified.LetKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsToken, modified.EqualsToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LetClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LetClauseSyntax original, LetClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="JoinClause"/>.
//    /// </summary>
//    partial class JoinClauseServiceProvider : IEqualityCondition<JoinClauseSyntax, JoinClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(JoinClauseSyntax, JoinClauseSyntax)"/> is not executed and <see cref="Equal(JoinClauseSyntax, JoinClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
//        partial void EqualAfter(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="JoinClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(JoinClauseSyntax, JoinClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(JoinClauseSyntax original, JoinClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.JoinKeyword, modified.JoinKeyword)) &&
//                ((original.Type == null && modified.Type == null) || (original.Type != null && modified.Type != null && this.LanguageServiceProvider.Equal(original.Type, modified.Type))) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.InKeyword, modified.InKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.InExpression, modified.InExpression)) &&
//                (this.LanguageServiceProvider.Equal(original.OnKeyword, modified.OnKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.LeftExpression, modified.LeftExpression)) &&
//                (this.LanguageServiceProvider.Equal(original.EqualsKeyword, modified.EqualsKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.RightExpression, modified.RightExpression)) &&
//                ((original.Into == null && modified.Into == null) || (original.Into != null && modified.Into != null && this.LanguageServiceProvider.Equal(original.Into, modified.Into))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="JoinClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(JoinClauseSyntax original, JoinClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="WhereClause"/>.
//    /// </summary>
//    partial class WhereClauseServiceProvider : IEqualityCondition<WhereClauseSyntax, WhereClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(WhereClauseSyntax, WhereClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhereClauseSyntax, WhereClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(WhereClauseSyntax, WhereClauseSyntax)"/> is not executed and <see cref="Equal(WhereClauseSyntax, WhereClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(WhereClauseSyntax original, WhereClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(WhereClauseSyntax, WhereClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhereClauseSyntax, WhereClauseSyntax)"/>.</param>
//        partial void EqualAfter(WhereClauseSyntax original, WhereClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="WhereClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(WhereClauseSyntax, WhereClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(WhereClauseSyntax original, WhereClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.WhereKeyword, modified.WhereKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="WhereClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(WhereClauseSyntax original, WhereClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="OrderByClause"/>.
//    /// </summary>
//    partial class OrderByClauseServiceProvider : IEqualityCondition<OrderByClauseSyntax, OrderByClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/> is not executed and <see cref="Equal(OrderByClauseSyntax, OrderByClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(OrderByClauseSyntax original, OrderByClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(OrderByClauseSyntax, OrderByClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</param>
//        partial void EqualAfter(OrderByClauseSyntax original, OrderByClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OrderByClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(OrderByClauseSyntax, OrderByClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(OrderByClauseSyntax original, OrderByClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OrderByKeyword, modified.OrderByKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Orderings, modified.Orderings)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="OrderByClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(OrderByClauseSyntax original, OrderByClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SelectClause"/>.
//    /// </summary>
//    partial class SelectClauseServiceProvider : IEqualityCondition<SelectClauseSyntax, SelectClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SelectClauseSyntax, SelectClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SelectClauseSyntax, SelectClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SelectClauseSyntax, SelectClauseSyntax)"/> is not executed and <see cref="Equal(SelectClauseSyntax, SelectClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SelectClauseSyntax original, SelectClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SelectClauseSyntax, SelectClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SelectClauseSyntax, SelectClauseSyntax)"/>.</param>
//        partial void EqualAfter(SelectClauseSyntax original, SelectClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SelectClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SelectClauseSyntax, SelectClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SelectClauseSyntax original, SelectClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.SelectKeyword, modified.SelectKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SelectClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SelectClauseSyntax original, SelectClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="GroupClause"/>.
//    /// </summary>
//    partial class GroupClauseServiceProvider : IEqualityCondition<GroupClauseSyntax, GroupClauseSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(GroupClauseSyntax, GroupClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GroupClauseSyntax, GroupClauseSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(GroupClauseSyntax, GroupClauseSyntax)"/> is not executed and <see cref="Equal(GroupClauseSyntax, GroupClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(GroupClauseSyntax original, GroupClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(GroupClauseSyntax, GroupClauseSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GroupClauseSyntax, GroupClauseSyntax)"/>.</param>
//        partial void EqualAfter(GroupClauseSyntax original, GroupClauseSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="GroupClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(GroupClauseSyntax, GroupClauseSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(GroupClauseSyntax original, GroupClauseSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.GroupKeyword, modified.GroupKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.GroupExpression, modified.GroupExpression)) &&
//                (this.LanguageServiceProvider.Equal(original.ByKeyword, modified.ByKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ByExpression, modified.ByExpression)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="GroupClauseSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(GroupClauseSyntax original, GroupClauseSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DeclarationPattern"/>.
//    /// </summary>
//    partial class DeclarationPatternServiceProvider : IEqualityCondition<DeclarationPatternSyntax, DeclarationPatternSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/> is not executed and <see cref="Equal(DeclarationPatternSyntax, DeclarationPatternSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DeclarationPatternSyntax original, DeclarationPatternSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</param>
//        partial void EqualAfter(DeclarationPatternSyntax original, DeclarationPatternSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DeclarationPatternSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.Designation, modified.Designation)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DeclarationPatternSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ConstantPattern"/>.
//    /// </summary>
//    partial class ConstantPatternServiceProvider : IEqualityCondition<ConstantPatternSyntax, ConstantPatternSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/> is not executed and <see cref="Equal(ConstantPatternSyntax, ConstantPatternSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ConstantPatternSyntax original, ConstantPatternSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ConstantPatternSyntax, ConstantPatternSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</param>
//        partial void EqualAfter(ConstantPatternSyntax original, ConstantPatternSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstantPatternSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ConstantPatternSyntax, ConstantPatternSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ConstantPatternSyntax original, ConstantPatternSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ConstantPatternSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ConstantPatternSyntax original, ConstantPatternSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="InterpolatedStringText"/>.
//    /// </summary>
//    partial class InterpolatedStringTextServiceProvider : IEqualityCondition<InterpolatedStringTextSyntax, InterpolatedStringTextSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/> is not executed and <see cref="Equal(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</param>
//        partial void EqualAfter(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterpolatedStringTextSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.TextToken, modified.TextToken))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterpolatedStringTextSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Interpolation"/>.
//    /// </summary>
//    partial class InterpolationServiceProvider : IEqualityCondition<InterpolationSyntax, InterpolationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(InterpolationSyntax, InterpolationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationSyntax, InterpolationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(InterpolationSyntax, InterpolationSyntax)"/> is not executed and <see cref="Equal(InterpolationSyntax, InterpolationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(InterpolationSyntax original, InterpolationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(InterpolationSyntax, InterpolationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(InterpolationSyntax, InterpolationSyntax)"/>.</param>
//        partial void EqualAfter(InterpolationSyntax original, InterpolationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterpolationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(InterpolationSyntax, InterpolationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(InterpolationSyntax original, InterpolationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                ((original.AlignmentClause == null && modified.AlignmentClause == null) || (original.AlignmentClause != null && modified.AlignmentClause != null && this.LanguageServiceProvider.Equal(original.AlignmentClause, modified.AlignmentClause))) &&
//                ((original.FormatClause == null && modified.FormatClause == null) || (original.FormatClause != null && modified.FormatClause != null && this.LanguageServiceProvider.Equal(original.FormatClause, modified.FormatClause))) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="InterpolationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(InterpolationSyntax original, InterpolationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="Block"/>.
//    /// </summary>
//    partial class BlockServiceProvider : IEqualityCondition<BlockSyntax, BlockSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BlockSyntax, BlockSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BlockSyntax, BlockSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BlockSyntax, BlockSyntax)"/> is not executed and <see cref="Equal(BlockSyntax, BlockSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BlockSyntax original, BlockSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BlockSyntax, BlockSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BlockSyntax, BlockSyntax)"/>.</param>
//        partial void EqualAfter(BlockSyntax original, BlockSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BlockSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BlockSyntax, BlockSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BlockSyntax original, BlockSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statements, modified.Statements)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BlockSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BlockSyntax original, BlockSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LocalFunctionStatement"/>.
//    /// </summary>
//    partial class LocalFunctionStatementServiceProvider : IEqualityCondition<LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> is not executed and <see cref="Equal(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        partial void EqualAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.ReturnType, modified.ReturnType)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.Equal(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.Equal(original.ParameterList, modified.ParameterList)) &&
//                (this.LanguageServiceProvider.Equal(original.ConstraintClauses, modified.ConstraintClauses)) &&
//                ((original.Body == null && modified.Body == null) || (original.Body != null && modified.Body != null && this.LanguageServiceProvider.Equal(original.Body, modified.Body))) &&
//                ((original.ExpressionBody == null && modified.ExpressionBody == null) || (original.ExpressionBody != null && modified.ExpressionBody != null && this.LanguageServiceProvider.Equal(original.ExpressionBody, modified.ExpressionBody))) &&
//                ((original.SemicolonToken == null && modified.SemicolonToken == null) || (original.SemicolonToken != null && modified.SemicolonToken != null && this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LocalDeclarationStatement"/>.
//    /// </summary>
//    partial class LocalDeclarationStatementServiceProvider : IEqualityCondition<LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> is not executed and <see cref="Equal(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
//        partial void EqualAfter(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Modifiers, modified.Modifiers)) &&
//                (this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ExpressionStatement"/>.
//    /// </summary>
//    partial class ExpressionStatementServiceProvider : IEqualityCondition<ExpressionStatementSyntax, ExpressionStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/> is not executed and <see cref="Equal(ExpressionStatementSyntax, ExpressionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ExpressionStatementSyntax original, ExpressionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</param>
//        partial void EqualAfter(ExpressionStatementSyntax original, ExpressionStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ExpressionStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ExpressionStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="EmptyStatement"/>.
//    /// </summary>
//    partial class EmptyStatementServiceProvider : IEqualityCondition<EmptyStatementSyntax, EmptyStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/> is not executed and <see cref="Equal(EmptyStatementSyntax, EmptyStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(EmptyStatementSyntax original, EmptyStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(EmptyStatementSyntax, EmptyStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</param>
//        partial void EqualAfter(EmptyStatementSyntax original, EmptyStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EmptyStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(EmptyStatementSyntax, EmptyStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(EmptyStatementSyntax original, EmptyStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="EmptyStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(EmptyStatementSyntax original, EmptyStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LabeledStatement"/>.
//    /// </summary>
//    partial class LabeledStatementServiceProvider : IEqualityCondition<LabeledStatementSyntax, LabeledStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/> is not executed and <see cref="Equal(LabeledStatementSyntax, LabeledStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
//        partial void EqualAfter(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LabeledStatementSyntax original, LabeledStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LabeledStatementSyntax original, LabeledStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="GotoStatement"/>.
//    /// </summary>
//    partial class GotoStatementServiceProvider : IEqualityCondition<GotoStatementSyntax, GotoStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(GotoStatementSyntax, GotoStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GotoStatementSyntax, GotoStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(GotoStatementSyntax, GotoStatementSyntax)"/> is not executed and <see cref="Equal(GotoStatementSyntax, GotoStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(GotoStatementSyntax original, GotoStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(GotoStatementSyntax, GotoStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(GotoStatementSyntax, GotoStatementSyntax)"/>.</param>
//        partial void EqualAfter(GotoStatementSyntax original, GotoStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="GotoStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(GotoStatementSyntax, GotoStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(GotoStatementSyntax original, GotoStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.GotoKeyword, modified.GotoKeyword)) &&
//                ((original.CaseOrDefaultKeyword == null && modified.CaseOrDefaultKeyword == null) || (original.CaseOrDefaultKeyword != null && modified.CaseOrDefaultKeyword != null && this.LanguageServiceProvider.Equal(original.CaseOrDefaultKeyword, modified.CaseOrDefaultKeyword))) &&
//                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="GotoStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(GotoStatementSyntax original, GotoStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="BreakStatement"/>.
//    /// </summary>
//    partial class BreakStatementServiceProvider : IEqualityCondition<BreakStatementSyntax, BreakStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(BreakStatementSyntax, BreakStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BreakStatementSyntax, BreakStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(BreakStatementSyntax, BreakStatementSyntax)"/> is not executed and <see cref="Equal(BreakStatementSyntax, BreakStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(BreakStatementSyntax original, BreakStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(BreakStatementSyntax, BreakStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(BreakStatementSyntax, BreakStatementSyntax)"/>.</param>
//        partial void EqualAfter(BreakStatementSyntax original, BreakStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BreakStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(BreakStatementSyntax, BreakStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(BreakStatementSyntax original, BreakStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.BreakKeyword, modified.BreakKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="BreakStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(BreakStatementSyntax original, BreakStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ContinueStatement"/>.
//    /// </summary>
//    partial class ContinueStatementServiceProvider : IEqualityCondition<ContinueStatementSyntax, ContinueStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/> is not executed and <see cref="Equal(ContinueStatementSyntax, ContinueStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ContinueStatementSyntax original, ContinueStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ContinueStatementSyntax, ContinueStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</param>
//        partial void EqualAfter(ContinueStatementSyntax original, ContinueStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ContinueStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ContinueStatementSyntax, ContinueStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ContinueStatementSyntax original, ContinueStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ContinueKeyword, modified.ContinueKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ContinueStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ContinueStatementSyntax original, ContinueStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ReturnStatement"/>.
//    /// </summary>
//    partial class ReturnStatementServiceProvider : IEqualityCondition<ReturnStatementSyntax, ReturnStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/> is not executed and <see cref="Equal(ReturnStatementSyntax, ReturnStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ReturnStatementSyntax original, ReturnStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ReturnStatementSyntax, ReturnStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</param>
//        partial void EqualAfter(ReturnStatementSyntax original, ReturnStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ReturnStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ReturnStatementSyntax, ReturnStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ReturnStatementSyntax original, ReturnStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ReturnKeyword, modified.ReturnKeyword)) &&
//                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ReturnStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ReturnStatementSyntax original, ReturnStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ThrowStatement"/>.
//    /// </summary>
//    partial class ThrowStatementServiceProvider : IEqualityCondition<ThrowStatementSyntax, ThrowStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/> is not executed and <see cref="Equal(ThrowStatementSyntax, ThrowStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ThrowStatementSyntax original, ThrowStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ThrowStatementSyntax, ThrowStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</param>
//        partial void EqualAfter(ThrowStatementSyntax original, ThrowStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ThrowStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ThrowStatementSyntax, ThrowStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ThrowStatementSyntax original, ThrowStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ThrowKeyword, modified.ThrowKeyword)) &&
//                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ThrowStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ThrowStatementSyntax original, ThrowStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="YieldStatement"/>.
//    /// </summary>
//    partial class YieldStatementServiceProvider : IEqualityCondition<YieldStatementSyntax, YieldStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(YieldStatementSyntax, YieldStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(YieldStatementSyntax, YieldStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(YieldStatementSyntax, YieldStatementSyntax)"/> is not executed and <see cref="Equal(YieldStatementSyntax, YieldStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(YieldStatementSyntax original, YieldStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(YieldStatementSyntax, YieldStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(YieldStatementSyntax, YieldStatementSyntax)"/>.</param>
//        partial void EqualAfter(YieldStatementSyntax original, YieldStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="YieldStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(YieldStatementSyntax, YieldStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(YieldStatementSyntax original, YieldStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.YieldKeyword, modified.YieldKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ReturnOrBreakKeyword, modified.ReturnOrBreakKeyword)) &&
//                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="YieldStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(YieldStatementSyntax original, YieldStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="WhileStatement"/>.
//    /// </summary>
//    partial class WhileStatementServiceProvider : IEqualityCondition<WhileStatementSyntax, WhileStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(WhileStatementSyntax, WhileStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhileStatementSyntax, WhileStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(WhileStatementSyntax, WhileStatementSyntax)"/> is not executed and <see cref="Equal(WhileStatementSyntax, WhileStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(WhileStatementSyntax original, WhileStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(WhileStatementSyntax, WhileStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(WhileStatementSyntax, WhileStatementSyntax)"/>.</param>
//        partial void EqualAfter(WhileStatementSyntax original, WhileStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="WhileStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(WhileStatementSyntax, WhileStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(WhileStatementSyntax original, WhileStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.WhileKeyword, modified.WhileKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="WhileStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(WhileStatementSyntax original, WhileStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DoStatement"/>.
//    /// </summary>
//    partial class DoStatementServiceProvider : IEqualityCondition<DoStatementSyntax, DoStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DoStatementSyntax, DoStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DoStatementSyntax, DoStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DoStatementSyntax, DoStatementSyntax)"/> is not executed and <see cref="Equal(DoStatementSyntax, DoStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DoStatementSyntax original, DoStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DoStatementSyntax, DoStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DoStatementSyntax, DoStatementSyntax)"/>.</param>
//        partial void EqualAfter(DoStatementSyntax original, DoStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DoStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DoStatementSyntax, DoStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DoStatementSyntax original, DoStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.DoKeyword, modified.DoKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)) &&
//                (this.LanguageServiceProvider.Equal(original.WhileKeyword, modified.WhileKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.SemicolonToken, modified.SemicolonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DoStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DoStatementSyntax original, DoStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ForStatement"/>.
//    /// </summary>
//    partial class ForStatementServiceProvider : IEqualityCondition<ForStatementSyntax, ForStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForStatementSyntax, ForStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ForStatementSyntax, ForStatementSyntax)"/> is not executed and <see cref="Equal(ForStatementSyntax, ForStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ForStatementSyntax original, ForStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForStatementSyntax, ForStatementSyntax)"/>.</param>
//        partial void EqualAfter(ForStatementSyntax original, ForStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ForStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ForStatementSyntax, ForStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ForStatementSyntax original, ForStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ForKeyword, modified.ForKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration))) &&
//                (this.LanguageServiceProvider.Equal(original.Initializers, modified.Initializers)) &&
//                (this.LanguageServiceProvider.Equal(original.FirstSemicolonToken, modified.FirstSemicolonToken)) &&
//                ((original.Condition == null && modified.Condition == null) || (original.Condition != null && modified.Condition != null && this.LanguageServiceProvider.Equal(original.Condition, modified.Condition))) &&
//                (this.LanguageServiceProvider.Equal(original.SecondSemicolonToken, modified.SecondSemicolonToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Incrementors, modified.Incrementors)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ForStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ForStatementSyntax original, ForStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="UsingStatement"/>.
//    /// </summary>
//    partial class UsingStatementServiceProvider : IEqualityCondition<UsingStatementSyntax, UsingStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(UsingStatementSyntax, UsingStatementSyntax)"/> is not executed and <see cref="Equal(UsingStatementSyntax, UsingStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
//        partial void EqualAfter(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="UsingStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(UsingStatementSyntax, UsingStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(UsingStatementSyntax original, UsingStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.UsingKeyword, modified.UsingKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                ((original.Declaration == null && modified.Declaration == null) || (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration))) &&
//                ((original.Expression == null && modified.Expression == null) || (original.Expression != null && modified.Expression != null && this.LanguageServiceProvider.Equal(original.Expression, modified.Expression))) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="UsingStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(UsingStatementSyntax original, UsingStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="FixedStatement"/>.
//    /// </summary>
//    partial class FixedStatementServiceProvider : IEqualityCondition<FixedStatementSyntax, FixedStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(FixedStatementSyntax, FixedStatementSyntax)"/> is not executed and <see cref="Equal(FixedStatementSyntax, FixedStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
//        partial void EqualAfter(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="FixedStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(FixedStatementSyntax, FixedStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(FixedStatementSyntax original, FixedStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.FixedKeyword, modified.FixedKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Declaration, modified.Declaration)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="FixedStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(FixedStatementSyntax original, FixedStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CheckedStatement"/>.
//    /// </summary>
//    partial class CheckedStatementServiceProvider : IEqualityCondition<CheckedStatementSyntax, CheckedStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/> is not executed and <see cref="Equal(CheckedStatementSyntax, CheckedStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CheckedStatementSyntax original, CheckedStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CheckedStatementSyntax, CheckedStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</param>
//        partial void EqualAfter(CheckedStatementSyntax original, CheckedStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CheckedStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CheckedStatementSyntax, CheckedStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CheckedStatementSyntax original, CheckedStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Block, modified.Block)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CheckedStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CheckedStatementSyntax original, CheckedStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="UnsafeStatement"/>.
//    /// </summary>
//    partial class UnsafeStatementServiceProvider : IEqualityCondition<UnsafeStatementSyntax, UnsafeStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/> is not executed and <see cref="Equal(UnsafeStatementSyntax, UnsafeStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(UnsafeStatementSyntax original, UnsafeStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</param>
//        partial void EqualAfter(UnsafeStatementSyntax original, UnsafeStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="UnsafeStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.UnsafeKeyword, modified.UnsafeKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Block, modified.Block)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="UnsafeStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="LockStatement"/>.
//    /// </summary>
//    partial class LockStatementServiceProvider : IEqualityCondition<LockStatementSyntax, LockStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(LockStatementSyntax, LockStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LockStatementSyntax, LockStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(LockStatementSyntax, LockStatementSyntax)"/> is not executed and <see cref="Equal(LockStatementSyntax, LockStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(LockStatementSyntax original, LockStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(LockStatementSyntax, LockStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(LockStatementSyntax, LockStatementSyntax)"/>.</param>
//        partial void EqualAfter(LockStatementSyntax original, LockStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LockStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(LockStatementSyntax, LockStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(LockStatementSyntax original, LockStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.LockKeyword, modified.LockKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="LockStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(LockStatementSyntax original, LockStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="IfStatement"/>.
//    /// </summary>
//    partial class IfStatementServiceProvider : IEqualityCondition<IfStatementSyntax, IfStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(IfStatementSyntax, IfStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IfStatementSyntax, IfStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(IfStatementSyntax, IfStatementSyntax)"/> is not executed and <see cref="Equal(IfStatementSyntax, IfStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(IfStatementSyntax original, IfStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(IfStatementSyntax, IfStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(IfStatementSyntax, IfStatementSyntax)"/>.</param>
//        partial void EqualAfter(IfStatementSyntax original, IfStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IfStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(IfStatementSyntax, IfStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(IfStatementSyntax original, IfStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.IfKeyword, modified.IfKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Condition, modified.Condition)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)) &&
//                ((original.Else == null && modified.Else == null) || (original.Else != null && modified.Else != null && this.LanguageServiceProvider.Equal(original.Else, modified.Else))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="IfStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(IfStatementSyntax original, IfStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SwitchStatement"/>.
//    /// </summary>
//    partial class SwitchStatementServiceProvider : IEqualityCondition<SwitchStatementSyntax, SwitchStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/> is not executed and <see cref="Equal(SwitchStatementSyntax, SwitchStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SwitchStatementSyntax original, SwitchStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SwitchStatementSyntax, SwitchStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</param>
//        partial void EqualAfter(SwitchStatementSyntax original, SwitchStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SwitchStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SwitchStatementSyntax, SwitchStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SwitchStatementSyntax original, SwitchStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.SwitchKeyword, modified.SwitchKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenBraceToken, modified.OpenBraceToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Sections, modified.Sections)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseBraceToken, modified.CloseBraceToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SwitchStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SwitchStatementSyntax original, SwitchStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="TryStatement"/>.
//    /// </summary>
//    partial class TryStatementServiceProvider : IEqualityCondition<TryStatementSyntax, TryStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(TryStatementSyntax, TryStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TryStatementSyntax, TryStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(TryStatementSyntax, TryStatementSyntax)"/> is not executed and <see cref="Equal(TryStatementSyntax, TryStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(TryStatementSyntax original, TryStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(TryStatementSyntax, TryStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(TryStatementSyntax, TryStatementSyntax)"/>.</param>
//        partial void EqualAfter(TryStatementSyntax original, TryStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TryStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(TryStatementSyntax, TryStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(TryStatementSyntax original, TryStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.TryKeyword, modified.TryKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Block, modified.Block)) &&
//                (this.LanguageServiceProvider.Equal(original.Catches, modified.Catches)) &&
//                ((original.Finally == null && modified.Finally == null) || (original.Finally != null && modified.Finally != null && this.LanguageServiceProvider.Equal(original.Finally, modified.Finally))))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="TryStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(TryStatementSyntax original, TryStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ForEachStatement"/>.
//    /// </summary>
//    partial class ForEachStatementServiceProvider : IEqualityCondition<ForEachStatementSyntax, ForEachStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/> is not executed and <see cref="Equal(ForEachStatementSyntax, ForEachStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
//        partial void EqualAfter(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ForEachStatementSyntax original, ForEachStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ForEachKeyword, modified.ForEachKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Type, modified.Type)) &&
//                (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier)) &&
//                (this.LanguageServiceProvider.Equal(original.InKeyword, modified.InKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ForEachStatementSyntax original, ForEachStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ForEachVariableStatement"/>.
//    /// </summary>
//    partial class ForEachVariableStatementServiceProvider : IEqualityCondition<ForEachVariableStatementSyntax, ForEachVariableStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> is not executed and <see cref="Equal(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</param>
//        partial void EqualAfter(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ForEachVariableStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.ForEachKeyword, modified.ForEachKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Variable, modified.Variable)) &&
//                (this.LanguageServiceProvider.Equal(original.InKeyword, modified.InKeyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Expression, modified.Expression)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Statement, modified.Statement)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ForEachVariableStatementSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="SingleVariableDesignation"/>.
//    /// </summary>
//    partial class SingleVariableDesignationServiceProvider : IEqualityCondition<SingleVariableDesignationSyntax, SingleVariableDesignationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> is not executed and <see cref="Equal(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
//        partial void EqualAfter(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.Identifier, modified.Identifier))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DiscardDesignation"/>.
//    /// </summary>
//    partial class DiscardDesignationServiceProvider : IEqualityCondition<DiscardDesignationSyntax, DiscardDesignationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/> is not executed and <see cref="Equal(DiscardDesignationSyntax, DiscardDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DiscardDesignationSyntax original, DiscardDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</param>
//        partial void EqualAfter(DiscardDesignationSyntax original, DiscardDesignationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DiscardDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.Equal(original.UnderscoreToken, modified.UnderscoreToken))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DiscardDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="ParenthesizedVariableDesignation"/>.
//    /// </summary>
//    partial class ParenthesizedVariableDesignationServiceProvider : IEqualityCondition<ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/> is not executed and <see cref="Equal(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</param>
//        partial void EqualAfter(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedVariableDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.OpenParenToken, modified.OpenParenToken)) &&
//                (this.LanguageServiceProvider.Equal(original.Variables, modified.Variables)) &&
//                (this.LanguageServiceProvider.Equal(original.CloseParenToken, modified.CloseParenToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="ParenthesizedVariableDesignationSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CasePatternSwitchLabel"/>.
//    /// </summary>
//    partial class CasePatternSwitchLabelServiceProvider : IEqualityCondition<CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/> is not executed and <see cref="Equal(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</param>
//        partial void EqualAfter(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CasePatternSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Pattern, modified.Pattern)) &&
//                ((original.WhenClause == null && modified.WhenClause == null) || (original.WhenClause != null && modified.WhenClause != null && this.LanguageServiceProvider.Equal(original.WhenClause, modified.WhenClause))) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CasePatternSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="CaseSwitchLabel"/>.
//    /// </summary>
//    partial class CaseSwitchLabelServiceProvider : IEqualityCondition<CaseSwitchLabelSyntax, CaseSwitchLabelSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/> is not executed and <see cref="Equal(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</param>
//        partial void EqualAfter(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CaseSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.Value, modified.Value)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="CaseSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//    /// <summary>
//    /// Provides language-aware services regarding <see cref="DefaultSwitchLabel"/>.
//    /// </summary>
//    partial class DefaultSwitchLabelServiceProvider : IEqualityCondition<DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="EqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="EqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/> is not executed and <see cref="Equal(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void EqualBefore(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="EqualCore(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="Equal(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</param>
//        partial void EqualAfter(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DefaultSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="Equal(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.</remarks>
//        protected virtual bool EqualCore(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
//    	{
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.Equal(original.Keyword, modified.Keyword)) &&
//                (this.LanguageServiceProvider.Equal(original.ColonToken, modified.ColonToken)))
//    			return true;
    
//    	    return false;
//    	}	
    
//    	/// <summary>
//        /// Determines if two <see cref="DefaultSwitchLabelSyntax"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are equal, otherwise returns false.</returns>
//        public virtual bool Equal(DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
//    	{
//        	bool result = false, ignoreCore = false;
//        	EqualBefore(original, modified, ref result, ref ignoreCore);
//        	if(ignoreCore) 
//        		return result;
        	
//        	result = this.EqualCore(original, modified);
//        	EqualAfter(original, modified, ref result);
//        	return result;
//         }
//    }
    
//}
//// Generated helper templates
//// Generated items
