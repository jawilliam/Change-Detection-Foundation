
//using Jawilliam.CDF.Approach.Awareness;
//using Jawilliam.CDF.Approach.Criterions;
//using Jawilliam.CDF.Approach.Flad;
//using Jawilliam.CDF.Approach.Services;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Linq;

//namespace Jawilliam.CDF.CSharp.Awareness
//{
//    partial class SyntaxTokenServiceProvider : ISignatureEqualityCriterion<SyntaxNodeOrToken?, SyntaxToken, SyntaxToken>
//    {
//    	/*/// <summary>
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
//        }*/
    
//        /// <summary>
//        /// Determines if two elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch(SyntaxToken original, SyntaxToken modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//        {
//    		matchingDescription = null;
    
//            if (original == null || modified == null)
//                return false;
        
//            if (!string.IsNullOrWhiteSpace(original.ValueText) && 
//    		    !string.IsNullOrWhiteSpace(modified.ValueText) && 
//    			original.ValueText == modified.ValueText)
//    		{
//                matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//        		return true;
//    		}
        
//            return false;
//        }
//    }
    
//    partial class LanguageServiceProvider
//    {
//    	/// <summary>
//        /// Determines if two elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
//        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureEqualityMatch<TOriginal, TModified>(TOriginal original, TModified modified, MatchingContext<SyntaxNodeOrToken?> context)
//        where TOriginal : SyntaxNode where TModified : SyntaxNode
//        {
//            return this.SignatureEqualityMatch<TOriginal, TModified>(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
//        }
    
//        /// <summary>
//        /// Determines if two elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
//        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch<TOriginal, TModified>(TOriginal original, TModified modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//        where TOriginal : SyntaxNode where TModified : SyntaxNode
//        {
//            matchingDescription = null;
//            if (original != null && modified != null)
//            {
//                if (this.GetElementTypeServiceProvider((SyntaxKind)original.RawKind) is ISignatureEqualityCriterion<SyntaxNodeOrToken?, TOriginal, TModified> elementTypeServiceProvider)
//                    return elementTypeServiceProvider.SignatureEqualityMatch(original, modified, context, out matchingDescription);
//            }
//            return false;
//        }
    
//        /// <summary>
//        /// Determines if two elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        public virtual bool SignatureEqualityMatch(SyntaxNode original, SyntaxNode modified, MatchingContext<SyntaxNodeOrToken?> context)
//        {
//            return this.SignatureEqualityMatch(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
//        }
    
//        /// <summary>
//        /// Determines if two elements are signature-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch(SyntaxNode original, SyntaxNode modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//        {
//            var parameterModifier = new System.Reflection.ParameterModifier(4);
//            parameterModifier[3] = true;
//            var genericMethod = this.GetType().GetMethod("SignatureEqualityMatch", 
//    			new[] { original.GetType(), modified.GetType(), typeof(MatchingContext<SyntaxNodeOrToken?>), typeof(MatchInfo<SyntaxNodeOrToken?>) }, 
//    			new System.Reflection.ParameterModifier[] { parameterModifier }).MakeGenericMethod(original.GetType(), modified.GetType());
        
//            matchingDescription = null;
//            return (bool)genericMethod.Invoke(this, new object[] { original, modified, context, matchingDescription });
//        }
        
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="equal">logic of equality.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified, Func<T, T, bool> equal, MatchingContext<SyntaxNodeOrToken?> context) where T : SyntaxNode
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
            
//        	return true;
//        }	
        
//        /// <summary>
//        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified, MatchingContext<SyntaxNodeOrToken?> context) where T : SyntaxNode
//        {
//            return this.SignatureEqualityMatch(original, modified, (o, m) => this.SignatureEqualityMatch(o, m, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription), context);
//        }
    
