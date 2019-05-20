
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace Jawilliam.CDF.CSharp.Awareness
{
    /// <summary>
    /// Provides C#-specific information for source code change detection. 
    /// </summary>
    public partial class LanguageServiceProvider :  Jawilliam.CDF.Approach.Services.ILanguageServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current procedure is being called.</param>
        public LanguageServiceProvider(CSharpFlad approach)
        {
            this.Approach = approach ?? throw new ArgumentNullException(nameof(approach));
        }
    
        /// <summary>
        /// Gets or sets the solution wherein the current procedure is being called.
        /// </summary>
        public virtual CSharpFlad Approach { get; private set; }
    
    	/// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the requested element type.</returns>
        public virtual  Jawilliam.CDF.Approach.Services.IElementTypeServiceProvider GetElementTypeServiceProvider(string type, string subtype = null)
    	{
    		switch(type)
    		{
    			case "TypeArgumentList": return this.TypeArgumentListServiceProvider;
    			case "ArrayRankSpecifier": return this.ArrayRankSpecifierServiceProvider;
    			case "TupleElement": return this.TupleElementServiceProvider;
    			case "Argument": return this.ArgumentServiceProvider;
    			case "NameColon": return this.NameColonServiceProvider;
    			case "AnonymousObjectMemberDeclarator": return this.AnonymousObjectMemberDeclaratorServiceProvider;
    			case "QueryBody": return this.QueryBodyServiceProvider;
    			case "JoinIntoClause": return this.JoinIntoClauseServiceProvider;
    			case "Ordering": return this.OrderingServiceProvider;
    			case "QueryContinuation": return this.QueryContinuationServiceProvider;
    			case "WhenClause": return this.WhenClauseServiceProvider;
    			case "InterpolationAlignmentClause": return this.InterpolationAlignmentClauseServiceProvider;
    			case "InterpolationFormatClause": return this.InterpolationFormatClauseServiceProvider;
    			case "VariableDeclaration": return this.VariableDeclarationServiceProvider;
    			case "VariableDeclarator": return this.VariableDeclaratorServiceProvider;
    			case "EqualsValueClause": return this.EqualsValueClauseServiceProvider;
    			case "ElseClause": return this.ElseClauseServiceProvider;
    			case "SwitchSection": return this.SwitchSectionServiceProvider;
    			case "CatchClause": return this.CatchClauseServiceProvider;
    			case "CatchDeclaration": return this.CatchDeclarationServiceProvider;
    			case "CatchFilterClause": return this.CatchFilterClauseServiceProvider;
    			case "FinallyClause": return this.FinallyClauseServiceProvider;
    			case "CompilationUnit": return this.CompilationUnitServiceProvider;
    			case "ExternAliasDirective": return this.ExternAliasDirectiveServiceProvider;
    			case "UsingDirective": return this.UsingDirectiveServiceProvider;
    			case "AttributeList": return this.AttributeListServiceProvider;
    			case "AttributeTargetSpecifier": return this.AttributeTargetSpecifierServiceProvider;
    			case "Attribute": return this.AttributeServiceProvider;
    			case "AttributeArgumentList": return this.AttributeArgumentListServiceProvider;
    			case "AttributeArgument": return this.AttributeArgumentServiceProvider;
    			case "NameEquals": return this.NameEqualsServiceProvider;
    			case "TypeParameterList": return this.TypeParameterListServiceProvider;
    			case "TypeParameter": return this.TypeParameterServiceProvider;
    			case "BaseList": return this.BaseListServiceProvider;
    			case "TypeParameterConstraintClause": return this.TypeParameterConstraintClauseServiceProvider;
    			case "ExplicitInterfaceSpecifier": return this.ExplicitInterfaceSpecifierServiceProvider;
    			case "ConstructorInitializer": return this.ConstructorInitializerServiceProvider;
    			case "ArrowExpressionClause": return this.ArrowExpressionClauseServiceProvider;
    			case "AccessorList": return this.AccessorListServiceProvider;
    			case "AccessorDeclaration": return this.AccessorDeclarationServiceProvider;
    			case "Parameter": return this.ParameterServiceProvider;
    			case "CrefParameter": return this.CrefParameterServiceProvider;
    			case "XmlElementStartTag": return this.XmlElementStartTagServiceProvider;
    			case "XmlElementEndTag": return this.XmlElementEndTagServiceProvider;
    			case "XmlName": return this.XmlNameServiceProvider;
    			case "XmlPrefix": return this.XmlPrefixServiceProvider;
    			case "ParenthesizedExpression": return this.ParenthesizedExpressionServiceProvider;
    			case "TupleExpression": return this.TupleExpressionServiceProvider;
    			case "PrefixUnaryExpression": return this.PrefixUnaryExpressionServiceProvider;
    			case "AwaitExpression": return this.AwaitExpressionServiceProvider;
    			case "PostfixUnaryExpression": return this.PostfixUnaryExpressionServiceProvider;
    			case "MemberAccessExpression": return this.MemberAccessExpressionServiceProvider;
    			case "ConditionalAccessExpression": return this.ConditionalAccessExpressionServiceProvider;
    			case "MemberBindingExpression": return this.MemberBindingExpressionServiceProvider;
    			case "ElementBindingExpression": return this.ElementBindingExpressionServiceProvider;
    			case "ImplicitElementAccess": return this.ImplicitElementAccessServiceProvider;
    			case "BinaryExpression": return this.BinaryExpressionServiceProvider;
    			case "AssignmentExpression": return this.AssignmentExpressionServiceProvider;
    			case "ConditionalExpression": return this.ConditionalExpressionServiceProvider;
    			case "LiteralExpression": return this.LiteralExpressionServiceProvider;
    			case "MakeRefExpression": return this.MakeRefExpressionServiceProvider;
    			case "RefTypeExpression": return this.RefTypeExpressionServiceProvider;
    			case "RefValueExpression": return this.RefValueExpressionServiceProvider;
    			case "CheckedExpression": return this.CheckedExpressionServiceProvider;
    			case "DefaultExpression": return this.DefaultExpressionServiceProvider;
    			case "TypeOfExpression": return this.TypeOfExpressionServiceProvider;
    			case "SizeOfExpression": return this.SizeOfExpressionServiceProvider;
    			case "InvocationExpression": return this.InvocationExpressionServiceProvider;
    			case "ElementAccessExpression": return this.ElementAccessExpressionServiceProvider;
    			case "DeclarationExpression": return this.DeclarationExpressionServiceProvider;
    			case "CastExpression": return this.CastExpressionServiceProvider;
    			case "RefExpression": return this.RefExpressionServiceProvider;
    			case "InitializerExpression": return this.InitializerExpressionServiceProvider;
    			case "ObjectCreationExpression": return this.ObjectCreationExpressionServiceProvider;
    			case "AnonymousObjectCreationExpression": return this.AnonymousObjectCreationExpressionServiceProvider;
    			case "ArrayCreationExpression": return this.ArrayCreationExpressionServiceProvider;
    			case "ImplicitArrayCreationExpression": return this.ImplicitArrayCreationExpressionServiceProvider;
    			case "StackAllocArrayCreationExpression": return this.StackAllocArrayCreationExpressionServiceProvider;
    			case "QueryExpression": return this.QueryExpressionServiceProvider;
    			case "OmittedArraySizeExpression": return this.OmittedArraySizeExpressionServiceProvider;
    			case "InterpolatedStringExpression": return this.InterpolatedStringExpressionServiceProvider;
    			case "IsPatternExpression": return this.IsPatternExpressionServiceProvider;
    			case "ThrowExpression": return this.ThrowExpressionServiceProvider;
    			case "PredefinedType": return this.PredefinedTypeServiceProvider;
    			case "ArrayType": return this.ArrayTypeServiceProvider;
    			case "PointerType": return this.PointerTypeServiceProvider;
    			case "NullableType": return this.NullableTypeServiceProvider;
    			case "TupleType": return this.TupleTypeServiceProvider;
    			case "OmittedTypeArgument": return this.OmittedTypeArgumentServiceProvider;
    			case "RefType": return this.RefTypeServiceProvider;
    			case "QualifiedName": return this.QualifiedNameServiceProvider;
    			case "AliasQualifiedName": return this.AliasQualifiedNameServiceProvider;
    			case "IdentifierName": return this.IdentifierNameServiceProvider;
    			case "GenericName": return this.GenericNameServiceProvider;
    			case "ThisExpression": return this.ThisExpressionServiceProvider;
    			case "BaseExpression": return this.BaseExpressionServiceProvider;
    			case "AnonymousMethodExpression": return this.AnonymousMethodExpressionServiceProvider;
    			case "SimpleLambdaExpression": return this.SimpleLambdaExpressionServiceProvider;
    			case "ParenthesizedLambdaExpression": return this.ParenthesizedLambdaExpressionServiceProvider;
    			case "ArgumentList": return this.ArgumentListServiceProvider;
    			case "BracketedArgumentList": return this.BracketedArgumentListServiceProvider;
    			case "FromClause": return this.FromClauseServiceProvider;
    			case "LetClause": return this.LetClauseServiceProvider;
    			case "JoinClause": return this.JoinClauseServiceProvider;
    			case "WhereClause": return this.WhereClauseServiceProvider;
    			case "OrderByClause": return this.OrderByClauseServiceProvider;
    			case "SelectClause": return this.SelectClauseServiceProvider;
    			case "GroupClause": return this.GroupClauseServiceProvider;
    			case "DeclarationPattern": return this.DeclarationPatternServiceProvider;
    			case "ConstantPattern": return this.ConstantPatternServiceProvider;
    			case "InterpolatedStringText": return this.InterpolatedStringTextServiceProvider;
    			case "Interpolation": return this.InterpolationServiceProvider;
    			case "GlobalStatement": return this.GlobalStatementServiceProvider;
    			case "NamespaceDeclaration": return this.NamespaceDeclarationServiceProvider;
    			case "DelegateDeclaration": return this.DelegateDeclarationServiceProvider;
    			case "EnumMemberDeclaration": return this.EnumMemberDeclarationServiceProvider;
    			case "IncompleteMember": return this.IncompleteMemberServiceProvider;
    			case "EnumDeclaration": return this.EnumDeclarationServiceProvider;
    			case "ClassDeclaration": return this.ClassDeclarationServiceProvider;
    			case "StructDeclaration": return this.StructDeclarationServiceProvider;
    			case "InterfaceDeclaration": return this.InterfaceDeclarationServiceProvider;
    			case "FieldDeclaration": return this.FieldDeclarationServiceProvider;
    			case "EventFieldDeclaration": return this.EventFieldDeclarationServiceProvider;
    			case "MethodDeclaration": return this.MethodDeclarationServiceProvider;
    			case "OperatorDeclaration": return this.OperatorDeclarationServiceProvider;
    			case "ConversionOperatorDeclaration": return this.ConversionOperatorDeclarationServiceProvider;
    			case "ConstructorDeclaration": return this.ConstructorDeclarationServiceProvider;
    			case "DestructorDeclaration": return this.DestructorDeclarationServiceProvider;
    			case "PropertyDeclaration": return this.PropertyDeclarationServiceProvider;
    			case "EventDeclaration": return this.EventDeclarationServiceProvider;
    			case "IndexerDeclaration": return this.IndexerDeclarationServiceProvider;
    			case "Block": return this.BlockServiceProvider;
    			case "LocalFunctionStatement": return this.LocalFunctionStatementServiceProvider;
    			case "LocalDeclarationStatement": return this.LocalDeclarationStatementServiceProvider;
    			case "ExpressionStatement": return this.ExpressionStatementServiceProvider;
    			case "EmptyStatement": return this.EmptyStatementServiceProvider;
    			case "LabeledStatement": return this.LabeledStatementServiceProvider;
    			case "GotoStatement": return this.GotoStatementServiceProvider;
    			case "BreakStatement": return this.BreakStatementServiceProvider;
    			case "ContinueStatement": return this.ContinueStatementServiceProvider;
    			case "ReturnStatement": return this.ReturnStatementServiceProvider;
    			case "ThrowStatement": return this.ThrowStatementServiceProvider;
    			case "YieldStatement": return this.YieldStatementServiceProvider;
    			case "WhileStatement": return this.WhileStatementServiceProvider;
    			case "DoStatement": return this.DoStatementServiceProvider;
    			case "ForStatement": return this.ForStatementServiceProvider;
    			case "UsingStatement": return this.UsingStatementServiceProvider;
    			case "FixedStatement": return this.FixedStatementServiceProvider;
    			case "CheckedStatement": return this.CheckedStatementServiceProvider;
    			case "UnsafeStatement": return this.UnsafeStatementServiceProvider;
    			case "LockStatement": return this.LockStatementServiceProvider;
    			case "IfStatement": return this.IfStatementServiceProvider;
    			case "SwitchStatement": return this.SwitchStatementServiceProvider;
    			case "TryStatement": return this.TryStatementServiceProvider;
    			case "ForEachStatement": return this.ForEachStatementServiceProvider;
    			case "ForEachVariableStatement": return this.ForEachVariableStatementServiceProvider;
    			case "SingleVariableDesignation": return this.SingleVariableDesignationServiceProvider;
    			case "DiscardDesignation": return this.DiscardDesignationServiceProvider;
    			case "ParenthesizedVariableDesignation": return this.ParenthesizedVariableDesignationServiceProvider;
    			case "CasePatternSwitchLabel": return this.CasePatternSwitchLabelServiceProvider;
    			case "CaseSwitchLabel": return this.CaseSwitchLabelServiceProvider;
    			case "DefaultSwitchLabel": return this.DefaultSwitchLabelServiceProvider;
    			case "SimpleBaseType": return this.SimpleBaseTypeServiceProvider;
    			case "ConstructorConstraint": return this.ConstructorConstraintServiceProvider;
    			case "ClassOrStructConstraint": return this.ClassOrStructConstraintServiceProvider;
    			case "TypeConstraint": return this.TypeConstraintServiceProvider;
    			case "ParameterList": return this.ParameterListServiceProvider;
    			case "BracketedParameterList": return this.BracketedParameterListServiceProvider;
    			case "SkippedTokensTrivia": return this.SkippedTokensTriviaServiceProvider;
    			case "DocumentationCommentTrivia": return this.DocumentationCommentTriviaServiceProvider;
    			case "EndIfDirectiveTrivia": return this.EndIfDirectiveTriviaServiceProvider;
    			case "RegionDirectiveTrivia": return this.RegionDirectiveTriviaServiceProvider;
    			case "EndRegionDirectiveTrivia": return this.EndRegionDirectiveTriviaServiceProvider;
    			case "ErrorDirectiveTrivia": return this.ErrorDirectiveTriviaServiceProvider;
    			case "WarningDirectiveTrivia": return this.WarningDirectiveTriviaServiceProvider;
    			case "BadDirectiveTrivia": return this.BadDirectiveTriviaServiceProvider;
    			case "DefineDirectiveTrivia": return this.DefineDirectiveTriviaServiceProvider;
    			case "UndefDirectiveTrivia": return this.UndefDirectiveTriviaServiceProvider;
    			case "LineDirectiveTrivia": return this.LineDirectiveTriviaServiceProvider;
    			case "PragmaWarningDirectiveTrivia": return this.PragmaWarningDirectiveTriviaServiceProvider;
    			case "PragmaChecksumDirectiveTrivia": return this.PragmaChecksumDirectiveTriviaServiceProvider;
    			case "ReferenceDirectiveTrivia": return this.ReferenceDirectiveTriviaServiceProvider;
    			case "LoadDirectiveTrivia": return this.LoadDirectiveTriviaServiceProvider;
    			case "ShebangDirectiveTrivia": return this.ShebangDirectiveTriviaServiceProvider;
    			case "ElseDirectiveTrivia": return this.ElseDirectiveTriviaServiceProvider;
    			case "IfDirectiveTrivia": return this.IfDirectiveTriviaServiceProvider;
    			case "ElifDirectiveTrivia": return this.ElifDirectiveTriviaServiceProvider;
    			case "TypeCref": return this.TypeCrefServiceProvider;
    			case "QualifiedCref": return this.QualifiedCrefServiceProvider;
    			case "NameMemberCref": return this.NameMemberCrefServiceProvider;
    			case "IndexerMemberCref": return this.IndexerMemberCrefServiceProvider;
    			case "OperatorMemberCref": return this.OperatorMemberCrefServiceProvider;
    			case "ConversionOperatorMemberCref": return this.ConversionOperatorMemberCrefServiceProvider;
    			case "CrefParameterList": return this.CrefParameterListServiceProvider;
    			case "CrefBracketedParameterList": return this.CrefBracketedParameterListServiceProvider;
    			case "XmlElement": return this.XmlElementServiceProvider;
    			case "XmlEmptyElement": return this.XmlEmptyElementServiceProvider;
    			case "XmlText": return this.XmlTextServiceProvider;
    			case "XmlCDataSection": return this.XmlCDataSectionServiceProvider;
    			case "XmlProcessingInstruction": return this.XmlProcessingInstructionServiceProvider;
    			case "XmlComment": return this.XmlCommentServiceProvider;
    			case "XmlTextAttribute": return this.XmlTextAttributeServiceProvider;
    			case "XmlCrefAttribute": return this.XmlCrefAttributeServiceProvider;
    			case "XmlNameAttribute": return this.XmlNameAttributeServiceProvider;
    			default: return null;//throw new ArgumentException(nameof(type));
    		}
    	}
    
    	/// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the requested element type.</returns>
        public virtual  Jawilliam.CDF.Approach.Services.IElementTypeServiceProvider GetElementTypeServiceProvider(SyntaxKind type, string subtype = null)
    	{
    		switch(type)
    		{
    			case SyntaxKind.TypeArgumentList: return this.TypeArgumentListServiceProvider;
    			case SyntaxKind.ArrayRankSpecifier: return this.ArrayRankSpecifierServiceProvider;
    			case SyntaxKind.TupleElement: return this.TupleElementServiceProvider;
    			case SyntaxKind.Argument: return this.ArgumentServiceProvider;
    			case SyntaxKind.NameColon: return this.NameColonServiceProvider;
    			case SyntaxKind.AnonymousObjectMemberDeclarator: return this.AnonymousObjectMemberDeclaratorServiceProvider;
    			case SyntaxKind.QueryBody: return this.QueryBodyServiceProvider;
    			case SyntaxKind.JoinIntoClause: return this.JoinIntoClauseServiceProvider;
    			case SyntaxKind.AscendingOrdering:
    			case SyntaxKind.DescendingOrdering: return this.OrderingServiceProvider;
    			case SyntaxKind.QueryContinuation: return this.QueryContinuationServiceProvider;
    			case SyntaxKind.WhenClause: return this.WhenClauseServiceProvider;
    			case SyntaxKind.InterpolationAlignmentClause: return this.InterpolationAlignmentClauseServiceProvider;
    			case SyntaxKind.InterpolationFormatClause: return this.InterpolationFormatClauseServiceProvider;
    			case SyntaxKind.VariableDeclaration: return this.VariableDeclarationServiceProvider;
    			case SyntaxKind.VariableDeclarator: return this.VariableDeclaratorServiceProvider;
    			case SyntaxKind.EqualsValueClause: return this.EqualsValueClauseServiceProvider;
    			case SyntaxKind.ElseClause: return this.ElseClauseServiceProvider;
    			case SyntaxKind.SwitchSection: return this.SwitchSectionServiceProvider;
    			case SyntaxKind.CatchClause: return this.CatchClauseServiceProvider;
    			case SyntaxKind.CatchDeclaration: return this.CatchDeclarationServiceProvider;
    			case SyntaxKind.CatchFilterClause: return this.CatchFilterClauseServiceProvider;
    			case SyntaxKind.FinallyClause: return this.FinallyClauseServiceProvider;
    			case SyntaxKind.CompilationUnit: return this.CompilationUnitServiceProvider;
    			case SyntaxKind.ExternAliasDirective: return this.ExternAliasDirectiveServiceProvider;
    			case SyntaxKind.UsingDirective: return this.UsingDirectiveServiceProvider;
    			case SyntaxKind.AttributeList: return this.AttributeListServiceProvider;
    			case SyntaxKind.AttributeTargetSpecifier: return this.AttributeTargetSpecifierServiceProvider;
    			case SyntaxKind.Attribute: return this.AttributeServiceProvider;
    			case SyntaxKind.AttributeArgumentList: return this.AttributeArgumentListServiceProvider;
    			case SyntaxKind.AttributeArgument: return this.AttributeArgumentServiceProvider;
    			case SyntaxKind.NameEquals: return this.NameEqualsServiceProvider;
    			case SyntaxKind.TypeParameterList: return this.TypeParameterListServiceProvider;
    			case SyntaxKind.TypeParameter: return this.TypeParameterServiceProvider;
    			case SyntaxKind.BaseList: return this.BaseListServiceProvider;
    			case SyntaxKind.TypeParameterConstraintClause: return this.TypeParameterConstraintClauseServiceProvider;
    			case SyntaxKind.ExplicitInterfaceSpecifier: return this.ExplicitInterfaceSpecifierServiceProvider;
    			case SyntaxKind.BaseConstructorInitializer:
    			case SyntaxKind.ThisConstructorInitializer: return this.ConstructorInitializerServiceProvider;
    			case SyntaxKind.ArrowExpressionClause: return this.ArrowExpressionClauseServiceProvider;
    			case SyntaxKind.AccessorList: return this.AccessorListServiceProvider;
    			case SyntaxKind.AddAccessorDeclaration:
    			case SyntaxKind.RemoveAccessorDeclaration:
    			case SyntaxKind.GetAccessorDeclaration:
    			case SyntaxKind.SetAccessorDeclaration: return this.AccessorDeclarationServiceProvider;
    			case SyntaxKind.Parameter: return this.ParameterServiceProvider;
    			case SyntaxKind.CrefParameter: return this.CrefParameterServiceProvider;
    			case SyntaxKind.XmlElementStartTag: return this.XmlElementStartTagServiceProvider;
    			case SyntaxKind.XmlElementEndTag: return this.XmlElementEndTagServiceProvider;
    			case SyntaxKind.XmlName: return this.XmlNameServiceProvider;
    			case SyntaxKind.XmlPrefix: return this.XmlPrefixServiceProvider;
    			case SyntaxKind.ParenthesizedExpression: return this.ParenthesizedExpressionServiceProvider;
    			case SyntaxKind.TupleExpression: return this.TupleExpressionServiceProvider;
    			case SyntaxKind.UnaryPlusExpression:
                case SyntaxKind.UnaryMinusExpression:
                case SyntaxKind.BitwiseNotExpression:
                case SyntaxKind.LogicalNotExpression:
                case SyntaxKind.PreIncrementExpression:
                case SyntaxKind.PreDecrementExpression:
                case SyntaxKind.AddressOfExpression:
                case SyntaxKind.PointerIndirectionExpression: return this.PrefixUnaryExpressionServiceProvider;
    			case SyntaxKind.AwaitExpression: return this.AwaitExpressionServiceProvider;
    			case SyntaxKind.PostIncrementExpression:
                case SyntaxKind.PostDecrementExpression: return this.PostfixUnaryExpressionServiceProvider;
    			case SyntaxKind.SimpleMemberAccessExpression:
                case SyntaxKind.PointerMemberAccessExpression: return this.MemberAccessExpressionServiceProvider;
    			case SyntaxKind.ConditionalAccessExpression: return this.ConditionalAccessExpressionServiceProvider;
    			case SyntaxKind.MemberBindingExpression: return this.MemberBindingExpressionServiceProvider;
    			case SyntaxKind.ElementBindingExpression: return this.ElementBindingExpressionServiceProvider;
    			case SyntaxKind.ImplicitElementAccess: return this.ImplicitElementAccessServiceProvider;
    			case SyntaxKind.AddExpression:
                case SyntaxKind.SubtractExpression:
                case SyntaxKind.MultiplyExpression:
                case SyntaxKind.DivideExpression:
                case SyntaxKind.ModuloExpression:
                case SyntaxKind.LeftShiftExpression:
                case SyntaxKind.RightShiftExpression:
                case SyntaxKind.LogicalOrExpression:
                case SyntaxKind.LogicalAndExpression:
                case SyntaxKind.BitwiseOrExpression:
                case SyntaxKind.BitwiseAndExpression:
                case SyntaxKind.ExclusiveOrExpression:
                case SyntaxKind.EqualsExpression:
                case SyntaxKind.NotEqualsExpression:
                case SyntaxKind.LessThanExpression:
                case SyntaxKind.LessThanOrEqualExpression:
                case SyntaxKind.GreaterThanExpression:
                case SyntaxKind.GreaterThanOrEqualExpression:
                case SyntaxKind.IsExpression:
                case SyntaxKind.AsExpression:
                case SyntaxKind.CoalesceExpression: return this.BinaryExpressionServiceProvider;
    			case SyntaxKind.SimpleAssignmentExpression:
                case SyntaxKind.AddAssignmentExpression:
                case SyntaxKind.SubtractAssignmentExpression:
                case SyntaxKind.MultiplyAssignmentExpression:
                case SyntaxKind.DivideAssignmentExpression:
                case SyntaxKind.ModuloAssignmentExpression:
                case SyntaxKind.AndAssignmentExpression:
                case SyntaxKind.ExclusiveOrAssignmentExpression:
                case SyntaxKind.OrAssignmentExpression:
                case SyntaxKind.LeftShiftAssignmentExpression:
                case SyntaxKind.RightShiftAssignmentExpression: return this.AssignmentExpressionServiceProvider;
    			case SyntaxKind.ConditionalExpression: return this.ConditionalExpressionServiceProvider;
    			case SyntaxKind.ArgListExpression:
                case SyntaxKind.NumericLiteralExpression:
                case SyntaxKind.StringLiteralExpression:
                case SyntaxKind.CharacterLiteralExpression:
                case SyntaxKind.TrueLiteralExpression:
                case SyntaxKind.FalseLiteralExpression:
                case SyntaxKind.NullLiteralExpression: return this.LiteralExpressionServiceProvider;
    			case SyntaxKind.MakeRefExpression: return this.MakeRefExpressionServiceProvider;
    			case SyntaxKind.RefTypeExpression: return this.RefTypeExpressionServiceProvider;
    			case SyntaxKind.RefValueExpression: return this.RefValueExpressionServiceProvider;
    			case SyntaxKind.CheckedExpression: return this.CheckedExpressionServiceProvider;
    			case SyntaxKind.DefaultExpression: return this.DefaultExpressionServiceProvider;
    			case SyntaxKind.TypeOfExpression: return this.TypeOfExpressionServiceProvider;
    			case SyntaxKind.SizeOfExpression: return this.SizeOfExpressionServiceProvider;
    			case SyntaxKind.InvocationExpression: return this.InvocationExpressionServiceProvider;
    			case SyntaxKind.ElementAccessExpression: return this.ElementAccessExpressionServiceProvider;
    			case SyntaxKind.DeclarationExpression: return this.DeclarationExpressionServiceProvider;
    			case SyntaxKind.CastExpression: return this.CastExpressionServiceProvider;
    			case SyntaxKind.RefExpression: return this.RefExpressionServiceProvider;
    			case SyntaxKind.ObjectInitializerExpression:
                case SyntaxKind.CollectionInitializerExpression:
                case SyntaxKind.ArrayInitializerExpression:
                case SyntaxKind.ComplexElementInitializerExpression: return this.InitializerExpressionServiceProvider;
    			case SyntaxKind.ObjectCreationExpression: return this.ObjectCreationExpressionServiceProvider;
    			case SyntaxKind.AnonymousObjectCreationExpression: return this.AnonymousObjectCreationExpressionServiceProvider;
    			case SyntaxKind.ArrayCreationExpression: return this.ArrayCreationExpressionServiceProvider;
    			case SyntaxKind.ImplicitArrayCreationExpression: return this.ImplicitArrayCreationExpressionServiceProvider;
    			case SyntaxKind.StackAllocArrayCreationExpression: return this.StackAllocArrayCreationExpressionServiceProvider;
    			case SyntaxKind.QueryExpression: return this.QueryExpressionServiceProvider;
    			case SyntaxKind.OmittedArraySizeExpression: return this.OmittedArraySizeExpressionServiceProvider;
    			case SyntaxKind.InterpolatedStringExpression: return this.InterpolatedStringExpressionServiceProvider;
    			case SyntaxKind.IsPatternExpression: return this.IsPatternExpressionServiceProvider;
    			case SyntaxKind.ThrowExpression: return this.ThrowExpressionServiceProvider;
    			case SyntaxKind.PredefinedType: return this.PredefinedTypeServiceProvider;
    			case SyntaxKind.ArrayType: return this.ArrayTypeServiceProvider;
    			case SyntaxKind.PointerType: return this.PointerTypeServiceProvider;
    			case SyntaxKind.NullableType: return this.NullableTypeServiceProvider;
    			case SyntaxKind.TupleType: return this.TupleTypeServiceProvider;
    			case SyntaxKind.OmittedTypeArgument: return this.OmittedTypeArgumentServiceProvider;
    			case SyntaxKind.RefType: return this.RefTypeServiceProvider;
    			case SyntaxKind.QualifiedName: return this.QualifiedNameServiceProvider;
    			case SyntaxKind.AliasQualifiedName: return this.AliasQualifiedNameServiceProvider;
    			case SyntaxKind.IdentifierName: return this.IdentifierNameServiceProvider;
    			case SyntaxKind.GenericName: return this.GenericNameServiceProvider;
    			case SyntaxKind.ThisExpression: return this.ThisExpressionServiceProvider;
    			case SyntaxKind.BaseExpression: return this.BaseExpressionServiceProvider;
    			case SyntaxKind.AnonymousMethodExpression: return this.AnonymousMethodExpressionServiceProvider;
    			case SyntaxKind.SimpleLambdaExpression: return this.SimpleLambdaExpressionServiceProvider;
    			case SyntaxKind.ParenthesizedLambdaExpression: return this.ParenthesizedLambdaExpressionServiceProvider;
    			case SyntaxKind.ArgumentList: return this.ArgumentListServiceProvider;
    			case SyntaxKind.BracketedArgumentList: return this.BracketedArgumentListServiceProvider;
    			case SyntaxKind.FromClause: return this.FromClauseServiceProvider;
    			case SyntaxKind.LetClause: return this.LetClauseServiceProvider;
    			case SyntaxKind.JoinClause: return this.JoinClauseServiceProvider;
    			case SyntaxKind.WhereClause: return this.WhereClauseServiceProvider;
    			case SyntaxKind.OrderByClause: return this.OrderByClauseServiceProvider;
    			case SyntaxKind.SelectClause: return this.SelectClauseServiceProvider;
    			case SyntaxKind.GroupClause: return this.GroupClauseServiceProvider;
    			case SyntaxKind.DeclarationPattern: return this.DeclarationPatternServiceProvider;
    			case SyntaxKind.ConstantPattern: return this.ConstantPatternServiceProvider;
    			case SyntaxKind.InterpolatedStringText: return this.InterpolatedStringTextServiceProvider;
    			case SyntaxKind.Interpolation: return this.InterpolationServiceProvider;
    			case SyntaxKind.GlobalStatement: return this.GlobalStatementServiceProvider;
    			case SyntaxKind.NamespaceDeclaration: return this.NamespaceDeclarationServiceProvider;
    			case SyntaxKind.DelegateDeclaration: return this.DelegateDeclarationServiceProvider;
    			case SyntaxKind.EnumMemberDeclaration: return this.EnumMemberDeclarationServiceProvider;
    			case SyntaxKind.IncompleteMember: return this.IncompleteMemberServiceProvider;
    			case SyntaxKind.EnumDeclaration: return this.EnumDeclarationServiceProvider;
    			case SyntaxKind.ClassDeclaration: return this.ClassDeclarationServiceProvider;
    			case SyntaxKind.StructDeclaration: return this.StructDeclarationServiceProvider;
    			case SyntaxKind.InterfaceDeclaration: return this.InterfaceDeclarationServiceProvider;
    			case SyntaxKind.FieldDeclaration: return this.FieldDeclarationServiceProvider;
    			case SyntaxKind.EventFieldDeclaration: return this.EventFieldDeclarationServiceProvider;
    			case SyntaxKind.MethodDeclaration: return this.MethodDeclarationServiceProvider;
    			case SyntaxKind.OperatorDeclaration: return this.OperatorDeclarationServiceProvider;
    			case SyntaxKind.ConversionOperatorDeclaration: return this.ConversionOperatorDeclarationServiceProvider;
    			case SyntaxKind.ConstructorDeclaration: return this.ConstructorDeclarationServiceProvider;
    			case SyntaxKind.DestructorDeclaration: return this.DestructorDeclarationServiceProvider;
    			case SyntaxKind.PropertyDeclaration: return this.PropertyDeclarationServiceProvider;
    			case SyntaxKind.EventDeclaration: return this.EventDeclarationServiceProvider;
    			case SyntaxKind.IndexerDeclaration: return this.IndexerDeclarationServiceProvider;
    			case SyntaxKind.Block: return this.BlockServiceProvider;
    			case SyntaxKind.LocalFunctionStatement: return this.LocalFunctionStatementServiceProvider;
    			case SyntaxKind.LocalDeclarationStatement: return this.LocalDeclarationStatementServiceProvider;
    			case SyntaxKind.ExpressionStatement: return this.ExpressionStatementServiceProvider;
    			case SyntaxKind.EmptyStatement: return this.EmptyStatementServiceProvider;
    			case SyntaxKind.LabeledStatement: return this.LabeledStatementServiceProvider;
    			case SyntaxKind.GotoStatement: return this.GotoStatementServiceProvider;
    			case SyntaxKind.BreakStatement: return this.BreakStatementServiceProvider;
    			case SyntaxKind.ContinueStatement: return this.ContinueStatementServiceProvider;
    			case SyntaxKind.ReturnStatement: return this.ReturnStatementServiceProvider;
    			case SyntaxKind.ThrowStatement: return this.ThrowStatementServiceProvider;
    			case SyntaxKind.YieldReturnStatement:
                case SyntaxKind.YieldBreakStatement: return this.YieldStatementServiceProvider;
    			case SyntaxKind.WhileStatement: return this.WhileStatementServiceProvider;
    			case SyntaxKind.DoStatement: return this.DoStatementServiceProvider;
    			case SyntaxKind.ForStatement: return this.ForStatementServiceProvider;
    			case SyntaxKind.UsingStatement: return this.UsingStatementServiceProvider;
    			case SyntaxKind.FixedStatement: return this.FixedStatementServiceProvider;
    			case SyntaxKind.CheckedStatement: return this.CheckedStatementServiceProvider;
    			case SyntaxKind.UnsafeStatement: return this.UnsafeStatementServiceProvider;
    			case SyntaxKind.LockStatement: return this.LockStatementServiceProvider;
    			case SyntaxKind.IfStatement: return this.IfStatementServiceProvider;
    			case SyntaxKind.SwitchStatement: return this.SwitchStatementServiceProvider;
    			case SyntaxKind.TryStatement: return this.TryStatementServiceProvider;
    			case SyntaxKind.ForEachStatement: return this.ForEachStatementServiceProvider;
    			case SyntaxKind.ForEachVariableStatement: return this.ForEachVariableStatementServiceProvider;
    			case SyntaxKind.SingleVariableDesignation: return this.SingleVariableDesignationServiceProvider;
    			case SyntaxKind.DiscardDesignation: return this.DiscardDesignationServiceProvider;
    			case SyntaxKind.ParenthesizedVariableDesignation: return this.ParenthesizedVariableDesignationServiceProvider;
    			case SyntaxKind.CasePatternSwitchLabel: return this.CasePatternSwitchLabelServiceProvider;
    			case SyntaxKind.CaseSwitchLabel: return this.CaseSwitchLabelServiceProvider;
    			case SyntaxKind.DefaultSwitchLabel: return this.DefaultSwitchLabelServiceProvider;
    			case SyntaxKind.SimpleBaseType: return this.SimpleBaseTypeServiceProvider;
    			case SyntaxKind.ConstructorConstraint: return this.ConstructorConstraintServiceProvider;
    			case SyntaxKind.ClassConstraint:
    			case SyntaxKind.StructConstraint: return this.ClassOrStructConstraintServiceProvider;
    			case SyntaxKind.TypeConstraint: return this.TypeConstraintServiceProvider;
    			case SyntaxKind.ParameterList: return this.ParameterListServiceProvider;
    			case SyntaxKind.BracketedParameterList: return this.BracketedParameterListServiceProvider;
    			case SyntaxKind.SkippedTokensTrivia: return this.SkippedTokensTriviaServiceProvider;
    			case SyntaxKind.SingleLineDocumentationCommentTrivia:
    			case SyntaxKind.MultiLineDocumentationCommentTrivia:  return this.DocumentationCommentTriviaServiceProvider;
    			case SyntaxKind.EndIfDirectiveTrivia: return this.EndIfDirectiveTriviaServiceProvider;
    			case SyntaxKind.RegionDirectiveTrivia: return this.RegionDirectiveTriviaServiceProvider;
    			case SyntaxKind.EndRegionDirectiveTrivia: return this.EndRegionDirectiveTriviaServiceProvider;
    			case SyntaxKind.ErrorDirectiveTrivia: return this.ErrorDirectiveTriviaServiceProvider;
    			case SyntaxKind.WarningDirectiveTrivia: return this.WarningDirectiveTriviaServiceProvider;
    			case SyntaxKind.BadDirectiveTrivia: return this.BadDirectiveTriviaServiceProvider;
    			case SyntaxKind.DefineDirectiveTrivia: return this.DefineDirectiveTriviaServiceProvider;
    			case SyntaxKind.UndefDirectiveTrivia: return this.UndefDirectiveTriviaServiceProvider;
    			case SyntaxKind.LineDirectiveTrivia: return this.LineDirectiveTriviaServiceProvider;
    			case SyntaxKind.PragmaWarningDirectiveTrivia: return this.PragmaWarningDirectiveTriviaServiceProvider;
    			case SyntaxKind.PragmaChecksumDirectiveTrivia: return this.PragmaChecksumDirectiveTriviaServiceProvider;
    			case SyntaxKind.ReferenceDirectiveTrivia: return this.ReferenceDirectiveTriviaServiceProvider;
    			case SyntaxKind.LoadDirectiveTrivia: return this.LoadDirectiveTriviaServiceProvider;
    			case SyntaxKind.ShebangDirectiveTrivia: return this.ShebangDirectiveTriviaServiceProvider;
    			case SyntaxKind.ElseDirectiveTrivia: return this.ElseDirectiveTriviaServiceProvider;
    			case SyntaxKind.IfDirectiveTrivia: return this.IfDirectiveTriviaServiceProvider;
    			case SyntaxKind.ElifDirectiveTrivia: return this.ElifDirectiveTriviaServiceProvider;
    			case SyntaxKind.TypeCref: return this.TypeCrefServiceProvider;
    			case SyntaxKind.QualifiedCref: return this.QualifiedCrefServiceProvider;
    			case SyntaxKind.NameMemberCref: return this.NameMemberCrefServiceProvider;
    			case SyntaxKind.IndexerMemberCref: return this.IndexerMemberCrefServiceProvider;
    			case SyntaxKind.OperatorMemberCref: return this.OperatorMemberCrefServiceProvider;
    			case SyntaxKind.ConversionOperatorMemberCref: return this.ConversionOperatorMemberCrefServiceProvider;
    			case SyntaxKind.CrefParameterList: return this.CrefParameterListServiceProvider;
    			case SyntaxKind.CrefBracketedParameterList: return this.CrefBracketedParameterListServiceProvider;
    			case SyntaxKind.XmlElement: return this.XmlElementServiceProvider;
    			case SyntaxKind.XmlEmptyElement: return this.XmlEmptyElementServiceProvider;
    			case SyntaxKind.XmlText: return this.XmlTextServiceProvider;
    			case SyntaxKind.XmlCDataSection: return this.XmlCDataSectionServiceProvider;
    			case SyntaxKind.XmlProcessingInstruction: return this.XmlProcessingInstructionServiceProvider;
    			case SyntaxKind.XmlComment: return this.XmlCommentServiceProvider;
    			case SyntaxKind.XmlTextAttribute: return this.XmlTextAttributeServiceProvider;
    			case SyntaxKind.XmlCrefAttribute: return this.XmlCrefAttributeServiceProvider;
    			case SyntaxKind.XmlNameAttribute: return this.XmlNameAttributeServiceProvider;
    			default: throw new ArgumentException(nameof(type));
    		}
    	}
    
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
        /// Provides language-specific information about the "SyntaxToken" type.
        /// </summary>
        public virtual SyntaxTokenServiceProvider SyntaxTokenServiceProvider
        {
            get => _syntaxTokenServiceProvider ?? (_syntaxTokenServiceProvider = new SyntaxTokenServiceProvider(this));
            set => _syntaxTokenServiceProvider = value;
        }
        private SyntaxTokenServiceProvider _syntaxTokenServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeArgumentList" type.
        /// </summary>
    	public virtual TypeArgumentListServiceProvider TypeArgumentListServiceProvider
    	{
    		get => _typeArgumentListServiceProvider ?? (_typeArgumentListServiceProvider = new TypeArgumentListServiceProvider(this));
    		set => _typeArgumentListServiceProvider = value;
    	}
    	private TypeArgumentListServiceProvider _typeArgumentListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayRankSpecifier" type.
        /// </summary>
    	public virtual ArrayRankSpecifierServiceProvider ArrayRankSpecifierServiceProvider
    	{
    		get => _arrayRankSpecifierServiceProvider ?? (_arrayRankSpecifierServiceProvider = new ArrayRankSpecifierServiceProvider(this));
    		set => _arrayRankSpecifierServiceProvider = value;
    	}
    	private ArrayRankSpecifierServiceProvider _arrayRankSpecifierServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleElement" type.
        /// </summary>
    	public virtual TupleElementServiceProvider TupleElementServiceProvider
    	{
    		get => _tupleElementServiceProvider ?? (_tupleElementServiceProvider = new TupleElementServiceProvider(this));
    		set => _tupleElementServiceProvider = value;
    	}
    	private TupleElementServiceProvider _tupleElementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Argument" type.
        /// </summary>
    	public virtual ArgumentServiceProvider ArgumentServiceProvider
    	{
    		get => _argumentServiceProvider ?? (_argumentServiceProvider = new ArgumentServiceProvider(this));
    		set => _argumentServiceProvider = value;
    	}
    	private ArgumentServiceProvider _argumentServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "NameColon" type.
        /// </summary>
    	public virtual NameColonServiceProvider NameColonServiceProvider
    	{
    		get => _nameColonServiceProvider ?? (_nameColonServiceProvider = new NameColonServiceProvider(this));
    		set => _nameColonServiceProvider = value;
    	}
    	private NameColonServiceProvider _nameColonServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectMemberDeclarator" type.
        /// </summary>
    	public virtual AnonymousObjectMemberDeclaratorServiceProvider AnonymousObjectMemberDeclaratorServiceProvider
    	{
    		get => _anonymousObjectMemberDeclaratorServiceProvider ?? (_anonymousObjectMemberDeclaratorServiceProvider = new AnonymousObjectMemberDeclaratorServiceProvider(this));
    		set => _anonymousObjectMemberDeclaratorServiceProvider = value;
    	}
    	private AnonymousObjectMemberDeclaratorServiceProvider _anonymousObjectMemberDeclaratorServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryBody" type.
        /// </summary>
    	public virtual QueryBodyServiceProvider QueryBodyServiceProvider
    	{
    		get => _queryBodyServiceProvider ?? (_queryBodyServiceProvider = new QueryBodyServiceProvider(this));
    		set => _queryBodyServiceProvider = value;
    	}
    	private QueryBodyServiceProvider _queryBodyServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinIntoClause" type.
        /// </summary>
    	public virtual JoinIntoClauseServiceProvider JoinIntoClauseServiceProvider
    	{
    		get => _joinIntoClauseServiceProvider ?? (_joinIntoClauseServiceProvider = new JoinIntoClauseServiceProvider(this));
    		set => _joinIntoClauseServiceProvider = value;
    	}
    	private JoinIntoClauseServiceProvider _joinIntoClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Ordering" type.
        /// </summary>
    	public virtual OrderingServiceProvider OrderingServiceProvider
    	{
    		get => _orderingServiceProvider ?? (_orderingServiceProvider = new OrderingServiceProvider(this));
    		set => _orderingServiceProvider = value;
    	}
    	private OrderingServiceProvider _orderingServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryContinuation" type.
        /// </summary>
    	public virtual QueryContinuationServiceProvider QueryContinuationServiceProvider
    	{
    		get => _queryContinuationServiceProvider ?? (_queryContinuationServiceProvider = new QueryContinuationServiceProvider(this));
    		set => _queryContinuationServiceProvider = value;
    	}
    	private QueryContinuationServiceProvider _queryContinuationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "WhenClause" type.
        /// </summary>
    	public virtual WhenClauseServiceProvider WhenClauseServiceProvider
    	{
    		get => _whenClauseServiceProvider ?? (_whenClauseServiceProvider = new WhenClauseServiceProvider(this));
    		set => _whenClauseServiceProvider = value;
    	}
    	private WhenClauseServiceProvider _whenClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationAlignmentClause" type.
        /// </summary>
    	public virtual InterpolationAlignmentClauseServiceProvider InterpolationAlignmentClauseServiceProvider
    	{
    		get => _interpolationAlignmentClauseServiceProvider ?? (_interpolationAlignmentClauseServiceProvider = new InterpolationAlignmentClauseServiceProvider(this));
    		set => _interpolationAlignmentClauseServiceProvider = value;
    	}
    	private InterpolationAlignmentClauseServiceProvider _interpolationAlignmentClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationFormatClause" type.
        /// </summary>
    	public virtual InterpolationFormatClauseServiceProvider InterpolationFormatClauseServiceProvider
    	{
    		get => _interpolationFormatClauseServiceProvider ?? (_interpolationFormatClauseServiceProvider = new InterpolationFormatClauseServiceProvider(this));
    		set => _interpolationFormatClauseServiceProvider = value;
    	}
    	private InterpolationFormatClauseServiceProvider _interpolationFormatClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclaration" type.
        /// </summary>
    	public virtual VariableDeclarationServiceProvider VariableDeclarationServiceProvider
    	{
    		get => _variableDeclarationServiceProvider ?? (_variableDeclarationServiceProvider = new VariableDeclarationServiceProvider(this));
    		set => _variableDeclarationServiceProvider = value;
    	}
    	private VariableDeclarationServiceProvider _variableDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclarator" type.
        /// </summary>
    	public virtual VariableDeclaratorServiceProvider VariableDeclaratorServiceProvider
    	{
    		get => _variableDeclaratorServiceProvider ?? (_variableDeclaratorServiceProvider = new VariableDeclaratorServiceProvider(this));
    		set => _variableDeclaratorServiceProvider = value;
    	}
    	private VariableDeclaratorServiceProvider _variableDeclaratorServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EqualsValueClause" type.
        /// </summary>
    	public virtual EqualsValueClauseServiceProvider EqualsValueClauseServiceProvider
    	{
    		get => _equalsValueClauseServiceProvider ?? (_equalsValueClauseServiceProvider = new EqualsValueClauseServiceProvider(this));
    		set => _equalsValueClauseServiceProvider = value;
    	}
    	private EqualsValueClauseServiceProvider _equalsValueClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseClause" type.
        /// </summary>
    	public virtual ElseClauseServiceProvider ElseClauseServiceProvider
    	{
    		get => _elseClauseServiceProvider ?? (_elseClauseServiceProvider = new ElseClauseServiceProvider(this));
    		set => _elseClauseServiceProvider = value;
    	}
    	private ElseClauseServiceProvider _elseClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchSection" type.
        /// </summary>
    	public virtual SwitchSectionServiceProvider SwitchSectionServiceProvider
    	{
    		get => _switchSectionServiceProvider ?? (_switchSectionServiceProvider = new SwitchSectionServiceProvider(this));
    		set => _switchSectionServiceProvider = value;
    	}
    	private SwitchSectionServiceProvider _switchSectionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchClause" type.
        /// </summary>
    	public virtual CatchClauseServiceProvider CatchClauseServiceProvider
    	{
    		get => _catchClauseServiceProvider ?? (_catchClauseServiceProvider = new CatchClauseServiceProvider(this));
    		set => _catchClauseServiceProvider = value;
    	}
    	private CatchClauseServiceProvider _catchClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchDeclaration" type.
        /// </summary>
    	public virtual CatchDeclarationServiceProvider CatchDeclarationServiceProvider
    	{
    		get => _catchDeclarationServiceProvider ?? (_catchDeclarationServiceProvider = new CatchDeclarationServiceProvider(this));
    		set => _catchDeclarationServiceProvider = value;
    	}
    	private CatchDeclarationServiceProvider _catchDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchFilterClause" type.
        /// </summary>
    	public virtual CatchFilterClauseServiceProvider CatchFilterClauseServiceProvider
    	{
    		get => _catchFilterClauseServiceProvider ?? (_catchFilterClauseServiceProvider = new CatchFilterClauseServiceProvider(this));
    		set => _catchFilterClauseServiceProvider = value;
    	}
    	private CatchFilterClauseServiceProvider _catchFilterClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "FinallyClause" type.
        /// </summary>
    	public virtual FinallyClauseServiceProvider FinallyClauseServiceProvider
    	{
    		get => _finallyClauseServiceProvider ?? (_finallyClauseServiceProvider = new FinallyClauseServiceProvider(this));
    		set => _finallyClauseServiceProvider = value;
    	}
    	private FinallyClauseServiceProvider _finallyClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CompilationUnit" type.
        /// </summary>
    	public virtual CompilationUnitServiceProvider CompilationUnitServiceProvider
    	{
    		get => _compilationUnitServiceProvider ?? (_compilationUnitServiceProvider = new CompilationUnitServiceProvider(this));
    		set => _compilationUnitServiceProvider = value;
    	}
    	private CompilationUnitServiceProvider _compilationUnitServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ExternAliasDirective" type.
        /// </summary>
    	public virtual ExternAliasDirectiveServiceProvider ExternAliasDirectiveServiceProvider
    	{
    		get => _externAliasDirectiveServiceProvider ?? (_externAliasDirectiveServiceProvider = new ExternAliasDirectiveServiceProvider(this));
    		set => _externAliasDirectiveServiceProvider = value;
    	}
    	private ExternAliasDirectiveServiceProvider _externAliasDirectiveServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingDirective" type.
        /// </summary>
    	public virtual UsingDirectiveServiceProvider UsingDirectiveServiceProvider
    	{
    		get => _usingDirectiveServiceProvider ?? (_usingDirectiveServiceProvider = new UsingDirectiveServiceProvider(this));
    		set => _usingDirectiveServiceProvider = value;
    	}
    	private UsingDirectiveServiceProvider _usingDirectiveServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeList" type.
        /// </summary>
    	public virtual AttributeListServiceProvider AttributeListServiceProvider
    	{
    		get => _attributeListServiceProvider ?? (_attributeListServiceProvider = new AttributeListServiceProvider(this));
    		set => _attributeListServiceProvider = value;
    	}
    	private AttributeListServiceProvider _attributeListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeTargetSpecifier" type.
        /// </summary>
    	public virtual AttributeTargetSpecifierServiceProvider AttributeTargetSpecifierServiceProvider
    	{
    		get => _attributeTargetSpecifierServiceProvider ?? (_attributeTargetSpecifierServiceProvider = new AttributeTargetSpecifierServiceProvider(this));
    		set => _attributeTargetSpecifierServiceProvider = value;
    	}
    	private AttributeTargetSpecifierServiceProvider _attributeTargetSpecifierServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Attribute" type.
        /// </summary>
    	public virtual AttributeServiceProvider AttributeServiceProvider
    	{
    		get => _attributeServiceProvider ?? (_attributeServiceProvider = new AttributeServiceProvider(this));
    		set => _attributeServiceProvider = value;
    	}
    	private AttributeServiceProvider _attributeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeArgumentList" type.
        /// </summary>
    	public virtual AttributeArgumentListServiceProvider AttributeArgumentListServiceProvider
    	{
    		get => _attributeArgumentListServiceProvider ?? (_attributeArgumentListServiceProvider = new AttributeArgumentListServiceProvider(this));
    		set => _attributeArgumentListServiceProvider = value;
    	}
    	private AttributeArgumentListServiceProvider _attributeArgumentListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeArgument" type.
        /// </summary>
    	public virtual AttributeArgumentServiceProvider AttributeArgumentServiceProvider
    	{
    		get => _attributeArgumentServiceProvider ?? (_attributeArgumentServiceProvider = new AttributeArgumentServiceProvider(this));
    		set => _attributeArgumentServiceProvider = value;
    	}
    	private AttributeArgumentServiceProvider _attributeArgumentServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "NameEquals" type.
        /// </summary>
    	public virtual NameEqualsServiceProvider NameEqualsServiceProvider
    	{
    		get => _nameEqualsServiceProvider ?? (_nameEqualsServiceProvider = new NameEqualsServiceProvider(this));
    		set => _nameEqualsServiceProvider = value;
    	}
    	private NameEqualsServiceProvider _nameEqualsServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterList" type.
        /// </summary>
    	public virtual TypeParameterListServiceProvider TypeParameterListServiceProvider
    	{
    		get => _typeParameterListServiceProvider ?? (_typeParameterListServiceProvider = new TypeParameterListServiceProvider(this));
    		set => _typeParameterListServiceProvider = value;
    	}
    	private TypeParameterListServiceProvider _typeParameterListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameter" type.
        /// </summary>
    	public virtual TypeParameterServiceProvider TypeParameterServiceProvider
    	{
    		get => _typeParameterServiceProvider ?? (_typeParameterServiceProvider = new TypeParameterServiceProvider(this));
    		set => _typeParameterServiceProvider = value;
    	}
    	private TypeParameterServiceProvider _typeParameterServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseList" type.
        /// </summary>
    	public virtual BaseListServiceProvider BaseListServiceProvider
    	{
    		get => _baseListServiceProvider ?? (_baseListServiceProvider = new BaseListServiceProvider(this));
    		set => _baseListServiceProvider = value;
    	}
    	private BaseListServiceProvider _baseListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterConstraintClause" type.
        /// </summary>
    	public virtual TypeParameterConstraintClauseServiceProvider TypeParameterConstraintClauseServiceProvider
    	{
    		get => _typeParameterConstraintClauseServiceProvider ?? (_typeParameterConstraintClauseServiceProvider = new TypeParameterConstraintClauseServiceProvider(this));
    		set => _typeParameterConstraintClauseServiceProvider = value;
    	}
    	private TypeParameterConstraintClauseServiceProvider _typeParameterConstraintClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ExplicitInterfaceSpecifier" type.
        /// </summary>
    	public virtual ExplicitInterfaceSpecifierServiceProvider ExplicitInterfaceSpecifierServiceProvider
    	{
    		get => _explicitInterfaceSpecifierServiceProvider ?? (_explicitInterfaceSpecifierServiceProvider = new ExplicitInterfaceSpecifierServiceProvider(this));
    		set => _explicitInterfaceSpecifierServiceProvider = value;
    	}
    	private ExplicitInterfaceSpecifierServiceProvider _explicitInterfaceSpecifierServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorInitializer" type.
        /// </summary>
    	public virtual ConstructorInitializerServiceProvider ConstructorInitializerServiceProvider
    	{
    		get => _constructorInitializerServiceProvider ?? (_constructorInitializerServiceProvider = new ConstructorInitializerServiceProvider(this));
    		set => _constructorInitializerServiceProvider = value;
    	}
    	private ConstructorInitializerServiceProvider _constructorInitializerServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrowExpressionClause" type.
        /// </summary>
    	public virtual ArrowExpressionClauseServiceProvider ArrowExpressionClauseServiceProvider
    	{
    		get => _arrowExpressionClauseServiceProvider ?? (_arrowExpressionClauseServiceProvider = new ArrowExpressionClauseServiceProvider(this));
    		set => _arrowExpressionClauseServiceProvider = value;
    	}
    	private ArrowExpressionClauseServiceProvider _arrowExpressionClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorList" type.
        /// </summary>
    	public virtual AccessorListServiceProvider AccessorListServiceProvider
    	{
    		get => _accessorListServiceProvider ?? (_accessorListServiceProvider = new AccessorListServiceProvider(this));
    		set => _accessorListServiceProvider = value;
    	}
    	private AccessorListServiceProvider _accessorListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorDeclaration" type.
        /// </summary>
    	public virtual AccessorDeclarationServiceProvider AccessorDeclarationServiceProvider
    	{
    		get => _accessorDeclarationServiceProvider ?? (_accessorDeclarationServiceProvider = new AccessorDeclarationServiceProvider(this));
    		set => _accessorDeclarationServiceProvider = value;
    	}
    	private AccessorDeclarationServiceProvider _accessorDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Parameter" type.
        /// </summary>
    	public virtual ParameterServiceProvider ParameterServiceProvider
    	{
    		get => _parameterServiceProvider ?? (_parameterServiceProvider = new ParameterServiceProvider(this));
    		set => _parameterServiceProvider = value;
    	}
    	private ParameterServiceProvider _parameterServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameter" type.
        /// </summary>
    	public virtual CrefParameterServiceProvider CrefParameterServiceProvider
    	{
    		get => _crefParameterServiceProvider ?? (_crefParameterServiceProvider = new CrefParameterServiceProvider(this));
    		set => _crefParameterServiceProvider = value;
    	}
    	private CrefParameterServiceProvider _crefParameterServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementStartTag" type.
        /// </summary>
    	public virtual XmlElementStartTagServiceProvider XmlElementStartTagServiceProvider
    	{
    		get => _xmlElementStartTagServiceProvider ?? (_xmlElementStartTagServiceProvider = new XmlElementStartTagServiceProvider(this));
    		set => _xmlElementStartTagServiceProvider = value;
    	}
    	private XmlElementStartTagServiceProvider _xmlElementStartTagServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementEndTag" type.
        /// </summary>
    	public virtual XmlElementEndTagServiceProvider XmlElementEndTagServiceProvider
    	{
    		get => _xmlElementEndTagServiceProvider ?? (_xmlElementEndTagServiceProvider = new XmlElementEndTagServiceProvider(this));
    		set => _xmlElementEndTagServiceProvider = value;
    	}
    	private XmlElementEndTagServiceProvider _xmlElementEndTagServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlName" type.
        /// </summary>
    	public virtual XmlNameServiceProvider XmlNameServiceProvider
    	{
    		get => _xmlNameServiceProvider ?? (_xmlNameServiceProvider = new XmlNameServiceProvider(this));
    		set => _xmlNameServiceProvider = value;
    	}
    	private XmlNameServiceProvider _xmlNameServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlPrefix" type.
        /// </summary>
    	public virtual XmlPrefixServiceProvider XmlPrefixServiceProvider
    	{
    		get => _xmlPrefixServiceProvider ?? (_xmlPrefixServiceProvider = new XmlPrefixServiceProvider(this));
    		set => _xmlPrefixServiceProvider = value;
    	}
    	private XmlPrefixServiceProvider _xmlPrefixServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedExpression" type.
        /// </summary>
    	public virtual ParenthesizedExpressionServiceProvider ParenthesizedExpressionServiceProvider
    	{
    		get => _parenthesizedExpressionServiceProvider ?? (_parenthesizedExpressionServiceProvider = new ParenthesizedExpressionServiceProvider(this));
    		set => _parenthesizedExpressionServiceProvider = value;
    	}
    	private ParenthesizedExpressionServiceProvider _parenthesizedExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleExpression" type.
        /// </summary>
    	public virtual TupleExpressionServiceProvider TupleExpressionServiceProvider
    	{
    		get => _tupleExpressionServiceProvider ?? (_tupleExpressionServiceProvider = new TupleExpressionServiceProvider(this));
    		set => _tupleExpressionServiceProvider = value;
    	}
    	private TupleExpressionServiceProvider _tupleExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PrefixUnaryExpression" type.
        /// </summary>
    	public virtual PrefixUnaryExpressionServiceProvider PrefixUnaryExpressionServiceProvider
    	{
    		get => _prefixUnaryExpressionServiceProvider ?? (_prefixUnaryExpressionServiceProvider = new PrefixUnaryExpressionServiceProvider(this));
    		set => _prefixUnaryExpressionServiceProvider = value;
    	}
    	private PrefixUnaryExpressionServiceProvider _prefixUnaryExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AwaitExpression" type.
        /// </summary>
    	public virtual AwaitExpressionServiceProvider AwaitExpressionServiceProvider
    	{
    		get => _awaitExpressionServiceProvider ?? (_awaitExpressionServiceProvider = new AwaitExpressionServiceProvider(this));
    		set => _awaitExpressionServiceProvider = value;
    	}
    	private AwaitExpressionServiceProvider _awaitExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PostfixUnaryExpression" type.
        /// </summary>
    	public virtual PostfixUnaryExpressionServiceProvider PostfixUnaryExpressionServiceProvider
    	{
    		get => _postfixUnaryExpressionServiceProvider ?? (_postfixUnaryExpressionServiceProvider = new PostfixUnaryExpressionServiceProvider(this));
    		set => _postfixUnaryExpressionServiceProvider = value;
    	}
    	private PostfixUnaryExpressionServiceProvider _postfixUnaryExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberAccessExpression" type.
        /// </summary>
    	public virtual MemberAccessExpressionServiceProvider MemberAccessExpressionServiceProvider
    	{
    		get => _memberAccessExpressionServiceProvider ?? (_memberAccessExpressionServiceProvider = new MemberAccessExpressionServiceProvider(this));
    		set => _memberAccessExpressionServiceProvider = value;
    	}
    	private MemberAccessExpressionServiceProvider _memberAccessExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalAccessExpression" type.
        /// </summary>
    	public virtual ConditionalAccessExpressionServiceProvider ConditionalAccessExpressionServiceProvider
    	{
    		get => _conditionalAccessExpressionServiceProvider ?? (_conditionalAccessExpressionServiceProvider = new ConditionalAccessExpressionServiceProvider(this));
    		set => _conditionalAccessExpressionServiceProvider = value;
    	}
    	private ConditionalAccessExpressionServiceProvider _conditionalAccessExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberBindingExpression" type.
        /// </summary>
    	public virtual MemberBindingExpressionServiceProvider MemberBindingExpressionServiceProvider
    	{
    		get => _memberBindingExpressionServiceProvider ?? (_memberBindingExpressionServiceProvider = new MemberBindingExpressionServiceProvider(this));
    		set => _memberBindingExpressionServiceProvider = value;
    	}
    	private MemberBindingExpressionServiceProvider _memberBindingExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementBindingExpression" type.
        /// </summary>
    	public virtual ElementBindingExpressionServiceProvider ElementBindingExpressionServiceProvider
    	{
    		get => _elementBindingExpressionServiceProvider ?? (_elementBindingExpressionServiceProvider = new ElementBindingExpressionServiceProvider(this));
    		set => _elementBindingExpressionServiceProvider = value;
    	}
    	private ElementBindingExpressionServiceProvider _elementBindingExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitElementAccess" type.
        /// </summary>
    	public virtual ImplicitElementAccessServiceProvider ImplicitElementAccessServiceProvider
    	{
    		get => _implicitElementAccessServiceProvider ?? (_implicitElementAccessServiceProvider = new ImplicitElementAccessServiceProvider(this));
    		set => _implicitElementAccessServiceProvider = value;
    	}
    	private ImplicitElementAccessServiceProvider _implicitElementAccessServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BinaryExpression" type.
        /// </summary>
    	public virtual BinaryExpressionServiceProvider BinaryExpressionServiceProvider
    	{
    		get => _binaryExpressionServiceProvider ?? (_binaryExpressionServiceProvider = new BinaryExpressionServiceProvider(this));
    		set => _binaryExpressionServiceProvider = value;
    	}
    	private BinaryExpressionServiceProvider _binaryExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AssignmentExpression" type.
        /// </summary>
    	public virtual AssignmentExpressionServiceProvider AssignmentExpressionServiceProvider
    	{
    		get => _assignmentExpressionServiceProvider ?? (_assignmentExpressionServiceProvider = new AssignmentExpressionServiceProvider(this));
    		set => _assignmentExpressionServiceProvider = value;
    	}
    	private AssignmentExpressionServiceProvider _assignmentExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalExpression" type.
        /// </summary>
    	public virtual ConditionalExpressionServiceProvider ConditionalExpressionServiceProvider
    	{
    		get => _conditionalExpressionServiceProvider ?? (_conditionalExpressionServiceProvider = new ConditionalExpressionServiceProvider(this));
    		set => _conditionalExpressionServiceProvider = value;
    	}
    	private ConditionalExpressionServiceProvider _conditionalExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LiteralExpression" type.
        /// </summary>
    	public virtual LiteralExpressionServiceProvider LiteralExpressionServiceProvider
    	{
    		get => _literalExpressionServiceProvider ?? (_literalExpressionServiceProvider = new LiteralExpressionServiceProvider(this));
    		set => _literalExpressionServiceProvider = value;
    	}
    	private LiteralExpressionServiceProvider _literalExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "MakeRefExpression" type.
        /// </summary>
    	public virtual MakeRefExpressionServiceProvider MakeRefExpressionServiceProvider
    	{
    		get => _makeRefExpressionServiceProvider ?? (_makeRefExpressionServiceProvider = new MakeRefExpressionServiceProvider(this));
    		set => _makeRefExpressionServiceProvider = value;
    	}
    	private MakeRefExpressionServiceProvider _makeRefExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "RefTypeExpression" type.
        /// </summary>
    	public virtual RefTypeExpressionServiceProvider RefTypeExpressionServiceProvider
    	{
    		get => _refTypeExpressionServiceProvider ?? (_refTypeExpressionServiceProvider = new RefTypeExpressionServiceProvider(this));
    		set => _refTypeExpressionServiceProvider = value;
    	}
    	private RefTypeExpressionServiceProvider _refTypeExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "RefValueExpression" type.
        /// </summary>
    	public virtual RefValueExpressionServiceProvider RefValueExpressionServiceProvider
    	{
    		get => _refValueExpressionServiceProvider ?? (_refValueExpressionServiceProvider = new RefValueExpressionServiceProvider(this));
    		set => _refValueExpressionServiceProvider = value;
    	}
    	private RefValueExpressionServiceProvider _refValueExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedExpression" type.
        /// </summary>
    	public virtual CheckedExpressionServiceProvider CheckedExpressionServiceProvider
    	{
    		get => _checkedExpressionServiceProvider ?? (_checkedExpressionServiceProvider = new CheckedExpressionServiceProvider(this));
    		set => _checkedExpressionServiceProvider = value;
    	}
    	private CheckedExpressionServiceProvider _checkedExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultExpression" type.
        /// </summary>
    	public virtual DefaultExpressionServiceProvider DefaultExpressionServiceProvider
    	{
    		get => _defaultExpressionServiceProvider ?? (_defaultExpressionServiceProvider = new DefaultExpressionServiceProvider(this));
    		set => _defaultExpressionServiceProvider = value;
    	}
    	private DefaultExpressionServiceProvider _defaultExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeOfExpression" type.
        /// </summary>
    	public virtual TypeOfExpressionServiceProvider TypeOfExpressionServiceProvider
    	{
    		get => _typeOfExpressionServiceProvider ?? (_typeOfExpressionServiceProvider = new TypeOfExpressionServiceProvider(this));
    		set => _typeOfExpressionServiceProvider = value;
    	}
    	private TypeOfExpressionServiceProvider _typeOfExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SizeOfExpression" type.
        /// </summary>
    	public virtual SizeOfExpressionServiceProvider SizeOfExpressionServiceProvider
    	{
    		get => _sizeOfExpressionServiceProvider ?? (_sizeOfExpressionServiceProvider = new SizeOfExpressionServiceProvider(this));
    		set => _sizeOfExpressionServiceProvider = value;
    	}
    	private SizeOfExpressionServiceProvider _sizeOfExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InvocationExpression" type.
        /// </summary>
    	public virtual InvocationExpressionServiceProvider InvocationExpressionServiceProvider
    	{
    		get => _invocationExpressionServiceProvider ?? (_invocationExpressionServiceProvider = new InvocationExpressionServiceProvider(this));
    		set => _invocationExpressionServiceProvider = value;
    	}
    	private InvocationExpressionServiceProvider _invocationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementAccessExpression" type.
        /// </summary>
    	public virtual ElementAccessExpressionServiceProvider ElementAccessExpressionServiceProvider
    	{
    		get => _elementAccessExpressionServiceProvider ?? (_elementAccessExpressionServiceProvider = new ElementAccessExpressionServiceProvider(this));
    		set => _elementAccessExpressionServiceProvider = value;
    	}
    	private ElementAccessExpressionServiceProvider _elementAccessExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationExpression" type.
        /// </summary>
    	public virtual DeclarationExpressionServiceProvider DeclarationExpressionServiceProvider
    	{
    		get => _declarationExpressionServiceProvider ?? (_declarationExpressionServiceProvider = new DeclarationExpressionServiceProvider(this));
    		set => _declarationExpressionServiceProvider = value;
    	}
    	private DeclarationExpressionServiceProvider _declarationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CastExpression" type.
        /// </summary>
    	public virtual CastExpressionServiceProvider CastExpressionServiceProvider
    	{
    		get => _castExpressionServiceProvider ?? (_castExpressionServiceProvider = new CastExpressionServiceProvider(this));
    		set => _castExpressionServiceProvider = value;
    	}
    	private CastExpressionServiceProvider _castExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "RefExpression" type.
        /// </summary>
    	public virtual RefExpressionServiceProvider RefExpressionServiceProvider
    	{
    		get => _refExpressionServiceProvider ?? (_refExpressionServiceProvider = new RefExpressionServiceProvider(this));
    		set => _refExpressionServiceProvider = value;
    	}
    	private RefExpressionServiceProvider _refExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InitializerExpression" type.
        /// </summary>
    	public virtual InitializerExpressionServiceProvider InitializerExpressionServiceProvider
    	{
    		get => _initializerExpressionServiceProvider ?? (_initializerExpressionServiceProvider = new InitializerExpressionServiceProvider(this));
    		set => _initializerExpressionServiceProvider = value;
    	}
    	private InitializerExpressionServiceProvider _initializerExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ObjectCreationExpression" type.
        /// </summary>
    	public virtual ObjectCreationExpressionServiceProvider ObjectCreationExpressionServiceProvider
    	{
    		get => _objectCreationExpressionServiceProvider ?? (_objectCreationExpressionServiceProvider = new ObjectCreationExpressionServiceProvider(this));
    		set => _objectCreationExpressionServiceProvider = value;
    	}
    	private ObjectCreationExpressionServiceProvider _objectCreationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectCreationExpression" type.
        /// </summary>
    	public virtual AnonymousObjectCreationExpressionServiceProvider AnonymousObjectCreationExpressionServiceProvider
    	{
    		get => _anonymousObjectCreationExpressionServiceProvider ?? (_anonymousObjectCreationExpressionServiceProvider = new AnonymousObjectCreationExpressionServiceProvider(this));
    		set => _anonymousObjectCreationExpressionServiceProvider = value;
    	}
    	private AnonymousObjectCreationExpressionServiceProvider _anonymousObjectCreationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayCreationExpression" type.
        /// </summary>
    	public virtual ArrayCreationExpressionServiceProvider ArrayCreationExpressionServiceProvider
    	{
    		get => _arrayCreationExpressionServiceProvider ?? (_arrayCreationExpressionServiceProvider = new ArrayCreationExpressionServiceProvider(this));
    		set => _arrayCreationExpressionServiceProvider = value;
    	}
    	private ArrayCreationExpressionServiceProvider _arrayCreationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitArrayCreationExpression" type.
        /// </summary>
    	public virtual ImplicitArrayCreationExpressionServiceProvider ImplicitArrayCreationExpressionServiceProvider
    	{
    		get => _implicitArrayCreationExpressionServiceProvider ?? (_implicitArrayCreationExpressionServiceProvider = new ImplicitArrayCreationExpressionServiceProvider(this));
    		set => _implicitArrayCreationExpressionServiceProvider = value;
    	}
    	private ImplicitArrayCreationExpressionServiceProvider _implicitArrayCreationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "StackAllocArrayCreationExpression" type.
        /// </summary>
    	public virtual StackAllocArrayCreationExpressionServiceProvider StackAllocArrayCreationExpressionServiceProvider
    	{
    		get => _stackAllocArrayCreationExpressionServiceProvider ?? (_stackAllocArrayCreationExpressionServiceProvider = new StackAllocArrayCreationExpressionServiceProvider(this));
    		set => _stackAllocArrayCreationExpressionServiceProvider = value;
    	}
    	private StackAllocArrayCreationExpressionServiceProvider _stackAllocArrayCreationExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryExpression" type.
        /// </summary>
    	public virtual QueryExpressionServiceProvider QueryExpressionServiceProvider
    	{
    		get => _queryExpressionServiceProvider ?? (_queryExpressionServiceProvider = new QueryExpressionServiceProvider(this));
    		set => _queryExpressionServiceProvider = value;
    	}
    	private QueryExpressionServiceProvider _queryExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedArraySizeExpression" type.
        /// </summary>
    	public virtual OmittedArraySizeExpressionServiceProvider OmittedArraySizeExpressionServiceProvider
    	{
    		get => _omittedArraySizeExpressionServiceProvider ?? (_omittedArraySizeExpressionServiceProvider = new OmittedArraySizeExpressionServiceProvider(this));
    		set => _omittedArraySizeExpressionServiceProvider = value;
    	}
    	private OmittedArraySizeExpressionServiceProvider _omittedArraySizeExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringExpression" type.
        /// </summary>
    	public virtual InterpolatedStringExpressionServiceProvider InterpolatedStringExpressionServiceProvider
    	{
    		get => _interpolatedStringExpressionServiceProvider ?? (_interpolatedStringExpressionServiceProvider = new InterpolatedStringExpressionServiceProvider(this));
    		set => _interpolatedStringExpressionServiceProvider = value;
    	}
    	private InterpolatedStringExpressionServiceProvider _interpolatedStringExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IsPatternExpression" type.
        /// </summary>
    	public virtual IsPatternExpressionServiceProvider IsPatternExpressionServiceProvider
    	{
    		get => _isPatternExpressionServiceProvider ?? (_isPatternExpressionServiceProvider = new IsPatternExpressionServiceProvider(this));
    		set => _isPatternExpressionServiceProvider = value;
    	}
    	private IsPatternExpressionServiceProvider _isPatternExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowExpression" type.
        /// </summary>
    	public virtual ThrowExpressionServiceProvider ThrowExpressionServiceProvider
    	{
    		get => _throwExpressionServiceProvider ?? (_throwExpressionServiceProvider = new ThrowExpressionServiceProvider(this));
    		set => _throwExpressionServiceProvider = value;
    	}
    	private ThrowExpressionServiceProvider _throwExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PredefinedType" type.
        /// </summary>
    	public virtual PredefinedTypeServiceProvider PredefinedTypeServiceProvider
    	{
    		get => _predefinedTypeServiceProvider ?? (_predefinedTypeServiceProvider = new PredefinedTypeServiceProvider(this));
    		set => _predefinedTypeServiceProvider = value;
    	}
    	private PredefinedTypeServiceProvider _predefinedTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayType" type.
        /// </summary>
    	public virtual ArrayTypeServiceProvider ArrayTypeServiceProvider
    	{
    		get => _arrayTypeServiceProvider ?? (_arrayTypeServiceProvider = new ArrayTypeServiceProvider(this));
    		set => _arrayTypeServiceProvider = value;
    	}
    	private ArrayTypeServiceProvider _arrayTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PointerType" type.
        /// </summary>
    	public virtual PointerTypeServiceProvider PointerTypeServiceProvider
    	{
    		get => _pointerTypeServiceProvider ?? (_pointerTypeServiceProvider = new PointerTypeServiceProvider(this));
    		set => _pointerTypeServiceProvider = value;
    	}
    	private PointerTypeServiceProvider _pointerTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "NullableType" type.
        /// </summary>
    	public virtual NullableTypeServiceProvider NullableTypeServiceProvider
    	{
    		get => _nullableTypeServiceProvider ?? (_nullableTypeServiceProvider = new NullableTypeServiceProvider(this));
    		set => _nullableTypeServiceProvider = value;
    	}
    	private NullableTypeServiceProvider _nullableTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleType" type.
        /// </summary>
    	public virtual TupleTypeServiceProvider TupleTypeServiceProvider
    	{
    		get => _tupleTypeServiceProvider ?? (_tupleTypeServiceProvider = new TupleTypeServiceProvider(this));
    		set => _tupleTypeServiceProvider = value;
    	}
    	private TupleTypeServiceProvider _tupleTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedTypeArgument" type.
        /// </summary>
    	public virtual OmittedTypeArgumentServiceProvider OmittedTypeArgumentServiceProvider
    	{
    		get => _omittedTypeArgumentServiceProvider ?? (_omittedTypeArgumentServiceProvider = new OmittedTypeArgumentServiceProvider(this));
    		set => _omittedTypeArgumentServiceProvider = value;
    	}
    	private OmittedTypeArgumentServiceProvider _omittedTypeArgumentServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "RefType" type.
        /// </summary>
    	public virtual RefTypeServiceProvider RefTypeServiceProvider
    	{
    		get => _refTypeServiceProvider ?? (_refTypeServiceProvider = new RefTypeServiceProvider(this));
    		set => _refTypeServiceProvider = value;
    	}
    	private RefTypeServiceProvider _refTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedName" type.
        /// </summary>
    	public virtual QualifiedNameServiceProvider QualifiedNameServiceProvider
    	{
    		get => _qualifiedNameServiceProvider ?? (_qualifiedNameServiceProvider = new QualifiedNameServiceProvider(this));
    		set => _qualifiedNameServiceProvider = value;
    	}
    	private QualifiedNameServiceProvider _qualifiedNameServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AliasQualifiedName" type.
        /// </summary>
    	public virtual AliasQualifiedNameServiceProvider AliasQualifiedNameServiceProvider
    	{
    		get => _aliasQualifiedNameServiceProvider ?? (_aliasQualifiedNameServiceProvider = new AliasQualifiedNameServiceProvider(this));
    		set => _aliasQualifiedNameServiceProvider = value;
    	}
    	private AliasQualifiedNameServiceProvider _aliasQualifiedNameServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IdentifierName" type.
        /// </summary>
    	public virtual IdentifierNameServiceProvider IdentifierNameServiceProvider
    	{
    		get => _identifierNameServiceProvider ?? (_identifierNameServiceProvider = new IdentifierNameServiceProvider(this));
    		set => _identifierNameServiceProvider = value;
    	}
    	private IdentifierNameServiceProvider _identifierNameServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "GenericName" type.
        /// </summary>
    	public virtual GenericNameServiceProvider GenericNameServiceProvider
    	{
    		get => _genericNameServiceProvider ?? (_genericNameServiceProvider = new GenericNameServiceProvider(this));
    		set => _genericNameServiceProvider = value;
    	}
    	private GenericNameServiceProvider _genericNameServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ThisExpression" type.
        /// </summary>
    	public virtual ThisExpressionServiceProvider ThisExpressionServiceProvider
    	{
    		get => _thisExpressionServiceProvider ?? (_thisExpressionServiceProvider = new ThisExpressionServiceProvider(this));
    		set => _thisExpressionServiceProvider = value;
    	}
    	private ThisExpressionServiceProvider _thisExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseExpression" type.
        /// </summary>
    	public virtual BaseExpressionServiceProvider BaseExpressionServiceProvider
    	{
    		get => _baseExpressionServiceProvider ?? (_baseExpressionServiceProvider = new BaseExpressionServiceProvider(this));
    		set => _baseExpressionServiceProvider = value;
    	}
    	private BaseExpressionServiceProvider _baseExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousMethodExpression" type.
        /// </summary>
    	public virtual AnonymousMethodExpressionServiceProvider AnonymousMethodExpressionServiceProvider
    	{
    		get => _anonymousMethodExpressionServiceProvider ?? (_anonymousMethodExpressionServiceProvider = new AnonymousMethodExpressionServiceProvider(this));
    		set => _anonymousMethodExpressionServiceProvider = value;
    	}
    	private AnonymousMethodExpressionServiceProvider _anonymousMethodExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleLambdaExpression" type.
        /// </summary>
    	public virtual SimpleLambdaExpressionServiceProvider SimpleLambdaExpressionServiceProvider
    	{
    		get => _simpleLambdaExpressionServiceProvider ?? (_simpleLambdaExpressionServiceProvider = new SimpleLambdaExpressionServiceProvider(this));
    		set => _simpleLambdaExpressionServiceProvider = value;
    	}
    	private SimpleLambdaExpressionServiceProvider _simpleLambdaExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedLambdaExpression" type.
        /// </summary>
    	public virtual ParenthesizedLambdaExpressionServiceProvider ParenthesizedLambdaExpressionServiceProvider
    	{
    		get => _parenthesizedLambdaExpressionServiceProvider ?? (_parenthesizedLambdaExpressionServiceProvider = new ParenthesizedLambdaExpressionServiceProvider(this));
    		set => _parenthesizedLambdaExpressionServiceProvider = value;
    	}
    	private ParenthesizedLambdaExpressionServiceProvider _parenthesizedLambdaExpressionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ArgumentList" type.
        /// </summary>
    	public virtual ArgumentListServiceProvider ArgumentListServiceProvider
    	{
    		get => _argumentListServiceProvider ?? (_argumentListServiceProvider = new ArgumentListServiceProvider(this));
    		set => _argumentListServiceProvider = value;
    	}
    	private ArgumentListServiceProvider _argumentListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedArgumentList" type.
        /// </summary>
    	public virtual BracketedArgumentListServiceProvider BracketedArgumentListServiceProvider
    	{
    		get => _bracketedArgumentListServiceProvider ?? (_bracketedArgumentListServiceProvider = new BracketedArgumentListServiceProvider(this));
    		set => _bracketedArgumentListServiceProvider = value;
    	}
    	private BracketedArgumentListServiceProvider _bracketedArgumentListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "FromClause" type.
        /// </summary>
    	public virtual FromClauseServiceProvider FromClauseServiceProvider
    	{
    		get => _fromClauseServiceProvider ?? (_fromClauseServiceProvider = new FromClauseServiceProvider(this));
    		set => _fromClauseServiceProvider = value;
    	}
    	private FromClauseServiceProvider _fromClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LetClause" type.
        /// </summary>
    	public virtual LetClauseServiceProvider LetClauseServiceProvider
    	{
    		get => _letClauseServiceProvider ?? (_letClauseServiceProvider = new LetClauseServiceProvider(this));
    		set => _letClauseServiceProvider = value;
    	}
    	private LetClauseServiceProvider _letClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinClause" type.
        /// </summary>
    	public virtual JoinClauseServiceProvider JoinClauseServiceProvider
    	{
    		get => _joinClauseServiceProvider ?? (_joinClauseServiceProvider = new JoinClauseServiceProvider(this));
    		set => _joinClauseServiceProvider = value;
    	}
    	private JoinClauseServiceProvider _joinClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "WhereClause" type.
        /// </summary>
    	public virtual WhereClauseServiceProvider WhereClauseServiceProvider
    	{
    		get => _whereClauseServiceProvider ?? (_whereClauseServiceProvider = new WhereClauseServiceProvider(this));
    		set => _whereClauseServiceProvider = value;
    	}
    	private WhereClauseServiceProvider _whereClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "OrderByClause" type.
        /// </summary>
    	public virtual OrderByClauseServiceProvider OrderByClauseServiceProvider
    	{
    		get => _orderByClauseServiceProvider ?? (_orderByClauseServiceProvider = new OrderByClauseServiceProvider(this));
    		set => _orderByClauseServiceProvider = value;
    	}
    	private OrderByClauseServiceProvider _orderByClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SelectClause" type.
        /// </summary>
    	public virtual SelectClauseServiceProvider SelectClauseServiceProvider
    	{
    		get => _selectClauseServiceProvider ?? (_selectClauseServiceProvider = new SelectClauseServiceProvider(this));
    		set => _selectClauseServiceProvider = value;
    	}
    	private SelectClauseServiceProvider _selectClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "GroupClause" type.
        /// </summary>
    	public virtual GroupClauseServiceProvider GroupClauseServiceProvider
    	{
    		get => _groupClauseServiceProvider ?? (_groupClauseServiceProvider = new GroupClauseServiceProvider(this));
    		set => _groupClauseServiceProvider = value;
    	}
    	private GroupClauseServiceProvider _groupClauseServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationPattern" type.
        /// </summary>
    	public virtual DeclarationPatternServiceProvider DeclarationPatternServiceProvider
    	{
    		get => _declarationPatternServiceProvider ?? (_declarationPatternServiceProvider = new DeclarationPatternServiceProvider(this));
    		set => _declarationPatternServiceProvider = value;
    	}
    	private DeclarationPatternServiceProvider _declarationPatternServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstantPattern" type.
        /// </summary>
    	public virtual ConstantPatternServiceProvider ConstantPatternServiceProvider
    	{
    		get => _constantPatternServiceProvider ?? (_constantPatternServiceProvider = new ConstantPatternServiceProvider(this));
    		set => _constantPatternServiceProvider = value;
    	}
    	private ConstantPatternServiceProvider _constantPatternServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringText" type.
        /// </summary>
    	public virtual InterpolatedStringTextServiceProvider InterpolatedStringTextServiceProvider
    	{
    		get => _interpolatedStringTextServiceProvider ?? (_interpolatedStringTextServiceProvider = new InterpolatedStringTextServiceProvider(this));
    		set => _interpolatedStringTextServiceProvider = value;
    	}
    	private InterpolatedStringTextServiceProvider _interpolatedStringTextServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Interpolation" type.
        /// </summary>
    	public virtual InterpolationServiceProvider InterpolationServiceProvider
    	{
    		get => _interpolationServiceProvider ?? (_interpolationServiceProvider = new InterpolationServiceProvider(this));
    		set => _interpolationServiceProvider = value;
    	}
    	private InterpolationServiceProvider _interpolationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "GlobalStatement" type.
        /// </summary>
    	public virtual GlobalStatementServiceProvider GlobalStatementServiceProvider
    	{
    		get => _globalStatementServiceProvider ?? (_globalStatementServiceProvider = new GlobalStatementServiceProvider(this));
    		set => _globalStatementServiceProvider = value;
    	}
    	private GlobalStatementServiceProvider _globalStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "NamespaceDeclaration" type.
        /// </summary>
    	public virtual NamespaceDeclarationServiceProvider NamespaceDeclarationServiceProvider
    	{
    		get => _namespaceDeclarationServiceProvider ?? (_namespaceDeclarationServiceProvider = new NamespaceDeclarationServiceProvider(this));
    		set => _namespaceDeclarationServiceProvider = value;
    	}
    	private NamespaceDeclarationServiceProvider _namespaceDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DelegateDeclaration" type.
        /// </summary>
    	public virtual DelegateDeclarationServiceProvider DelegateDeclarationServiceProvider
    	{
    		get => _delegateDeclarationServiceProvider ?? (_delegateDeclarationServiceProvider = new DelegateDeclarationServiceProvider(this));
    		set => _delegateDeclarationServiceProvider = value;
    	}
    	private DelegateDeclarationServiceProvider _delegateDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumMemberDeclaration" type.
        /// </summary>
    	public virtual EnumMemberDeclarationServiceProvider EnumMemberDeclarationServiceProvider
    	{
    		get => _enumMemberDeclarationServiceProvider ?? (_enumMemberDeclarationServiceProvider = new EnumMemberDeclarationServiceProvider(this));
    		set => _enumMemberDeclarationServiceProvider = value;
    	}
    	private EnumMemberDeclarationServiceProvider _enumMemberDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IncompleteMember" type.
        /// </summary>
    	public virtual IncompleteMemberServiceProvider IncompleteMemberServiceProvider
    	{
    		get => _incompleteMemberServiceProvider ?? (_incompleteMemberServiceProvider = new IncompleteMemberServiceProvider(this));
    		set => _incompleteMemberServiceProvider = value;
    	}
    	private IncompleteMemberServiceProvider _incompleteMemberServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumDeclaration" type.
        /// </summary>
    	public virtual EnumDeclarationServiceProvider EnumDeclarationServiceProvider
    	{
    		get => _enumDeclarationServiceProvider ?? (_enumDeclarationServiceProvider = new EnumDeclarationServiceProvider(this));
    		set => _enumDeclarationServiceProvider = value;
    	}
    	private EnumDeclarationServiceProvider _enumDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassDeclaration" type.
        /// </summary>
    	public virtual ClassDeclarationServiceProvider ClassDeclarationServiceProvider
    	{
    		get => _classDeclarationServiceProvider ?? (_classDeclarationServiceProvider = new ClassDeclarationServiceProvider(this));
    		set => _classDeclarationServiceProvider = value;
    	}
    	private ClassDeclarationServiceProvider _classDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "StructDeclaration" type.
        /// </summary>
    	public virtual StructDeclarationServiceProvider StructDeclarationServiceProvider
    	{
    		get => _structDeclarationServiceProvider ?? (_structDeclarationServiceProvider = new StructDeclarationServiceProvider(this));
    		set => _structDeclarationServiceProvider = value;
    	}
    	private StructDeclarationServiceProvider _structDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "InterfaceDeclaration" type.
        /// </summary>
    	public virtual InterfaceDeclarationServiceProvider InterfaceDeclarationServiceProvider
    	{
    		get => _interfaceDeclarationServiceProvider ?? (_interfaceDeclarationServiceProvider = new InterfaceDeclarationServiceProvider(this));
    		set => _interfaceDeclarationServiceProvider = value;
    	}
    	private InterfaceDeclarationServiceProvider _interfaceDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "FieldDeclaration" type.
        /// </summary>
    	public virtual FieldDeclarationServiceProvider FieldDeclarationServiceProvider
    	{
    		get => _fieldDeclarationServiceProvider ?? (_fieldDeclarationServiceProvider = new FieldDeclarationServiceProvider(this));
    		set => _fieldDeclarationServiceProvider = value;
    	}
    	private FieldDeclarationServiceProvider _fieldDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EventFieldDeclaration" type.
        /// </summary>
    	public virtual EventFieldDeclarationServiceProvider EventFieldDeclarationServiceProvider
    	{
    		get => _eventFieldDeclarationServiceProvider ?? (_eventFieldDeclarationServiceProvider = new EventFieldDeclarationServiceProvider(this));
    		set => _eventFieldDeclarationServiceProvider = value;
    	}
    	private EventFieldDeclarationServiceProvider _eventFieldDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "MethodDeclaration" type.
        /// </summary>
    	public virtual MethodDeclarationServiceProvider MethodDeclarationServiceProvider
    	{
    		get => _methodDeclarationServiceProvider ?? (_methodDeclarationServiceProvider = new MethodDeclarationServiceProvider(this));
    		set => _methodDeclarationServiceProvider = value;
    	}
    	private MethodDeclarationServiceProvider _methodDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorDeclaration" type.
        /// </summary>
    	public virtual OperatorDeclarationServiceProvider OperatorDeclarationServiceProvider
    	{
    		get => _operatorDeclarationServiceProvider ?? (_operatorDeclarationServiceProvider = new OperatorDeclarationServiceProvider(this));
    		set => _operatorDeclarationServiceProvider = value;
    	}
    	private OperatorDeclarationServiceProvider _operatorDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorDeclaration" type.
        /// </summary>
    	public virtual ConversionOperatorDeclarationServiceProvider ConversionOperatorDeclarationServiceProvider
    	{
    		get => _conversionOperatorDeclarationServiceProvider ?? (_conversionOperatorDeclarationServiceProvider = new ConversionOperatorDeclarationServiceProvider(this));
    		set => _conversionOperatorDeclarationServiceProvider = value;
    	}
    	private ConversionOperatorDeclarationServiceProvider _conversionOperatorDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorDeclaration" type.
        /// </summary>
    	public virtual ConstructorDeclarationServiceProvider ConstructorDeclarationServiceProvider
    	{
    		get => _constructorDeclarationServiceProvider ?? (_constructorDeclarationServiceProvider = new ConstructorDeclarationServiceProvider(this));
    		set => _constructorDeclarationServiceProvider = value;
    	}
    	private ConstructorDeclarationServiceProvider _constructorDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DestructorDeclaration" type.
        /// </summary>
    	public virtual DestructorDeclarationServiceProvider DestructorDeclarationServiceProvider
    	{
    		get => _destructorDeclarationServiceProvider ?? (_destructorDeclarationServiceProvider = new DestructorDeclarationServiceProvider(this));
    		set => _destructorDeclarationServiceProvider = value;
    	}
    	private DestructorDeclarationServiceProvider _destructorDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PropertyDeclaration" type.
        /// </summary>
    	public virtual PropertyDeclarationServiceProvider PropertyDeclarationServiceProvider
    	{
    		get => _propertyDeclarationServiceProvider ?? (_propertyDeclarationServiceProvider = new PropertyDeclarationServiceProvider(this));
    		set => _propertyDeclarationServiceProvider = value;
    	}
    	private PropertyDeclarationServiceProvider _propertyDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EventDeclaration" type.
        /// </summary>
    	public virtual EventDeclarationServiceProvider EventDeclarationServiceProvider
    	{
    		get => _eventDeclarationServiceProvider ?? (_eventDeclarationServiceProvider = new EventDeclarationServiceProvider(this));
    		set => _eventDeclarationServiceProvider = value;
    	}
    	private EventDeclarationServiceProvider _eventDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerDeclaration" type.
        /// </summary>
    	public virtual IndexerDeclarationServiceProvider IndexerDeclarationServiceProvider
    	{
    		get => _indexerDeclarationServiceProvider ?? (_indexerDeclarationServiceProvider = new IndexerDeclarationServiceProvider(this));
    		set => _indexerDeclarationServiceProvider = value;
    	}
    	private IndexerDeclarationServiceProvider _indexerDeclarationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "Block" type.
        /// </summary>
    	public virtual BlockServiceProvider BlockServiceProvider
    	{
    		get => _blockServiceProvider ?? (_blockServiceProvider = new BlockServiceProvider(this));
    		set => _blockServiceProvider = value;
    	}
    	private BlockServiceProvider _blockServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalFunctionStatement" type.
        /// </summary>
    	public virtual LocalFunctionStatementServiceProvider LocalFunctionStatementServiceProvider
    	{
    		get => _localFunctionStatementServiceProvider ?? (_localFunctionStatementServiceProvider = new LocalFunctionStatementServiceProvider(this));
    		set => _localFunctionStatementServiceProvider = value;
    	}
    	private LocalFunctionStatementServiceProvider _localFunctionStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalDeclarationStatement" type.
        /// </summary>
    	public virtual LocalDeclarationStatementServiceProvider LocalDeclarationStatementServiceProvider
    	{
    		get => _localDeclarationStatementServiceProvider ?? (_localDeclarationStatementServiceProvider = new LocalDeclarationStatementServiceProvider(this));
    		set => _localDeclarationStatementServiceProvider = value;
    	}
    	private LocalDeclarationStatementServiceProvider _localDeclarationStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ExpressionStatement" type.
        /// </summary>
    	public virtual ExpressionStatementServiceProvider ExpressionStatementServiceProvider
    	{
    		get => _expressionStatementServiceProvider ?? (_expressionStatementServiceProvider = new ExpressionStatementServiceProvider(this));
    		set => _expressionStatementServiceProvider = value;
    	}
    	private ExpressionStatementServiceProvider _expressionStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EmptyStatement" type.
        /// </summary>
    	public virtual EmptyStatementServiceProvider EmptyStatementServiceProvider
    	{
    		get => _emptyStatementServiceProvider ?? (_emptyStatementServiceProvider = new EmptyStatementServiceProvider(this));
    		set => _emptyStatementServiceProvider = value;
    	}
    	private EmptyStatementServiceProvider _emptyStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LabeledStatement" type.
        /// </summary>
    	public virtual LabeledStatementServiceProvider LabeledStatementServiceProvider
    	{
    		get => _labeledStatementServiceProvider ?? (_labeledStatementServiceProvider = new LabeledStatementServiceProvider(this));
    		set => _labeledStatementServiceProvider = value;
    	}
    	private LabeledStatementServiceProvider _labeledStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "GotoStatement" type.
        /// </summary>
    	public virtual GotoStatementServiceProvider GotoStatementServiceProvider
    	{
    		get => _gotoStatementServiceProvider ?? (_gotoStatementServiceProvider = new GotoStatementServiceProvider(this));
    		set => _gotoStatementServiceProvider = value;
    	}
    	private GotoStatementServiceProvider _gotoStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BreakStatement" type.
        /// </summary>
    	public virtual BreakStatementServiceProvider BreakStatementServiceProvider
    	{
    		get => _breakStatementServiceProvider ?? (_breakStatementServiceProvider = new BreakStatementServiceProvider(this));
    		set => _breakStatementServiceProvider = value;
    	}
    	private BreakStatementServiceProvider _breakStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ContinueStatement" type.
        /// </summary>
    	public virtual ContinueStatementServiceProvider ContinueStatementServiceProvider
    	{
    		get => _continueStatementServiceProvider ?? (_continueStatementServiceProvider = new ContinueStatementServiceProvider(this));
    		set => _continueStatementServiceProvider = value;
    	}
    	private ContinueStatementServiceProvider _continueStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ReturnStatement" type.
        /// </summary>
    	public virtual ReturnStatementServiceProvider ReturnStatementServiceProvider
    	{
    		get => _returnStatementServiceProvider ?? (_returnStatementServiceProvider = new ReturnStatementServiceProvider(this));
    		set => _returnStatementServiceProvider = value;
    	}
    	private ReturnStatementServiceProvider _returnStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowStatement" type.
        /// </summary>
    	public virtual ThrowStatementServiceProvider ThrowStatementServiceProvider
    	{
    		get => _throwStatementServiceProvider ?? (_throwStatementServiceProvider = new ThrowStatementServiceProvider(this));
    		set => _throwStatementServiceProvider = value;
    	}
    	private ThrowStatementServiceProvider _throwStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "YieldStatement" type.
        /// </summary>
    	public virtual YieldStatementServiceProvider YieldStatementServiceProvider
    	{
    		get => _yieldStatementServiceProvider ?? (_yieldStatementServiceProvider = new YieldStatementServiceProvider(this));
    		set => _yieldStatementServiceProvider = value;
    	}
    	private YieldStatementServiceProvider _yieldStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "WhileStatement" type.
        /// </summary>
    	public virtual WhileStatementServiceProvider WhileStatementServiceProvider
    	{
    		get => _whileStatementServiceProvider ?? (_whileStatementServiceProvider = new WhileStatementServiceProvider(this));
    		set => _whileStatementServiceProvider = value;
    	}
    	private WhileStatementServiceProvider _whileStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DoStatement" type.
        /// </summary>
    	public virtual DoStatementServiceProvider DoStatementServiceProvider
    	{
    		get => _doStatementServiceProvider ?? (_doStatementServiceProvider = new DoStatementServiceProvider(this));
    		set => _doStatementServiceProvider = value;
    	}
    	private DoStatementServiceProvider _doStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ForStatement" type.
        /// </summary>
    	public virtual ForStatementServiceProvider ForStatementServiceProvider
    	{
    		get => _forStatementServiceProvider ?? (_forStatementServiceProvider = new ForStatementServiceProvider(this));
    		set => _forStatementServiceProvider = value;
    	}
    	private ForStatementServiceProvider _forStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingStatement" type.
        /// </summary>
    	public virtual UsingStatementServiceProvider UsingStatementServiceProvider
    	{
    		get => _usingStatementServiceProvider ?? (_usingStatementServiceProvider = new UsingStatementServiceProvider(this));
    		set => _usingStatementServiceProvider = value;
    	}
    	private UsingStatementServiceProvider _usingStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "FixedStatement" type.
        /// </summary>
    	public virtual FixedStatementServiceProvider FixedStatementServiceProvider
    	{
    		get => _fixedStatementServiceProvider ?? (_fixedStatementServiceProvider = new FixedStatementServiceProvider(this));
    		set => _fixedStatementServiceProvider = value;
    	}
    	private FixedStatementServiceProvider _fixedStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedStatement" type.
        /// </summary>
    	public virtual CheckedStatementServiceProvider CheckedStatementServiceProvider
    	{
    		get => _checkedStatementServiceProvider ?? (_checkedStatementServiceProvider = new CheckedStatementServiceProvider(this));
    		set => _checkedStatementServiceProvider = value;
    	}
    	private CheckedStatementServiceProvider _checkedStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "UnsafeStatement" type.
        /// </summary>
    	public virtual UnsafeStatementServiceProvider UnsafeStatementServiceProvider
    	{
    		get => _unsafeStatementServiceProvider ?? (_unsafeStatementServiceProvider = new UnsafeStatementServiceProvider(this));
    		set => _unsafeStatementServiceProvider = value;
    	}
    	private UnsafeStatementServiceProvider _unsafeStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LockStatement" type.
        /// </summary>
    	public virtual LockStatementServiceProvider LockStatementServiceProvider
    	{
    		get => _lockStatementServiceProvider ?? (_lockStatementServiceProvider = new LockStatementServiceProvider(this));
    		set => _lockStatementServiceProvider = value;
    	}
    	private LockStatementServiceProvider _lockStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IfStatement" type.
        /// </summary>
    	public virtual IfStatementServiceProvider IfStatementServiceProvider
    	{
    		get => _ifStatementServiceProvider ?? (_ifStatementServiceProvider = new IfStatementServiceProvider(this));
    		set => _ifStatementServiceProvider = value;
    	}
    	private IfStatementServiceProvider _ifStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchStatement" type.
        /// </summary>
    	public virtual SwitchStatementServiceProvider SwitchStatementServiceProvider
    	{
    		get => _switchStatementServiceProvider ?? (_switchStatementServiceProvider = new SwitchStatementServiceProvider(this));
    		set => _switchStatementServiceProvider = value;
    	}
    	private SwitchStatementServiceProvider _switchStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TryStatement" type.
        /// </summary>
    	public virtual TryStatementServiceProvider TryStatementServiceProvider
    	{
    		get => _tryStatementServiceProvider ?? (_tryStatementServiceProvider = new TryStatementServiceProvider(this));
    		set => _tryStatementServiceProvider = value;
    	}
    	private TryStatementServiceProvider _tryStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachStatement" type.
        /// </summary>
    	public virtual ForEachStatementServiceProvider ForEachStatementServiceProvider
    	{
    		get => _forEachStatementServiceProvider ?? (_forEachStatementServiceProvider = new ForEachStatementServiceProvider(this));
    		set => _forEachStatementServiceProvider = value;
    	}
    	private ForEachStatementServiceProvider _forEachStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachVariableStatement" type.
        /// </summary>
    	public virtual ForEachVariableStatementServiceProvider ForEachVariableStatementServiceProvider
    	{
    		get => _forEachVariableStatementServiceProvider ?? (_forEachVariableStatementServiceProvider = new ForEachVariableStatementServiceProvider(this));
    		set => _forEachVariableStatementServiceProvider = value;
    	}
    	private ForEachVariableStatementServiceProvider _forEachVariableStatementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SingleVariableDesignation" type.
        /// </summary>
    	public virtual SingleVariableDesignationServiceProvider SingleVariableDesignationServiceProvider
    	{
    		get => _singleVariableDesignationServiceProvider ?? (_singleVariableDesignationServiceProvider = new SingleVariableDesignationServiceProvider(this));
    		set => _singleVariableDesignationServiceProvider = value;
    	}
    	private SingleVariableDesignationServiceProvider _singleVariableDesignationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DiscardDesignation" type.
        /// </summary>
    	public virtual DiscardDesignationServiceProvider DiscardDesignationServiceProvider
    	{
    		get => _discardDesignationServiceProvider ?? (_discardDesignationServiceProvider = new DiscardDesignationServiceProvider(this));
    		set => _discardDesignationServiceProvider = value;
    	}
    	private DiscardDesignationServiceProvider _discardDesignationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedVariableDesignation" type.
        /// </summary>
    	public virtual ParenthesizedVariableDesignationServiceProvider ParenthesizedVariableDesignationServiceProvider
    	{
    		get => _parenthesizedVariableDesignationServiceProvider ?? (_parenthesizedVariableDesignationServiceProvider = new ParenthesizedVariableDesignationServiceProvider(this));
    		set => _parenthesizedVariableDesignationServiceProvider = value;
    	}
    	private ParenthesizedVariableDesignationServiceProvider _parenthesizedVariableDesignationServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CasePatternSwitchLabel" type.
        /// </summary>
    	public virtual CasePatternSwitchLabelServiceProvider CasePatternSwitchLabelServiceProvider
    	{
    		get => _casePatternSwitchLabelServiceProvider ?? (_casePatternSwitchLabelServiceProvider = new CasePatternSwitchLabelServiceProvider(this));
    		set => _casePatternSwitchLabelServiceProvider = value;
    	}
    	private CasePatternSwitchLabelServiceProvider _casePatternSwitchLabelServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CaseSwitchLabel" type.
        /// </summary>
    	public virtual CaseSwitchLabelServiceProvider CaseSwitchLabelServiceProvider
    	{
    		get => _caseSwitchLabelServiceProvider ?? (_caseSwitchLabelServiceProvider = new CaseSwitchLabelServiceProvider(this));
    		set => _caseSwitchLabelServiceProvider = value;
    	}
    	private CaseSwitchLabelServiceProvider _caseSwitchLabelServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultSwitchLabel" type.
        /// </summary>
    	public virtual DefaultSwitchLabelServiceProvider DefaultSwitchLabelServiceProvider
    	{
    		get => _defaultSwitchLabelServiceProvider ?? (_defaultSwitchLabelServiceProvider = new DefaultSwitchLabelServiceProvider(this));
    		set => _defaultSwitchLabelServiceProvider = value;
    	}
    	private DefaultSwitchLabelServiceProvider _defaultSwitchLabelServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleBaseType" type.
        /// </summary>
    	public virtual SimpleBaseTypeServiceProvider SimpleBaseTypeServiceProvider
    	{
    		get => _simpleBaseTypeServiceProvider ?? (_simpleBaseTypeServiceProvider = new SimpleBaseTypeServiceProvider(this));
    		set => _simpleBaseTypeServiceProvider = value;
    	}
    	private SimpleBaseTypeServiceProvider _simpleBaseTypeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorConstraint" type.
        /// </summary>
    	public virtual ConstructorConstraintServiceProvider ConstructorConstraintServiceProvider
    	{
    		get => _constructorConstraintServiceProvider ?? (_constructorConstraintServiceProvider = new ConstructorConstraintServiceProvider(this));
    		set => _constructorConstraintServiceProvider = value;
    	}
    	private ConstructorConstraintServiceProvider _constructorConstraintServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassOrStructConstraint" type.
        /// </summary>
    	public virtual ClassOrStructConstraintServiceProvider ClassOrStructConstraintServiceProvider
    	{
    		get => _classOrStructConstraintServiceProvider ?? (_classOrStructConstraintServiceProvider = new ClassOrStructConstraintServiceProvider(this));
    		set => _classOrStructConstraintServiceProvider = value;
    	}
    	private ClassOrStructConstraintServiceProvider _classOrStructConstraintServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeConstraint" type.
        /// </summary>
    	public virtual TypeConstraintServiceProvider TypeConstraintServiceProvider
    	{
    		get => _typeConstraintServiceProvider ?? (_typeConstraintServiceProvider = new TypeConstraintServiceProvider(this));
    		set => _typeConstraintServiceProvider = value;
    	}
    	private TypeConstraintServiceProvider _typeConstraintServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ParameterList" type.
        /// </summary>
    	public virtual ParameterListServiceProvider ParameterListServiceProvider
    	{
    		get => _parameterListServiceProvider ?? (_parameterListServiceProvider = new ParameterListServiceProvider(this));
    		set => _parameterListServiceProvider = value;
    	}
    	private ParameterListServiceProvider _parameterListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedParameterList" type.
        /// </summary>
    	public virtual BracketedParameterListServiceProvider BracketedParameterListServiceProvider
    	{
    		get => _bracketedParameterListServiceProvider ?? (_bracketedParameterListServiceProvider = new BracketedParameterListServiceProvider(this));
    		set => _bracketedParameterListServiceProvider = value;
    	}
    	private BracketedParameterListServiceProvider _bracketedParameterListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "SkippedTokensTrivia" type.
        /// </summary>
    	public virtual SkippedTokensTriviaServiceProvider SkippedTokensTriviaServiceProvider
    	{
    		get => _skippedTokensTriviaServiceProvider ?? (_skippedTokensTriviaServiceProvider = new SkippedTokensTriviaServiceProvider(this));
    		set => _skippedTokensTriviaServiceProvider = value;
    	}
    	private SkippedTokensTriviaServiceProvider _skippedTokensTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DocumentationCommentTrivia" type.
        /// </summary>
    	public virtual DocumentationCommentTriviaServiceProvider DocumentationCommentTriviaServiceProvider
    	{
    		get => _documentationCommentTriviaServiceProvider ?? (_documentationCommentTriviaServiceProvider = new DocumentationCommentTriviaServiceProvider(this));
    		set => _documentationCommentTriviaServiceProvider = value;
    	}
    	private DocumentationCommentTriviaServiceProvider _documentationCommentTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EndIfDirectiveTrivia" type.
        /// </summary>
    	public virtual EndIfDirectiveTriviaServiceProvider EndIfDirectiveTriviaServiceProvider
    	{
    		get => _endIfDirectiveTriviaServiceProvider ?? (_endIfDirectiveTriviaServiceProvider = new EndIfDirectiveTriviaServiceProvider(this));
    		set => _endIfDirectiveTriviaServiceProvider = value;
    	}
    	private EndIfDirectiveTriviaServiceProvider _endIfDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "RegionDirectiveTrivia" type.
        /// </summary>
    	public virtual RegionDirectiveTriviaServiceProvider RegionDirectiveTriviaServiceProvider
    	{
    		get => _regionDirectiveTriviaServiceProvider ?? (_regionDirectiveTriviaServiceProvider = new RegionDirectiveTriviaServiceProvider(this));
    		set => _regionDirectiveTriviaServiceProvider = value;
    	}
    	private RegionDirectiveTriviaServiceProvider _regionDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "EndRegionDirectiveTrivia" type.
        /// </summary>
    	public virtual EndRegionDirectiveTriviaServiceProvider EndRegionDirectiveTriviaServiceProvider
    	{
    		get => _endRegionDirectiveTriviaServiceProvider ?? (_endRegionDirectiveTriviaServiceProvider = new EndRegionDirectiveTriviaServiceProvider(this));
    		set => _endRegionDirectiveTriviaServiceProvider = value;
    	}
    	private EndRegionDirectiveTriviaServiceProvider _endRegionDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ErrorDirectiveTrivia" type.
        /// </summary>
    	public virtual ErrorDirectiveTriviaServiceProvider ErrorDirectiveTriviaServiceProvider
    	{
    		get => _errorDirectiveTriviaServiceProvider ?? (_errorDirectiveTriviaServiceProvider = new ErrorDirectiveTriviaServiceProvider(this));
    		set => _errorDirectiveTriviaServiceProvider = value;
    	}
    	private ErrorDirectiveTriviaServiceProvider _errorDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "WarningDirectiveTrivia" type.
        /// </summary>
    	public virtual WarningDirectiveTriviaServiceProvider WarningDirectiveTriviaServiceProvider
    	{
    		get => _warningDirectiveTriviaServiceProvider ?? (_warningDirectiveTriviaServiceProvider = new WarningDirectiveTriviaServiceProvider(this));
    		set => _warningDirectiveTriviaServiceProvider = value;
    	}
    	private WarningDirectiveTriviaServiceProvider _warningDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "BadDirectiveTrivia" type.
        /// </summary>
    	public virtual BadDirectiveTriviaServiceProvider BadDirectiveTriviaServiceProvider
    	{
    		get => _badDirectiveTriviaServiceProvider ?? (_badDirectiveTriviaServiceProvider = new BadDirectiveTriviaServiceProvider(this));
    		set => _badDirectiveTriviaServiceProvider = value;
    	}
    	private BadDirectiveTriviaServiceProvider _badDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "DefineDirectiveTrivia" type.
        /// </summary>
    	public virtual DefineDirectiveTriviaServiceProvider DefineDirectiveTriviaServiceProvider
    	{
    		get => _defineDirectiveTriviaServiceProvider ?? (_defineDirectiveTriviaServiceProvider = new DefineDirectiveTriviaServiceProvider(this));
    		set => _defineDirectiveTriviaServiceProvider = value;
    	}
    	private DefineDirectiveTriviaServiceProvider _defineDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "UndefDirectiveTrivia" type.
        /// </summary>
    	public virtual UndefDirectiveTriviaServiceProvider UndefDirectiveTriviaServiceProvider
    	{
    		get => _undefDirectiveTriviaServiceProvider ?? (_undefDirectiveTriviaServiceProvider = new UndefDirectiveTriviaServiceProvider(this));
    		set => _undefDirectiveTriviaServiceProvider = value;
    	}
    	private UndefDirectiveTriviaServiceProvider _undefDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LineDirectiveTrivia" type.
        /// </summary>
    	public virtual LineDirectiveTriviaServiceProvider LineDirectiveTriviaServiceProvider
    	{
    		get => _lineDirectiveTriviaServiceProvider ?? (_lineDirectiveTriviaServiceProvider = new LineDirectiveTriviaServiceProvider(this));
    		set => _lineDirectiveTriviaServiceProvider = value;
    	}
    	private LineDirectiveTriviaServiceProvider _lineDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaWarningDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaWarningDirectiveTriviaServiceProvider PragmaWarningDirectiveTriviaServiceProvider
    	{
    		get => _pragmaWarningDirectiveTriviaServiceProvider ?? (_pragmaWarningDirectiveTriviaServiceProvider = new PragmaWarningDirectiveTriviaServiceProvider(this));
    		set => _pragmaWarningDirectiveTriviaServiceProvider = value;
    	}
    	private PragmaWarningDirectiveTriviaServiceProvider _pragmaWarningDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaChecksumDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaChecksumDirectiveTriviaServiceProvider PragmaChecksumDirectiveTriviaServiceProvider
    	{
    		get => _pragmaChecksumDirectiveTriviaServiceProvider ?? (_pragmaChecksumDirectiveTriviaServiceProvider = new PragmaChecksumDirectiveTriviaServiceProvider(this));
    		set => _pragmaChecksumDirectiveTriviaServiceProvider = value;
    	}
    	private PragmaChecksumDirectiveTriviaServiceProvider _pragmaChecksumDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ReferenceDirectiveTrivia" type.
        /// </summary>
    	public virtual ReferenceDirectiveTriviaServiceProvider ReferenceDirectiveTriviaServiceProvider
    	{
    		get => _referenceDirectiveTriviaServiceProvider ?? (_referenceDirectiveTriviaServiceProvider = new ReferenceDirectiveTriviaServiceProvider(this));
    		set => _referenceDirectiveTriviaServiceProvider = value;
    	}
    	private ReferenceDirectiveTriviaServiceProvider _referenceDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "LoadDirectiveTrivia" type.
        /// </summary>
    	public virtual LoadDirectiveTriviaServiceProvider LoadDirectiveTriviaServiceProvider
    	{
    		get => _loadDirectiveTriviaServiceProvider ?? (_loadDirectiveTriviaServiceProvider = new LoadDirectiveTriviaServiceProvider(this));
    		set => _loadDirectiveTriviaServiceProvider = value;
    	}
    	private LoadDirectiveTriviaServiceProvider _loadDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ShebangDirectiveTrivia" type.
        /// </summary>
    	public virtual ShebangDirectiveTriviaServiceProvider ShebangDirectiveTriviaServiceProvider
    	{
    		get => _shebangDirectiveTriviaServiceProvider ?? (_shebangDirectiveTriviaServiceProvider = new ShebangDirectiveTriviaServiceProvider(this));
    		set => _shebangDirectiveTriviaServiceProvider = value;
    	}
    	private ShebangDirectiveTriviaServiceProvider _shebangDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseDirectiveTrivia" type.
        /// </summary>
    	public virtual ElseDirectiveTriviaServiceProvider ElseDirectiveTriviaServiceProvider
    	{
    		get => _elseDirectiveTriviaServiceProvider ?? (_elseDirectiveTriviaServiceProvider = new ElseDirectiveTriviaServiceProvider(this));
    		set => _elseDirectiveTriviaServiceProvider = value;
    	}
    	private ElseDirectiveTriviaServiceProvider _elseDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IfDirectiveTrivia" type.
        /// </summary>
    	public virtual IfDirectiveTriviaServiceProvider IfDirectiveTriviaServiceProvider
    	{
    		get => _ifDirectiveTriviaServiceProvider ?? (_ifDirectiveTriviaServiceProvider = new IfDirectiveTriviaServiceProvider(this));
    		set => _ifDirectiveTriviaServiceProvider = value;
    	}
    	private IfDirectiveTriviaServiceProvider _ifDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ElifDirectiveTrivia" type.
        /// </summary>
    	public virtual ElifDirectiveTriviaServiceProvider ElifDirectiveTriviaServiceProvider
    	{
    		get => _elifDirectiveTriviaServiceProvider ?? (_elifDirectiveTriviaServiceProvider = new ElifDirectiveTriviaServiceProvider(this));
    		set => _elifDirectiveTriviaServiceProvider = value;
    	}
    	private ElifDirectiveTriviaServiceProvider _elifDirectiveTriviaServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeCref" type.
        /// </summary>
    	public virtual TypeCrefServiceProvider TypeCrefServiceProvider
    	{
    		get => _typeCrefServiceProvider ?? (_typeCrefServiceProvider = new TypeCrefServiceProvider(this));
    		set => _typeCrefServiceProvider = value;
    	}
    	private TypeCrefServiceProvider _typeCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedCref" type.
        /// </summary>
    	public virtual QualifiedCrefServiceProvider QualifiedCrefServiceProvider
    	{
    		get => _qualifiedCrefServiceProvider ?? (_qualifiedCrefServiceProvider = new QualifiedCrefServiceProvider(this));
    		set => _qualifiedCrefServiceProvider = value;
    	}
    	private QualifiedCrefServiceProvider _qualifiedCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "NameMemberCref" type.
        /// </summary>
    	public virtual NameMemberCrefServiceProvider NameMemberCrefServiceProvider
    	{
    		get => _nameMemberCrefServiceProvider ?? (_nameMemberCrefServiceProvider = new NameMemberCrefServiceProvider(this));
    		set => _nameMemberCrefServiceProvider = value;
    	}
    	private NameMemberCrefServiceProvider _nameMemberCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerMemberCref" type.
        /// </summary>
    	public virtual IndexerMemberCrefServiceProvider IndexerMemberCrefServiceProvider
    	{
    		get => _indexerMemberCrefServiceProvider ?? (_indexerMemberCrefServiceProvider = new IndexerMemberCrefServiceProvider(this));
    		set => _indexerMemberCrefServiceProvider = value;
    	}
    	private IndexerMemberCrefServiceProvider _indexerMemberCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorMemberCref" type.
        /// </summary>
    	public virtual OperatorMemberCrefServiceProvider OperatorMemberCrefServiceProvider
    	{
    		get => _operatorMemberCrefServiceProvider ?? (_operatorMemberCrefServiceProvider = new OperatorMemberCrefServiceProvider(this));
    		set => _operatorMemberCrefServiceProvider = value;
    	}
    	private OperatorMemberCrefServiceProvider _operatorMemberCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorMemberCref" type.
        /// </summary>
    	public virtual ConversionOperatorMemberCrefServiceProvider ConversionOperatorMemberCrefServiceProvider
    	{
    		get => _conversionOperatorMemberCrefServiceProvider ?? (_conversionOperatorMemberCrefServiceProvider = new ConversionOperatorMemberCrefServiceProvider(this));
    		set => _conversionOperatorMemberCrefServiceProvider = value;
    	}
    	private ConversionOperatorMemberCrefServiceProvider _conversionOperatorMemberCrefServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameterList" type.
        /// </summary>
    	public virtual CrefParameterListServiceProvider CrefParameterListServiceProvider
    	{
    		get => _crefParameterListServiceProvider ?? (_crefParameterListServiceProvider = new CrefParameterListServiceProvider(this));
    		set => _crefParameterListServiceProvider = value;
    	}
    	private CrefParameterListServiceProvider _crefParameterListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefBracketedParameterList" type.
        /// </summary>
    	public virtual CrefBracketedParameterListServiceProvider CrefBracketedParameterListServiceProvider
    	{
    		get => _crefBracketedParameterListServiceProvider ?? (_crefBracketedParameterListServiceProvider = new CrefBracketedParameterListServiceProvider(this));
    		set => _crefBracketedParameterListServiceProvider = value;
    	}
    	private CrefBracketedParameterListServiceProvider _crefBracketedParameterListServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElement" type.
        /// </summary>
    	public virtual XmlElementServiceProvider XmlElementServiceProvider
    	{
    		get => _xmlElementServiceProvider ?? (_xmlElementServiceProvider = new XmlElementServiceProvider(this));
    		set => _xmlElementServiceProvider = value;
    	}
    	private XmlElementServiceProvider _xmlElementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlEmptyElement" type.
        /// </summary>
    	public virtual XmlEmptyElementServiceProvider XmlEmptyElementServiceProvider
    	{
    		get => _xmlEmptyElementServiceProvider ?? (_xmlEmptyElementServiceProvider = new XmlEmptyElementServiceProvider(this));
    		set => _xmlEmptyElementServiceProvider = value;
    	}
    	private XmlEmptyElementServiceProvider _xmlEmptyElementServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlText" type.
        /// </summary>
    	public virtual XmlTextServiceProvider XmlTextServiceProvider
    	{
    		get => _xmlTextServiceProvider ?? (_xmlTextServiceProvider = new XmlTextServiceProvider(this));
    		set => _xmlTextServiceProvider = value;
    	}
    	private XmlTextServiceProvider _xmlTextServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCDataSection" type.
        /// </summary>
    	public virtual XmlCDataSectionServiceProvider XmlCDataSectionServiceProvider
    	{
    		get => _xmlCDataSectionServiceProvider ?? (_xmlCDataSectionServiceProvider = new XmlCDataSectionServiceProvider(this));
    		set => _xmlCDataSectionServiceProvider = value;
    	}
    	private XmlCDataSectionServiceProvider _xmlCDataSectionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlProcessingInstruction" type.
        /// </summary>
    	public virtual XmlProcessingInstructionServiceProvider XmlProcessingInstructionServiceProvider
    	{
    		get => _xmlProcessingInstructionServiceProvider ?? (_xmlProcessingInstructionServiceProvider = new XmlProcessingInstructionServiceProvider(this));
    		set => _xmlProcessingInstructionServiceProvider = value;
    	}
    	private XmlProcessingInstructionServiceProvider _xmlProcessingInstructionServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlComment" type.
        /// </summary>
    	public virtual XmlCommentServiceProvider XmlCommentServiceProvider
    	{
    		get => _xmlCommentServiceProvider ?? (_xmlCommentServiceProvider = new XmlCommentServiceProvider(this));
    		set => _xmlCommentServiceProvider = value;
    	}
    	private XmlCommentServiceProvider _xmlCommentServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlTextAttribute" type.
        /// </summary>
    	public virtual XmlTextAttributeServiceProvider XmlTextAttributeServiceProvider
    	{
    		get => _xmlTextAttributeServiceProvider ?? (_xmlTextAttributeServiceProvider = new XmlTextAttributeServiceProvider(this));
    		set => _xmlTextAttributeServiceProvider = value;
    	}
    	private XmlTextAttributeServiceProvider _xmlTextAttributeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCrefAttribute" type.
        /// </summary>
    	public virtual XmlCrefAttributeServiceProvider XmlCrefAttributeServiceProvider
    	{
    		get => _xmlCrefAttributeServiceProvider ?? (_xmlCrefAttributeServiceProvider = new XmlCrefAttributeServiceProvider(this));
    		set => _xmlCrefAttributeServiceProvider = value;
    	}
    	private XmlCrefAttributeServiceProvider _xmlCrefAttributeServiceProvider;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlNameAttribute" type.
        /// </summary>
    	public virtual XmlNameAttributeServiceProvider XmlNameAttributeServiceProvider
    	{
    		get => _xmlNameAttributeServiceProvider ?? (_xmlNameAttributeServiceProvider = new XmlNameAttributeServiceProvider(this));
    		set => _xmlNameAttributeServiceProvider = value;
    	}
    	private XmlNameAttributeServiceProvider _xmlNameAttributeServiceProvider;
    
    }
}
// Generated helper templates
// Generated items
