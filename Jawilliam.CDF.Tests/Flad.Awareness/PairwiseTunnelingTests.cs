using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Awareness;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.CSharp.Awareness;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    /// <summary>
    /// Summary description for TopologyTests
    /// </summary>
    [TestClass]
    public class PairwiseTunnelingTests
    {
        [TestMethod]
        public void ParenthesizedExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");
            var modified = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");

            var originalRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(), 
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            original = originalRoot.DescendantNodesAndSelf().OfType<ParenthesizedExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ParenthesizedExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified,
                            modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, 
                            modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void PrefixUnaryExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3");
            var modified = (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<PrefixUnaryExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<PrefixUnaryExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AwaitExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x");
            var modified = (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<AwaitExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AwaitExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AwaitKeyword].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AwaitKeyword].Match.Modified,
                            modified.AwaitKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AwaitKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AwaitKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void PostfixUnaryExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++");
            var modified = (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<PostfixUnaryExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<PostfixUnaryExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            var modified = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<MemberAccessExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<MemberAccessExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConditionalAccessExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r");
            var modified = (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ConditionalAccessExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConditionalAccessExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            var modified = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<MemberBindingExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<MemberBindingExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BinaryExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2");
            var modified = (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AssignmentExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2");
            var modified = (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<AssignmentExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AssignmentExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified,
                            modified.OperatorToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConditionalExpressionServiceProvider_Pairwising_OK()
        {
            var node = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");
            var modified = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ConditionalExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConditionalExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match.Modified,
                            modified.QuestionToken);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified,
                            modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.QuestionToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ThisExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this");
            var modified = (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ThisExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ThisExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Token].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Token].Match.Modified,
                            modified.Token);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Token].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Token].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BaseExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base");
            var modified = (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<BaseExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<BaseExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Token].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Token].Match.Modified,
                            modified.Token);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Token].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Token].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void LiteralExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3");
            var modified = (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<LiteralExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<LiteralExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Token].Match?.GetType(),
                            typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Token].Match.Modified,
                            modified.Token);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Token].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Token].Match.Modified, modified.Token);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void MakeRefExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)");
            var modified = (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<MakeRefExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<MakeRefExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void RefTypeExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)");
            var modified = (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<RefTypeExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<RefTypeExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void RefValueExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)");
            var modified = (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<RefValueExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<RefValueExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.Comma].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Comma].Match.Modified, modified.Comma);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.Comma].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Comma].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CheckedExpressionServiceProvider_Pairwising_OK()
        {
            var node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");
            var modified = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<CheckedExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<CheckedExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DefaultExpressionServiceProvider_Pairwising_OK()
        {
            var node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)");
            var modified = (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<DefaultExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<DefaultExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void TypeOfExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)");
            var modified = (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<TypeOfExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeOfExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void SizeOfExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)");
            var modified = (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<SizeOfExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<SizeOfExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CastExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x");
            var modified = (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<CastExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<CastExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AnonymousMethodExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }");
            var modified = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<AnonymousMethodExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AnonymousMethodExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match.Modified, modified.AsyncKeyword);
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match.Modified, modified.DelegateKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AsyncKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.DelegateKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4");
            var modified = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<SimpleLambdaExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<SimpleLambdaExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match.Modified, modified.AsyncKeyword);
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match.Modified, modified.ArrowToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AsyncKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ArrowToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4");
            var modified = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ParenthesizedLambdaExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ParenthesizedLambdaExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match.Modified, modified.AsyncKeyword);
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match.Modified, modified.ArrowToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsyncKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AsyncKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ArrowToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InitializerExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer;
            var modified = ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InitializerExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InitializerExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ObjectCreationExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }");
            var modified = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ObjectCreationExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ObjectCreationExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match.Modified, modified.NewKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.NewKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AnonymousObjectCreationExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }");
            var modified = (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<AnonymousObjectCreationExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AnonymousObjectCreationExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match.Modified, modified.NewKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.NewKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ArrayCreationExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}");
            var modified = (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ArrayCreationExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArrayCreationExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match.Modified, modified.NewKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.NewKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ImplicitArrayCreationExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}");
            var modified = (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ImplicitArrayCreationExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ImplicitArrayCreationExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match.Modified, modified.NewKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match.Modified, modified.OpenBracketToken);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match.Modified, modified.CloseBracketToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.NewKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void StackAllocArrayCreationExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]");
            var modified = (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<StackAllocArrayCreationExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<StackAllocArrayCreationExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.StackAllocKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.StackAllocKeyword].Match.Modified, modified.StackAllocKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.StackAllocKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.StackAllocKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterpolatedStringExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"");
            var modified = (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"");

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(original))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement(modified))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InterpolatedStringExpressionSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterpolatedStringExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.StringStartToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.StringStartToken].Match.Modified, modified.StringStartToken);
            Assert.AreEqual(originals.Annotations[original.StringEndToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.StringEndToken].Match.Modified, modified.StringEndToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.StringStartToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.StringStartToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.StringEndToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.StringEndToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterpolatedStringTextServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0];
            var modified = (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0];

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)original.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)modified.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InterpolatedStringTextSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterpolatedStringTextSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.TextToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.TextToken].Match.Modified, modified.TextToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.TextToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.TextToken].Match.Modified, modified.TextToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterpolationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1];
            var modified = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1];

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)original.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)modified.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InterpolationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterpolationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterpolationAlignmentClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause;
            var modified = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InterpolationAlignmentClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterpolationAlignmentClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.CommaToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CommaToken].Match.Modified, modified.CommaToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.CommaToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CommaToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterpolationFormatClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause;
            var modified = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InterpolatedStringExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<InterpolationFormatClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterpolationFormatClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            Assert.AreEqual(originals.Annotations[original.FormatStringToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FormatStringToken].Match.Modified, modified.FormatStringToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.FormatStringToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FormatStringToken].Match.Modified, modified.FormatStringToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ArgumentListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList;
            var modified = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)original.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)modified.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ArgumentListSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArgumentListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BracketedArgumentListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList;
            var modified = ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((ElementAccessExpressionSyntax)original.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((ElementAccessExpressionSyntax)modified.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<BracketedArgumentListSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<BracketedArgumentListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match.Modified, modified.OpenBracketToken);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match.Modified, modified.CloseBracketToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ArgumentServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0];
            var modified = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0];

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.IsTrue(original.RefKindKeyword != null && !originals.Annotations.ContainsKey(original.RefKindKeyword));
            Assert.IsTrue(modified.RefKindKeyword != null && !modifieds.Annotations.ContainsKey(modified.RefKindKeyword));
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.IsTrue(original.RefKindKeyword != null && !originals.Annotations.ContainsKey(original.RefKindKeyword));
            Assert.IsTrue(modified.RefKindKeyword != null && !modifieds.Annotations.ContainsKey(modified.RefKindKeyword));
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            original = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0];
            modified = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0];

            originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match.Modified, modified.RefKindKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.RefKindKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            original = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0];
            modified = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0];

            originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArgumentSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match.Modified, modified.RefKindKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.RefKindKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.RefKindKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void NameColonServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon;
            var modified = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)original.Parent.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((InvocationExpressionSyntax)modified.Parent.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<NameColonSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<NameColonSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void NameEqualsServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals;
            var modified = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((AnonymousObjectCreationExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((AnonymousObjectCreationExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<NameEqualsSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<NameEqualsSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match.Modified, modified.EqualsToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EqualsToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void FromClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause;
            var modified = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<FromClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<FromClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FromKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FromKeyword].Match.Modified, modified.FromKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match.Modified, modified.InKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FromKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.FromKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.InKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void LetClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]);
            var modified = ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<LetClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<LetClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LetKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.LetKeyword].Match.Modified, modified.LetKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match.Modified, modified.EqualsToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LetKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.LetKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EqualsToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void JoinClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]);
            var modified = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<JoinClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<JoinClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.JoinKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.JoinKeyword].Match.Modified, modified.JoinKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match.Modified, modified.InKeyword);
            Assert.AreEqual(originals.Annotations[original.OnKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OnKeyword].Match.Modified, modified.OnKeyword);
            Assert.AreEqual(originals.Annotations[original.EqualsKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EqualsKeyword].Match.Modified, modified.EqualsKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.JoinKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.JoinKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.InKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert); ;
            Assert.AreEqual(originals.Annotations[original.OnKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OnKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert); ;
            Assert.AreEqual(originals.Annotations[original.EqualsKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EqualsKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into;
            var modified = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<JoinIntoClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<JoinIntoClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match.Modified, modified.IntoKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.IntoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void WhereClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]);
            var modified = ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<WhereClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<WhereClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match.Modified, modified.WhereKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.WhereKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void OrderByClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]);
            var modified = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<OrderByClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<OrderByClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OrderByKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OrderByKeyword].Match.Modified, modified.OrderByKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OrderByKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OrderByKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void OrderingServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0];
            var modified = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0];

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<OrderingSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<OrderingSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AscendingOrDescendingKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AscendingOrDescendingKeyword].Match.Modified, modified.AscendingOrDescendingKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AscendingOrDescendingKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AscendingOrDescendingKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void SelectClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup);
            var modified = ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<SelectClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<SelectClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SelectKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SelectKeyword].Match.Modified, modified.SelectKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SelectKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SelectKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void GroupClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup);
            var modified = ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup);

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<GroupClauseSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<GroupClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GroupKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GroupKeyword].Match.Modified, modified.GroupKeyword);
            Assert.AreEqual(originals.Annotations[original.ByKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ByKeyword].Match.Modified, modified.ByKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GroupKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GroupKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ByKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ByKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var original = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation;
            var modified = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation;

            var originalRoot = SyntaxFactory.CompilationUnit(
               SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
               SyntaxFactory.List<UsingDirectiveSyntax>(),
               SyntaxFactory.List<AttributeListSyntax>(),
               SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)original.Parent.Parent))
               }),
               SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
            var modifiedRoot = SyntaxFactory.CompilationUnit(
                SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                SyntaxFactory.List<UsingDirectiveSyntax>(),
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    SyntaxFactory.GlobalStatement(
                        SyntaxFactory.ExpressionStatement((QueryExpressionSyntax)modified.Parent.Parent))
                }),
                SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            original = originalRoot.DescendantNodesAndSelf().OfType<QueryContinuationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<QueryContinuationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match.Modified, modified.IntoKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IntoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.IntoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void PredefinedTypeServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public int A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public int A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<PredefinedTypeSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<PredefinedTypeSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void PointerTypeServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public int* A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public int* A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<PointerTypeSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<PointerTypeSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsteriskToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.AsteriskToken].Match.Modified, modified.AsteriskToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.AsteriskToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.AsteriskToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void NullableTypeServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public int? A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public int? A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<NullableTypeSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<NullableTypeSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match.Modified, modified.QuestionToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.QuestionToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.QuestionToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void OmittedTypeArgumentServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public T<> A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public T<> A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<OmittedTypeArgumentSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<OmittedTypeArgumentSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OmittedTypeArgumentToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OmittedTypeArgumentToken].Match.Modified, modified.OmittedTypeArgumentToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OmittedTypeArgumentToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OmittedTypeArgumentToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void QualifiedNameServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public A.B A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public A.B A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<QualifiedNameSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<QualifiedNameSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DotToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.DotToken].Match.Modified, modified.DotToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DotToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.DotToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public global::B A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public global::B A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<AliasQualifiedNameSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<AliasQualifiedNameSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonColonToken].Match.Modified, modified.ColonColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void GenericNameServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B<> A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B<> A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<GenericNameSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<GenericNameSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void TypeArgumentListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B<> A { get; } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B<> A { get; } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<TypeArgumentListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeArgumentListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match.Modified, modified.LessThanToken);
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match.Modified, modified.GreaterThanToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.LessThanToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GreaterThanToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ArrayRankSpecifierServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B A => new int[1,2] ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B A => new int[1,2] ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ArrayRankSpecifierSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArrayRankSpecifierSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match.Modified, modified.OpenBracketToken);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match.Modified, modified.CloseBracketToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void OmittedArraySizeExpressionServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B A => new int[]{5} ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B A => new int[]{5} ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<OmittedArraySizeExpressionSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<OmittedArraySizeExpressionSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OmittedArraySizeExpressionToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OmittedArraySizeExpressionToken].Match.Modified, modified.OmittedArraySizeExpressionToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OmittedArraySizeExpressionToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OmittedArraySizeExpressionToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BlockServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public B A { get{ x = 5;x += 3; } } ");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public B A { get{ x = 5;x += 3; } } ");

            var original = originalRoot.DescendantNodesAndSelf().OfType<BlockSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<BlockSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_Pairwising_OK()
        {
            var node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];

            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { const int a; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { const int a; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<LocalDeclarationStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<LocalDeclarationStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ExpressionStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { 3; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { 3; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ExpressionStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ExpressionStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EmptyStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { ; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { ; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EmptyStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EmptyStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { l: 3; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { l: 3; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<LabeledStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<LabeledStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void GotoStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto l; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto l; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match.Modified, modified.GotoKeyword);
            Assert.IsTrue(original.CaseOrDefaultKeyword != null && !originals.Annotations.ContainsKey(original.CaseOrDefaultKeyword));
            Assert.IsTrue(modified.CaseOrDefaultKeyword != null && !modifieds.Annotations.ContainsKey(modified.CaseOrDefaultKeyword));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GotoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.IsTrue(original.CaseOrDefaultKeyword != null && !originals.Annotations.ContainsKey(original.CaseOrDefaultKeyword));
            Assert.IsTrue(modified.CaseOrDefaultKeyword != null && !modifieds.Annotations.ContainsKey(modified.CaseOrDefaultKeyword));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto case l; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto case l; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match.Modified, modified.GotoKeyword);
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match.Modified, modified.CaseOrDefaultKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GotoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CaseOrDefaultKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto default; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { goto default; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<GotoStatementSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match.Modified, modified.GotoKeyword);
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match.Modified, modified.CaseOrDefaultKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.GotoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GotoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CaseOrDefaultKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CaseOrDefaultKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BreakStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { break; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { break; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<BreakStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<BreakStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.BreakKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.BreakKeyword].Match.Modified, modified.BreakKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.BreakKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.BreakKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ContinueStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("void a() { continue; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("void a() { continue; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ContinueStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ContinueStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ContinueKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ContinueKeyword].Match.Modified, modified.ContinueKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ContinueKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ContinueKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ReturnStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { return 5; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { return 5; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ReturnStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ReturnStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ReturnKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ReturnKeyword].Match.Modified, modified.ReturnKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ReturnKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ReturnKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ThrowStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { throw 5; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { throw 5; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ThrowStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ThrowStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ThrowKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ThrowKeyword].Match.Modified, modified.ThrowKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ThrowKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ThrowKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void YieldStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { yield return 5; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { yield return 5; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<YieldStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<YieldStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match.Modified, modified.YieldKeyword);
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match.Modified, modified.ReturnOrBreakKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.YieldKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ReturnOrBreakKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { yield break; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { yield break; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<YieldStatementSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<YieldStatementSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match.Modified, modified.YieldKeyword);
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match.Modified, modified.ReturnOrBreakKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.YieldKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.YieldKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ReturnOrBreakKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ReturnOrBreakKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void WhileStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { while (x < 0) x = 5; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { while (x < 0) x = 5; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<WhileStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<WhileStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match.Modified, modified.WhileKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.WhileKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DoStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { do x = 5; while (x < 0); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { do x = 5; while (x < 0); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<DoStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<DoStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DoKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.DoKeyword].Match.Modified, modified.DoKeyword);
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match.Modified, modified.WhileKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DoKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.DoKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.WhileKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.WhileKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ForStatementServiceProvider_Pairwising_OK()
        {
            var node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);");
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { for(int a = 0, b = 4; a < 0; a++, --b); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { for(int a = 0, b = 4; a < 0; a++, --b); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ForStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ForStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ForKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ForKeyword].Match.Modified, modified.ForKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.FirstSemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FirstSemicolonToken].Match.Modified, modified.FirstSemicolonToken);
            Assert.AreEqual(originals.Annotations[original.SecondSemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SecondSemicolonToken].Match.Modified, modified.SecondSemicolonToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ForKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ForKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.FirstSemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.FirstSemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SecondSemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SecondSemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { foreach(int a in ac); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { foreach(int a in ac); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ForEachStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ForEachStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ForEachKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ForEachKeyword].Match.Modified, modified.ForEachKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match.Modified, modified.InKeyword);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ForEachKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ForEachKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.InKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.InKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void UsingStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { using(int a, b = 4); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { using(int a, b = 4); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<UsingStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<UsingStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.UsingKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.UsingKeyword].Match.Modified, modified.UsingKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.UsingKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.UsingKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void FixedStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { fixed(int a, b = 4); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { fixed(int a, b = 4); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<FixedStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<FixedStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FixedKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FixedKeyword].Match.Modified, modified.FixedKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FixedKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.FixedKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CheckedStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { checked { x = 5;} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { checked { x = 5;} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<CheckedStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<CheckedStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { unchecked { x = 5;} }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { unchecked { x = 5;} }");

            original = originalRoot.DescendantNodesAndSelf().OfType<CheckedStatementSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<CheckedStatementSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

       [TestMethod]
        public void UnsafeStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { unsafe { x = 5;} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { unsafe { x = 5;} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<UnsafeStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<UnsafeStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.UnsafeKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.UnsafeKeyword].Match.Modified, modified.UnsafeKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.UnsafeKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.UnsafeKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void LockStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { lock(b = 4); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { lock(b = 4); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<LockStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<LockStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LockKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.LockKeyword].Match.Modified, modified.LockKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LockKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.LockKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void IfStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { if(b == 4); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { if(b == 4); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<IfStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<IfStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IfKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.IfKeyword].Match.Modified, modified.IfKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.IfKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.IfKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void SwitchStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case default; } }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case default; } }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<SwitchStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<SwitchStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SwitchKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SwitchKeyword].Match.Modified, modified.SwitchKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SwitchKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SwitchKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void TryStatementServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<TryStatementSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<TryStatementSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.TryKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.TryKeyword].Match.Modified, modified.TryKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.TryKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.TryKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[0];
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("fixed(int a); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("fixed(int a); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<VariableDeclaratorSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<VariableDeclaratorSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EqualsValueClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { fixed(int a = 4); }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { fixed(int a = 4); }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EqualsValueClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EqualsValueClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match.Modified, modified.EqualsToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EqualsToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EqualsToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ElseClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { if(b == 4); else; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { if(b == 4); else; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ElseClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ElseClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ElseKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ElseKeyword].Match.Modified, modified.ElseKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ElseKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ElseKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CaseSwitchLabelServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case 4: return 4; default: return 10; } }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case 4: return 4; default: return 10; } }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<CaseSwitchLabelSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<CaseSwitchLabelSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DefaultSwitchLabelServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case 4: return 4; default: return 10; } }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { switch(b){ case 4: return 4; default: return 10; } }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<DefaultSwitchLabelSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<DefaultSwitchLabelSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CatchClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<CatchClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<CatchClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.CatchKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CatchKeyword].Match.Modified, modified.CatchKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.CatchKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CatchKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<CatchDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<CatchDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void CatchFilterClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<CatchFilterClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<CatchFilterClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhenKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.WhenKeyword].Match.Modified, modified.WhenKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhenKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.WhenKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void FinallyClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} finally {a1 = \"Catch a1\";} }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int a() { try{a + 5} finally {a1 = \"Catch a1\";} }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<FinallyClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<FinallyClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FinallyKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.FinallyKeyword].Match.Modified, modified.FinallyKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.FinallyKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.FinallyKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;");

            var original = originalRoot.DescendantNodesAndSelf().OfType<DelegateDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<DelegateDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match.Modified, modified.DelegateKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DelegateKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.DelegateKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EnumDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EnumDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EnumKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EnumKeyword].Match.Modified, modified.EnumKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EnumKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EnumKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<StructDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<StructDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<InterfaceDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<InterfaceDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1];
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EnumMemberDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EnumMemberDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void TypeParameterListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<TypeParameterListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeParameterListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match.Modified, modified.LessThanToken);
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match.Modified, modified.GreaterThanToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.LessThanToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.LessThanToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.GreaterThanToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.GreaterThanToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }
        //Assert.IsTrue(original.RefKindKeyword != null && !originals.Annotations.ContainsKey(original.RefKindKeyword));
        
        [TestMethod]
        public void TypeParameterServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.IsTrue(original.VarianceKeyword != null && !originals.Annotations.ContainsKey(original.VarianceKeyword));
            Assert.IsTrue(modified.VarianceKeyword != null && !originals.Annotations.ContainsKey(modified.VarianceKeyword));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.IsTrue(original.VarianceKeyword != null && !originals.Annotations.ContainsKey(original.VarianceKeyword));
            Assert.IsTrue(modified.VarianceKeyword != null && !originals.Annotations.ContainsKey(modified.VarianceKeyword));
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}");

            original = originalRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match.Modified, modified.VarianceKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.VarianceKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] out B, in C> {}");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<[Serializable] out B, in C> {}");

            original = originalRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeParameterSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match.Modified, modified.VarianceKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.VarianceKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.VarianceKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<TypeParameterConstraintClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<TypeParameterConstraintClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match.Modified, modified.WhereKeyword);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.WhereKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.WhereKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConstructorConstraintServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ConstructorConstraintSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConstructorConstraintSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match.Modified, modified.NewKeyword);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.NewKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.NewKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ClassOrStructConstraintServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ClassOrStructConstraintSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ClassOrStructConstraintSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match.Modified, modified.ClassOrStructKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ClassOrStructKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            originalRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : struct {};");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : struct {};");

            original = originalRoot.DescendantNodesAndSelf().OfType<ClassOrStructConstraintSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<ClassOrStructConstraintSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match.Modified, modified.ClassOrStructKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ClassOrStructKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ClassOrStructKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BaseListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};");

            var original = originalRoot.DescendantNodesAndSelf().OfType<BaseListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<BaseListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<FieldDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<FieldDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EventFieldDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EventFieldDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match.Modified, modified.EventKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EventKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_Pairwising_OK()
        {
            var node = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ExplicitInterfaceSpecifierSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ExplicitInterfaceSpecifierSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DotToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.DotToken].Match.Modified, modified.DotToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.DotToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.DotToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };");

            var original = originalRoot.DescendantNodesAndSelf().OfType<MethodDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<MethodDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };");

            var original = originalRoot.DescendantNodesAndSelf().OfType<OperatorDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<OperatorDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match.Modified, modified.OperatorKeyword);
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified, modified.OperatorToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.OperatorToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorToken].Match.Modified, modified.OperatorToken);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ConversionOperatorDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConversionOperatorDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ImplicitOrExplicitKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ImplicitOrExplicitKeyword].Match.Modified, modified.ImplicitOrExplicitKeyword);
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match.Modified, modified.OperatorKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ImplicitOrExplicitKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ImplicitOrExplicitKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.OperatorKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OperatorKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ConstructorDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConstructorDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ConstructorInitializerServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ConstructorInitializerSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ConstructorInitializerSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match.Modified, modified.ColonToken);
            Assert.AreEqual(originals.Annotations[original.ThisOrBaseKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ThisOrBaseKeyword].Match.Modified, modified.ThisOrBaseKeyword);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ColonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ColonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.ThisOrBaseKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ThisOrBaseKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<DestructorDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<DestructorDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.TildeToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.TildeToken].Match.Modified, modified.TildeToken);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.TildeToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.TildeToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;");

            var original = originalRoot.DescendantNodesAndSelf().OfType<PropertyDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<PropertyDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ArrowExpressionClauseServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ArrowExpressionClauseSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ArrowExpressionClauseSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match.Modified, modified.ArrowToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ArrowToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ArrowToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<EventDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<EventDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match.Modified, modified.EventKeyword);
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EventKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EventKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;");

            var original = originalRoot.DescendantNodesAndSelf().OfType<IndexerDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<IndexerDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ThisKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.ThisKeyword].Match.Modified, modified.ThisKeyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.ThisKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.ThisKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AccessorListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;");

            var original = originalRoot.DescendantNodesAndSelf().OfType<AccessorListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match.Modified, modified.OpenBraceToken);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match.Modified, modified.CloseBraceToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBraceToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBraceToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void AccessorDeclarationServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }");

            var original = originalRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originalRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{}; get; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{}; get; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{}; remove; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{}; remove; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originalRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{}; add; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{}; add; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });
            
            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.Keyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();

            originalRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{}; get; }");
            modifiedRoot = SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{}; get; }");

            original = originalRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];
            modified = modifiedRoot.DescendantNodesAndSelf().OfType<AccessorDeclarationSyntax>().ToList()[0];

            args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            flad.MatchingSet().PartnersEvent += ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match.Modified, modified.SemicolonToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Keyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Keyword].Match.Modified, modified.Keyword);
            Assert.AreEqual(originals.Annotations[original.SemicolonToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.SemicolonToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ParameterListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ParameterListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ParameterListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match.Modified, modified.OpenParenToken);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match.Modified, modified.CloseParenToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseParenToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseParenToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void BracketedParameterListServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<BracketedParameterListSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<BracketedParameterListSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match.Modified, modified.OpenBracketToken);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match.Modified, modified.CloseBracketToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.OpenBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.OpenBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.CloseBracketToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.CloseBracketToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void ParameterServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}");

            var original = originalRoot.DescendantNodesAndSelf().OfType<ParameterSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf().OfType<ParameterSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreNotEqual(originals.Annotations[original.Identifier].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.Identifier].Match.Modified, modified.Identifier);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void DocumentationCommentTriviaServiceProvider_Pairwising_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit(
            "/// <summary>" + Environment.NewLine +
            "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + Environment.NewLine +
            "/// </summary>" + Environment.NewLine +
            "/// <param name=\"node\">node of interest.</param>" + Environment.NewLine +
            "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>" + Environment.NewLine +
            "public virtual void F();");

            var modifiedRoot = SyntaxFactory.ParseCompilationUnit(
            "/// <summary>" + Environment.NewLine +
            "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + Environment.NewLine +
            "/// </summary>" + Environment.NewLine +
            "/// <param name=\"node\">node of interest.</param>" + Environment.NewLine +
            "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>" + Environment.NewLine +
            "public virtual void F();");

            var original = originalRoot.DescendantNodesAndSelf(descendIntoTrivia: true).OfType<DocumentationCommentTriviaSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf(descendIntoTrivia: true).OfType<DocumentationCommentTriviaSyntax>().ToList()[0];
            
            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EndOfComment].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EndOfComment].Match.Modified, modified.EndOfComment);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.EndOfComment].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EndOfComment].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void EndIfDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndIfDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);

            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var originals = flad.Originals<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            originals.KeepAnnotations = true;
            var modifieds = flad.Modifieds<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>();
            modifieds.KeepAnnotations = true;

            var originalRoot = SyntaxFactory.ParseCompilationUnit("namespace A {}");
            var modifiedRoot = SyntaxFactory.ParseCompilationUnit("namespace A {}");

            var original = originalRoot.DescendantNodesAndSelf(descendIntoTrivia: true).OfType<EndIfDirectiveTriviaSyntax>().ToList()[0];
            var modified = modifiedRoot.DescendantNodesAndSelf(descendIntoTrivia: true).OfType<EndIfDirectiveTriviaSyntax>().ToList()[0];

            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNodeOrToken?>(delegate (out SyntaxNodeOrToken? o, out SyntaxNodeOrToken? m)
            {
                o = originalRoot;
                m = modifiedRoot;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.HashToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.HashToken].Match.Modified, modified.HashToken);
            Assert.AreEqual(originals.Annotations[original.EndIfKeyword].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EndIfKeyword].Match.Modified, modified.EndIfKeyword);
            Assert.AreEqual(originals.Annotations[original.EndOfDirectiveToken].Match?.GetType(), typeof(PairwiseMatchInfo<SyntaxNodeOrToken?>.Tunneling));
            Assert.AreEqual(originals.Annotations[original.EndOfDirectiveToken].Match.Modified, modified.EndOfDirectiveToken);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
            flad.MatchingSet().PartnersEvent -= ((LanguageServiceProvider)flad.LanguageProvider()).PartnersEventHandler;

            originals.KeepAnnotations = true;
            modifieds.KeepAnnotations = true;
            changes = flad.GetChanges(args).Translate();
            Assert.AreEqual(originals.Annotations[original.HashToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.HashToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.EndIfKeyword].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EndIfKeyword].Match.Criterion, (int)MatchInfoCriterions.Insert);
            Assert.AreEqual(originals.Annotations[original.EndOfDirectiveToken].Match, null);
            Assert.AreEqual(modifieds.Annotations[modified.EndOfDirectiveToken].Match.Criterion, (int)MatchInfoCriterions.Insert);
            originals.KeepAnnotations = false;
            originals.EndDetection();
            modifieds.KeepAnnotations = false;
            modifieds.EndDetection();
        }

        [TestMethod]
        public void RegionDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void EndRegionDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndRegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ErrorDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ErrorDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void WarningDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.WarningDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void LineDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Line).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void PragmaWarningDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var separatedSyntaxList = SyntaxFactory.SeparatedList(new ExpressionSyntax[] { SyntaxFactory.IdentifierName("warning-list"), SyntaxFactory.IdentifierName("CS3021") });
            var node = SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), separatedSyntaxList, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.DisableOrRestoreKeyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ErrorCodes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.ErrorCodes[1]).Name.LocalName);
        }

        [TestMethod]
        public void PragmaChecksumDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Guid).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Bytes).Name.LocalName);
        }

        [TestMethod]
        public void ReferenceDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void LoadDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void ShebangDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ShebangDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ElseDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElseDirectiveTrivia(true, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void IfDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void ElifDirectiveTriviaServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void TypeCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"int\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<TypeCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void QualifiedCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N.A\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<QualifiedCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Container).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Member).Name.LocalName);
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);
            
            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"explicit operator N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void CrefParameterListServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void CrefBracketedParameterListServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void CrefParameterServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.StartTag).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Content[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.EndTag).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void XmlNameServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Prefix).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.LocalName).Name.LocalName);

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.LocalName).Name.LocalName);
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Prefix).Name.LocalName);
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Cref).Name.LocalName);
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void XmlTextServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCDataSectionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCommentServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void CompilationUnitServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("using static d; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute];");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Alias).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Alias).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{using static d; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
        }

        [TestMethod]
        public void AttributeListServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Target).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);

            node = ((FieldDeclarationSyntax)((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a {[XAttribute(\"X\"), YAttribute(Y: 3)]int f;}").Members[0]).Members[0]).AttributeLists[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);
        }

        [TestMethod]
        public void AttributeTargetSpecifierServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void AttributeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute]").AttributeLists[0].Attributes[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void AttributeArgumentListServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute()]").AttributeLists[0].Attributes[0].ArgumentList;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void AttributeArgumentServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameColon).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y = 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameEquals).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void WhenClauseServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void TupleTypeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Elements[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Elements[1]).Name.LocalName);
        }

        [TestMethod]
        public void TupleExpressionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);
        }

        [TestMethod]
        public void TupleElementServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var type = SyntaxFactory.ParseTypeName("(string, int)");
            var node = SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);

            node = SyntaxFactory.TupleElement(type);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void ThrowExpressionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void DiscardDesignationServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ParenthesizedVariableDesignationServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[]
                {
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                     SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken))
                }),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Variables[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Variables[1]).Name.LocalName);

            node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[0]),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void RefExpressionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void CasePatternSwitchLabelServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.WhenClause).Name.LocalName);

            node = SyntaxFactory.CasePatternSwitchLabel(node.Keyword, node.Pattern, null, node.ColonToken);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
        }

        [TestMethod]
        public void IsPatternExpressionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
        }

        [TestMethod]
        public void DeclarationExpressionServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Designation).Name.LocalName);
        }

        [TestMethod]
        public void ForEachVariableStatementServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Variable).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void DeclarationPatternServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Designation).Name.LocalName);
        }

        [TestMethod]
        public void ConstantPatternServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
                                              
            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
        }



        [TestMethod]
        public void RefTypeServiceProvider_Pairwising_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"));
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void AllElementTypeSuitableFor_NameEqualityMatch_IsTested()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var cases = (from t in concreteTypes
                         from p in t.Properties?.Property
                         //where p.Rules?.Topology?.relevant ?? false
                         select new { Type = t, Property = p }).ToList();

            var testedCases = (from m in this.GetType().GetMethods()
                               let nameParts = m.Name.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                               where nameParts.Length == 3 && nameParts[1] == "Pairwising" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Select(info => info.Type.name).Distinct().Except(testedCases).ToArray();
            var b = testedCases.Except(cases.Select(info => info.Type.name).Distinct()).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }
    }
}