//        /// <summary>
//        /// Determines if two <see cref="SyntaxList{TNode}"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="equal">logic of equality.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch<T>(SyntaxList<T> original, SyntaxList<T> modified, Func<T, T, bool> equal, MatchingContext<SyntaxNodeOrToken?> context) where T : SyntaxNode
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
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch<T>(SyntaxList<T> original, SyntaxList<T> modified, MatchingContext<SyntaxNodeOrToken?> context) where T : SyntaxNode
//        {
//            return this.SignatureEqualityMatch(original, modified, (o, m) => this.SignatureEqualityMatch(o, m, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription), context);
//        }
        
//        /// <summary>
//        /// Determines if two <see cref="SyntaxToken"/> elements are equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are signature-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are signature-based exactly equal, this parameter will contain the corresponding matching description.</param>
//        public virtual bool SignatureEqualityMatch(SyntaxToken original, SyntaxToken modified, MatchingContext<SyntaxNodeOrToken?> context)
//        {
//            return this.SyntaxTokenServiceProvider.SignatureEqualityMatch(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
//        }
//    }
    
//    /*
    
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
//    }*/
    
//    public partial class TypeParameterListServiceProvider
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//    	/// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = original.Parameters.Count() == modified.Parameters.Count()
//    			? new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified }
//    			: null;
    
