
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Criterions;

namespace Jawilliam.CDF.CSharp.Awareness
{
    partial class PredefinedTypeServiceProvider
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(PredefinedTypeSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(PredefinedTypeSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(PredefinedTypeSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(PredefinedTypeSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.BoolKeyword
               && modified.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ByteKeyword
               && modified.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.SByteKeyword
               && modified.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.IntKeyword
               && modified.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UIntKeyword
               && modified.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ShortKeyword
               && modified.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UShortKeyword
               && modified.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.LongKeyword
               && modified.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ULongKeyword
               && modified.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.FloatKeyword
               && modified.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DoubleKeyword
               && modified.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DecimalKeyword
               && modified.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringKeyword
               && modified.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.CharKeyword
               && modified.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ObjectKeyword
               && modified.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public bool AliasMatch(PredefinedTypeSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(PredefinedTypeSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(PredefinedTypeSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(PredefinedTypeSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(PredefinedTypeSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.BoolKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ByteKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.SByteKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.IntKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UIntKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ShortKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UShortKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.LongKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ULongKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.FloatKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DoubleKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DecimalKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.CharKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(original.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ObjectKeyword
               && (modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public bool AliasMatch(PredefinedTypeSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    }
    
    partial class QualifiedNameServiceProvider
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(QualifiedNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(QualifiedNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(QualifiedNameSyntax, IdentifierNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(QualifiedNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Boolean"
               && modified.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Byte"
               && modified.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "SByte"
               && modified.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int32"
               && modified.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt32"
               && modified.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int16"
               && modified.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt16"
               && modified.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int64"
               && modified.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt64"
               && modified.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Single"
               && modified.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Double"
               && modified.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Decimal"
               && modified.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "String"
               && modified.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Char"
               && modified.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Object"
               && modified.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        public bool AliasMatch(QualifiedNameSyntax original, IdentifierNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(QualifiedNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(QualifiedNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(QualifiedNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(QualifiedNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.BoolKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ByteKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.SByteKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.IntKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UIntKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ShortKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UShortKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.LongKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ULongKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.FloatKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DoubleKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DecimalKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.CharKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ObjectKeyword
               && (original.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (original.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public bool AliasMatch(QualifiedNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    }
    
    partial class IdentifierNameServiceProvider
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(IdentifierNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(IdentifierNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(IdentifierNameSyntax, PredefinedTypeSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(IdentifierNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.BoolKeyword
               && original.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ByteKeyword
               && original.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.SByteKeyword
               && original.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.IntKeyword
               && original.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UIntKeyword
               && original.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ShortKeyword
               && original.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.UShortKeyword
               && original.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.LongKeyword
               && original.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ULongKeyword
               && original.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.FloatKeyword
               && original.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DoubleKeyword
               && original.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.DecimalKeyword
               && original.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringKeyword
               && original.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.CharKeyword
               && original.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if(modified.Keyword.RawKind == (int)Microsoft.CodeAnalysis.CSharp.SyntaxKind.ObjectKeyword
               && original.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public bool AliasMatch(IdentifierNameSyntax original, PredefinedTypeSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="AliasMatch(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="AliasMatchCore(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> is not executed and <see cref="AliasMatch(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/> returns the current value of <paramref name="result"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchBefore(IdentifierNameSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="AliasMatchCore(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?})"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        /// <param name="result">Mechanism to modify the result of <see cref="AliasMatch(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</param>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        partial void AliasMatchAfter(IdentifierNameSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result);
    
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        /// <remarks>This is the default implementation for <see cref="AliasMatch(IdentifierNameSyntax, QualifiedNameSyntax, MatchingContext{SyntaxNodeOrToken?}, ref MatchInfo{SyntaxNodeOrToken?})"/>.</remarks>
        protected virtual bool AliasMatchCore(IdentifierNameSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, out MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Boolean"
               && original.Identifier.ValueText == "Boolean")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Byte"
               && original.Identifier.ValueText == "Byte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "SByte"
               && original.Identifier.ValueText == "SByte")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int32"
               && original.Identifier.ValueText == "Int32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt32"
               && original.Identifier.ValueText == "UInt32")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int16"
               && original.Identifier.ValueText == "Int16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt16"
               && original.Identifier.ValueText == "UInt16")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Int64"
               && original.Identifier.ValueText == "Int64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "UInt64"
               && original.Identifier.ValueText == "UInt64")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Single"
               && original.Identifier.ValueText == "Single")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Double"
               && original.Identifier.ValueText == "Double")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Decimal"
               && original.Identifier.ValueText == "Decimal")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "String"
               && original.Identifier.ValueText == "String")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Char"
               && original.Identifier.ValueText == "Char")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    		
    		if((modified.Left as IdentifierNameSyntax)?.Identifier.ValueText == "System"
               && (modified.Right as IdentifierNameSyntax)?.Identifier.ValueText == "Object"
               && original.Identifier.ValueText == "Object")
    		{		
    			matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.Alias) { Original = original, Modified = modified };
    			return true;
    		}
    
    		matchingDescription = null;
    		return false;
    	}    
    
    	/// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description. It should be actually an "out" parameter, but partial methods do not support "out" parameters.</param>
        public bool AliasMatch(IdentifierNameSyntax original, QualifiedNameSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription)
    	{
    		bool result = false;
    		var ignoreCore = false;
    		AliasMatchBefore(original, modified, context, ref matchingDescription, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.AliasMatchCore(original, modified, context, out matchingDescription);
    		AliasMatchAfter(original, modified, context, ref matchingDescription, ref result);
    		return result;
    	}
    
    }
    
}
// Generated helper templates
// Generated items
