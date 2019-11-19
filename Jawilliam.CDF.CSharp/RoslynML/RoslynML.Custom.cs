using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynML
    {
        /// <summary>
        /// Loads the content given as a full path or a textual content.
        /// </summary>
        /// <param name="pathOrContent">full path or textual content</param>
        /// <param name="path">informs if the content is given as a full path or textual content.</param>
        /// <returns>XML-like representation of the Roslyn-based AST.</returns>
        public virtual XElement Load(string pathOrContent, bool path = true)
        {
            string content = path ? System.IO.File.ReadAllText(pathOrContent) : pathOrContent;
            var ast = SyntaxFactory.ParseCompilationUnit(content).SyntaxTree.GetRoot();
            return this.Visit(ast);
        }

        /// <summary>
        /// Loads the content given as a full path or a textual content.
        /// </summary>
        /// <param name="pathOrContent">full path or textual content</param>
        /// <param name="path">informs if the content is given as a full path or textual content.</param>
        /// <param name="includeTrivia">informs whether the trivia should be included, or not.</param>
        /// <returns>XML-like representation of the Roslyn-based AST.</returns>
        public virtual XElement GetTree(string pathOrContent, bool path = true, bool includeTrivia = false)
        {
            var xElement = this.Load(pathOrContent, path);

            int roslynId = 0, gumTreefiedId = 0;
            this.SetRoslynMLIDs(xElement, ref roslynId);
            this.SetGumTreefiedIDs(xElement, ref gumTreefiedId);

            if (includeTrivia)
            {
                foreach (var xItem in xElement.DescendantNodesAndSelf().OfType<XElement>())
                {
                    var annotation = xItem.Annotation(typeof((XElement[], XElement[])));
                    if (annotation != null)
                    {
                        var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;

                        foreach (var lt in leadingTrivia)
                        {
                            XElement xLocation = xItem;
                            while (!xLocation.ElementsBeforeSelf().OfType<XElement>().Any() &&
                                   ((xLocation.Parent?.Name.LocalName.EndsWith("List") ?? false) ||
                                    (xLocation.Parent?.Name.LocalName.StartsWith("List_of_") ?? false)))
                            {
                                this.FixListTrivia(xLocation.Parent);
                                xLocation = xLocation.Parent;
                            }
                            xLocation.AddBeforeSelf(lt);
                            this.SetRoslynMLIDs(lt, ref roslynId);
                            this.SetGumTreefiedIDs(lt, ref gumTreefiedId);
                        }

                        foreach (var tt in trailingTrivia)
                        {
                            XElement xLocation = xItem;
                            while (!xLocation.ElementsAfterSelf().OfType<XElement>().Any() &&
                                   ((xLocation.Parent?.Name.LocalName.EndsWith("List") ?? false) ||
                                    (xLocation.Parent?.Name.LocalName.StartsWith("List_of_") ?? false)))
                            {
                                this.FixListTrivia(xLocation.Parent);
                                xLocation = xLocation.Parent;
                            }
                            xLocation.AddAfterSelf(tt);
                            this.SetRoslynMLIDs(tt, ref roslynId);
                            this.SetGumTreefiedIDs(tt, ref gumTreefiedId);
                        }

                        xItem.RemoveAnnotations(typeof(((XElement, SyntaxNode)?[], (XElement, SyntaxNode)?[])));

                        leadingTrivia.ToArray()
                            .Where(lt => lt.Name.LocalName == "CommentTrivia")
                            .ForEach(this.FixCommentTrivia);
                        trailingTrivia.ToArray()
                            .Where(tt => tt.Name.LocalName == "CommentTrivia")
                            .ForEach(this.FixCommentTrivia);
                    }
                }
            }

            return xElement;
        }

        private XNode GetTriviaParentElement(XNode xElement, SyntaxNode parent)
        {
            var ancestors = xElement.Ancestors();

            var label = parent.Kind().ToString();
            string startLine = (parent.GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
            string startColumn = (parent.GetLocation().GetLineSpan().StartLinePosition.Character + 1).ToString(CultureInfo.InvariantCulture);
            string endLine = (parent.GetLocation().GetLineSpan().EndLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
            string endColumn = (parent.GetLocation().GetLineSpan().EndLinePosition.Character).ToString(CultureInfo.InvariantCulture);

            XNode last = xElement;
            foreach (var a in ancestors)
            {
                if ((a.Attribute("kind")?.Value ?? a.Name.LocalName) == label &&
                   a.Attribute("startLine").Value == startLine &&
                   a.Attribute("startColumn").Value == startColumn &&
                   a.Attribute("endLine").Value == endLine &&
                   a.Attribute("endColumn").Value == endColumn)
                    break;
                last = a;
            }

            return last;
        }

        /// <summary>
        /// Converts an XML-like AST representation to the XML-like AST representation internally expected by GumTree.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="typeBasedLabels"></param>
        /// <returns></returns>
        public virtual XElement Gumtreefy(XElement source, bool typeBasedLabels = false)
        {
            return this.CoreGumtreefy(source, typeBasedLabels).Single();
        }

        private IEnumerable<XElement> CoreGumtreefy(XElement source, bool nameBasedLabels)
        {
            if (source.Name.LocalName.Contains("_of_") || source.Name.LocalName == "TokenList")
            {
                foreach (var child in source.Elements())
                {
                    var rChildren = this.CoreGumtreefy(child, nameBasedLabels).ToArray();
                    foreach (var rChild in rChildren)
                    {
                        yield return rChild;
                    }
                }
                yield break;
            } 

            var result = new XElement("tree");

            var kindAtt = source.Attribute("kind");
            var kind = kindAtt != null ? kindAtt.Value : source.Name.LocalName;
            var kindVal = (SyntaxKind)Enum.Parse(typeof(SyntaxKind), kind);

            if (nameBasedLabels)
            {
                kindVal = this.GetNameBasedLabelType(kindVal);
                kind = source.Name.LocalName;
            }

            result.Add(new XAttribute("type", ((int)kindVal).ToString(CultureInfo.InvariantCulture)));
            result.Add(new XAttribute("typeLabel", kind));

            if (source.Name.LocalName == "Token" || !source.Elements().Any())
                result.Add(new XAttribute("label", source.Value ?? ""));

            var startLineAtt = source.Attribute("startLine");
            if (startLineAtt != null)
                result.Add(new XAttribute("line_before", startLineAtt.Value));

            var startColumnAtt = source.Attribute("startColumn");
            if (startColumnAtt != null)
                result.Add(new XAttribute("col_before", startColumnAtt.Value));

            var endLineAtt = source.Attribute("endLine");
            if (endLineAtt != null)
                result.Add(new XAttribute("line_after", endLineAtt.Value));

            var endColumnAtt = source.Attribute("endColumn");
            if (endColumnAtt != null)
                result.Add(new XAttribute("col_after", endColumnAtt.Value));

            var posAtt = source.Attribute("pos");
            if (posAtt != null)
                result.Add(posAtt);

            var lengthAtt = source.Attribute("length");
            if (lengthAtt != null)
                result.Add(lengthAtt);

            foreach (var child in source.Elements())
            {
                result.Add(this.CoreGumtreefy(child, nameBasedLabels).ToArray());
            }

            yield return result;
        }



        /// <summary>
        /// Gets the name-based label type to generate a srcML-like serialization where the label is the name, instead of the kind.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <returns>For multi-label element types, it always return one unique label, otherwise the element type is already a name-based element type.</returns>
        public virtual SyntaxKind GetNameBasedLabelType(SyntaxKind type)
        {
            if (8193 <= (int)type && 8517 >= (int)type)
                return (SyntaxKind)8193;

            switch (type)
            {
                case SyntaxKind.AttributeArgument: return SyntaxKind.AttributeArgument;
                case SyntaxKind.NameEquals: return SyntaxKind.NameEquals;
                case SyntaxKind.TypeParameterList: return SyntaxKind.TypeParameterList;
                case SyntaxKind.TypeParameter: return SyntaxKind.TypeParameter;
                case SyntaxKind.BaseList: return SyntaxKind.BaseList;
                case SyntaxKind.TypeParameterConstraintClause: return SyntaxKind.TypeParameterConstraintClause;
                case SyntaxKind.ExplicitInterfaceSpecifier: return SyntaxKind.ExplicitInterfaceSpecifier;
                case SyntaxKind.BaseConstructorInitializer:
                case SyntaxKind.ThisConstructorInitializer: return SyntaxKind.ThisConstructorInitializer;
                case SyntaxKind.ArrowExpressionClause: return SyntaxKind.ArrowExpressionClause;
                case SyntaxKind.AccessorList: return SyntaxKind.AccessorList;
                case SyntaxKind.GetAccessorDeclaration:
                case SyntaxKind.SetAccessorDeclaration:
                case SyntaxKind.AddAccessorDeclaration:
                case SyntaxKind.RemoveAccessorDeclaration:
                case SyntaxKind.UnknownAccessorDeclaration: return SyntaxKind.UnknownAccessorDeclaration;
                case SyntaxKind.Parameter: return SyntaxKind.Parameter;
                case SyntaxKind.CrefParameter: return SyntaxKind.CrefParameter;
                case SyntaxKind.XmlElementStartTag: return SyntaxKind.XmlElementStartTag;
                case SyntaxKind.XmlElementEndTag: return SyntaxKind.XmlElementEndTag;
                case SyntaxKind.XmlName: return SyntaxKind.XmlName;
                case SyntaxKind.XmlPrefix: return SyntaxKind.XmlPrefix;
                case SyntaxKind.TypeArgumentList: return SyntaxKind.TypeArgumentList;
                case SyntaxKind.ArrayRankSpecifier: return SyntaxKind.ArrayRankSpecifier;
                case SyntaxKind.TupleElement: return SyntaxKind.TupleElement;
                case SyntaxKind.Argument: return SyntaxKind.Argument;
                case SyntaxKind.NameColon: return SyntaxKind.NameColon;
                case SyntaxKind.AnonymousObjectMemberDeclarator: return SyntaxKind.AnonymousObjectMemberDeclarator;
                case SyntaxKind.QueryBody: return SyntaxKind.QueryBody;
                case SyntaxKind.JoinIntoClause: return SyntaxKind.JoinIntoClause;
                case SyntaxKind.AscendingOrdering:
                case SyntaxKind.DescendingOrdering: return SyntaxKind.DescendingOrdering;
                case SyntaxKind.QueryContinuation: return SyntaxKind.QueryContinuation;
                case SyntaxKind.WhenClause: return SyntaxKind.WhenClause;
                case SyntaxKind.InterpolationAlignmentClause: return SyntaxKind.InterpolationAlignmentClause;
                case SyntaxKind.InterpolationFormatClause: return SyntaxKind.InterpolationFormatClause;
                case SyntaxKind.VariableDeclaration: return SyntaxKind.VariableDeclaration;
                case SyntaxKind.VariableDeclarator: return SyntaxKind.VariableDeclarator;
                case SyntaxKind.EqualsValueClause: return SyntaxKind.EqualsValueClause;
                case SyntaxKind.ElseClause: return SyntaxKind.ElseClause;
                case SyntaxKind.SwitchSection: return SyntaxKind.SwitchSection;
                case SyntaxKind.CatchClause: return SyntaxKind.CatchClause;
                case SyntaxKind.CatchDeclaration: return SyntaxKind.CatchDeclaration;
                case SyntaxKind.CatchFilterClause: return SyntaxKind.CatchFilterClause;
                case SyntaxKind.FinallyClause: return SyntaxKind.FinallyClause;
                case SyntaxKind.CompilationUnit: return SyntaxKind.CompilationUnit;
                case SyntaxKind.ExternAliasDirective: return SyntaxKind.ExternAliasDirective;
                case SyntaxKind.UsingDirective: return SyntaxKind.UsingDirective;
                case SyntaxKind.AttributeList: return SyntaxKind.AttributeList;
                case SyntaxKind.AttributeTargetSpecifier: return SyntaxKind.AttributeTargetSpecifier;
                case SyntaxKind.Attribute: return SyntaxKind.Attribute;
                case SyntaxKind.AttributeArgumentList: return SyntaxKind.AttributeArgumentList;
                case SyntaxKind.DelegateDeclaration: return SyntaxKind.DelegateDeclaration;
                case SyntaxKind.EnumMemberDeclaration: return SyntaxKind.EnumMemberDeclaration;
                case SyntaxKind.IncompleteMember: return SyntaxKind.IncompleteMember;
                case SyntaxKind.GlobalStatement: return SyntaxKind.GlobalStatement;
                case SyntaxKind.NamespaceDeclaration: return SyntaxKind.NamespaceDeclaration;
                case SyntaxKind.EnumDeclaration: return SyntaxKind.EnumDeclaration;
                case SyntaxKind.ClassDeclaration: return SyntaxKind.ClassDeclaration;
                case SyntaxKind.StructDeclaration: return SyntaxKind.StructDeclaration;
                case SyntaxKind.InterfaceDeclaration: return SyntaxKind.InterfaceDeclaration;
                case SyntaxKind.FieldDeclaration: return SyntaxKind.FieldDeclaration;
                case SyntaxKind.EventFieldDeclaration: return SyntaxKind.EventFieldDeclaration;
                case SyntaxKind.MethodDeclaration: return SyntaxKind.MethodDeclaration;
                case SyntaxKind.OperatorDeclaration: return SyntaxKind.OperatorDeclaration;
                case SyntaxKind.ConversionOperatorDeclaration: return SyntaxKind.ConversionOperatorDeclaration;
                case SyntaxKind.ConstructorDeclaration: return SyntaxKind.ConstructorDeclaration;
                case SyntaxKind.DestructorDeclaration: return SyntaxKind.DestructorDeclaration;
                case SyntaxKind.PropertyDeclaration: return SyntaxKind.PropertyDeclaration;
                case SyntaxKind.EventDeclaration: return SyntaxKind.EventDeclaration;
                case SyntaxKind.IndexerDeclaration: return SyntaxKind.IndexerDeclaration;
                case SyntaxKind.SimpleBaseType: return SyntaxKind.SimpleBaseType;
                case SyntaxKind.ConstructorConstraint: return SyntaxKind.ConstructorConstraint;
                case SyntaxKind.ClassConstraint:
                case SyntaxKind.StructConstraint: return SyntaxKind.StructConstraint;
                case SyntaxKind.TypeConstraint: return SyntaxKind.TypeConstraint;
                case SyntaxKind.ParameterList: return SyntaxKind.ParameterList;
                case SyntaxKind.BracketedParameterList: return SyntaxKind.BracketedParameterList;
                case SyntaxKind.SkippedTokensTrivia: return SyntaxKind.SkippedTokensTrivia;
                case SyntaxKind.SingleLineDocumentationCommentTrivia:
                case SyntaxKind.MultiLineDocumentationCommentTrivia: return SyntaxKind.MultiLineDocumentationCommentTrivia;
                case SyntaxKind.EndIfDirectiveTrivia: return SyntaxKind.EndIfDirectiveTrivia;
                case SyntaxKind.RegionDirectiveTrivia: return SyntaxKind.RegionDirectiveTrivia;
                case SyntaxKind.EndRegionDirectiveTrivia: return SyntaxKind.EndRegionDirectiveTrivia;
                case SyntaxKind.ErrorDirectiveTrivia: return SyntaxKind.ErrorDirectiveTrivia;
                case SyntaxKind.WarningDirectiveTrivia: return SyntaxKind.WarningDirectiveTrivia;
                case SyntaxKind.BadDirectiveTrivia: return SyntaxKind.BadDirectiveTrivia;
                case SyntaxKind.DefineDirectiveTrivia: return SyntaxKind.DefineDirectiveTrivia;
                case SyntaxKind.UndefDirectiveTrivia: return SyntaxKind.UndefDirectiveTrivia;
                case SyntaxKind.LineDirectiveTrivia: return SyntaxKind.LineDirectiveTrivia;
                case SyntaxKind.PragmaWarningDirectiveTrivia: return SyntaxKind.PragmaWarningDirectiveTrivia;
                case SyntaxKind.PragmaChecksumDirectiveTrivia: return SyntaxKind.PragmaChecksumDirectiveTrivia;
                case SyntaxKind.ReferenceDirectiveTrivia: return SyntaxKind.ReferenceDirectiveTrivia;
                case SyntaxKind.LoadDirectiveTrivia: return SyntaxKind.LoadDirectiveTrivia;
                case SyntaxKind.ShebangDirectiveTrivia: return SyntaxKind.ShebangDirectiveTrivia;
                case SyntaxKind.ElseDirectiveTrivia: return SyntaxKind.ElseDirectiveTrivia;
                case SyntaxKind.IfDirectiveTrivia: return SyntaxKind.IfDirectiveTrivia;
                case SyntaxKind.ElifDirectiveTrivia: return SyntaxKind.ElifDirectiveTrivia;
                case SyntaxKind.TypeCref: return SyntaxKind.TypeCref;
                case SyntaxKind.QualifiedCref: return SyntaxKind.QualifiedCref;
                case SyntaxKind.NameMemberCref: return SyntaxKind.NameMemberCref;
                case SyntaxKind.IndexerMemberCref: return SyntaxKind.IndexerMemberCref;
                case SyntaxKind.OperatorMemberCref: return SyntaxKind.OperatorMemberCref;
                case SyntaxKind.ConversionOperatorMemberCref: return SyntaxKind.ConversionOperatorMemberCref;
                case SyntaxKind.CrefParameterList: return SyntaxKind.CrefParameterList;
                case SyntaxKind.CrefBracketedParameterList: return SyntaxKind.CrefBracketedParameterList;
                case SyntaxKind.XmlElement: return SyntaxKind.XmlElement;
                case SyntaxKind.XmlEmptyElement: return SyntaxKind.XmlEmptyElement;
                case SyntaxKind.XmlText: return SyntaxKind.XmlText;
                case SyntaxKind.XmlCDataSection: return SyntaxKind.XmlCDataSection;
                case SyntaxKind.XmlProcessingInstruction: return SyntaxKind.XmlProcessingInstruction;
                case SyntaxKind.XmlComment: return SyntaxKind.XmlComment;
                case SyntaxKind.XmlTextAttribute: return SyntaxKind.XmlTextAttribute;
                case SyntaxKind.XmlCrefAttribute: return SyntaxKind.XmlCrefAttribute;
                case SyntaxKind.XmlNameAttribute: return SyntaxKind.XmlNameAttribute;
                case SyntaxKind.ParenthesizedExpression: return SyntaxKind.ParenthesizedExpression;
                case SyntaxKind.TupleExpression: return SyntaxKind.TupleExpression;
                case SyntaxKind.UnaryPlusExpression:
                case SyntaxKind.UnaryMinusExpression:
                case SyntaxKind.BitwiseNotExpression:
                case SyntaxKind.LogicalNotExpression:
                case SyntaxKind.PreIncrementExpression:
                case SyntaxKind.PreDecrementExpression:
                case SyntaxKind.AddressOfExpression:
                case SyntaxKind.PointerIndirectionExpression: return SyntaxKind.PointerIndirectionExpression;
                case SyntaxKind.AwaitExpression: return SyntaxKind.AwaitExpression;
                case SyntaxKind.PostIncrementExpression:
                case SyntaxKind.PostDecrementExpression: return SyntaxKind.PostDecrementExpression;
                case SyntaxKind.SimpleMemberAccessExpression:
                case SyntaxKind.PointerMemberAccessExpression: return SyntaxKind.PointerMemberAccessExpression;
                case SyntaxKind.ConditionalAccessExpression: return SyntaxKind.ConditionalAccessExpression;
                case SyntaxKind.MemberBindingExpression: return SyntaxKind.MemberBindingExpression;
                case SyntaxKind.ElementBindingExpression: return SyntaxKind.ElementBindingExpression;
                case SyntaxKind.ImplicitElementAccess: return SyntaxKind.ImplicitElementAccess;
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
                case SyntaxKind.CoalesceExpression: return SyntaxKind.CoalesceExpression;
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
                case SyntaxKind.RightShiftAssignmentExpression: return SyntaxKind.RightShiftAssignmentExpression;
                case SyntaxKind.ConditionalExpression: return SyntaxKind.ConditionalExpression;
                case SyntaxKind.ArgListExpression:
                case SyntaxKind.NumericLiteralExpression:
                case SyntaxKind.StringLiteralExpression:
                case SyntaxKind.CharacterLiteralExpression:
                case SyntaxKind.TrueLiteralExpression:
                case SyntaxKind.FalseLiteralExpression:
                case SyntaxKind.NullLiteralExpression:
                case SyntaxKind.DefaultLiteralExpression: return SyntaxKind.DefaultLiteralExpression;
                case SyntaxKind.MakeRefExpression: return SyntaxKind.MakeRefExpression;
                case SyntaxKind.RefTypeExpression: return SyntaxKind.RefTypeExpression;
                case SyntaxKind.RefValueExpression: return SyntaxKind.RefValueExpression;
                case SyntaxKind.CheckedExpression:
                case SyntaxKind.UncheckedExpression: return SyntaxKind.CheckedExpression;
                case SyntaxKind.DefaultExpression: return SyntaxKind.DefaultExpression;
                case SyntaxKind.TypeOfExpression: return SyntaxKind.TypeOfExpression;
                case SyntaxKind.SizeOfExpression: return SyntaxKind.SizeOfExpression;
                case SyntaxKind.InvocationExpression: return SyntaxKind.InvocationExpression;
                case SyntaxKind.ElementAccessExpression: return SyntaxKind.ElementAccessExpression;
                case SyntaxKind.DeclarationExpression: return SyntaxKind.DeclarationExpression;
                case SyntaxKind.CastExpression: return SyntaxKind.CastExpression;
                case SyntaxKind.RefExpression: return SyntaxKind.RefExpression;
                case SyntaxKind.ObjectInitializerExpression:
                case SyntaxKind.CollectionInitializerExpression:
                case SyntaxKind.ArrayInitializerExpression:
                case SyntaxKind.ComplexElementInitializerExpression: return SyntaxKind.ComplexElementInitializerExpression;
                case SyntaxKind.ObjectCreationExpression: return SyntaxKind.ObjectCreationExpression;
                case SyntaxKind.AnonymousObjectCreationExpression: return SyntaxKind.AnonymousObjectCreationExpression;
                case SyntaxKind.ArrayCreationExpression: return SyntaxKind.ArrayCreationExpression;
                case SyntaxKind.ImplicitArrayCreationExpression: return SyntaxKind.ImplicitArrayCreationExpression;
                case SyntaxKind.StackAllocArrayCreationExpression: return SyntaxKind.StackAllocArrayCreationExpression;
                case SyntaxKind.QueryExpression: return SyntaxKind.QueryExpression;
                case SyntaxKind.OmittedArraySizeExpression: return SyntaxKind.OmittedArraySizeExpression;
                case SyntaxKind.InterpolatedStringExpression: return SyntaxKind.InterpolatedStringExpression;
                case SyntaxKind.IsPatternExpression: return SyntaxKind.IsPatternExpression;
                case SyntaxKind.ThrowExpression: return SyntaxKind.ThrowExpression;
                case SyntaxKind.PredefinedType: return SyntaxKind.PredefinedType;
                case SyntaxKind.ArrayType: return SyntaxKind.ArrayType;
                case SyntaxKind.PointerType: return SyntaxKind.PointerType;
                case SyntaxKind.NullableType: return SyntaxKind.NullableType;
                case SyntaxKind.TupleType: return SyntaxKind.TupleType;
                case SyntaxKind.OmittedTypeArgument: return SyntaxKind.OmittedTypeArgument;
                case SyntaxKind.RefType: return SyntaxKind.RefType;
                case SyntaxKind.QualifiedName: return SyntaxKind.QualifiedName;
                case SyntaxKind.AliasQualifiedName: return SyntaxKind.AliasQualifiedName;
                case SyntaxKind.IdentifierName: return SyntaxKind.IdentifierName;
                case SyntaxKind.GenericName: return SyntaxKind.GenericName;
                case SyntaxKind.ThisExpression: return SyntaxKind.ThisExpression;
                case SyntaxKind.BaseExpression: return SyntaxKind.BaseExpression;
                case SyntaxKind.AnonymousMethodExpression: return SyntaxKind.AnonymousMethodExpression;
                case SyntaxKind.SimpleLambdaExpression: return SyntaxKind.SimpleLambdaExpression;
                case SyntaxKind.ParenthesizedLambdaExpression: return SyntaxKind.ParenthesizedLambdaExpression;
                case SyntaxKind.ArgumentList: return SyntaxKind.ArgumentList;
                case SyntaxKind.BracketedArgumentList: return SyntaxKind.BracketedArgumentList;
                case SyntaxKind.FromClause: return SyntaxKind.FromClause;
                case SyntaxKind.LetClause: return SyntaxKind.LetClause;
                case SyntaxKind.JoinClause: return SyntaxKind.JoinClause;
                case SyntaxKind.WhereClause: return SyntaxKind.WhereClause;
                case SyntaxKind.OrderByClause: return SyntaxKind.OrderByClause;
                case SyntaxKind.SelectClause: return SyntaxKind.SelectClause;
                case SyntaxKind.GroupClause: return SyntaxKind.GroupClause;
                case SyntaxKind.DeclarationPattern: return SyntaxKind.DeclarationPattern;
                case SyntaxKind.ConstantPattern: return SyntaxKind.ConstantPattern;
                case SyntaxKind.InterpolatedStringText: return SyntaxKind.InterpolatedStringText;
                case SyntaxKind.Interpolation: return SyntaxKind.Interpolation;
                case SyntaxKind.Block: return SyntaxKind.Block;
                case SyntaxKind.LocalFunctionStatement: return SyntaxKind.LocalFunctionStatement;
                case SyntaxKind.LocalDeclarationStatement: return SyntaxKind.LocalDeclarationStatement;
                case SyntaxKind.ExpressionStatement: return SyntaxKind.ExpressionStatement;
                case SyntaxKind.EmptyStatement: return SyntaxKind.EmptyStatement;
                case SyntaxKind.LabeledStatement: return SyntaxKind.LabeledStatement;
                case SyntaxKind.GotoStatement:
                case SyntaxKind.GotoCaseStatement:
                case SyntaxKind.GotoDefaultStatement: return SyntaxKind.GotoStatement;
                case SyntaxKind.BreakStatement: return SyntaxKind.BreakStatement;
                case SyntaxKind.ContinueStatement: return SyntaxKind.ContinueStatement;
                case SyntaxKind.ReturnStatement: return SyntaxKind.ReturnStatement;
                case SyntaxKind.ThrowStatement: return SyntaxKind.ThrowStatement;
                case SyntaxKind.YieldReturnStatement:
                case SyntaxKind.YieldBreakStatement: return SyntaxKind.YieldBreakStatement;
                case SyntaxKind.WhileStatement: return SyntaxKind.WhileStatement;
                case SyntaxKind.DoStatement: return SyntaxKind.DoStatement;
                case SyntaxKind.ForStatement: return SyntaxKind.ForStatement;
                case SyntaxKind.UsingStatement: return SyntaxKind.UsingStatement;
                case SyntaxKind.FixedStatement: return SyntaxKind.FixedStatement;
                case SyntaxKind.CheckedStatement:
                case SyntaxKind.UncheckedStatement: return SyntaxKind.CheckedStatement;
                case SyntaxKind.UnsafeStatement: return SyntaxKind.UnsafeStatement;
                case SyntaxKind.LockStatement: return SyntaxKind.LockStatement;
                case SyntaxKind.IfStatement: return SyntaxKind.IfStatement;
                case SyntaxKind.SwitchStatement: return SyntaxKind.SwitchStatement;
                case SyntaxKind.TryStatement: return SyntaxKind.TryStatement;
                case SyntaxKind.ForEachStatement: return SyntaxKind.ForEachStatement;
                case SyntaxKind.ForEachVariableStatement: return SyntaxKind.ForEachVariableStatement;
                case SyntaxKind.SingleVariableDesignation: return SyntaxKind.SingleVariableDesignation;
                case SyntaxKind.DiscardDesignation: return SyntaxKind.DiscardDesignation;
                case SyntaxKind.ParenthesizedVariableDesignation: return SyntaxKind.ParenthesizedVariableDesignation;
                case SyntaxKind.CasePatternSwitchLabel: return SyntaxKind.CasePatternSwitchLabel;
                case SyntaxKind.CaseSwitchLabel: return SyntaxKind.CaseSwitchLabel;
                case SyntaxKind.DefaultSwitchLabel: return SyntaxKind.DefaultSwitchLabel;
                case SyntaxKind.SingleLineCommentTrivia:
                case SyntaxKind.MultiLineCommentTrivia: return SyntaxKind.MultiLineCommentTrivia;
                default: throw new ArgumentException(nameof(type));
            }
        }

        /// <summary>
        /// Sets the ID for all elements in the AST.
        /// </summary>
        /// <param name="root">AST root.</param>
        public virtual void SetRoslynMLIDs(XElement root)
        {
            int i = 0;
            this.SetRoslynMLIDs(root, ref i);
        }

        /// <summary>
        /// Sets the ID for all elements in the AST, starting from a given id.
        /// </summary>
        /// <param name="root">AST root.</param>
        /// <param name="id">the next available id.</param>
        public virtual void SetRoslynMLIDs(XElement root, ref int id)
        {
            foreach (var item in root.PostOrder(n => n.Elements()))
            {
                item.Add(new XAttribute("RmID", id++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        /// <summary>
        /// Sets the ID for elements used for GumTree's AST.
        /// </summary>
        /// <param name="root">AST root.</param>
        public virtual void SetGumTreefiedIDs(XElement root)
        {
            int i = 0;
            this.SetGumTreefiedIDs(root, ref i);
        }

        /// <summary>
        /// Sets the ID for the elements used for GumTree's AST, starting from a given id.
        /// </summary>
        /// <param name="root">AST root.</param>
        /// <param name="id">the next available id.</param>
        public virtual void SetGumTreefiedIDs(XElement root, ref int id)
        {
            foreach (var item in root.PostOrder(n => n.Elements()).Where(n => !n.Name.LocalName.Contains("_of_") && n.Name.LocalName != "TokenList"))
            {
                item.Add(new XAttribute("GtID", id++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        /// <summary>
        /// Reassigns the ID for the elements used for GumTree's AST, considering that the order of the elements changed and the actual "GtID" are not correct now.  
        /// </summary>
        /// <param name="root">AST root.</param>
        public virtual void ReassignGtIds(XElement root)
        {
            foreach (var e in root.PostOrder(n => n.Elements()))
            {
                var attr = e.Attribute("GtID");
                attr?.Remove();
            }
            this.SetGumTreefiedIDs(root);
        }

        /// <summary>
        /// Removes from the tree those elements that do not satisfy a given filter.
        /// </summary>
        /// <param name="source">tree root.</param>
        /// <param name="selector">predicate to determine what element types remain (true) or not (false).</param>
        public virtual void Prune(XElement source, Func<XElement, bool> selector)
        {
            foreach (var item in source.Elements().ToList())
            {
                if (!selector(item))
                    item.Remove();
                else
                    this.Prune(item, selector);
            }
        }

        /// <summary>
        /// Converts an XML-like AST representation internally expected by GumTree to an equivalent <see cref="ElementTree"/>.
        /// </summary>
        /// <param name="source">XML-like AST representation internally expected by GumTree</param>
        /// <param name="RmIDOrGtID">if true, the loaded id will be the attribute RmID, otherwise it will be the GtID one.</param>
        /// <returns>the equivalent representation according to the <see cref="ElementTree"/> format.</returns>
        public virtual ElementTree AsGumtreefiedElementTree(XElement source, bool RmIDOrGtID = true)
        {
            var eSource = new ElementTree()
            {
                Root = new ElementVersion
                {
                    Id = RmIDOrGtID ? source.Attribute("RmID")?.Value : source.Attribute("GtID")?.Value,
                    GlobalId = !RmIDOrGtID ? source.Attribute("RmID")?.Value : source.Attribute("GtID")?.Value,
                    Label = (source.Attribute("typeLabel")?.Value ?? source.Attribute("kind")?.Value) ?? source.Name.LocalName,
                    Value = source.Attribute("label")?.Value ?? (source.Elements().Count() == 0 ? source.Value : null)
                }
            };

            var eChildren = new List<ElementTree>(source.Elements().Count());
            foreach (var item in source.Elements())
            {
                var eItem = this.AsGumtreefiedElementTree(item, RmIDOrGtID);
                eChildren.Add(eItem);
                eItem.Parent = eSource;
            }

            eSource.Children = eChildren;
            return eSource;
        }

        private void FixListTrivia(XElement list)
        {
            var firstChild = list.Elements().FirstOrDefault(/*c => !c.Name.LocalName.EndsWith("Trivia")*/);
            if (firstChild != null)
            {
                var annotation = firstChild.Annotation(typeof((XElement[], XElement[])));
                if (annotation != null)
                {
                    var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;
                    if (leadingTrivia.Any())
                    {
                        var (lt, tt) = ((XElement[], XElement[]))(list.Annotation(typeof((XElement[], XElement[]))) ?? (new XElement[0], new XElement[0]));
                        list.RemoveAnnotations(typeof((XElement[], XElement[])));
                        list.AddAnnotation((lt.Union(leadingTrivia).ToArray(), tt));

                        firstChild.RemoveAnnotations(typeof((XElement[], XElement[])));
                        firstChild.AddAnnotation((new XElement[0], trailingTrivia));
                    }
                }
            }

            var lastChild = list.Elements().LastOrDefault(/*c => !c.Name.LocalName.EndsWith("Trivia")*/);
            if (lastChild != null)
            {
                var annotation = lastChild.Annotation(typeof((XElement[], XElement[])));
                if (annotation != null)
                {
                    var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;
                    if (trailingTrivia.Any())
                    {
                        var (lt, tt) = ((XElement[], XElement[]))(list.Annotation(typeof((XElement[], XElement[]))) ?? (new XElement[0], new XElement[0]));
                        list.RemoveAnnotations(typeof((XElement[], XElement[])));
                        list.AddAnnotation((lt, tt.Union(trailingTrivia).ToArray()));

                        lastChild.RemoveAnnotations(typeof((XElement[], XElement[])));
                        lastChild.AddAnnotation((leadingTrivia, new XElement[0]));
                    }
                }
            }
        }

        private void FixCommentTrivia(XElement comment)
        {
            int startLine = int.Parse(comment.Attribute("startLine").Value, CultureInfo.InvariantCulture);
            int startColumn = int.Parse(comment.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
            int endLine = int.Parse(comment.Attribute("endLine").Value, CultureInfo.InvariantCulture);
            int endColumn = int.Parse(comment.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

            var context = comment.Ancestors().FirstOrDefault(delegate(XElement a)
            {
                if (a.Name.LocalName == "CompilationUnit")
                    return true;

                if (a.Name.LocalName.EndsWith("List") || a.Name.LocalName.StartsWith("List_of_") ||
                    a.Name.LocalName.EndsWith("SeparatedList") || a.Name.LocalName.StartsWith("SeparatedList_of_") ||
                    a.Name.LocalName.EndsWith("TokenList"))
                    return false;

                int xStartLine = int.Parse(a.Attribute("startLine").Value, CultureInfo.InvariantCulture);
                int xStartColumn = int.Parse(a.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
                int xEndLine = int.Parse(a.Attribute("endLine").Value, CultureInfo.InvariantCulture);
                int xEndColumn = int.Parse(a.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

                return (xStartLine < startLine || (xStartLine == startLine && xStartColumn < startColumn)) &&
                       (endLine < xEndLine || (endLine == xEndLine && endColumn < xEndColumn));
            });

            var rightSibling = context?.DescendantsAndSelf().FirstOrDefault(delegate(XElement a)
            {
                if (a.Name.LocalName.EndsWith("List") || a.Name.LocalName.StartsWith("List_of_") ||
                    a.Name.LocalName.EndsWith("SeparatedList") || a.Name.LocalName.StartsWith("SeparatedList_of_") ||
                    a.Name.LocalName.EndsWith("TokenList") || 
                    a.Attribute("startLine") == null ||
                    a.Attribute("startColumn") == null ||
                    a.Attribute("endLine") == null ||
                    a.Attribute("endColumn") == null)
                    return false;

                int xStartLine = int.Parse(a.Attribute("startLine").Value, CultureInfo.InvariantCulture);
                int xStartColumn = int.Parse(a.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
                int xEndLine = int.Parse(a.Attribute("endLine").Value, CultureInfo.InvariantCulture);
                int xEndColumn = int.Parse(a.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

                return (xStartLine > endLine || (xStartLine == endLine && xStartColumn > endColumn));
            }) /*?? (context.Elements().FirstOrDefault())*/;

            if (rightSibling?.Name.LocalName == "CompilationUnit")
                rightSibling = rightSibling.Elements().FirstOrDefault(e => e.Name.LocalName != "CommentTrivia");

            if (rightSibling != null)
            {
                comment.Remove();
                rightSibling.AddBeforeSelf(comment);
            }
        }
    }
}