//    		return matchingDescription != null;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        public virtual bool SignatureEqualityMatch(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class TypeParameterServiceProvider
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        public virtual bool SignatureEqualityMatch(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ConstructorInitializerServiceProvider
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.ThisOrBaseKeyword, modified.ThisOrBaseKeyword, context)) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ArgumentList, modified.ArgumentList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        public virtual bool SignatureEqualityMatch(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ParameterServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParameterSyntax, ParameterSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.Type != null && modified.Type != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.Type, modified.Type, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParameterSyntax, ParameterSyntax>.SignatureEqualityMatch(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class CrefParameterServiceProvider
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(CrefParameterSyntax original, CrefParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(CrefParameterSyntax original, CrefParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(CrefParameterSyntax, CrefParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(CrefParameterSyntax original, CrefParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Type, modified.Type, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        public virtual bool SignatureEqualityMatch(CrefParameterSyntax original, CrefParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class DelegateDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, DelegateDeclarationSyntax, DelegateDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, DelegateDeclarationSyntax, DelegateDeclarationSyntax>.SignatureEqualityMatch(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ClassDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ClassDeclarationSyntax, ClassDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ClassDeclarationSyntax, ClassDeclarationSyntax>.SignatureEqualityMatch(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class StructDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, StructDeclarationSyntax, StructDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, StructDeclarationSyntax, StructDeclarationSyntax>.SignatureEqualityMatch(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class InterfaceDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>.SignatureEqualityMatch(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class MethodDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, MethodDeclarationSyntax, MethodDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
//                (this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, MethodDeclarationSyntax, MethodDeclarationSyntax>.SignatureEqualityMatch(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class OperatorDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, OperatorDeclarationSyntax, OperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.OperatorToken, modified.OperatorToken, context)) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, OperatorDeclarationSyntax, OperatorDeclarationSyntax>.SignatureEqualityMatch(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ConversionOperatorDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.SignatureEqualityMatch(original.Type, modified.Type, context)) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>.SignatureEqualityMatch(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ConstructorDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>.SignatureEqualityMatch(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class EventDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, EventDeclarationSyntax, EventDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
//                (this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, EventDeclarationSyntax, EventDeclarationSyntax>.SignatureEqualityMatch(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class IndexerDeclarationServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, IndexerDeclarationSyntax, IndexerDeclarationSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
//                (this.LanguageServiceProvider.EqualityMatch(original.ThisKeyword, modified.ThisKeyword, context)) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, IndexerDeclarationSyntax, IndexerDeclarationSyntax>.SignatureEqualityMatch(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ParameterListServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParameterListSyntax, ParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ParameterListSyntax original, ParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ParameterListSyntax original, ParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ParameterListSyntax, ParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ParameterListSyntax original, ParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParameterListSyntax, ParameterListSyntax>.SignatureEqualityMatch(ParameterListSyntax original, ParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class BracketedParameterListServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, BracketedParameterListSyntax, BracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(BracketedParameterListSyntax, BracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, BracketedParameterListSyntax, BracketedParameterListSyntax>.SignatureEqualityMatch(BracketedParameterListSyntax original, BracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class NameMemberCrefServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, NameMemberCrefSyntax, NameMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.SignatureEqualityMatch(original.Name, modified.Name, context)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, NameMemberCrefSyntax, NameMemberCrefSyntax>.SignatureEqualityMatch(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class IndexerMemberCrefServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.ThisKeyword, modified.ThisKeyword, context)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>.SignatureEqualityMatch(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class OperatorMemberCrefServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.OperatorToken, modified.OperatorToken, context)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>.SignatureEqualityMatch(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ConversionOperatorMemberCrefServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.SignatureEqualityMatch(original.Type, modified.Type, context)) &&
//                ((original.Parameters == null && modified.Parameters == null) || (original.Parameters != null && modified.Parameters != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax>.SignatureEqualityMatch(ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class CrefParameterListServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, CrefParameterListSyntax, CrefParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(CrefParameterListSyntax original, CrefParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(CrefParameterListSyntax original, CrefParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(CrefParameterListSyntax, CrefParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(CrefParameterListSyntax original, CrefParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, CrefParameterListSyntax, CrefParameterListSyntax>.SignatureEqualityMatch(CrefParameterListSyntax original, CrefParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class CrefBracketedParameterListServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameters, modified.Parameters, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax>.SignatureEqualityMatch(CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class AnonymousMethodExpressionServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (original.ParameterList != null && modified.ParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax>.SignatureEqualityMatch(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class SimpleLambdaExpressionServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.Parameter, modified.Parameter, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>.SignatureEqualityMatch(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class ParenthesizedLambdaExpressionServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax>.SignatureEqualityMatch(ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//    public partial class LocalFunctionStatementServiceProvider: ISignatureEqualityCriterion<SyntaxNodeOrToken?, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
//    {
//    	/// <summary>
//        /// Method hook for implementing logic to execute before the <see cref="SignatureEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="ignoreCore">If true, the <see cref="SignatureEqualityMatchCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="SignatureEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="SignatureEqualityMatchCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
//        /// <param name="result">Mechanism to modify the result of <see cref="SignatureEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        partial void SignatureEqualityMatchAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        /// <remarks>This is the default implementation for <see cref="SignatureEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
//        protected virtual bool SignatureEqualityMatchCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		matchingDescription = null;
//    		if(original == null || modified == null) 
//    			return false;
    
//            if ((this.LanguageServiceProvider.EqualityMatch(original.Identifier, modified.Identifier, context)) &&
//                ((original.TypeParameterList == null && modified.TypeParameterList == null) || (original.TypeParameterList != null && modified.TypeParameterList != null && this.LanguageServiceProvider.SignatureEqualityMatch(original.TypeParameterList, modified.TypeParameterList, context))) &&
//                (this.LanguageServiceProvider.SignatureEqualityMatch(original.ParameterList, modified.ParameterList, context)))
//    		{
//    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.SignatureEquality) { Original = original, Modified = modified };
//    			return true;
//    		}
    
//    	    return false;
//    	}
    
//        /// <summary>
//        /// Determines if two elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
//        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
//        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
//        bool ISignatureEqualityCriterion<SyntaxNodeOrToken?, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>.SignatureEqualityMatch(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
//    	{
//    		bool result = false;
//    		var ignoreCore = false;
//    		matchingDescription = null;
//    		SignatureEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
//    		if(ignoreCore) 
//    			return result;
    		
//    		result = this.SignatureEqualityMatchCore(original, modified, context, out matchingDescription);
//    		SignatureEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
//    		return result;
//    	}    
//    }
    
//}
//// Generated helper templates
//// Generated items
