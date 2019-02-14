
using Jawilliam.CDF.Approach.Flad;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Flad
{
    public partial class AttributeArgumentServiceProvider : INameEqualityCondition<AttributeArgumentSyntax, AttributeArgumentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> is not executed and <see cref="NameExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if ((original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(original.NameEquals, modified.NameEquals)) ||
                (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(original.NameColon, modified.NameColon)))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AttributeArgumentSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class NameEqualsServiceProvider : INameEqualityCondition<NameEqualsSyntax, NameEqualsSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/> is not executed and <see cref="NameExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(NameEqualsSyntax original, NameEqualsSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameEqualsSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(NameEqualsSyntax, NameEqualsSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(NameEqualsSyntax original, NameEqualsSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="NameEqualsSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(NameEqualsSyntax original, NameEqualsSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class TypeParameterServiceProvider : INameEqualityCondition<TypeParameterSyntax, TypeParameterSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/> is not executed and <see cref="NameExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(TypeParameterSyntax original, TypeParameterSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(TypeParameterSyntax, TypeParameterSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(TypeParameterSyntax original, TypeParameterSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(TypeParameterSyntax original, TypeParameterSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class TypeParameterConstraintClauseServiceProvider : INameEqualityCondition<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="TypeParameterConstraintClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ExplicitInterfaceSpecifierServiceProvider : INameEqualityCondition<ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> is not executed and <see cref="NameExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ExplicitInterfaceSpecifierSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ParameterServiceProvider : INameEqualityCondition<ParameterSyntax, ParameterSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/> is not executed and <see cref="NameExactlyEqual(ParameterSyntax, ParameterSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ParameterSyntax original, ParameterSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ParameterSyntax original, ParameterSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ParameterSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ParameterSyntax, ParameterSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ParameterSyntax original, ParameterSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ParameterSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ParameterSyntax original, ParameterSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlElementStartTagServiceProvider : INameEqualityCondition<XmlElementStartTagSyntax, XmlElementStartTagSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlElementStartTagSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlElementEndTagServiceProvider : INameEqualityCondition<XmlElementEndTagSyntax, XmlElementEndTagSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlElementEndTagSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlNameServiceProvider : INameEqualityCondition<XmlNameSyntax, XmlNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlNameSyntax original, XmlNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlNameSyntax original, XmlNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlNameSyntax, XmlNameSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlNameSyntax original, XmlNameSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (((original.Prefix == null && modified.Prefix == null) || (original.Prefix != null && modified.Prefix != null && this.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(original.Prefix, modified.Prefix))) &&
                (!string.IsNullOrWhiteSpace(original.LocalName.ValueText) && !string.IsNullOrWhiteSpace(modified.LocalName.ValueText) && original.LocalName.ValueText == modified.LocalName.ValueText))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlNameSyntax original, XmlNameSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlPrefixServiceProvider : INameEqualityCondition<XmlPrefixSyntax, XmlPrefixSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlPrefixSyntax, XmlPrefixSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlPrefixSyntax original, XmlPrefixSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Prefix.ValueText) && !string.IsNullOrWhiteSpace(modified.Prefix.ValueText) && original.Prefix.ValueText == modified.Prefix.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlPrefixSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlPrefixSyntax original, XmlPrefixSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class TupleElementServiceProvider : INameEqualityCondition<TupleElementSyntax, TupleElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/> is not executed and <see cref="NameExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(TupleElementSyntax original, TupleElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(TupleElementSyntax original, TupleElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="TupleElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(TupleElementSyntax, TupleElementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(TupleElementSyntax original, TupleElementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Identifier != null && modified.Identifier != null && !string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="TupleElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(TupleElementSyntax original, TupleElementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ArgumentServiceProvider : INameEqualityCondition<ArgumentSyntax, ArgumentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/> is not executed and <see cref="NameExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ArgumentSyntax original, ArgumentSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ArgumentSyntax original, ArgumentSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ArgumentSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ArgumentSyntax, ArgumentSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ArgumentSyntax original, ArgumentSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.NameColon != null && modified.NameColon != null && this.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(original.NameColon, modified.NameColon))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ArgumentSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ArgumentSyntax original, ArgumentSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class NameColonServiceProvider : INameEqualityCondition<NameColonSyntax, NameColonSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/> is not executed and <see cref="NameExactlyEqual(NameColonSyntax, NameColonSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(NameColonSyntax original, NameColonSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(NameColonSyntax original, NameColonSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameColonSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(NameColonSyntax, NameColonSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(NameColonSyntax original, NameColonSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="NameColonSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(NameColonSyntax original, NameColonSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class AnonymousObjectMemberDeclaratorServiceProvider : INameEqualityCondition<AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> is not executed and <see cref="NameExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.NameEquals != null && modified.NameEquals != null && this.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(original.NameEquals, modified.NameEquals))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AnonymousObjectMemberDeclaratorSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class QueryBodyServiceProvider : INameEqualityCondition<QueryBodySyntax, QueryBodySyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/> is not executed and <see cref="NameExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(QueryBodySyntax original, QueryBodySyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</param>
        partial void NameExactlyEqualAfter(QueryBodySyntax original, QueryBodySyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryBodySyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(QueryBodySyntax, QueryBodySyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(QueryBodySyntax original, QueryBodySyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Continuation != null && modified.Continuation != null && this.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(original.Continuation, modified.Continuation))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="QueryBodySyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(QueryBodySyntax original, QueryBodySyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class JoinIntoClauseServiceProvider : INameEqualityCondition<JoinIntoClauseSyntax, JoinIntoClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="JoinIntoClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class QueryContinuationServiceProvider : INameEqualityCondition<QueryContinuationSyntax, QueryContinuationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/> is not executed and <see cref="NameExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(QueryContinuationSyntax, QueryContinuationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(QueryContinuationSyntax original, QueryContinuationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="QueryContinuationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(QueryContinuationSyntax original, QueryContinuationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class VariableDeclarationServiceProvider : INameEqualityCondition<VariableDeclarationSyntax, VariableDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Variables, modified.Variables))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class VariableDeclaratorServiceProvider : INameEqualityCondition<VariableDeclaratorSyntax, VariableDeclaratorSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> is not executed and <see cref="NameExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="VariableDeclaratorSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class CatchClauseServiceProvider : INameEqualityCondition<CatchClauseSyntax, CatchClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(CatchClauseSyntax original, CatchClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CatchClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(CatchClauseSyntax, CatchClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(CatchClauseSyntax original, CatchClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="CatchClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(CatchClauseSyntax original, CatchClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class CatchDeclarationServiceProvider : INameEqualityCondition<CatchDeclarationSyntax, CatchDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Identifier != null && modified.Identifier != null && !string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="CatchDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ExternAliasDirectiveServiceProvider : INameEqualityCondition<ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> is not executed and <see cref="NameExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ExternAliasDirectiveSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class UsingDirectiveServiceProvider : INameEqualityCondition<UsingDirectiveSyntax, UsingDirectiveSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> is not executed and <see cref="NameExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="UsingDirectiveSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class AttributeListServiceProvider : INameEqualityCondition<AttributeListSyntax, AttributeListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/> is not executed and <see cref="NameExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AttributeListSyntax original, AttributeListSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AttributeListSyntax original, AttributeListSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeListSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AttributeListSyntax, AttributeListSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AttributeListSyntax original, AttributeListSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Target != null && modified.Target != null && this.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(original.Target, modified.Target))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AttributeListSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AttributeListSyntax original, AttributeListSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class AttributeTargetSpecifierServiceProvider : INameEqualityCondition<AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> is not executed and <see cref="NameExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AttributeTargetSpecifierSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class AttributeServiceProvider : INameEqualityCondition<AttributeSyntax, AttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/> is not executed and <see cref="NameExactlyEqual(AttributeSyntax, AttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AttributeSyntax original, AttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AttributeSyntax original, AttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AttributeSyntax, AttributeSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AttributeSyntax original, AttributeSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AttributeSyntax original, AttributeSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class DelegateDeclarationServiceProvider : INameEqualityCondition<DelegateDeclarationSyntax, DelegateDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="DelegateDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class EnumMemberDeclarationServiceProvider : INameEqualityCondition<EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="EnumMemberDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class NamespaceDeclarationServiceProvider : INameEqualityCondition<NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="NamespaceDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class EnumDeclarationServiceProvider : INameEqualityCondition<EnumDeclarationSyntax, EnumDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="EnumDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ClassDeclarationServiceProvider : INameEqualityCondition<ClassDeclarationSyntax, ClassDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ClassDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class StructDeclarationServiceProvider : INameEqualityCondition<StructDeclarationSyntax, StructDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(StructDeclarationSyntax original, StructDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="StructDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(StructDeclarationSyntax original, StructDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class InterfaceDeclarationServiceProvider : INameEqualityCondition<InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="InterfaceDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class FieldDeclarationServiceProvider : INameEqualityCondition<FieldDeclarationSyntax, FieldDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="FieldDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class EventFieldDeclarationServiceProvider : INameEqualityCondition<EventFieldDeclarationSyntax, EventFieldDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="EventFieldDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class MethodDeclarationServiceProvider : INameEqualityCondition<MethodDeclarationSyntax, MethodDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="MethodDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class OperatorDeclarationServiceProvider : INameEqualityCondition<OperatorDeclarationSyntax, OperatorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.OperatorToken.ValueText) && !string.IsNullOrWhiteSpace(modified.OperatorToken.ValueText) && original.OperatorToken.ValueText == modified.OperatorToken.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="OperatorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ConstructorDeclarationServiceProvider : INameEqualityCondition<ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ConstructorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class DestructorDeclarationServiceProvider : INameEqualityCondition<DestructorDeclarationSyntax, DestructorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="DestructorDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class PropertyDeclarationServiceProvider : INameEqualityCondition<PropertyDeclarationSyntax, PropertyDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="PropertyDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class EventDeclarationServiceProvider : INameEqualityCondition<EventDeclarationSyntax, EventDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(EventDeclarationSyntax, EventDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(EventDeclarationSyntax original, EventDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="EventDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(EventDeclarationSyntax original, EventDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class IndexerDeclarationServiceProvider : INameEqualityCondition<IndexerDeclarationSyntax, IndexerDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> is not executed and <see cref="NameExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.ThisKeyword.ValueText) && !string.IsNullOrWhiteSpace(modified.ThisKeyword.ValueText) && original.ThisKeyword.ValueText == modified.ThisKeyword.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="IndexerDeclarationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class BadDirectiveTriviaServiceProvider : INameEqualityCondition<BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> is not executed and <see cref="NameExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="BadDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class DefineDirectiveTriviaServiceProvider : INameEqualityCondition<DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> is not executed and <see cref="NameExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Name.ValueText) && !string.IsNullOrWhiteSpace(modified.Name.ValueText) && original.Name.ValueText == modified.Name.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="DefineDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class UndefDirectiveTriviaServiceProvider : INameEqualityCondition<UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> is not executed and <see cref="NameExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Name.ValueText) && !string.IsNullOrWhiteSpace(modified.Name.ValueText) && original.Name.ValueText == modified.Name.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="UndefDirectiveTriviaSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class NameMemberCrefServiceProvider : INameEqualityCondition<NameMemberCrefSyntax, NameMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> is not executed and <see cref="NameExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="NameMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class IndexerMemberCrefServiceProvider : INameEqualityCondition<IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> is not executed and <see cref="NameExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.ThisKeyword.ValueText) && !string.IsNullOrWhiteSpace(modified.ThisKeyword.ValueText) && original.ThisKeyword.ValueText == modified.ThisKeyword.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="IndexerMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class OperatorMemberCrefServiceProvider : INameEqualityCondition<OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> is not executed and <see cref="NameExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.OperatorToken.ValueText) && !string.IsNullOrWhiteSpace(modified.OperatorToken.ValueText) && original.OperatorToken.ValueText == modified.OperatorToken.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="OperatorMemberCrefSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlElementServiceProvider : INameEqualityCondition<XmlElementSyntax, XmlElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlElementSyntax original, XmlElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlElementSyntax original, XmlElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlElementSyntax, XmlElementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlElementSyntax original, XmlElementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(original.StartTag, modified.StartTag))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlElementSyntax original, XmlElementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlEmptyElementServiceProvider : INameEqualityCondition<XmlEmptyElementSyntax, XmlEmptyElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlEmptyElementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlProcessingInstructionServiceProvider : INameEqualityCondition<XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlProcessingInstructionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlTextAttributeServiceProvider : INameEqualityCondition<XmlTextAttributeSyntax, XmlTextAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlTextAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlCrefAttributeServiceProvider : INameEqualityCondition<XmlCrefAttributeSyntax, XmlCrefAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Cref, modified.Cref))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlCrefAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class XmlNameAttributeServiceProvider : INameEqualityCondition<XmlNameAttributeSyntax, XmlNameAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> is not executed and <see cref="NameExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Identifier, modified.Identifier))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="XmlNameAttributeSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class MemberAccessExpressionServiceProvider : INameEqualityCondition<MemberAccessExpressionSyntax, MemberAccessExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> is not executed and <see cref="NameExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="MemberAccessExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class MemberBindingExpressionServiceProvider : INameEqualityCondition<MemberBindingExpressionSyntax, MemberBindingExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> is not executed and <see cref="NameExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="MemberBindingExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class QueryExpressionServiceProvider : INameEqualityCondition<QueryExpressionSyntax, QueryExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/> is not executed and <see cref="NameExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(QueryExpressionSyntax, QueryExpressionSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(QueryExpressionSyntax original, QueryExpressionSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(original.FromClause, modified.FromClause))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="QueryExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(QueryExpressionSyntax original, QueryExpressionSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class AliasQualifiedNameServiceProvider : INameEqualityCondition<AliasQualifiedNameSyntax, AliasQualifiedNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> is not executed and <see cref="NameExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="AliasQualifiedNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class IdentifierNameServiceProvider : INameEqualityCondition<IdentifierNameSyntax, IdentifierNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/> is not executed and <see cref="NameExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(IdentifierNameSyntax, IdentifierNameSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(IdentifierNameSyntax original, IdentifierNameSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="IdentifierNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(IdentifierNameSyntax original, IdentifierNameSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class GenericNameServiceProvider : INameEqualityCondition<GenericNameSyntax, GenericNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/> is not executed and <see cref="NameExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(GenericNameSyntax original, GenericNameSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(GenericNameSyntax original, GenericNameSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="GenericNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(GenericNameSyntax, GenericNameSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(GenericNameSyntax original, GenericNameSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="GenericNameSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(GenericNameSyntax original, GenericNameSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class SimpleLambdaExpressionServiceProvider : INameEqualityCondition<SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> is not executed and <see cref="NameExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(original.Parameter, modified.Parameter))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="SimpleLambdaExpressionSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class FromClauseServiceProvider : INameEqualityCondition<FromClauseSyntax, FromClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(FromClauseSyntax original, FromClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(FromClauseSyntax original, FromClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FromClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(FromClauseSyntax, FromClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(FromClauseSyntax original, FromClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="FromClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(FromClauseSyntax original, FromClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class LetClauseServiceProvider : INameEqualityCondition<LetClauseSyntax, LetClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(LetClauseSyntax original, LetClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(LetClauseSyntax original, LetClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LetClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(LetClauseSyntax, LetClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(LetClauseSyntax original, LetClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="LetClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(LetClauseSyntax original, LetClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class JoinClauseServiceProvider : INameEqualityCondition<JoinClauseSyntax, JoinClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/> is not executed and <see cref="NameExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(JoinClauseSyntax original, JoinClauseSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="JoinClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(JoinClauseSyntax, JoinClauseSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(JoinClauseSyntax original, JoinClauseSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="JoinClauseSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(JoinClauseSyntax original, JoinClauseSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class LocalFunctionStatementServiceProvider : INameEqualityCondition<LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="LocalFunctionStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class LocalDeclarationStatementServiceProvider : INameEqualityCondition<LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="LocalDeclarationStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class LabeledStatementServiceProvider : INameEqualityCondition<LabeledStatementSyntax, LabeledStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(LabeledStatementSyntax, LabeledStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(LabeledStatementSyntax original, LabeledStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="LabeledStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(LabeledStatementSyntax original, LabeledStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ForStatementServiceProvider : INameEqualityCondition<ForStatementSyntax, ForStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ForStatementSyntax original, ForStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ForStatementSyntax original, ForStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ForStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ForStatementSyntax, ForStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ForStatementSyntax original, ForStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ForStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ForStatementSyntax original, ForStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class UsingStatementServiceProvider : INameEqualityCondition<UsingStatementSyntax, UsingStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(UsingStatementSyntax original, UsingStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="UsingStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(UsingStatementSyntax, UsingStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(UsingStatementSyntax original, UsingStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (original.Declaration != null && modified.Declaration != null && this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="UsingStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(UsingStatementSyntax original, UsingStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class FixedStatementServiceProvider : INameEqualityCondition<FixedStatementSyntax, FixedStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(FixedStatementSyntax original, FixedStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="FixedStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(FixedStatementSyntax, FixedStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(FixedStatementSyntax original, FixedStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (this.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(original.Declaration, modified.Declaration))
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="FixedStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(FixedStatementSyntax original, FixedStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class ForEachStatementServiceProvider : INameEqualityCondition<ForEachStatementSyntax, ForEachStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/> is not executed and <see cref="NameExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(ForEachStatementSyntax, ForEachStatementSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(ForEachStatementSyntax original, ForEachStatementSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="ForEachStatementSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(ForEachStatementSyntax original, ForEachStatementSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
    public partial class SingleVariableDesignationServiceProvider : INameEqualityCondition<SingleVariableDesignationSyntax, SingleVariableDesignationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="NameExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="NameExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> is not executed and <see cref="NameExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/> returns the current value of <paramref name="result"/>.</param>
        partial void NameExactlyEqualBefore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool result);
    
        /// <summary>
        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="NameExactlyEqual(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.</remarks>
        protected virtual bool NameExactlyEqualCore(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
        {
    		if(original == null || modified == null) 
    			return false;
    
            if (!string.IsNullOrWhiteSpace(original.Identifier.ValueText) && !string.IsNullOrWhiteSpace(modified.Identifier.ValueText) && original.Identifier.ValueText == modified.Identifier.ValueText)
    			return true;
    
    	    return false;
    	}
    
        /// <summary>
        /// Determines if two <see cref="SingleVariableDesignationSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
        {
    		bool result = false, ignoreCore = false;
    		NameExactlyEqualBefore(original, modified, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.NameExactlyEqualCore(original, modified);
    		NameExactlyEqualAfter(original, modified, ref result);
    		return result;
        }
    }
    
}
// Generated helper templates
// Generated items
