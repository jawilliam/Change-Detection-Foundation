
//using Jawilliam.CDF.Approach.Flad;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Linq;

//namespace Jawilliam.CDF.CSharp.Flad
//{
//    partial class SyntaxTokenServiceProvider : ISignatureEqualityCondition<SyntaxToken, SyntaxToken>
//    {
//        /// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual(SyntaxToken original, SyntaxToken modified)
//        {
//            return this.LanguageServiceProvider.Equal(original, modified);
//        }
    
//    	/// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureExactlyEqual(SyntaxToken original, SyntaxToken modified)
//        {
//            return this.LanguageServiceProvider.Equal(original, modified);
//        }
//    }
    
//    partial class LanguageServiceProvider
//    {
//    	/// <summary>
//        /// Determines if two typed elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
//        /// <typeparam name="TModified">Type of the original version.</typeparam>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureExactlyEqual<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
//        {
//            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(INameEqualityCondition<,>), "SignatureExactlyEqual", out object result))
//                return (bool)result;
    
//            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as ISignatureEqualityCondition<TOriginal, TModified>;
//            return serviceProvider?.SignatureExactlyEqual(original, modified) ?? false;
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
//        {
//            return this.Equal(original, modified, this.SignatureExactlyEqual);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureExactlyEqual(SyntaxToken original, SyntaxToken modified)
//        {
//            return this.SyntaxTokenServiceProvider.NameExactlyEqual(original, modified);
//        }
    
//    	/// <summary>
//        /// Determines if two typed elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
//        /// <typeparam name="TModified">Type of the original version.</typeparam>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
//        {
//            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(INameEqualityCondition<,>), "TypeExactlyEqual", out object result))
//                return (bool)result;
    
//            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as ITypeEqualityCondition<TOriginal, TModified>;
//            return serviceProvider?.TypeExactlyEqual(original, modified) ?? false;
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
//        {
//            return this.Equal(original, modified, this.TypeExactlyEqual);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual(SyntaxToken original, SyntaxToken modified)
//        {
//            return this.SyntaxTokenServiceProvider.NameExactlyEqual(original, modified);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="TypeSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual(TypeSyntax original, TypeSyntax modified)
//        {
//            return this.Equal(original, modified);
//        }
        
//        /// <summary>
//        /// Determines if two <see cref="TypeSyntax"/> elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool NameExactlyEqual(TypeSyntax original, TypeSyntax modified)
//        {
//            return this.Equal(original, modified);
//        }
//    }
    
//    partial class PredefinedTypeServiceProvider : ITypeEqualityCondition<PredefinedTypeSyntax, PredefinedTypeSyntax>
//    {
//    	/// <summary>
//        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
//        {
//            return this.LanguageServiceProvider.Equal(original, modified);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="PredefinedTypeSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureExactlyEqual(PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
//        {
//            return this.LanguageServiceProvider.Equal(original, modified);
//        }
//    }
    
//    partial class TypeParameterListServiceProvider : ITypeEqualityCondition<TypeParameterListSyntax, TypeParameterListSyntax>
//    {
//    	/// <summary>
//        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool TypeExactlyEqual(TypeParameterListSyntax original, TypeParameterListSyntax modified)
//        {
//            return original.Parameters.Count() == modified.Parameters.Count();
//        }
//    }
    
