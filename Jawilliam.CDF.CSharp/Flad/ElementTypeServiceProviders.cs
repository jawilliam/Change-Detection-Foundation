
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
        public SyntaxTokenServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    }
    
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeArgument"/>.
    /// </summary>
    public partial class AttributeArgumentServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameEquals"/>.
    /// </summary>
    public partial class NameEqualsServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameEqualsServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameterList"/>.
    /// </summary>
    public partial class TypeParameterListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameter"/>.
    /// </summary>
    public partial class TypeParameterServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseList"/>.
    /// </summary>
    public partial class BaseListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameterConstraintClause"/>.
    /// </summary>
    public partial class TypeParameterConstraintClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterConstraintClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExplicitInterfaceSpecifier"/>.
    /// </summary>
    public partial class ExplicitInterfaceSpecifierServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExplicitInterfaceSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorInitializer"/>.
    /// </summary>
    public partial class ConstructorInitializerServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorInitializerServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrowExpressionClause"/>.
    /// </summary>
    public partial class ArrowExpressionClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrowExpressionClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AccessorList"/>.
    /// </summary>
    public partial class AccessorListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AccessorListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AccessorDeclaration"/>.
    /// </summary>
    public partial class AccessorDeclarationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AccessorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Parameter"/>.
    /// </summary>
    public partial class ParameterServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefParameter"/>.
    /// </summary>
    public partial class CrefParameterServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefParameterServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElementStartTag"/>.
    /// </summary>
    public partial class XmlElementStartTagServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementStartTagServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElementEndTag"/>.
    /// </summary>
    public partial class XmlElementEndTagServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementEndTagServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlName"/>.
    /// </summary>
    public partial class XmlNameServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlPrefix"/>.
    /// </summary>
    public partial class XmlPrefixServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlPrefixServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeArgumentList"/>.
    /// </summary>
    public partial class TypeArgumentListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayRankSpecifier"/>.
    /// </summary>
    public partial class ArrayRankSpecifierServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayRankSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleElement"/>.
    /// </summary>
    public partial class TupleElementServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Argument"/>.
    /// </summary>
    public partial class ArgumentServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameColon"/>.
    /// </summary>
    public partial class NameColonServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameColonServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousObjectMemberDeclarator"/>.
    /// </summary>
    public partial class AnonymousObjectMemberDeclaratorServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousObjectMemberDeclaratorServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryBody"/>.
    /// </summary>
    public partial class QueryBodyServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryBodyServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="JoinIntoClause"/>.
    /// </summary>
    public partial class JoinIntoClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public JoinIntoClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Ordering"/>.
    /// </summary>
    public partial class OrderingServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OrderingServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryContinuation"/>.
    /// </summary>
    public partial class QueryContinuationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryContinuationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhenClause"/>.
    /// </summary>
    public partial class WhenClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhenClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolationAlignmentClause"/>.
    /// </summary>
    public partial class InterpolationAlignmentClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationAlignmentClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolationFormatClause"/>.
    /// </summary>
    public partial class InterpolationFormatClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationFormatClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="VariableDeclaration"/>.
    /// </summary>
    public partial class VariableDeclarationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public VariableDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="VariableDeclarator"/>.
    /// </summary>
    public partial class VariableDeclaratorServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public VariableDeclaratorServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EqualsValueClause"/>.
    /// </summary>
    public partial class EqualsValueClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EqualsValueClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElseClause"/>.
    /// </summary>
    public partial class ElseClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElseClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SwitchSection"/>.
    /// </summary>
    public partial class SwitchSectionServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SwitchSectionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchClause"/>.
    /// </summary>
    public partial class CatchClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchDeclaration"/>.
    /// </summary>
    public partial class CatchDeclarationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CatchFilterClause"/>.
    /// </summary>
    public partial class CatchFilterClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CatchFilterClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="FinallyClause"/>.
    /// </summary>
    public partial class FinallyClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FinallyClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CompilationUnit"/>.
    /// </summary>
    public partial class CompilationUnitServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CompilationUnitServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExternAliasDirective"/>.
    /// </summary>
    public partial class ExternAliasDirectiveServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExternAliasDirectiveServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="UsingDirective"/>.
    /// </summary>
    public partial class UsingDirectiveServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UsingDirectiveServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeList"/>.
    /// </summary>
    public partial class AttributeListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeTargetSpecifier"/>.
    /// </summary>
    public partial class AttributeTargetSpecifierServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeTargetSpecifierServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Attribute"/>.
    /// </summary>
    public partial class AttributeServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AttributeArgumentList"/>.
    /// </summary>
    public partial class AttributeArgumentListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AttributeArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DelegateDeclaration"/>.
    /// </summary>
    public partial class DelegateDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DelegateDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EnumMemberDeclaration"/>.
    /// </summary>
    public partial class EnumMemberDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EnumMemberDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IncompleteMember"/>.
    /// </summary>
    public partial class IncompleteMemberServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IncompleteMemberServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="GlobalStatement"/>.
    /// </summary>
    public partial class GlobalStatementServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GlobalStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="NamespaceDeclaration"/>.
    /// </summary>
    public partial class NamespaceDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NamespaceDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EnumDeclaration"/>.
    /// </summary>
    public partial class EnumDeclarationServiceProvider : BaseTypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EnumDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ClassDeclaration"/>.
    /// </summary>
    public partial class ClassDeclarationServiceProvider : TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ClassDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="StructDeclaration"/>.
    /// </summary>
    public partial class StructDeclarationServiceProvider : TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StructDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterfaceDeclaration"/>.
    /// </summary>
    public partial class InterfaceDeclarationServiceProvider : TypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterfaceDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeDeclaration"/>.
    /// </summary>
    public abstract partial class TypeDeclarationServiceProvider : BaseTypeDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "TypeParameterList";
    			yield return "ConstraintClauses";
    			yield return "Members";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseTypeDeclaration"/>.
    /// </summary>
    public abstract partial class BaseTypeDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseTypeDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Identifier";
    			yield return "BaseList";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
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
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="FieldDeclaration"/>.
    /// </summary>
    public partial class FieldDeclarationServiceProvider : BaseFieldDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FieldDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EventFieldDeclaration"/>.
    /// </summary>
    public partial class EventFieldDeclarationServiceProvider : BaseFieldDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EventFieldDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseFieldDeclaration"/>.
    /// </summary>
    public abstract partial class BaseFieldDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseFieldDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MethodDeclaration"/>.
    /// </summary>
    public partial class MethodDeclarationServiceProvider : BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MethodDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="OperatorDeclaration"/>.
    /// </summary>
    public partial class OperatorDeclarationServiceProvider : BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OperatorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConversionOperatorDeclaration"/>.
    /// </summary>
    public partial class ConversionOperatorDeclarationServiceProvider : BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConversionOperatorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorDeclaration"/>.
    /// </summary>
    public partial class ConstructorDeclarationServiceProvider : BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DestructorDeclaration"/>.
    /// </summary>
    public partial class DestructorDeclarationServiceProvider : BaseMethodDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DestructorDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseMethodDeclaration"/>.
    /// </summary>
    public abstract partial class BaseMethodDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseMethodDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
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
    			yield break;
    		}
    	}
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PropertyDeclaration"/>.
    /// </summary>
    public partial class PropertyDeclarationServiceProvider : BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PropertyDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EventDeclaration"/>.
    /// </summary>
    public partial class EventDeclarationServiceProvider : BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EventDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IndexerDeclaration"/>.
    /// </summary>
    public partial class IndexerDeclarationServiceProvider : BasePropertyDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IndexerDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BasePropertyDeclaration"/>.
    /// </summary>
    public abstract partial class BasePropertyDeclarationServiceProvider : MemberDeclarationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BasePropertyDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "AccessorList";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberDeclaration"/>.
    /// </summary>
    public abstract partial class MemberDeclarationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberDeclarationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SimpleBaseType"/>.
    /// </summary>
    public partial class SimpleBaseTypeServiceProvider : BaseTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SimpleBaseTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseType"/>.
    /// </summary>
    public abstract partial class BaseTypeServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstructorConstraint"/>.
    /// </summary>
    public partial class ConstructorConstraintServiceProvider : TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstructorConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ClassOrStructConstraint"/>.
    /// </summary>
    public partial class ClassOrStructConstraintServiceProvider : TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ClassOrStructConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeConstraint"/>.
    /// </summary>
    public partial class TypeConstraintServiceProvider : TypeParameterConstraintServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeParameterConstraint"/>.
    /// </summary>
    public abstract partial class TypeParameterConstraintServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeParameterConstraintServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParameterList"/>.
    /// </summary>
    public partial class ParameterListServiceProvider : BaseParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BracketedParameterList"/>.
    /// </summary>
    public partial class BracketedParameterListServiceProvider : BaseParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BracketedParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseParameterList"/>.
    /// </summary>
    public abstract partial class BaseParameterListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SkippedTokensTrivia"/>.
    /// </summary>
    public partial class SkippedTokensTriviaServiceProvider : StructuredTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SkippedTokensTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DocumentationCommentTrivia"/>.
    /// </summary>
    public partial class DocumentationCommentTriviaServiceProvider : StructuredTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DocumentationCommentTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EndIfDirectiveTrivia"/>.
    /// </summary>
    public partial class EndIfDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EndIfDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="RegionDirectiveTrivia"/>.
    /// </summary>
    public partial class RegionDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RegionDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EndRegionDirectiveTrivia"/>.
    /// </summary>
    public partial class EndRegionDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EndRegionDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ErrorDirectiveTrivia"/>.
    /// </summary>
    public partial class ErrorDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ErrorDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="WarningDirectiveTrivia"/>.
    /// </summary>
    public partial class WarningDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WarningDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BadDirectiveTrivia"/>.
    /// </summary>
    public partial class BadDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BadDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefineDirectiveTrivia"/>.
    /// </summary>
    public partial class DefineDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefineDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="UndefDirectiveTrivia"/>.
    /// </summary>
    public partial class UndefDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UndefDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LineDirectiveTrivia"/>.
    /// </summary>
    public partial class LineDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LineDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PragmaWarningDirectiveTrivia"/>.
    /// </summary>
    public partial class PragmaWarningDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PragmaWarningDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PragmaChecksumDirectiveTrivia"/>.
    /// </summary>
    public partial class PragmaChecksumDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PragmaChecksumDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ReferenceDirectiveTrivia"/>.
    /// </summary>
    public partial class ReferenceDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ReferenceDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LoadDirectiveTrivia"/>.
    /// </summary>
    public partial class LoadDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LoadDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ShebangDirectiveTrivia"/>.
    /// </summary>
    public partial class ShebangDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ShebangDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElseDirectiveTrivia"/>.
    /// </summary>
    public partial class ElseDirectiveTriviaServiceProvider : BranchingDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElseDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IfDirectiveTrivia"/>.
    /// </summary>
    public partial class IfDirectiveTriviaServiceProvider : ConditionalDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IfDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElifDirectiveTrivia"/>.
    /// </summary>
    public partial class ElifDirectiveTriviaServiceProvider : ConditionalDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElifDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConditionalDirectiveTrivia"/>.
    /// </summary>
    public abstract partial class ConditionalDirectiveTriviaServiceProvider : BranchingDirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConditionalDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Condition";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BranchingDirectiveTrivia"/>.
    /// </summary>
    public abstract partial class BranchingDirectiveTriviaServiceProvider : DirectiveTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BranchingDirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DirectiveTrivia"/>.
    /// </summary>
    public abstract partial class DirectiveTriviaServiceProvider : StructuredTriviaServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DirectiveTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="StructuredTrivia"/>.
    /// </summary>
    public abstract partial class StructuredTriviaServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StructuredTriviaServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeCref"/>.
    /// </summary>
    public partial class TypeCrefServiceProvider : CrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QualifiedCref"/>.
    /// </summary>
    public partial class QualifiedCrefServiceProvider : CrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QualifiedCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="NameMemberCref"/>.
    /// </summary>
    public partial class NameMemberCrefServiceProvider : MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IndexerMemberCref"/>.
    /// </summary>
    public partial class IndexerMemberCrefServiceProvider : MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IndexerMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="OperatorMemberCref"/>.
    /// </summary>
    public partial class OperatorMemberCrefServiceProvider : MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OperatorMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConversionOperatorMemberCref"/>.
    /// </summary>
    public partial class ConversionOperatorMemberCrefServiceProvider : MemberCrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConversionOperatorMemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberCref"/>.
    /// </summary>
    public abstract partial class MemberCrefServiceProvider : CrefServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberCrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Cref"/>.
    /// </summary>
    public abstract partial class CrefServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefParameterList"/>.
    /// </summary>
    public partial class CrefParameterListServiceProvider : BaseCrefParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CrefBracketedParameterList"/>.
    /// </summary>
    public partial class CrefBracketedParameterListServiceProvider : BaseCrefParameterListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CrefBracketedParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseCrefParameterList"/>.
    /// </summary>
    public abstract partial class BaseCrefParameterListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseCrefParameterListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlElement"/>.
    /// </summary>
    public partial class XmlElementServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlEmptyElement"/>.
    /// </summary>
    public partial class XmlEmptyElementServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlEmptyElementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlText"/>.
    /// </summary>
    public partial class XmlTextServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlTextServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlCDataSection"/>.
    /// </summary>
    public partial class XmlCDataSectionServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCDataSectionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlProcessingInstruction"/>.
    /// </summary>
    public partial class XmlProcessingInstructionServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlProcessingInstructionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlComment"/>.
    /// </summary>
    public partial class XmlCommentServiceProvider : XmlNodeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCommentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlNode"/>.
    /// </summary>
    public abstract partial class XmlNodeServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlNodeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlTextAttribute"/>.
    /// </summary>
    public partial class XmlTextAttributeServiceProvider : XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlTextAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlCrefAttribute"/>.
    /// </summary>
    public partial class XmlCrefAttributeServiceProvider : XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlCrefAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlNameAttribute"/>.
    /// </summary>
    public partial class XmlNameAttributeServiceProvider : XmlAttributeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlNameAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="XmlAttribute"/>.
    /// </summary>
    public abstract partial class XmlAttributeServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public XmlAttributeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedExpression"/>.
    /// </summary>
    public partial class ParenthesizedExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleExpression"/>.
    /// </summary>
    public partial class TupleExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PrefixUnaryExpression"/>.
    /// </summary>
    public partial class PrefixUnaryExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PrefixUnaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AwaitExpression"/>.
    /// </summary>
    public partial class AwaitExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AwaitExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PostfixUnaryExpression"/>.
    /// </summary>
    public partial class PostfixUnaryExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PostfixUnaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberAccessExpression"/>.
    /// </summary>
    public partial class MemberAccessExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConditionalAccessExpression"/>.
    /// </summary>
    public partial class ConditionalAccessExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConditionalAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MemberBindingExpression"/>.
    /// </summary>
    public partial class MemberBindingExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MemberBindingExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElementBindingExpression"/>.
    /// </summary>
    public partial class ElementBindingExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElementBindingExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ImplicitElementAccess"/>.
    /// </summary>
    public partial class ImplicitElementAccessServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ImplicitElementAccessServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BinaryExpression"/>.
    /// </summary>
    public partial class BinaryExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BinaryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AssignmentExpression"/>.
    /// </summary>
    public partial class AssignmentExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AssignmentExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConditionalExpression"/>.
    /// </summary>
    public partial class ConditionalExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConditionalExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LiteralExpression"/>.
    /// </summary>
    public partial class LiteralExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LiteralExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="MakeRefExpression"/>.
    /// </summary>
    public partial class MakeRefExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public MakeRefExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefTypeExpression"/>.
    /// </summary>
    public partial class RefTypeExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefTypeExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefValueExpression"/>.
    /// </summary>
    public partial class RefValueExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefValueExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CheckedExpression"/>.
    /// </summary>
    public partial class CheckedExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CheckedExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefaultExpression"/>.
    /// </summary>
    public partial class DefaultExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefaultExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TypeOfExpression"/>.
    /// </summary>
    public partial class TypeOfExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeOfExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SizeOfExpression"/>.
    /// </summary>
    public partial class SizeOfExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SizeOfExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InvocationExpression"/>.
    /// </summary>
    public partial class InvocationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InvocationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ElementAccessExpression"/>.
    /// </summary>
    public partial class ElementAccessExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElementAccessExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DeclarationExpression"/>.
    /// </summary>
    public partial class DeclarationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DeclarationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CastExpression"/>.
    /// </summary>
    public partial class CastExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CastExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefExpression"/>.
    /// </summary>
    public partial class RefExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InitializerExpression"/>.
    /// </summary>
    public partial class InitializerExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InitializerExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ObjectCreationExpression"/>.
    /// </summary>
    public partial class ObjectCreationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ObjectCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousObjectCreationExpression"/>.
    /// </summary>
    public partial class AnonymousObjectCreationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousObjectCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayCreationExpression"/>.
    /// </summary>
    public partial class ArrayCreationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ImplicitArrayCreationExpression"/>.
    /// </summary>
    public partial class ImplicitArrayCreationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ImplicitArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="StackAllocArrayCreationExpression"/>.
    /// </summary>
    public partial class StackAllocArrayCreationExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StackAllocArrayCreationExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryExpression"/>.
    /// </summary>
    public partial class QueryExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="OmittedArraySizeExpression"/>.
    /// </summary>
    public partial class OmittedArraySizeExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OmittedArraySizeExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolatedStringExpression"/>.
    /// </summary>
    public partial class InterpolatedStringExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolatedStringExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IsPatternExpression"/>.
    /// </summary>
    public partial class IsPatternExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IsPatternExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThrowExpression"/>.
    /// </summary>
    public partial class ThrowExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThrowExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PredefinedType"/>.
    /// </summary>
    public partial class PredefinedTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PredefinedTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArrayType"/>.
    /// </summary>
    public partial class ArrayTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArrayTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="PointerType"/>.
    /// </summary>
    public partial class PointerTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PointerTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="NullableType"/>.
    /// </summary>
    public partial class NullableTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NullableTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TupleType"/>.
    /// </summary>
    public partial class TupleTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TupleTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="OmittedTypeArgument"/>.
    /// </summary>
    public partial class OmittedTypeArgumentServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OmittedTypeArgumentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="RefType"/>.
    /// </summary>
    public partial class RefTypeServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public RefTypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QualifiedName"/>.
    /// </summary>
    public partial class QualifiedNameServiceProvider : NameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QualifiedNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AliasQualifiedName"/>.
    /// </summary>
    public partial class AliasQualifiedNameServiceProvider : NameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AliasQualifiedNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IdentifierName"/>.
    /// </summary>
    public partial class IdentifierNameServiceProvider : SimpleNameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IdentifierNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="GenericName"/>.
    /// </summary>
    public partial class GenericNameServiceProvider : SimpleNameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GenericNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SimpleName"/>.
    /// </summary>
    public abstract partial class SimpleNameServiceProvider : NameServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SimpleNameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Name"/>.
    /// </summary>
    public abstract partial class NameServiceProvider : TypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public NameServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Type"/>.
    /// </summary>
    public abstract partial class TypeServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TypeServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThisExpression"/>.
    /// </summary>
    public partial class ThisExpressionServiceProvider : InstanceExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThisExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseExpression"/>.
    /// </summary>
    public partial class BaseExpressionServiceProvider : InstanceExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InstanceExpression"/>.
    /// </summary>
    public abstract partial class InstanceExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InstanceExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousMethodExpression"/>.
    /// </summary>
    public partial class AnonymousMethodExpressionServiceProvider : AnonymousFunctionExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousMethodExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SimpleLambdaExpression"/>.
    /// </summary>
    public partial class SimpleLambdaExpressionServiceProvider : LambdaExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SimpleLambdaExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedLambdaExpression"/>.
    /// </summary>
    public partial class ParenthesizedLambdaExpressionServiceProvider : LambdaExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedLambdaExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LambdaExpression"/>.
    /// </summary>
    public abstract partial class LambdaExpressionServiceProvider : AnonymousFunctionExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LambdaExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArrowToken";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="AnonymousFunctionExpression"/>.
    /// </summary>
    public abstract partial class AnonymousFunctionExpressionServiceProvider : ExpressionServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public AnonymousFunctionExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Expression"/>.
    /// </summary>
    public abstract partial class ExpressionServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExpressionServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ArgumentList"/>.
    /// </summary>
    public partial class ArgumentListServiceProvider : BaseArgumentListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BracketedArgumentList"/>.
    /// </summary>
    public partial class BracketedArgumentListServiceProvider : BaseArgumentListServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BracketedArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BaseArgumentList"/>.
    /// </summary>
    public abstract partial class BaseArgumentListServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BaseArgumentListServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Arguments";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="FromClause"/>.
    /// </summary>
    public partial class FromClauseServiceProvider : QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FromClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LetClause"/>.
    /// </summary>
    public partial class LetClauseServiceProvider : QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LetClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="JoinClause"/>.
    /// </summary>
    public partial class JoinClauseServiceProvider : QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public JoinClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhereClause"/>.
    /// </summary>
    public partial class WhereClauseServiceProvider : QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhereClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="OrderByClause"/>.
    /// </summary>
    public partial class OrderByClauseServiceProvider : QueryClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public OrderByClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="QueryClause"/>.
    /// </summary>
    public abstract partial class QueryClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public QueryClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SelectClause"/>.
    /// </summary>
    public partial class SelectClauseServiceProvider : SelectOrGroupClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SelectClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="GroupClause"/>.
    /// </summary>
    public partial class GroupClauseServiceProvider : SelectOrGroupClauseServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GroupClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SelectOrGroupClause"/>.
    /// </summary>
    public abstract partial class SelectOrGroupClauseServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SelectOrGroupClauseServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DeclarationPattern"/>.
    /// </summary>
    public partial class DeclarationPatternServiceProvider : PatternServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DeclarationPatternServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ConstantPattern"/>.
    /// </summary>
    public partial class ConstantPatternServiceProvider : PatternServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ConstantPatternServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Pattern"/>.
    /// </summary>
    public abstract partial class PatternServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public PatternServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolatedStringText"/>.
    /// </summary>
    public partial class InterpolatedStringTextServiceProvider : InterpolatedStringContentServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolatedStringTextServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Interpolation"/>.
    /// </summary>
    public partial class InterpolationServiceProvider : InterpolatedStringContentServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="InterpolatedStringContent"/>.
    /// </summary>
    public abstract partial class InterpolatedStringContentServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public InterpolatedStringContentServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Block"/>.
    /// </summary>
    public partial class BlockServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BlockServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LocalFunctionStatement"/>.
    /// </summary>
    public partial class LocalFunctionStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LocalFunctionStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LocalDeclarationStatement"/>.
    /// </summary>
    public partial class LocalDeclarationStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LocalDeclarationStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ExpressionStatement"/>.
    /// </summary>
    public partial class ExpressionStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ExpressionStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="EmptyStatement"/>.
    /// </summary>
    public partial class EmptyStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public EmptyStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LabeledStatement"/>.
    /// </summary>
    public partial class LabeledStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LabeledStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="GotoStatement"/>.
    /// </summary>
    public partial class GotoStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public GotoStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="BreakStatement"/>.
    /// </summary>
    public partial class BreakStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public BreakStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ContinueStatement"/>.
    /// </summary>
    public partial class ContinueStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ContinueStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ReturnStatement"/>.
    /// </summary>
    public partial class ReturnStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ReturnStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ThrowStatement"/>.
    /// </summary>
    public partial class ThrowStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ThrowStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="YieldStatement"/>.
    /// </summary>
    public partial class YieldStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public YieldStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="WhileStatement"/>.
    /// </summary>
    public partial class WhileStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public WhileStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DoStatement"/>.
    /// </summary>
    public partial class DoStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DoStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForStatement"/>.
    /// </summary>
    public partial class ForStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="UsingStatement"/>.
    /// </summary>
    public partial class UsingStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UsingStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="FixedStatement"/>.
    /// </summary>
    public partial class FixedStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public FixedStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CheckedStatement"/>.
    /// </summary>
    public partial class CheckedStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CheckedStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="UnsafeStatement"/>.
    /// </summary>
    public partial class UnsafeStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public UnsafeStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="LockStatement"/>.
    /// </summary>
    public partial class LockStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public LockStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="IfStatement"/>.
    /// </summary>
    public partial class IfStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public IfStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SwitchStatement"/>.
    /// </summary>
    public partial class SwitchStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SwitchStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="TryStatement"/>.
    /// </summary>
    public partial class TryStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public TryStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForEachStatement"/>.
    /// </summary>
    public partial class ForEachStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForEachStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ForEachVariableStatement"/>.
    /// </summary>
    public partial class ForEachVariableStatementServiceProvider : CommonForEachStatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ForEachVariableStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CommonForEachStatement"/>.
    /// </summary>
    public abstract partial class CommonForEachStatementServiceProvider : StatementServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CommonForEachStatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="Statement"/>.
    /// </summary>
    public abstract partial class StatementServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public StatementServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SingleVariableDesignation"/>.
    /// </summary>
    public partial class SingleVariableDesignationServiceProvider : VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SingleVariableDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DiscardDesignation"/>.
    /// </summary>
    public partial class DiscardDesignationServiceProvider : VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DiscardDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="ParenthesizedVariableDesignation"/>.
    /// </summary>
    public partial class ParenthesizedVariableDesignationServiceProvider : VariableDesignationServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ParenthesizedVariableDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="VariableDesignation"/>.
    /// </summary>
    public abstract partial class VariableDesignationServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public VariableDesignationServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CasePatternSwitchLabel"/>.
    /// </summary>
    public partial class CasePatternSwitchLabelServiceProvider : SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CasePatternSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="CaseSwitchLabel"/>.
    /// </summary>
    public partial class CaseSwitchLabelServiceProvider : SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public CaseSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="DefaultSwitchLabel"/>.
    /// </summary>
    public partial class DefaultSwitchLabelServiceProvider : SwitchLabelServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public DefaultSwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
    /// <summary>
    /// Provides language-aware services regarding <see cref="SwitchLabel"/>.
    /// </summary>
    public abstract partial class SwitchLabelServiceProvider : ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SwitchLabelServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) 
    	{}
    
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
    
    	
    }
}
// Generated helper templates
// Generated items
