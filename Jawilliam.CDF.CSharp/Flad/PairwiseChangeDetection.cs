
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jawilliam.CDF.Approach.Flad;
using Jawilliam.CDF.Approach.Awareness;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Services;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class SyntaxTokenServiceProvider : INameEqualityCondition<SyntaxToken, SyntaxToken>
    {
        
    }
    
    partial class LanguageServiceProvider
    {
    	
    }
    
    partial class AttributeArgumentServiceProvider : IPairwisable<SyntaxNodeOrToken?, AttributeArgumentSyntax, AttributeArgumentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentSyntax original, AttributeArgumentSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentSyntax original, AttributeArgumentSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class NameEqualsServiceProvider : IPairwisable<SyntaxNodeOrToken?, NameEqualsSyntax, NameEqualsSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, NameEqualsSyntax original, NameEqualsSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, NameEqualsSyntax original, NameEqualsSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameEqualsSyntax, NameEqualsSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, NameEqualsSyntax original, NameEqualsSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, NameEqualsSyntax original, NameEqualsSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeParameterListSyntax, TypeParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterListSyntax, TypeParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterListSyntax original, TypeParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterListSyntax, TypeParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeParameterListSyntax original, TypeParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterListSyntax, TypeParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterListSyntax original, TypeParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanToken, modified.LessThanToken);
    		matchingSet.Partners(original.GreaterThanToken, modified.GreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeParameterListSyntax original, TypeParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeParameterServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeParameterSyntax, TypeParameterSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterSyntax original, TypeParameterSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeParameterSyntax original, TypeParameterSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterSyntax, TypeParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterSyntax original, TypeParameterSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeParameterSyntax original, TypeParameterSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseListSyntax, BaseListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseListSyntax, BaseListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseListSyntax original, BaseListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseListSyntax, BaseListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseListSyntax original, BaseListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseListSyntax, BaseListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseListSyntax original, BaseListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseListSyntax original, BaseListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeParameterConstraintClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.WhereKeyword, modified.WhereKeyword);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeParameterConstraintClauseSyntax original, TypeParameterConstraintClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ExplicitInterfaceSpecifierServiceProvider : IPairwisable<SyntaxNodeOrToken?, ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DotToken, modified.DotToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ExplicitInterfaceSpecifierSyntax original, ExplicitInterfaceSpecifierSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConstructorInitializerServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConstructorInitializerSyntax, ConstructorInitializerSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorInitializerSyntax, ConstructorInitializerSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConstructorInitializerSyntax original, ConstructorInitializerSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArrowExpressionClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ArrowToken, modified.ArrowToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArrowExpressionClauseSyntax original, ArrowExpressionClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AccessorListServiceProvider : IPairwisable<SyntaxNodeOrToken?, AccessorListSyntax, AccessorListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorListSyntax, AccessorListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AccessorListSyntax original, AccessorListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorListSyntax, AccessorListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AccessorListSyntax original, AccessorListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorListSyntax, AccessorListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AccessorListSyntax original, AccessorListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AccessorListSyntax original, AccessorListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AccessorDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, AccessorDeclarationSyntax, AccessorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AccessorDeclarationSyntax, AccessorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AccessorDeclarationSyntax original, AccessorDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ParameterServiceProvider : IPairwisable<SyntaxNodeOrToken?, ParameterSyntax, ParameterSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ParameterSyntax original, ParameterSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ParameterSyntax original, ParameterSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterSyntax, ParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ParameterSyntax original, ParameterSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ParameterSyntax original, ParameterSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CrefParameterServiceProvider : IPairwisable<SyntaxNodeOrToken?, CrefParameterSyntax, CrefParameterSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterSyntax, CrefParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CrefParameterSyntax original, CrefParameterSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterSyntax, CrefParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CrefParameterSyntax original, CrefParameterSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterSyntax, CrefParameterSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CrefParameterSyntax original, CrefParameterSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CrefParameterSyntax original, CrefParameterSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlElementStartTagServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlElementStartTagSyntax, XmlElementStartTagSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementStartTagSyntax, XmlElementStartTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanToken, modified.LessThanToken);
    		matchingSet.Partners(original.GreaterThanToken, modified.GreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlElementStartTagSyntax original, XmlElementStartTagSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlElementEndTagServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlElementEndTagSyntax, XmlElementEndTagSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementEndTagSyntax, XmlElementEndTagSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanSlashToken, modified.LessThanSlashToken);
    		matchingSet.Partners(original.GreaterThanToken, modified.GreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlElementEndTagSyntax original, XmlElementEndTagSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlNameSyntax, XmlNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlNameSyntax original, XmlNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlNameSyntax original, XmlNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameSyntax, XmlNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlNameSyntax original, XmlNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlNameSyntax original, XmlNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlPrefixServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlPrefixSyntax, XmlPrefixSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlPrefixSyntax original, XmlPrefixSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlPrefixSyntax original, XmlPrefixSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlPrefixSyntax, XmlPrefixSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlPrefixSyntax original, XmlPrefixSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlPrefixSyntax original, XmlPrefixSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeArgumentListServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeArgumentListSyntax, TypeArgumentListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeArgumentListSyntax original, TypeArgumentListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeArgumentListSyntax original, TypeArgumentListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeArgumentListSyntax, TypeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanToken, modified.LessThanToken);
    		matchingSet.Partners(original.GreaterThanToken, modified.GreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeArgumentListSyntax original, TypeArgumentListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArrayRankSpecifierServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArrayRankSpecifierSyntax original, ArrayRankSpecifierSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TupleElementServiceProvider : IPairwisable<SyntaxNodeOrToken?, TupleElementSyntax, TupleElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TupleElementSyntax original, TupleElementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TupleElementSyntax original, TupleElementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleElementSyntax, TupleElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TupleElementSyntax original, TupleElementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TupleElementSyntax original, TupleElementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArgumentServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArgumentSyntax, ArgumentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArgumentSyntax original, ArgumentSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArgumentSyntax original, ArgumentSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentSyntax, ArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArgumentSyntax original, ArgumentSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArgumentSyntax original, ArgumentSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class NameColonServiceProvider : IPairwisable<SyntaxNodeOrToken?, NameColonSyntax, NameColonSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, NameColonSyntax original, NameColonSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, NameColonSyntax original, NameColonSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameColonSyntax, NameColonSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, NameColonSyntax original, NameColonSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, NameColonSyntax original, NameColonSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AnonymousObjectMemberDeclaratorServiceProvider : IPairwisable<SyntaxNodeOrToken?, AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectMemberDeclaratorSyntax original, AnonymousObjectMemberDeclaratorSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class QueryBodyServiceProvider : IPairwisable<SyntaxNodeOrToken?, QueryBodySyntax, QueryBodySyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, QueryBodySyntax original, QueryBodySyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, QueryBodySyntax original, QueryBodySyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryBodySyntax, QueryBodySyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, QueryBodySyntax original, QueryBodySyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, QueryBodySyntax original, QueryBodySyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class JoinIntoClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, JoinIntoClauseSyntax, JoinIntoClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinIntoClauseSyntax, JoinIntoClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.IntoKeyword, modified.IntoKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, JoinIntoClauseSyntax original, JoinIntoClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OrderingServiceProvider : IPairwisable<SyntaxNodeOrToken?, OrderingSyntax, OrderingSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderingSyntax, OrderingSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OrderingSyntax original, OrderingSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderingSyntax, OrderingSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OrderingSyntax original, OrderingSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderingSyntax, OrderingSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OrderingSyntax original, OrderingSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.AscendingOrDescendingKeyword, modified.AscendingOrDescendingKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OrderingSyntax original, OrderingSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class QueryContinuationServiceProvider : IPairwisable<SyntaxNodeOrToken?, QueryContinuationSyntax, QueryContinuationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, QueryContinuationSyntax original, QueryContinuationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, QueryContinuationSyntax original, QueryContinuationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryContinuationSyntax, QueryContinuationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, QueryContinuationSyntax original, QueryContinuationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.IntoKeyword, modified.IntoKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, QueryContinuationSyntax original, QueryContinuationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class WhenClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, WhenClauseSyntax, WhenClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhenClauseSyntax, WhenClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, WhenClauseSyntax original, WhenClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhenClauseSyntax, WhenClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, WhenClauseSyntax original, WhenClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhenClauseSyntax, WhenClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, WhenClauseSyntax original, WhenClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.WhenKeyword, modified.WhenKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, WhenClauseSyntax original, WhenClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterpolationAlignmentClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.CommaToken, modified.CommaToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterpolationAlignmentClauseSyntax original, InterpolationAlignmentClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterpolationFormatClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    		matchingSet.Partners(original.FormatStringToken, modified.FormatStringToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterpolationFormatClauseSyntax original, InterpolationFormatClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class VariableDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, VariableDeclarationSyntax, VariableDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, VariableDeclarationSyntax original, VariableDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, VariableDeclarationSyntax original, VariableDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclarationSyntax, VariableDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, VariableDeclarationSyntax original, VariableDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class VariableDeclaratorServiceProvider : IPairwisable<SyntaxNodeOrToken?, VariableDeclaratorSyntax, VariableDeclaratorSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, VariableDeclaratorSyntax, VariableDeclaratorSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, VariableDeclaratorSyntax original, VariableDeclaratorSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EqualsValueClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, EqualsValueClauseSyntax, EqualsValueClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EqualsValueClauseSyntax, EqualsValueClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EqualsValueClauseSyntax original, EqualsValueClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ElseClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, ElseClauseSyntax, ElseClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseClauseSyntax, ElseClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ElseClauseSyntax original, ElseClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseClauseSyntax, ElseClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ElseClauseSyntax original, ElseClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseClauseSyntax, ElseClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ElseClauseSyntax original, ElseClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ElseKeyword, modified.ElseKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ElseClauseSyntax original, ElseClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SwitchSectionServiceProvider : IPairwisable<SyntaxNodeOrToken?, SwitchSectionSyntax, SwitchSectionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchSectionSyntax, SwitchSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SwitchSectionSyntax original, SwitchSectionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchSectionSyntax, SwitchSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SwitchSectionSyntax original, SwitchSectionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchSectionSyntax, SwitchSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SwitchSectionSyntax original, SwitchSectionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SwitchSectionSyntax original, SwitchSectionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CatchClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, CatchClauseSyntax, CatchClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CatchClauseSyntax original, CatchClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CatchClauseSyntax original, CatchClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchClauseSyntax, CatchClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CatchClauseSyntax original, CatchClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.CatchKeyword, modified.CatchKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CatchClauseSyntax original, CatchClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CatchDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, CatchDeclarationSyntax, CatchDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CatchDeclarationSyntax original, CatchDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CatchDeclarationSyntax original, CatchDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchDeclarationSyntax, CatchDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CatchDeclarationSyntax original, CatchDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CatchFilterClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, CatchFilterClauseSyntax, CatchFilterClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CatchFilterClauseSyntax, CatchFilterClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.WhenKeyword, modified.WhenKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CatchFilterClauseSyntax original, CatchFilterClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class FinallyClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, FinallyClauseSyntax, FinallyClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FinallyClauseSyntax, FinallyClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, FinallyClauseSyntax original, FinallyClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FinallyClauseSyntax, FinallyClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, FinallyClauseSyntax original, FinallyClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FinallyClauseSyntax, FinallyClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, FinallyClauseSyntax original, FinallyClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.FinallyKeyword, modified.FinallyKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, FinallyClauseSyntax original, FinallyClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CompilationUnitServiceProvider : IPairwisable<SyntaxNodeOrToken?, CompilationUnitSyntax, CompilationUnitSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CompilationUnitSyntax, CompilationUnitSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CompilationUnitSyntax original, CompilationUnitSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CompilationUnitSyntax, CompilationUnitSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CompilationUnitSyntax original, CompilationUnitSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CompilationUnitSyntax, CompilationUnitSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CompilationUnitSyntax original, CompilationUnitSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EndOfFileToken, modified.EndOfFileToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CompilationUnitSyntax original, CompilationUnitSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ExternAliasDirectiveServiceProvider : IPairwisable<SyntaxNodeOrToken?, ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ExternKeyword, modified.ExternKeyword);
    		matchingSet.Partners(original.AliasKeyword, modified.AliasKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ExternAliasDirectiveSyntax original, ExternAliasDirectiveSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class UsingDirectiveServiceProvider : IPairwisable<SyntaxNodeOrToken?, UsingDirectiveSyntax, UsingDirectiveSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, UsingDirectiveSyntax original, UsingDirectiveSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, UsingDirectiveSyntax original, UsingDirectiveSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingDirectiveSyntax, UsingDirectiveSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.UsingKeyword, modified.UsingKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, UsingDirectiveSyntax original, UsingDirectiveSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AttributeListServiceProvider : IPairwisable<SyntaxNodeOrToken?, AttributeListSyntax, AttributeListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AttributeListSyntax original, AttributeListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AttributeListSyntax original, AttributeListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeListSyntax, AttributeListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AttributeListSyntax original, AttributeListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AttributeListSyntax original, AttributeListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AttributeTargetSpecifierServiceProvider : IPairwisable<SyntaxNodeOrToken?, AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AttributeTargetSpecifierSyntax original, AttributeTargetSpecifierSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AttributeServiceProvider : IPairwisable<SyntaxNodeOrToken?, AttributeSyntax, AttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AttributeSyntax original, AttributeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AttributeSyntax original, AttributeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeSyntax, AttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AttributeSyntax original, AttributeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AttributeSyntax original, AttributeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AttributeArgumentListServiceProvider : IPairwisable<SyntaxNodeOrToken?, AttributeArgumentListSyntax, AttributeArgumentListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AttributeArgumentListSyntax, AttributeArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AttributeArgumentListSyntax original, AttributeArgumentListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DelegateDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, DelegateDeclarationSyntax, DelegateDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DelegateDeclarationSyntax, DelegateDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DelegateKeyword, modified.DelegateKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DelegateDeclarationSyntax original, DelegateDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EnumMemberDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EnumMemberDeclarationSyntax original, EnumMemberDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IncompleteMemberServiceProvider : IPairwisable<SyntaxNodeOrToken?, IncompleteMemberSyntax, IncompleteMemberSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IncompleteMemberSyntax original, IncompleteMemberSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IncompleteMemberSyntax original, IncompleteMemberSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IncompleteMemberSyntax, IncompleteMemberSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IncompleteMemberSyntax original, IncompleteMemberSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class GlobalStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, GlobalStatementSyntax, GlobalStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GlobalStatementSyntax, GlobalStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, GlobalStatementSyntax original, GlobalStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GlobalStatementSyntax, GlobalStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, GlobalStatementSyntax original, GlobalStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GlobalStatementSyntax, GlobalStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, GlobalStatementSyntax original, GlobalStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, GlobalStatementSyntax original, GlobalStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class NamespaceDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, NamespaceDeclarationSyntax, NamespaceDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NamespaceKeyword, modified.NamespaceKeyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, NamespaceDeclarationSyntax original, NamespaceDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EnumDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, EnumDeclarationSyntax, EnumDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EnumDeclarationSyntax original, EnumDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EnumDeclarationSyntax original, EnumDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EnumDeclarationSyntax, EnumDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EnumKeyword, modified.EnumKeyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EnumDeclarationSyntax original, EnumDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ClassDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, ClassDeclarationSyntax, ClassDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ClassDeclarationSyntax original, ClassDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ClassDeclarationSyntax original, ClassDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassDeclarationSyntax, ClassDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ClassDeclarationSyntax original, ClassDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class StructDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, StructDeclarationSyntax, StructDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, StructDeclarationSyntax original, StructDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StructDeclarationSyntax, StructDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, StructDeclarationSyntax original, StructDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, StructDeclarationSyntax original, StructDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterfaceDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterfaceDeclarationSyntax original, InterfaceDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeDeclarationSyntax, TypeDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeDeclarationSyntax, TypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeDeclarationSyntax original, TypeDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeDeclarationSyntax, TypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeDeclarationSyntax original, TypeDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeDeclarationSyntax, TypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeDeclarationSyntax original, TypeDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeDeclarationSyntax original, TypeDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseTypeDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseTypeDeclarationSyntax, BaseTypeDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeDeclarationSyntax, BaseTypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseTypeDeclarationSyntax original, BaseTypeDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeDeclarationSyntax, BaseTypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseTypeDeclarationSyntax original, BaseTypeDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeDeclarationSyntax, BaseTypeDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseTypeDeclarationSyntax original, BaseTypeDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseTypeDeclarationSyntax original, BaseTypeDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class FieldDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, FieldDeclarationSyntax, FieldDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, FieldDeclarationSyntax original, FieldDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, FieldDeclarationSyntax original, FieldDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FieldDeclarationSyntax, FieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, FieldDeclarationSyntax original, FieldDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EventFieldDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, EventFieldDeclarationSyntax, EventFieldDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EventKeyword, modified.EventKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EventFieldDeclarationSyntax original, EventFieldDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseFieldDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseFieldDeclarationSyntax, BaseFieldDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseFieldDeclarationSyntax, BaseFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseFieldDeclarationSyntax original, BaseFieldDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseFieldDeclarationSyntax, BaseFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseFieldDeclarationSyntax original, BaseFieldDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseFieldDeclarationSyntax, BaseFieldDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseFieldDeclarationSyntax original, BaseFieldDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseFieldDeclarationSyntax original, BaseFieldDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class MethodDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, MethodDeclarationSyntax, MethodDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, MethodDeclarationSyntax original, MethodDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, MethodDeclarationSyntax original, MethodDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MethodDeclarationSyntax, MethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, MethodDeclarationSyntax original, MethodDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OperatorDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, OperatorDeclarationSyntax, OperatorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorDeclarationSyntax, OperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorKeyword, modified.OperatorKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OperatorDeclarationSyntax original, OperatorDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConversionOperatorDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorKeyword, modified.OperatorKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorDeclarationSyntax original, ConversionOperatorDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConstructorDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConstructorDeclarationSyntax original, ConstructorDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DestructorDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, DestructorDeclarationSyntax, DestructorDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DestructorDeclarationSyntax, DestructorDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.TildeToken, modified.TildeToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DestructorDeclarationSyntax original, DestructorDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseMethodDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseMethodDeclarationSyntax, BaseMethodDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseMethodDeclarationSyntax, BaseMethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseMethodDeclarationSyntax original, BaseMethodDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseMethodDeclarationSyntax, BaseMethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseMethodDeclarationSyntax original, BaseMethodDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseMethodDeclarationSyntax, BaseMethodDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseMethodDeclarationSyntax original, BaseMethodDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseMethodDeclarationSyntax original, BaseMethodDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PropertyDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, PropertyDeclarationSyntax, PropertyDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PropertyDeclarationSyntax, PropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PropertyDeclarationSyntax original, PropertyDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EventDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, EventDeclarationSyntax, EventDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EventDeclarationSyntax original, EventDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EventDeclarationSyntax original, EventDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EventDeclarationSyntax, EventDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EventDeclarationSyntax original, EventDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EventKeyword, modified.EventKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EventDeclarationSyntax original, EventDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IndexerDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, IndexerDeclarationSyntax, IndexerDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerDeclarationSyntax, IndexerDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ThisKeyword, modified.ThisKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IndexerDeclarationSyntax original, IndexerDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BasePropertyDeclarationServiceProvider : IPairwisable<SyntaxNodeOrToken?, BasePropertyDeclarationSyntax, BasePropertyDeclarationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BasePropertyDeclarationSyntax, BasePropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BasePropertyDeclarationSyntax original, BasePropertyDeclarationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BasePropertyDeclarationSyntax, BasePropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BasePropertyDeclarationSyntax original, BasePropertyDeclarationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BasePropertyDeclarationSyntax, BasePropertyDeclarationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BasePropertyDeclarationSyntax original, BasePropertyDeclarationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BasePropertyDeclarationSyntax original, BasePropertyDeclarationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SimpleBaseTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, SimpleBaseTypeSyntax, SimpleBaseTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SimpleBaseTypeSyntax original, SimpleBaseTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseTypeSyntax, BaseTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeSyntax, BaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseTypeSyntax original, BaseTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeSyntax, BaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseTypeSyntax original, BaseTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseTypeSyntax, BaseTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseTypeSyntax original, BaseTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseTypeSyntax original, BaseTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConstructorConstraintServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConstructorConstraintSyntax, ConstructorConstraintSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstructorConstraintSyntax, ConstructorConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NewKeyword, modified.NewKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConstructorConstraintSyntax original, ConstructorConstraintSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ClassOrStructConstraintServiceProvider : IPairwisable<SyntaxNodeOrToken?, ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ClassOrStructConstraintSyntax original, ClassOrStructConstraintSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeConstraintServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeConstraintSyntax, TypeConstraintSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeConstraintSyntax, TypeConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeConstraintSyntax original, TypeConstraintSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeConstraintSyntax, TypeConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeConstraintSyntax original, TypeConstraintSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeConstraintSyntax, TypeConstraintSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeConstraintSyntax original, TypeConstraintSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeConstraintSyntax original, TypeConstraintSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, ParameterListSyntax, ParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterListSyntax, ParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ParameterListSyntax original, ParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterListSyntax, ParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ParameterListSyntax original, ParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParameterListSyntax, ParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ParameterListSyntax original, ParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ParameterListSyntax original, ParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BracketedParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BracketedParameterListSyntax, BracketedParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BracketedParameterListSyntax original, BracketedParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BracketedParameterListSyntax original, BracketedParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedParameterListSyntax, BracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BracketedParameterListSyntax original, BracketedParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseParameterListSyntax, BaseParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseParameterListSyntax, BaseParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseParameterListSyntax original, BaseParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseParameterListSyntax, BaseParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseParameterListSyntax original, BaseParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseParameterListSyntax, BaseParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseParameterListSyntax original, BaseParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseParameterListSyntax original, BaseParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SkippedTokensTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SkippedTokensTriviaSyntax original, SkippedTokensTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DocumentationCommentTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EndOfComment, modified.EndOfComment);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DocumentationCommentTriviaSyntax original, DocumentationCommentTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EndIfDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.EndIfKeyword, modified.EndIfKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EndIfDirectiveTriviaSyntax original, EndIfDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class RegionDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.RegionKeyword, modified.RegionKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, RegionDirectiveTriviaSyntax original, RegionDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EndRegionDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.EndRegionKeyword, modified.EndRegionKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EndRegionDirectiveTriviaSyntax original, EndRegionDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ErrorDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.ErrorKeyword, modified.ErrorKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ErrorDirectiveTriviaSyntax original, ErrorDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class WarningDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.WarningKeyword, modified.WarningKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, WarningDirectiveTriviaSyntax original, WarningDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BadDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BadDirectiveTriviaSyntax original, BadDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DefineDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.DefineKeyword, modified.DefineKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DefineDirectiveTriviaSyntax original, DefineDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class UndefDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.UndefKeyword, modified.UndefKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, UndefDirectiveTriviaSyntax original, UndefDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LineDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.LineKeyword, modified.LineKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LineDirectiveTriviaSyntax original, LineDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PragmaWarningDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.PragmaKeyword, modified.PragmaKeyword);
    		matchingSet.Partners(original.WarningKeyword, modified.WarningKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PragmaWarningDirectiveTriviaSyntax original, PragmaWarningDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PragmaChecksumDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.PragmaKeyword, modified.PragmaKeyword);
    		matchingSet.Partners(original.ChecksumKeyword, modified.ChecksumKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PragmaChecksumDirectiveTriviaSyntax original, PragmaChecksumDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ReferenceDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.ReferenceKeyword, modified.ReferenceKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ReferenceDirectiveTriviaSyntax original, ReferenceDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LoadDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.LoadKeyword, modified.LoadKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LoadDirectiveTriviaSyntax original, LoadDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ShebangDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.ExclamationToken, modified.ExclamationToken);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ShebangDirectiveTriviaSyntax original, ShebangDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ElseDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.ElseKeyword, modified.ElseKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ElseDirectiveTriviaSyntax original, ElseDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IfDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.IfKeyword, modified.IfKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IfDirectiveTriviaSyntax original, IfDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ElifDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.ElifKeyword, modified.ElifKeyword);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ElifDirectiveTriviaSyntax original, ElifDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConditionalDirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConditionalDirectiveTriviaSyntax, ConditionalDirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalDirectiveTriviaSyntax, ConditionalDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConditionalDirectiveTriviaSyntax original, ConditionalDirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalDirectiveTriviaSyntax, ConditionalDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConditionalDirectiveTriviaSyntax original, ConditionalDirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalDirectiveTriviaSyntax, ConditionalDirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConditionalDirectiveTriviaSyntax original, ConditionalDirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConditionalDirectiveTriviaSyntax original, ConditionalDirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DirectiveTriviaServiceProvider : IPairwisable<SyntaxNodeOrToken?, DirectiveTriviaSyntax, DirectiveTriviaSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DirectiveTriviaSyntax, DirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DirectiveTriviaSyntax original, DirectiveTriviaSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DirectiveTriviaSyntax, DirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DirectiveTriviaSyntax original, DirectiveTriviaSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DirectiveTriviaSyntax, DirectiveTriviaSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DirectiveTriviaSyntax original, DirectiveTriviaSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.HashToken, modified.HashToken);
    		matchingSet.Partners(original.EndOfDirectiveToken, modified.EndOfDirectiveToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DirectiveTriviaSyntax original, DirectiveTriviaSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeCrefSyntax, TypeCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeCrefSyntax, TypeCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeCrefSyntax original, TypeCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeCrefSyntax, TypeCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeCrefSyntax original, TypeCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeCrefSyntax, TypeCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeCrefSyntax original, TypeCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeCrefSyntax original, TypeCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class QualifiedCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, QualifiedCrefSyntax, QualifiedCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, QualifiedCrefSyntax original, QualifiedCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, QualifiedCrefSyntax original, QualifiedCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedCrefSyntax, QualifiedCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DotToken, modified.DotToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, QualifiedCrefSyntax original, QualifiedCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class NameMemberCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, NameMemberCrefSyntax, NameMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, NameMemberCrefSyntax original, NameMemberCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, NameMemberCrefSyntax original, NameMemberCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NameMemberCrefSyntax, NameMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, NameMemberCrefSyntax original, NameMemberCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IndexerMemberCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ThisKeyword, modified.ThisKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IndexerMemberCrefSyntax original, IndexerMemberCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OperatorMemberCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorKeyword, modified.OperatorKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OperatorMemberCrefSyntax original, OperatorMemberCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConversionOperatorMemberCrefServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorKeyword, modified.OperatorKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConversionOperatorMemberCrefSyntax original, ConversionOperatorMemberCrefSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CrefParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, CrefParameterListSyntax, CrefParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterListSyntax, CrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CrefParameterListSyntax original, CrefParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterListSyntax, CrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CrefParameterListSyntax original, CrefParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefParameterListSyntax, CrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CrefParameterListSyntax original, CrefParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CrefParameterListSyntax original, CrefParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CrefBracketedParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CrefBracketedParameterListSyntax original, CrefBracketedParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseCrefParameterListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseCrefParameterListSyntax, BaseCrefParameterListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseCrefParameterListSyntax, BaseCrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseCrefParameterListSyntax original, BaseCrefParameterListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseCrefParameterListSyntax, BaseCrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseCrefParameterListSyntax original, BaseCrefParameterListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseCrefParameterListSyntax, BaseCrefParameterListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseCrefParameterListSyntax original, BaseCrefParameterListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseCrefParameterListSyntax original, BaseCrefParameterListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlElementServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlElementSyntax, XmlElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlElementSyntax original, XmlElementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlElementSyntax original, XmlElementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlElementSyntax, XmlElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlElementSyntax original, XmlElementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlElementSyntax original, XmlElementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlEmptyElementServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlEmptyElementSyntax, XmlEmptyElementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlEmptyElementSyntax, XmlEmptyElementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanToken, modified.LessThanToken);
    		matchingSet.Partners(original.SlashGreaterThanToken, modified.SlashGreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlEmptyElementSyntax original, XmlEmptyElementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlTextServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlTextSyntax, XmlTextSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextSyntax, XmlTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlTextSyntax original, XmlTextSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextSyntax, XmlTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlTextSyntax original, XmlTextSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextSyntax, XmlTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlTextSyntax original, XmlTextSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlTextSyntax original, XmlTextSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlCDataSectionServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlCDataSectionSyntax, XmlCDataSectionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCDataSectionSyntax, XmlCDataSectionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.StartCDataToken, modified.StartCDataToken);
    		matchingSet.Partners(original.EndCDataToken, modified.EndCDataToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlCDataSectionSyntax original, XmlCDataSectionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlProcessingInstructionServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.StartProcessingInstructionToken, modified.StartProcessingInstructionToken);
    		matchingSet.Partners(original.EndProcessingInstructionToken, modified.EndProcessingInstructionToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlProcessingInstructionSyntax original, XmlProcessingInstructionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlCommentServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlCommentSyntax, XmlCommentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCommentSyntax, XmlCommentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlCommentSyntax original, XmlCommentSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCommentSyntax, XmlCommentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlCommentSyntax original, XmlCommentSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCommentSyntax, XmlCommentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlCommentSyntax original, XmlCommentSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LessThanExclamationMinusMinusToken, modified.LessThanExclamationMinusMinusToken);
    		matchingSet.Partners(original.MinusMinusGreaterThanToken, modified.MinusMinusGreaterThanToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlCommentSyntax original, XmlCommentSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlTextAttributeServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlTextAttributeSyntax, XmlTextAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlTextAttributeSyntax, XmlTextAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    		matchingSet.Partners(original.StartQuoteToken, modified.StartQuoteToken);
    		matchingSet.Partners(original.EndQuoteToken, modified.EndQuoteToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlTextAttributeSyntax original, XmlTextAttributeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlCrefAttributeServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlCrefAttributeSyntax, XmlCrefAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    		matchingSet.Partners(original.StartQuoteToken, modified.StartQuoteToken);
    		matchingSet.Partners(original.EndQuoteToken, modified.EndQuoteToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlCrefAttributeSyntax original, XmlCrefAttributeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlNameAttributeServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlNameAttributeSyntax, XmlNameAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlNameAttributeSyntax, XmlNameAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    		matchingSet.Partners(original.StartQuoteToken, modified.StartQuoteToken);
    		matchingSet.Partners(original.EndQuoteToken, modified.EndQuoteToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlNameAttributeSyntax original, XmlNameAttributeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class XmlAttributeServiceProvider : IPairwisable<SyntaxNodeOrToken?, XmlAttributeSyntax, XmlAttributeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlAttributeSyntax, XmlAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, XmlAttributeSyntax original, XmlAttributeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlAttributeSyntax, XmlAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, XmlAttributeSyntax original, XmlAttributeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, XmlAttributeSyntax, XmlAttributeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, XmlAttributeSyntax original, XmlAttributeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    		matchingSet.Partners(original.StartQuoteToken, modified.StartQuoteToken);
    		matchingSet.Partners(original.EndQuoteToken, modified.EndQuoteToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, XmlAttributeSyntax original, XmlAttributeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ParenthesizedExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedExpressionSyntax original, ParenthesizedExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TupleExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, TupleExpressionSyntax, TupleExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleExpressionSyntax, TupleExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TupleExpressionSyntax original, TupleExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleExpressionSyntax, TupleExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TupleExpressionSyntax original, TupleExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleExpressionSyntax, TupleExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TupleExpressionSyntax original, TupleExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TupleExpressionSyntax original, TupleExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PrefixUnaryExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PrefixUnaryExpressionSyntax original, PrefixUnaryExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AwaitExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, AwaitExpressionSyntax, AwaitExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AwaitExpressionSyntax original, AwaitExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AwaitExpressionSyntax original, AwaitExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AwaitExpressionSyntax, AwaitExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.AwaitKeyword, modified.AwaitKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AwaitExpressionSyntax original, AwaitExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PostfixUnaryExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PostfixUnaryExpressionSyntax original, PostfixUnaryExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class MemberAccessExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorToken, modified.OperatorToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConditionalAccessExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorToken, modified.OperatorToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConditionalAccessExpressionSyntax original, ConditionalAccessExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class MemberBindingExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, MemberBindingExpressionSyntax, MemberBindingExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OperatorToken, modified.OperatorToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, MemberBindingExpressionSyntax original, MemberBindingExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ElementBindingExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ElementBindingExpressionSyntax, ElementBindingExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ElementBindingExpressionSyntax original, ElementBindingExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ImplicitElementAccessServiceProvider : IPairwisable<SyntaxNodeOrToken?, ImplicitElementAccessSyntax, ImplicitElementAccessSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ImplicitElementAccessSyntax original, ImplicitElementAccessSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BinaryExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, BinaryExpressionSyntax, BinaryExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BinaryExpressionSyntax original, BinaryExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BinaryExpressionSyntax original, BinaryExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BinaryExpressionSyntax, BinaryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BinaryExpressionSyntax original, BinaryExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AssignmentExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, AssignmentExpressionSyntax, AssignmentExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AssignmentExpressionSyntax, AssignmentExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AssignmentExpressionSyntax original, AssignmentExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConditionalExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConditionalExpressionSyntax, ConditionalExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConditionalExpressionSyntax, ConditionalExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.QuestionToken, modified.QuestionToken);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConditionalExpressionSyntax original, ConditionalExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LiteralExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, LiteralExpressionSyntax, LiteralExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LiteralExpressionSyntax original, LiteralExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LiteralExpressionSyntax original, LiteralExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LiteralExpressionSyntax, LiteralExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LiteralExpressionSyntax original, LiteralExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class MakeRefExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, MakeRefExpressionSyntax, MakeRefExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, MakeRefExpressionSyntax, MakeRefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, MakeRefExpressionSyntax original, MakeRefExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class RefTypeExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, RefTypeExpressionSyntax, RefTypeExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeExpressionSyntax, RefTypeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, RefTypeExpressionSyntax original, RefTypeExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class RefValueExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, RefValueExpressionSyntax, RefValueExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, RefValueExpressionSyntax original, RefValueExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, RefValueExpressionSyntax original, RefValueExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefValueExpressionSyntax, RefValueExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.Comma, modified.Comma);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, RefValueExpressionSyntax original, RefValueExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CheckedExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, CheckedExpressionSyntax, CheckedExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CheckedExpressionSyntax original, CheckedExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CheckedExpressionSyntax original, CheckedExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedExpressionSyntax, CheckedExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CheckedExpressionSyntax original, CheckedExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DefaultExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, DefaultExpressionSyntax, DefaultExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DefaultExpressionSyntax original, DefaultExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DefaultExpressionSyntax original, DefaultExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultExpressionSyntax, DefaultExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DefaultExpressionSyntax original, DefaultExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TypeOfExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, TypeOfExpressionSyntax, TypeOfExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TypeOfExpressionSyntax, TypeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TypeOfExpressionSyntax original, TypeOfExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SizeOfExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, SizeOfExpressionSyntax, SizeOfExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SizeOfExpressionSyntax, SizeOfExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SizeOfExpressionSyntax original, SizeOfExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InvocationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, InvocationExpressionSyntax, InvocationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InvocationExpressionSyntax original, InvocationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InvocationExpressionSyntax original, InvocationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InvocationExpressionSyntax, InvocationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InvocationExpressionSyntax original, InvocationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ElementAccessExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ElementAccessExpressionSyntax, ElementAccessExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ElementAccessExpressionSyntax original, ElementAccessExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DeclarationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, DeclarationExpressionSyntax, DeclarationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationExpressionSyntax, DeclarationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DeclarationExpressionSyntax original, DeclarationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CastExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, CastExpressionSyntax, CastExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CastExpressionSyntax, CastExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CastExpressionSyntax original, CastExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CastExpressionSyntax, CastExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CastExpressionSyntax original, CastExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CastExpressionSyntax, CastExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CastExpressionSyntax original, CastExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CastExpressionSyntax original, CastExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class RefExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, RefExpressionSyntax, RefExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefExpressionSyntax, RefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, RefExpressionSyntax original, RefExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefExpressionSyntax, RefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, RefExpressionSyntax original, RefExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefExpressionSyntax, RefExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, RefExpressionSyntax original, RefExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.RefKeyword, modified.RefKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, RefExpressionSyntax original, RefExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InitializerExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, InitializerExpressionSyntax, InitializerExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InitializerExpressionSyntax original, InitializerExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InitializerExpressionSyntax original, InitializerExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InitializerExpressionSyntax, InitializerExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InitializerExpressionSyntax original, InitializerExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ObjectCreationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NewKeyword, modified.NewKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ObjectCreationExpressionSyntax original, ObjectCreationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AnonymousObjectCreationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NewKeyword, modified.NewKeyword);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AnonymousObjectCreationExpressionSyntax original, AnonymousObjectCreationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArrayCreationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NewKeyword, modified.NewKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArrayCreationExpressionSyntax original, ArrayCreationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ImplicitArrayCreationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.NewKeyword, modified.NewKeyword);
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ImplicitArrayCreationExpressionSyntax original, ImplicitArrayCreationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class StackAllocArrayCreationExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.StackAllocKeyword, modified.StackAllocKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, StackAllocArrayCreationExpressionSyntax original, StackAllocArrayCreationExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class QueryExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, QueryExpressionSyntax, QueryExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, QueryExpressionSyntax original, QueryExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, QueryExpressionSyntax original, QueryExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QueryExpressionSyntax, QueryExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, QueryExpressionSyntax original, QueryExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, QueryExpressionSyntax original, QueryExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OmittedArraySizeExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OmittedArraySizeExpressionToken, modified.OmittedArraySizeExpressionToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OmittedArraySizeExpressionSyntax original, OmittedArraySizeExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterpolatedStringExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.StringStartToken, modified.StringStartToken);
    		matchingSet.Partners(original.StringEndToken, modified.StringEndToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringExpressionSyntax original, InterpolatedStringExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IsPatternExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, IsPatternExpressionSyntax, IsPatternExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IsPatternExpressionSyntax, IsPatternExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.IsKeyword, modified.IsKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IsPatternExpressionSyntax original, IsPatternExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ThrowExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ThrowExpressionSyntax, ThrowExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ThrowExpressionSyntax original, ThrowExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ThrowExpressionSyntax original, ThrowExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowExpressionSyntax, ThrowExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ThrowKeyword, modified.ThrowKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ThrowExpressionSyntax original, ThrowExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PredefinedTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, PredefinedTypeSyntax, PredefinedTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PredefinedTypeSyntax original, PredefinedTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PredefinedTypeSyntax original, PredefinedTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PredefinedTypeSyntax, PredefinedTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PredefinedTypeSyntax original, PredefinedTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArrayTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArrayTypeSyntax, ArrayTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayTypeSyntax, ArrayTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArrayTypeSyntax original, ArrayTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayTypeSyntax, ArrayTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArrayTypeSyntax original, ArrayTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArrayTypeSyntax, ArrayTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArrayTypeSyntax original, ArrayTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArrayTypeSyntax original, ArrayTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class PointerTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, PointerTypeSyntax, PointerTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PointerTypeSyntax, PointerTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, PointerTypeSyntax original, PointerTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PointerTypeSyntax, PointerTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, PointerTypeSyntax original, PointerTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, PointerTypeSyntax, PointerTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, PointerTypeSyntax original, PointerTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.AsteriskToken, modified.AsteriskToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, PointerTypeSyntax original, PointerTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class NullableTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, NullableTypeSyntax, NullableTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NullableTypeSyntax, NullableTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, NullableTypeSyntax original, NullableTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NullableTypeSyntax, NullableTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, NullableTypeSyntax original, NullableTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, NullableTypeSyntax, NullableTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, NullableTypeSyntax original, NullableTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.QuestionToken, modified.QuestionToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, NullableTypeSyntax original, NullableTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TupleTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, TupleTypeSyntax, TupleTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleTypeSyntax, TupleTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TupleTypeSyntax original, TupleTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleTypeSyntax, TupleTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TupleTypeSyntax original, TupleTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TupleTypeSyntax, TupleTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TupleTypeSyntax original, TupleTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TupleTypeSyntax original, TupleTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OmittedTypeArgumentServiceProvider : IPairwisable<SyntaxNodeOrToken?, OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OmittedTypeArgumentToken, modified.OmittedTypeArgumentToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class RefTypeServiceProvider : IPairwisable<SyntaxNodeOrToken?, RefTypeSyntax, RefTypeSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeSyntax, RefTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, RefTypeSyntax original, RefTypeSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeSyntax, RefTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, RefTypeSyntax original, RefTypeSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, RefTypeSyntax, RefTypeSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, RefTypeSyntax original, RefTypeSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.RefKeyword, modified.RefKeyword);
    		matchingSet.Partners(original.ReadOnlyKeyword, modified.ReadOnlyKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, RefTypeSyntax original, RefTypeSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class QualifiedNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, QualifiedNameSyntax, QualifiedNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedNameSyntax, QualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, QualifiedNameSyntax original, QualifiedNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedNameSyntax, QualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, QualifiedNameSyntax original, QualifiedNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, QualifiedNameSyntax, QualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, QualifiedNameSyntax original, QualifiedNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DotToken, modified.DotToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, QualifiedNameSyntax original, QualifiedNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AliasQualifiedNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, AliasQualifiedNameSyntax, AliasQualifiedNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonColonToken, modified.ColonColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AliasQualifiedNameSyntax original, AliasQualifiedNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IdentifierNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, IdentifierNameSyntax, IdentifierNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IdentifierNameSyntax original, IdentifierNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IdentifierNameSyntax original, IdentifierNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IdentifierNameSyntax, IdentifierNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IdentifierNameSyntax original, IdentifierNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IdentifierNameSyntax original, IdentifierNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class GenericNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, GenericNameSyntax, GenericNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, GenericNameSyntax original, GenericNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, GenericNameSyntax original, GenericNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GenericNameSyntax, GenericNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, GenericNameSyntax original, GenericNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, GenericNameSyntax original, GenericNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SimpleNameServiceProvider : IPairwisable<SyntaxNodeOrToken?, SimpleNameSyntax, SimpleNameSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleNameSyntax, SimpleNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SimpleNameSyntax original, SimpleNameSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleNameSyntax, SimpleNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SimpleNameSyntax original, SimpleNameSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleNameSyntax, SimpleNameSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SimpleNameSyntax original, SimpleNameSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SimpleNameSyntax original, SimpleNameSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ThisExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ThisExpressionSyntax, ThisExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThisExpressionSyntax, ThisExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ThisExpressionSyntax original, ThisExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThisExpressionSyntax, ThisExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ThisExpressionSyntax original, ThisExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThisExpressionSyntax, ThisExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ThisExpressionSyntax original, ThisExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Token, modified.Token);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ThisExpressionSyntax original, ThisExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseExpressionSyntax, BaseExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseExpressionSyntax, BaseExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseExpressionSyntax original, BaseExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseExpressionSyntax, BaseExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseExpressionSyntax original, BaseExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseExpressionSyntax, BaseExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseExpressionSyntax original, BaseExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Token, modified.Token);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseExpressionSyntax original, BaseExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AnonymousMethodExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DelegateKeyword, modified.DelegateKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SimpleLambdaExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ArrowToken, modified.ArrowToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SimpleLambdaExpressionSyntax original, SimpleLambdaExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ParenthesizedLambdaExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ArrowToken, modified.ArrowToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedLambdaExpressionSyntax original, ParenthesizedLambdaExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LambdaExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, LambdaExpressionSyntax, LambdaExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LambdaExpressionSyntax, LambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LambdaExpressionSyntax original, LambdaExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LambdaExpressionSyntax, LambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LambdaExpressionSyntax original, LambdaExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LambdaExpressionSyntax, LambdaExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LambdaExpressionSyntax original, LambdaExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ArrowToken, modified.ArrowToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LambdaExpressionSyntax original, LambdaExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class AnonymousFunctionExpressionServiceProvider : IPairwisable<SyntaxNodeOrToken?, AnonymousFunctionExpressionSyntax, AnonymousFunctionExpressionSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousFunctionExpressionSyntax, AnonymousFunctionExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, AnonymousFunctionExpressionSyntax original, AnonymousFunctionExpressionSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousFunctionExpressionSyntax, AnonymousFunctionExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, AnonymousFunctionExpressionSyntax original, AnonymousFunctionExpressionSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, AnonymousFunctionExpressionSyntax, AnonymousFunctionExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, AnonymousFunctionExpressionSyntax original, AnonymousFunctionExpressionSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, AnonymousFunctionExpressionSyntax original, AnonymousFunctionExpressionSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ArgumentListServiceProvider : IPairwisable<SyntaxNodeOrToken?, ArgumentListSyntax, ArgumentListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentListSyntax, ArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ArgumentListSyntax original, ArgumentListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentListSyntax, ArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ArgumentListSyntax original, ArgumentListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ArgumentListSyntax, ArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ArgumentListSyntax original, ArgumentListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ArgumentListSyntax original, ArgumentListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BracketedArgumentListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BracketedArgumentListSyntax, BracketedArgumentListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BracketedArgumentListSyntax, BracketedArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBracketToken, modified.OpenBracketToken);
    		matchingSet.Partners(original.CloseBracketToken, modified.CloseBracketToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BracketedArgumentListSyntax original, BracketedArgumentListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BaseArgumentListServiceProvider : IPairwisable<SyntaxNodeOrToken?, BaseArgumentListSyntax, BaseArgumentListSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseArgumentListSyntax, BaseArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BaseArgumentListSyntax original, BaseArgumentListSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseArgumentListSyntax, BaseArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BaseArgumentListSyntax original, BaseArgumentListSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BaseArgumentListSyntax, BaseArgumentListSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BaseArgumentListSyntax original, BaseArgumentListSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BaseArgumentListSyntax original, BaseArgumentListSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class FromClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, FromClauseSyntax, FromClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, FromClauseSyntax original, FromClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, FromClauseSyntax original, FromClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FromClauseSyntax, FromClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, FromClauseSyntax original, FromClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.FromKeyword, modified.FromKeyword);
    		matchingSet.Partners(original.InKeyword, modified.InKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, FromClauseSyntax original, FromClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LetClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, LetClauseSyntax, LetClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LetClauseSyntax original, LetClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LetClauseSyntax original, LetClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LetClauseSyntax, LetClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LetClauseSyntax original, LetClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LetKeyword, modified.LetKeyword);
    		matchingSet.Partners(original.EqualsToken, modified.EqualsToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LetClauseSyntax original, LetClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class JoinClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, JoinClauseSyntax, JoinClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, JoinClauseSyntax original, JoinClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, JoinClauseSyntax original, JoinClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, JoinClauseSyntax, JoinClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, JoinClauseSyntax original, JoinClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.JoinKeyword, modified.JoinKeyword);
    		matchingSet.Partners(original.InKeyword, modified.InKeyword);
    		matchingSet.Partners(original.OnKeyword, modified.OnKeyword);
    		matchingSet.Partners(original.EqualsKeyword, modified.EqualsKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, JoinClauseSyntax original, JoinClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class WhereClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, WhereClauseSyntax, WhereClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhereClauseSyntax, WhereClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, WhereClauseSyntax original, WhereClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhereClauseSyntax, WhereClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, WhereClauseSyntax original, WhereClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhereClauseSyntax, WhereClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, WhereClauseSyntax original, WhereClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.WhereKeyword, modified.WhereKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, WhereClauseSyntax original, WhereClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class OrderByClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, OrderByClauseSyntax, OrderByClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderByClauseSyntax, OrderByClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, OrderByClauseSyntax original, OrderByClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderByClauseSyntax, OrderByClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, OrderByClauseSyntax original, OrderByClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, OrderByClauseSyntax, OrderByClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, OrderByClauseSyntax original, OrderByClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OrderByKeyword, modified.OrderByKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, OrderByClauseSyntax original, OrderByClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SelectClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, SelectClauseSyntax, SelectClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SelectClauseSyntax, SelectClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SelectClauseSyntax original, SelectClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SelectClauseSyntax, SelectClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SelectClauseSyntax original, SelectClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SelectClauseSyntax, SelectClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SelectClauseSyntax original, SelectClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SelectKeyword, modified.SelectKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SelectClauseSyntax original, SelectClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class GroupClauseServiceProvider : IPairwisable<SyntaxNodeOrToken?, GroupClauseSyntax, GroupClauseSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GroupClauseSyntax, GroupClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, GroupClauseSyntax original, GroupClauseSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GroupClauseSyntax, GroupClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, GroupClauseSyntax original, GroupClauseSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GroupClauseSyntax, GroupClauseSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, GroupClauseSyntax original, GroupClauseSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.GroupKeyword, modified.GroupKeyword);
    		matchingSet.Partners(original.ByKeyword, modified.ByKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, GroupClauseSyntax original, GroupClauseSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DeclarationPatternServiceProvider : IPairwisable<SyntaxNodeOrToken?, DeclarationPatternSyntax, DeclarationPatternSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DeclarationPatternSyntax original, DeclarationPatternSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DeclarationPatternSyntax original, DeclarationPatternSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DeclarationPatternSyntax, DeclarationPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DeclarationPatternSyntax original, DeclarationPatternSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ConstantPatternServiceProvider : IPairwisable<SyntaxNodeOrToken?, ConstantPatternSyntax, ConstantPatternSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstantPatternSyntax, ConstantPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ConstantPatternSyntax original, ConstantPatternSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstantPatternSyntax, ConstantPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ConstantPatternSyntax original, ConstantPatternSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ConstantPatternSyntax, ConstantPatternSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ConstantPatternSyntax original, ConstantPatternSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ConstantPatternSyntax original, ConstantPatternSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterpolatedStringTextServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterpolatedStringTextSyntax, InterpolatedStringTextSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterpolatedStringTextSyntax original, InterpolatedStringTextSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class InterpolationServiceProvider : IPairwisable<SyntaxNodeOrToken?, InterpolationSyntax, InterpolationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationSyntax, InterpolationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, InterpolationSyntax original, InterpolationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationSyntax, InterpolationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, InterpolationSyntax original, InterpolationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, InterpolationSyntax, InterpolationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, InterpolationSyntax original, InterpolationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, InterpolationSyntax original, InterpolationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BlockServiceProvider : IPairwisable<SyntaxNodeOrToken?, BlockSyntax, BlockSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BlockSyntax, BlockSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BlockSyntax original, BlockSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BlockSyntax, BlockSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BlockSyntax original, BlockSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BlockSyntax, BlockSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BlockSyntax original, BlockSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BlockSyntax original, BlockSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LocalFunctionStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LocalFunctionStatementSyntax original, LocalFunctionStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LocalDeclarationStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LocalDeclarationStatementSyntax original, LocalDeclarationStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ExpressionStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ExpressionStatementSyntax, ExpressionStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ExpressionStatementSyntax original, ExpressionStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ExpressionStatementSyntax original, ExpressionStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ExpressionStatementSyntax, ExpressionStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ExpressionStatementSyntax original, ExpressionStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class EmptyStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, EmptyStatementSyntax, EmptyStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EmptyStatementSyntax, EmptyStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, EmptyStatementSyntax original, EmptyStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EmptyStatementSyntax, EmptyStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, EmptyStatementSyntax original, EmptyStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, EmptyStatementSyntax, EmptyStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, EmptyStatementSyntax original, EmptyStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, EmptyStatementSyntax original, EmptyStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LabeledStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, LabeledStatementSyntax, LabeledStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LabeledStatementSyntax original, LabeledStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LabeledStatementSyntax original, LabeledStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LabeledStatementSyntax, LabeledStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LabeledStatementSyntax original, LabeledStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LabeledStatementSyntax original, LabeledStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class GotoStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, GotoStatementSyntax, GotoStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GotoStatementSyntax, GotoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, GotoStatementSyntax original, GotoStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GotoStatementSyntax, GotoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, GotoStatementSyntax original, GotoStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, GotoStatementSyntax, GotoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, GotoStatementSyntax original, GotoStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.GotoKeyword, modified.GotoKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, GotoStatementSyntax original, GotoStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class BreakStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, BreakStatementSyntax, BreakStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BreakStatementSyntax, BreakStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, BreakStatementSyntax original, BreakStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BreakStatementSyntax, BreakStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, BreakStatementSyntax original, BreakStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, BreakStatementSyntax, BreakStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, BreakStatementSyntax original, BreakStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.BreakKeyword, modified.BreakKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, BreakStatementSyntax original, BreakStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ContinueStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ContinueStatementSyntax, ContinueStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ContinueStatementSyntax, ContinueStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ContinueStatementSyntax original, ContinueStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ContinueStatementSyntax, ContinueStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ContinueStatementSyntax original, ContinueStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ContinueStatementSyntax, ContinueStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ContinueStatementSyntax original, ContinueStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ContinueKeyword, modified.ContinueKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ContinueStatementSyntax original, ContinueStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ReturnStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ReturnStatementSyntax, ReturnStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReturnStatementSyntax, ReturnStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ReturnStatementSyntax original, ReturnStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReturnStatementSyntax, ReturnStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ReturnStatementSyntax original, ReturnStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ReturnStatementSyntax, ReturnStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ReturnStatementSyntax original, ReturnStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ReturnKeyword, modified.ReturnKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ReturnStatementSyntax original, ReturnStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ThrowStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ThrowStatementSyntax, ThrowStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowStatementSyntax, ThrowStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ThrowStatementSyntax original, ThrowStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowStatementSyntax, ThrowStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ThrowStatementSyntax original, ThrowStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ThrowStatementSyntax, ThrowStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ThrowStatementSyntax original, ThrowStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ThrowKeyword, modified.ThrowKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ThrowStatementSyntax original, ThrowStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class YieldStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, YieldStatementSyntax, YieldStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, YieldStatementSyntax, YieldStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, YieldStatementSyntax original, YieldStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, YieldStatementSyntax, YieldStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, YieldStatementSyntax original, YieldStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, YieldStatementSyntax, YieldStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, YieldStatementSyntax original, YieldStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.YieldKeyword, modified.YieldKeyword);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, YieldStatementSyntax original, YieldStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class WhileStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, WhileStatementSyntax, WhileStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhileStatementSyntax, WhileStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, WhileStatementSyntax original, WhileStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhileStatementSyntax, WhileStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, WhileStatementSyntax original, WhileStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, WhileStatementSyntax, WhileStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, WhileStatementSyntax original, WhileStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.WhileKeyword, modified.WhileKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, WhileStatementSyntax original, WhileStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DoStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, DoStatementSyntax, DoStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DoStatementSyntax, DoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DoStatementSyntax original, DoStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DoStatementSyntax, DoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DoStatementSyntax original, DoStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DoStatementSyntax, DoStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DoStatementSyntax original, DoStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.DoKeyword, modified.DoKeyword);
    		matchingSet.Partners(original.WhileKeyword, modified.WhileKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    		matchingSet.Partners(original.SemicolonToken, modified.SemicolonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DoStatementSyntax original, DoStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ForStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ForStatementSyntax, ForStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ForStatementSyntax original, ForStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ForStatementSyntax original, ForStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForStatementSyntax, ForStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ForStatementSyntax original, ForStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ForKeyword, modified.ForKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.FirstSemicolonToken, modified.FirstSemicolonToken);
    		matchingSet.Partners(original.SecondSemicolonToken, modified.SecondSemicolonToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ForStatementSyntax original, ForStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class UsingStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, UsingStatementSyntax, UsingStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, UsingStatementSyntax original, UsingStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, UsingStatementSyntax original, UsingStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UsingStatementSyntax, UsingStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, UsingStatementSyntax original, UsingStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.UsingKeyword, modified.UsingKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, UsingStatementSyntax original, UsingStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class FixedStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, FixedStatementSyntax, FixedStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, FixedStatementSyntax original, FixedStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, FixedStatementSyntax original, FixedStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, FixedStatementSyntax, FixedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, FixedStatementSyntax original, FixedStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.FixedKeyword, modified.FixedKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, FixedStatementSyntax original, FixedStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CheckedStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, CheckedStatementSyntax, CheckedStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedStatementSyntax, CheckedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CheckedStatementSyntax original, CheckedStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedStatementSyntax, CheckedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CheckedStatementSyntax original, CheckedStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CheckedStatementSyntax, CheckedStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CheckedStatementSyntax original, CheckedStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CheckedStatementSyntax original, CheckedStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class UnsafeStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, UnsafeStatementSyntax, UnsafeStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, UnsafeStatementSyntax original, UnsafeStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, UnsafeStatementSyntax original, UnsafeStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, UnsafeStatementSyntax, UnsafeStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.UnsafeKeyword, modified.UnsafeKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, UnsafeStatementSyntax original, UnsafeStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class LockStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, LockStatementSyntax, LockStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LockStatementSyntax, LockStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, LockStatementSyntax original, LockStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LockStatementSyntax, LockStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, LockStatementSyntax original, LockStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, LockStatementSyntax, LockStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, LockStatementSyntax original, LockStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.LockKeyword, modified.LockKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, LockStatementSyntax original, LockStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class IfStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, IfStatementSyntax, IfStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfStatementSyntax, IfStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, IfStatementSyntax original, IfStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfStatementSyntax, IfStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, IfStatementSyntax original, IfStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, IfStatementSyntax, IfStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, IfStatementSyntax original, IfStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.IfKeyword, modified.IfKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, IfStatementSyntax original, IfStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SwitchStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, SwitchStatementSyntax, SwitchStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchStatementSyntax, SwitchStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SwitchStatementSyntax original, SwitchStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchStatementSyntax, SwitchStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SwitchStatementSyntax original, SwitchStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchStatementSyntax, SwitchStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SwitchStatementSyntax original, SwitchStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.SwitchKeyword, modified.SwitchKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    		matchingSet.Partners(original.OpenBraceToken, modified.OpenBraceToken);
    		matchingSet.Partners(original.CloseBraceToken, modified.CloseBraceToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SwitchStatementSyntax original, SwitchStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class TryStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, TryStatementSyntax, TryStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TryStatementSyntax, TryStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, TryStatementSyntax original, TryStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TryStatementSyntax, TryStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, TryStatementSyntax original, TryStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, TryStatementSyntax, TryStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, TryStatementSyntax original, TryStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.TryKeyword, modified.TryKeyword);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, TryStatementSyntax original, TryStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ForEachStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ForEachStatementSyntax, ForEachStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ForEachStatementSyntax original, ForEachStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ForEachStatementSyntax original, ForEachStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachStatementSyntax, ForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ForEachStatementSyntax original, ForEachStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ForEachKeyword, modified.ForEachKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.InKeyword, modified.InKeyword);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ForEachStatementSyntax original, ForEachStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ForEachVariableStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ForEachKeyword, modified.ForEachKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.InKeyword, modified.InKeyword);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ForEachVariableStatementSyntax original, ForEachVariableStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CommonForEachStatementServiceProvider : IPairwisable<SyntaxNodeOrToken?, CommonForEachStatementSyntax, CommonForEachStatementSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CommonForEachStatementSyntax, CommonForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CommonForEachStatementSyntax original, CommonForEachStatementSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CommonForEachStatementSyntax, CommonForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CommonForEachStatementSyntax original, CommonForEachStatementSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CommonForEachStatementSyntax, CommonForEachStatementSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CommonForEachStatementSyntax original, CommonForEachStatementSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.ForEachKeyword, modified.ForEachKeyword);
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.InKeyword, modified.InKeyword);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CommonForEachStatementSyntax original, CommonForEachStatementSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SingleVariableDesignationServiceProvider : IPairwisable<SyntaxNodeOrToken?, SingleVariableDesignationSyntax, SingleVariableDesignationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SingleVariableDesignationSyntax original, SingleVariableDesignationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DiscardDesignationServiceProvider : IPairwisable<SyntaxNodeOrToken?, DiscardDesignationSyntax, DiscardDesignationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DiscardDesignationSyntax original, DiscardDesignationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DiscardDesignationSyntax original, DiscardDesignationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DiscardDesignationSyntax, DiscardDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.UnderscoreToken, modified.UnderscoreToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DiscardDesignationSyntax original, DiscardDesignationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class ParenthesizedVariableDesignationServiceProvider : IPairwisable<SyntaxNodeOrToken?, ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.OpenParenToken, modified.OpenParenToken);
    		matchingSet.Partners(original.CloseParenToken, modified.CloseParenToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, ParenthesizedVariableDesignationSyntax original, ParenthesizedVariableDesignationSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CasePatternSwitchLabelServiceProvider : IPairwisable<SyntaxNodeOrToken?, CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CasePatternSwitchLabelSyntax original, CasePatternSwitchLabelSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class CaseSwitchLabelServiceProvider : IPairwisable<SyntaxNodeOrToken?, CaseSwitchLabelSyntax, CaseSwitchLabelSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, CaseSwitchLabelSyntax original, CaseSwitchLabelSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class DefaultSwitchLabelServiceProvider : IPairwisable<SyntaxNodeOrToken?, DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, DefaultSwitchLabelSyntax original, DefaultSwitchLabelSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
    partial class SwitchLabelServiceProvider : IPairwisable<SyntaxNodeOrToken?, SwitchLabelSyntax, SwitchLabelSyntax>
    {
        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchLabelSyntax, SwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        /// <param name="ignoreCore">If true, the <see cref="PartnersCore(IApproach{SyntaxNodeOrToken?}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> and <see cref="PartnersAfter(IApproach{TElement}, ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)"/> are not executed.</param>
        partial void PartnersBefore(IApproach<SyntaxNodeOrToken?> approach, SwitchLabelSyntax original, SwitchLabelSyntax modified, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchLabelSyntax, SwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        partial void PartnersAfter(IApproach<SyntaxNodeOrToken?> approach, SwitchLabelSyntax original, SwitchLabelSyntax modified);
    
        /// <summary>
        /// Core logic of <see cref="Partners(IApproach{SyntaxNodeOrToken?}, SwitchLabelSyntax, SwitchLabelSyntax)"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        protected virtual void PartnersCore(IApproach<SyntaxNodeOrToken?> approach, SwitchLabelSyntax original, SwitchLabelSyntax modified)
        {
    		if(original == null) 
    			throw new ArgumentNullException(nameof(original));
    
    		if(modified == null) 
    			throw new ArgumentNullException(nameof(modified));
    
    		var matchingSet = approach.MatchingSet();
    		matchingSet.Partners(original.Keyword, modified.Keyword);
    		matchingSet.Partners(original.ColonToken, modified.ColonToken);
    	}
    
    	/// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="approach">solution being executed.</param>
        public void Partners(IApproach<SyntaxNodeOrToken?> approach, SwitchLabelSyntax original, SwitchLabelSyntax modified)
    	{
    		bool ignoreCore = false;
    		this.PartnersBefore(approach, original, modified, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.PartnersCore(approach, original, modified);
    		this.PartnersAfter(approach, original, modified);
    	}
    }
    
}
// Generated helper templates
// Generated items