//    public partial class TypeParameterListServiceProvider : ISignatureEqualityCondition<TypeParameterListSyntax, TypeParameterListSyntax>
//    {
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(TypeParameterListSyntax, TypeParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(TypeParameterListSyntax, TypeParameterListSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(TypeParameterListSyntax original, TypeParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(TypeParameterListSyntax original, TypeParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class TypeParameterServiceProvider : ISignatureEqualityCondition<TypeParameterSyntax, TypeParameterSyntax>
//    {
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(TypeParameterSyntax original, TypeParameterSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="TypeParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(TypeParameterSyntax original, TypeParameterSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ParameterServiceProvider : ISignatureEqualityCondition<ParameterSyntax, ParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ParameterSyntax, ParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ParameterSyntax original, ParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ParameterSyntax original, ParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ParameterSyntax original, ParameterSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.Type != null && modified.Type != null && this.LanguageServiceProvider.TypeExactlyEqual(original.Type, modified.Type))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ParameterSyntax original, ParameterSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ParameterSyntax, ParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ParameterSyntax original, ParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ParameterSyntax original, ParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ParameterSyntax original, ParameterSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ParameterSyntax original, ParameterSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class CrefParameterServiceProvider : ISignatureEqualityCondition<CrefParameterSyntax, CrefParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/> is not executed and <see cref="TypeExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(CrefParameterSyntax original, CrefParameterSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.Type, modified.Type))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(CrefParameterSyntax original, CrefParameterSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(CrefParameterSyntax, CrefParameterSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(CrefParameterSyntax original, CrefParameterSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(CrefParameterSyntax, CrefParameterSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(CrefParameterSyntax original, CrefParameterSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(CrefParameterSyntax original, CrefParameterSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class DelegateDeclarationServiceProvider : ISignatureEqualityCondition<DelegateDeclarationSyntax, DelegateDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList)))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ClassDeclarationServiceProvider : ISignatureEqualityCondition<ClassDeclarationSyntax, ClassDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class StructDeclarationServiceProvider : ISignatureEqualityCondition<StructDeclarationSyntax, StructDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(StructDeclarationSyntax original, StructDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class InterfaceDeclarationServiceProvider : ISignatureEqualityCondition<InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class MethodDeclarationServiceProvider : ISignatureEqualityCondition<MethodDeclarationSyntax, MethodDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList)))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class OperatorDeclarationServiceProvider : ISignatureEqualityCondition<OperatorDeclarationSyntax, OperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ConversionOperatorDeclarationServiceProvider : ISignatureEqualityCondition<ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ConstructorDeclarationServiceProvider : ISignatureEqualityCondition<ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class EventDeclarationServiceProvider : ISignatureEqualityCondition<EventDeclarationSyntax, EventDeclarationSyntax>
//    {
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(EventDeclarationSyntax original, EventDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(EventDeclarationSyntax original, EventDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class IndexerDeclarationServiceProvider : ISignatureEqualityCondition<IndexerDeclarationSyntax, IndexerDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> is not executed and <see cref="TypeExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ParameterListServiceProvider : ISignatureEqualityCondition<ParameterListSyntax, ParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ParameterListSyntax original, ParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ParameterListSyntax original, ParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ParameterListSyntax original, ParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ParameterListSyntax original, ParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ParameterListSyntax original, ParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ParameterListSyntax, ParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ParameterListSyntax original, ParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ParameterListSyntax, ParameterListSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ParameterListSyntax original, ParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ParameterListSyntax original, ParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class BracketedParameterListServiceProvider : ISignatureEqualityCondition<BracketedParameterListSyntax, BracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> is not executed and <see cref="TypeExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="BracketedParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class NameMemberCrefServiceProvider : ISignatureEqualityCondition<NameMemberCrefSyntax, NameMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> is not executed and <see cref="TypeExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class IndexerMemberCrefServiceProvider : ISignatureEqualityCondition<IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> is not executed and <see cref="TypeExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class OperatorMemberCrefServiceProvider : ISignatureEqualityCondition<OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> is not executed and <see cref="TypeExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ConversionOperatorMemberCrefServiceProvider : ISignatureEqualityCondition<ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.TypeExactlyEqual(original.Type, modified.Type)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ConversionOperatorMemberCrefSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class CrefParameterListServiceProvider : ISignatureEqualityCondition<CrefParameterListSyntax, CrefParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/> is not executed and <see cref="TypeExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(CrefParameterListSyntax, CrefParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(CrefParameterListSyntax, CrefParameterListSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="CrefParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(CrefParameterListSyntax original, CrefParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class CrefBracketedParameterListServiceProvider : ISignatureEqualityCondition<CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> is not executed and <see cref="TypeExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.Parameters, modified.Parameters))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="CrefBracketedParameterListSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class AnonymousMethodExpressionServiceProvider : ISignatureEqualityCondition<AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> is not executed and <see cref="TypeExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.ParameterList != null && modified.ParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="AnonymousMethodExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class SimpleLambdaExpressionServiceProvider : ISignatureEqualityCondition<SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
//    {
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class ParenthesizedLambdaExpressionServiceProvider : ISignatureEqualityCondition<ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> is not executed and <see cref="TypeExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="ParenthesizedLambdaExpressionSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//    public partial class LocalFunctionStatementServiceProvider : ISignatureEqualityCondition<LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="TypeExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="TypeExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> is not executed and <see cref="TypeExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void TypeExactlyEqualBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="TypeExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</remarks>
//        protected virtual bool TypeExactlyEqualCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.TypeExactlyEqual(original.TypeParameterList, modified.TypeParameterList))) &&
//                (this.LanguageServiceProvider.TypeExactlyEqual(original.ParameterList, modified.ParameterList)))
//    			return true;
    
//    	    return false;
//    	}
    	
//        /// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are type-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool TypeExactlyEqual(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		TypeExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.TypeExactlyEqualCore(original, modified);
//    		TypeExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
    
//        /// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> is not executed and <see cref="SignatureExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
//        partial void SignatureExactlyEqualBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
//        partial void SignatureExactlyEqualAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result);
    
//        /// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        /// <remarks>This is the default implementation for <see cref="SignatureExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</remarks>
//        protected virtual bool SignatureExactlyEqualCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//        {
//    		if(original == null || modified == null) 
//    			return false;
    
//            if(this.LanguageServiceProvider.NameExactlyEqual(original, modified) && this.LanguageServiceProvider.TypeExactlyEqual(original, modified))
//    			return true;
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public bool SignatureExactlyEqual(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
//        {
//    		bool result = false, ignoreCore = false;
//    		SignatureExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureExactlyEqualCore(original, modified);
//    		SignatureExactlyEqualAfter(original, modified, ref result);
//    		return result;
//        }
//    }
    
//}
//// Generated helper templates
//// Generated items
