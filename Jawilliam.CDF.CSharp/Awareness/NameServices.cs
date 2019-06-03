
using Jawilliam.CDF.Approach.Awareness;
using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Flad;
using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Awareness
{
    partial class SyntaxTokenServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, SyntaxToken, SyntaxToken>
    {
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(SyntaxToken original, SyntaxToken modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        {
    		matchingDescription = null;
    
            if (original == null || modified == null)
                return false;
        
            if (!string.IsNullOrWhiteSpace(original.ValueText) && 
    		    !string.IsNullOrWhiteSpace(modified.ValueText) && 
    			original.ValueText == modified.ValueText)
    		{
                matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Equality) { Original = original, Modified = modified };
        		return true;
    		}
        
            return false;
        }
    }
    
    partial class LanguageServiceProvider
    {
    	/*/// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        public virtual bool NameEqualityMatch<TOriginal, TModified>(TOriginal original, TModified modified, MatchingContext<SyntaxNodeOrToken?> context)
        where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            return this.NameEqualityMatch<TOriginal, TModified>(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
        }
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch<TOriginal, TModified>(TOriginal original, TModified modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            matchingDescription = null;
            if (original != null && modified != null)
            {
                if (this.GetElementTypeServiceProvider((SyntaxKind)original.RawKind) is INameEqualityCriterion<SyntaxNodeOrToken?, TOriginal, TModified> elementTypeServiceProvider)
                    return elementTypeServiceProvider.NameEqualityMatch(original, modified, context, out matchingDescription);
            }
            return false;
        }
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        public virtual bool NameEqualityMatch(SyntaxNode original, SyntaxNode modified, MatchingContext<SyntaxNodeOrToken?> context)
        {
            return this.NameEqualityMatch(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
        }
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(SyntaxNode original, SyntaxNode modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        {
            var parameterModifier = new System.Reflection.ParameterModifier(4);
            parameterModifier[3] = true;
            var genericMethod = this.GetType().GetMethod("NameEqualityMatch", 
    			new[] { original.GetType(), modified.GetType(), typeof(MatchingContext<SyntaxNodeOrToken?>), typeof(MatchInfo<SyntaxNodeOrToken?>) }, 
    			new System.Reflection.ParameterModifier[] { parameterModifier }).MakeGenericMethod(original.GetType(), modified.GetType());
        
            matchingDescription = null;
            return (bool)genericMethod.Invoke(this, new object[] { original, modified, context, matchingDescription });
        }*/
    
    	/// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        protected virtual bool NameEqualityMatch<TOriginal, TModified>(IEnumerable<TOriginal> original, IEnumerable<TModified> modified, Func<TOriginal, TModified, bool> equal, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
    		matchingDescription = null;
    
    		if (original == null || modified == null)
                return false;
        
            if (original.Count() != modified.Count())
                return false;
    
    		var originalList = original.ToList();
    		var modifiedList = modified.ToList();
    
            if (originalList.Select((o, i) => equal(o, modifiedList[i])).All(r => r))
            {
                matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original as SyntaxNode, Modified = modified as SyntaxNode };
                return true;
            }
    
    		while(originalList.Count() > 0)
    		{
    			var o = originalList.First();
    			originalList.Remove(o);
    
    			var equalModifieds = modifiedList.Where(m => equal(o, m)).ToList();
    			if(equalModifieds.Count() != 1)
    				return false;
    
    			modifiedList.Remove(equalModifieds.Single());
    		}
    
    		if (originalList.Count() != modifiedList.Count())
                return false;
            
    		matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original as SyntaxNode, Modified = modified as SyntaxNode };
        	return true;
    	}
    
    	/// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch<TOriginal, TModified>(SeparatedSyntaxList<TOriginal> original, SeparatedSyntaxList<TModified> modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
    		return this.NameEqualityMatch(original, modified, (o, m) => this.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", o, m, context), context, out matchingDescription);
    	}		
    
    	/// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
        /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch<TOriginal, TModified>(SyntaxList<TOriginal> original, SyntaxList<TModified> modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
    		return this.NameEqualityMatch(original, modified, (o, m) => this.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", o, m, context), context, out matchingDescription);
    	}	
        /*
        /// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(SyntaxToken original, SyntaxToken modified, MatchingContext<SyntaxNodeOrToken?> context)
        {
            return this.SyntaxTokenServiceProvider.NameEqualityMatch(original, modified, context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription);
        }*/
    }
    
    partial class OmittedTypeArgumentServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax>
    {
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
        {
            if (original == null || modified == null)
            {
                matchingDescription = null;
                return false;
            }
    
            matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
        	return true;
        }
    }
    
    public partial class AttributeArgumentServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AttributeArgumentSyntax, AttributeArgumentSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AttributeArgumentSyntax, AttributeArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if ((original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameEquals, modified.NameEquals, context)) ||
                (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameColon, modified.NameColon, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if (original.NameEquals != null && modified.NameColon != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameEquals, modified.NameColon, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if (original.NameColon != null && modified.NameEquals != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameColon, modified.NameEquals, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class NameEqualsServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, NameEqualsSyntax, NameEqualsSyntax>, INameEqualityCriterion<SyntaxNodeOrToken?, NameEqualsSyntax, NameColonSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(NameEqualsSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(NameEqualsSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NameEqualsSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NameEqualsSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(NameEqualsSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        partial void NameEqualityMatchBefore(NameEqualsSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(NameEqualsSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NameEqualsSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NameEqualsSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(modified.Name.Identifier.ValueText == original.Name.Identifier.ValueText)
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(NameEqualsSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class TypeParameterListServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, TypeParameterListSyntax, TypeParameterListSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(TypeParameterListSyntax, TypeParameterListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Parameters, modified.Parameters, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(TypeParameterListSyntax original, TypeParameterListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class TypeParameterServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, TypeParameterSyntax, TypeParameterSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(TypeParameterSyntax, TypeParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(TypeParameterSyntax original, TypeParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class TypeParameterConstraintClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ExplicitInterfaceSpecifierServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ConstructorInitializerServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ConstructorInitializerSyntax, ConstructorInitializerSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ConstructorInitializerSyntax, ConstructorInitializerSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ThisOrBaseKeyword, modified.ThisOrBaseKeyword, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AccessorDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AccessorDeclarationSyntax, AccessorDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AccessorDeclarationSyntax, AccessorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Keyword, modified.Keyword, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ParameterServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ParameterSyntax, ParameterSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ParameterSyntax, ParameterSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ParameterSyntax original, ParameterSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlElementStartTagServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlElementStartTagSyntax, XmlElementStartTagSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlElementStartTagSyntax, XmlElementStartTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlElementEndTagServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlElementEndTagSyntax, XmlElementEndTagSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlElementEndTagSyntax, XmlElementEndTagSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlNameServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlNameSyntax, XmlNameSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlNameSyntax original, XmlNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlNameSyntax original, XmlNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlNameSyntax, XmlNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlNameSyntax original, XmlNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.Prefix == null && modified.Prefix == null) || (original.Prefix != null && modified.Prefix != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Prefix, modified.Prefix, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.LocalName, modified.LocalName, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlNameSyntax original, XmlNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlPrefixServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlPrefixSyntax, XmlPrefixSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlPrefixSyntax original, XmlPrefixSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlPrefixSyntax original, XmlPrefixSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlPrefixSyntax, XmlPrefixSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlPrefixSyntax original, XmlPrefixSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Prefix, modified.Prefix, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlPrefixSyntax original, XmlPrefixSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class TypeArgumentListServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, TypeArgumentListSyntax, TypeArgumentListSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(TypeArgumentListSyntax, TypeArgumentListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Arguments, modified.Arguments, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(TypeArgumentListSyntax original, TypeArgumentListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class TupleElementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, TupleElementSyntax, TupleElementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(TupleElementSyntax original, TupleElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(TupleElementSyntax original, TupleElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(TupleElementSyntax, TupleElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(TupleElementSyntax original, TupleElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(TupleElementSyntax original, TupleElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ArgumentServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ArgumentSyntax, ArgumentSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ArgumentSyntax original, ArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ArgumentSyntax original, ArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ArgumentSyntax, ArgumentSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ArgumentSyntax original, ArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameColon, modified.NameColon, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ArgumentSyntax original, ArgumentSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class NameColonServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, NameColonSyntax, NameColonSyntax>, INameEqualityCriterion<SyntaxNodeOrToken?, NameColonSyntax, NameEqualsSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(NameColonSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(NameColonSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NameColonSyntax, NameColonSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NameColonSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(NameColonSyntax original, NameColonSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        partial void NameEqualityMatchBefore(NameColonSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        partial void NameEqualityMatchAfter(NameColonSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NameColonSyntax, NameEqualsSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NameColonSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(original.Name.Identifier.ValueText == modified.Name.Identifier.ValueText)
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public virtual bool NameEqualityMatch(NameColonSyntax original, NameEqualsSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AnonymousObjectMemberDeclaratorServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.NameEquals, modified.NameEquals, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class QueryBodyServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, QueryBodySyntax, QueryBodySyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(QueryBodySyntax original, QueryBodySyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(QueryBodySyntax original, QueryBodySyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(QueryBodySyntax, QueryBodySyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(QueryBodySyntax original, QueryBodySyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Continuation != null && modified.Continuation != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Continuation, modified.Continuation, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(QueryBodySyntax original, QueryBodySyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class JoinIntoClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, JoinIntoClauseSyntax, JoinIntoClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(JoinIntoClauseSyntax, JoinIntoClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class QueryContinuationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, QueryContinuationSyntax, QueryContinuationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(QueryContinuationSyntax original, QueryContinuationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(QueryContinuationSyntax original, QueryContinuationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(QueryContinuationSyntax, QueryContinuationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(QueryContinuationSyntax original, QueryContinuationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(QueryContinuationSyntax original, QueryContinuationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class VariableDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, VariableDeclarationSyntax, VariableDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(VariableDeclarationSyntax, VariableDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Variables, modified.Variables, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class VariableDeclaratorServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, VariableDeclaratorSyntax, VariableDeclaratorSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(VariableDeclaratorSyntax, VariableDeclaratorSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class CatchClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, CatchClauseSyntax, CatchClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(CatchClauseSyntax original, CatchClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(CatchClauseSyntax original, CatchClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(CatchClauseSyntax, CatchClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(CatchClauseSyntax original, CatchClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(CatchClauseSyntax original, CatchClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class CatchDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, CatchDeclarationSyntax, CatchDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(CatchDeclarationSyntax, CatchDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Identifier != null && modified.Identifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ExternAliasDirectiveServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class UsingDirectiveServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, UsingDirectiveSyntax, UsingDirectiveSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(UsingDirectiveSyntax, UsingDirectiveSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.Alias == null && modified.Alias == null) || (original.Alias != null && modified.Alias != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Alias, modified.Alias, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AttributeListServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AttributeListSyntax, AttributeListSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AttributeListSyntax original, AttributeListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AttributeListSyntax original, AttributeListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AttributeListSyntax, AttributeListSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AttributeListSyntax original, AttributeListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.Target == null && modified.Target == null) || (original.Target != null && modified.Target != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Target, modified.Target, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Attributes, modified.Attributes, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AttributeListSyntax original, AttributeListSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AttributeTargetSpecifierServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AttributeServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AttributeSyntax, AttributeSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AttributeSyntax original, AttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AttributeSyntax original, AttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AttributeSyntax, AttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AttributeSyntax original, AttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AttributeSyntax original, AttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class DelegateDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, DelegateDeclarationSyntax, DelegateDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(DelegateDeclarationSyntax, DelegateDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class EnumMemberDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class NamespaceDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class EnumDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, EnumDeclarationSyntax, EnumDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(EnumDeclarationSyntax, EnumDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ClassDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ClassDeclarationSyntax, ClassDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ClassDeclarationSyntax, ClassDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class StructDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, StructDeclarationSyntax, StructDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(StructDeclarationSyntax, StructDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(StructDeclarationSyntax original, StructDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class InterfaceDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class FieldDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, FieldDeclarationSyntax, FieldDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(FieldDeclarationSyntax, FieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class EventFieldDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, EventFieldDeclarationSyntax, EventFieldDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class MethodDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, MethodDeclarationSyntax, MethodDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(MethodDeclarationSyntax, MethodDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class OperatorDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, OperatorDeclarationSyntax, OperatorDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(OperatorDeclarationSyntax, OperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.OperatorToken, modified.OperatorToken, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ConversionOperatorDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Type, modified.Type, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ConstructorDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class DestructorDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, DestructorDeclarationSyntax, DestructorDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(DestructorDeclarationSyntax, DestructorDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class PropertyDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, PropertyDeclarationSyntax, PropertyDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(PropertyDeclarationSyntax, PropertyDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class EventDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, EventDeclarationSyntax, EventDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(EventDeclarationSyntax, EventDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(EventDeclarationSyntax original, EventDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class IndexerDeclarationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, IndexerDeclarationSyntax, IndexerDeclarationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(IndexerDeclarationSyntax, IndexerDeclarationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (((original.ExplicitInterfaceSpecifier == null && modified.ExplicitInterfaceSpecifier == null) || (original.ExplicitInterfaceSpecifier != null && modified.ExplicitInterfaceSpecifier != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ExplicitInterfaceSpecifier, modified.ExplicitInterfaceSpecifier, context))) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ThisKeyword, modified.ThisKeyword, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class BadDirectiveTriviaServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class DefineDirectiveTriviaServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class UndefDirectiveTriviaServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class NameMemberCrefServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, NameMemberCrefSyntax, NameMemberCrefSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(NameMemberCrefSyntax, NameMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class IndexerMemberCrefServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.ThisKeyword, modified.ThisKeyword, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class OperatorMemberCrefServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.OperatorToken, modified.OperatorToken, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlElementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlElementSyntax, XmlElementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlElementSyntax original, XmlElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlElementSyntax original, XmlElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlElementSyntax, XmlElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlElementSyntax original, XmlElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.StartTag, modified.StartTag, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlElementSyntax original, XmlElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlEmptyElementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlEmptyElementSyntax, XmlEmptyElementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlEmptyElementSyntax, XmlEmptyElementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlProcessingInstructionServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlTextAttributeServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlTextAttributeSyntax, XmlTextAttributeSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlTextAttributeSyntax, XmlTextAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlCrefAttributeServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlCrefAttributeSyntax, XmlCrefAttributeSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Cref, modified.Cref, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class XmlNameAttributeServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, XmlNameAttributeSyntax, XmlNameAttributeSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(XmlNameAttributeSyntax, XmlNameAttributeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class MemberAccessExpressionServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if ((this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Expression, modified.Expression, context)) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class MemberBindingExpressionServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, MemberBindingExpressionSyntax, MemberBindingExpressionSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class QueryExpressionServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, QueryExpressionSyntax, QueryExpressionSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(QueryExpressionSyntax original, QueryExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(QueryExpressionSyntax original, QueryExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(QueryExpressionSyntax, QueryExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(QueryExpressionSyntax original, QueryExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.FromClause, modified.FromClause, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(QueryExpressionSyntax original, QueryExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class AliasQualifiedNameServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, AliasQualifiedNameSyntax, AliasQualifiedNameSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if ((this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Alias, modified.Alias, context)) &&
                (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context)))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class IdentifierNameServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, IdentifierNameSyntax, IdentifierNameSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(IdentifierNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(IdentifierNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(IdentifierNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(IdentifierNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(IdentifierNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class GenericNameServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, GenericNameSyntax, GenericNameSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(GenericNameSyntax original, GenericNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(GenericNameSyntax original, GenericNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(GenericNameSyntax, GenericNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(GenericNameSyntax original, GenericNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(GenericNameSyntax original, GenericNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class SimpleLambdaExpressionServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Parameter, modified.Parameter, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class FromClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, FromClauseSyntax, FromClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(FromClauseSyntax original, FromClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(FromClauseSyntax original, FromClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(FromClauseSyntax, FromClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(FromClauseSyntax original, FromClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(FromClauseSyntax original, FromClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class LetClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, LetClauseSyntax, LetClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(LetClauseSyntax original, LetClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(LetClauseSyntax original, LetClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(LetClauseSyntax, LetClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(LetClauseSyntax original, LetClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(LetClauseSyntax original, LetClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class JoinClauseServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, JoinClauseSyntax, JoinClauseSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(JoinClauseSyntax original, JoinClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(JoinClauseSyntax original, JoinClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(JoinClauseSyntax, JoinClauseSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(JoinClauseSyntax original, JoinClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(JoinClauseSyntax original, JoinClauseSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class LocalFunctionStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class LocalDeclarationStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class LabeledStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, LabeledStatementSyntax, LabeledStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(LabeledStatementSyntax original, LabeledStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(LabeledStatementSyntax original, LabeledStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(LabeledStatementSyntax, LabeledStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(LabeledStatementSyntax original, LabeledStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(LabeledStatementSyntax original, LabeledStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ForStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ForStatementSyntax, ForStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ForStatementSyntax original, ForStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ForStatementSyntax original, ForStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ForStatementSyntax, ForStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ForStatementSyntax original, ForStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ForStatementSyntax original, ForStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class UsingStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, UsingStatementSyntax, UsingStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(UsingStatementSyntax original, UsingStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(UsingStatementSyntax original, UsingStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(UsingStatementSyntax, UsingStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(UsingStatementSyntax original, UsingStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(UsingStatementSyntax original, UsingStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class FixedStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, FixedStatementSyntax, FixedStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(FixedStatementSyntax original, FixedStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(FixedStatementSyntax original, FixedStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(FixedStatementSyntax, FixedStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(FixedStatementSyntax original, FixedStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Declaration, modified.Declaration, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(FixedStatementSyntax original, FixedStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class ForEachStatementServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, ForEachStatementSyntax, ForEachStatementSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(ForEachStatementSyntax original, ForEachStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(ForEachStatementSyntax original, ForEachStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(ForEachStatementSyntax, ForEachStatementSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(ForEachStatementSyntax original, ForEachStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(ForEachStatementSyntax original, ForEachStatementSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
    public partial class SingleVariableDesignationServiceProvider : INameEqualityCriterion<SyntaxNodeOrToken?, SingleVariableDesignationSyntax, SingleVariableDesignationSyntax>
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameEqualityMatch(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameEqualityMatchCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="NameEqualityMatch(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchBefore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameEqualityMatchCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="NameEqualityMatch(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void NameEqualityMatchAfter(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="NameEqualityMatch(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool NameEqualityMatchCore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null || modified == null) 
    		{
    			matchingDescription = null;
    			return false;
    		}
    
            if (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Identifier, modified.Identifier, context))
    		{
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are name-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are name-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public virtual bool NameEqualityMatch(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		matchingDescription = null;
    		NameEqualityMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameEqualityMatchCore(original, modified, context, out matchingDescription);
    		NameEqualityMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    }
    
}
// Generated helper templates
// Generated items
