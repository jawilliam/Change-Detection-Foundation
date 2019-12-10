using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.CSharp.RoslynML;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    partial class RoslynMLDeltaExpanderTests
    {
        partial void ForStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void ForStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            ForStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodeRevisionPairs);
            foreach (((ForStatementSyntax Original, ForStatementSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((ForStatementSyntax, ForStatementSyntax), Action<RoslynML, XElement>)>
                    { (n, (r, n1) => { }), (n, (r, n1) => r.Defoliate(n1)) }))
            {
                id = 0;
                oExpectedLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Kind());
                mExpectedLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Kind());

                var oElement = converter.Visit(nodeRevisionPair.Original);
                converter.SetGumTreefiedIDs(oElement, ref id);
                converter.SetRoslynMLIDs(oElement, ref id);
                converter.Prune(oElement, selector.PruneSelector);
                defoliate(converter, oElement);

                var mId = id;

                var mElement = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mElement, ref id);
                converter.SetRoslynMLIDs(mElement, ref id);
                converter.Prune(mElement, selector.PruneSelector);
                defoliate(converter, mElement);

                id = 0;
                var oFullElement = converter.Visit(nodeRevisionPair.Original);
                converter.SetGumTreefiedIDs(oFullElement, ref id);
                converter.SetRoslynMLIDs(oFullElement, ref id);

                var mFullElement = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement, ref id);
                converter.SetRoslynMLIDs(mFullElement, ref id);

                DeltaExpander expander = new DeltaExpander();

                // Match
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[]
                    {
                        new XElement("Match",
                            new XAttribute("oId", oElement.GtID()),
                            new XAttribute("oLb", oElement.Label()),
                            new XAttribute("mId", mElement.GtID()),
                            new XAttribute("mLb", mElement.Label()))
                    },
                Actions: new XElement[0]));

                var totalProperties = 5;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oForKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.ForKeyword.Kind());
                var mForKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.ForKeyword.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oForKeywordLabel)
                    .Attribute("mLb").Value == mForKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oForKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mForKeywordLabel).GtID());

                var oOpenParenTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.OpenParenToken.Kind());
                var mOpenParenTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.OpenParenToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oOpenParenTokenLabel)
                    .Attribute("mLb").Value == mOpenParenTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oOpenParenTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mOpenParenTokenLabel).GtID());

                var oFirstSemicolonTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.FirstSemicolonToken.Kind());
                var mFirstSemicolonTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.FirstSemicolonToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oFirstSemicolonTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mFirstSemicolonTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oFirstSemicolonTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mFirstSemicolonTokenLabel).ToList()[0].GtID());

                var oSecondSemicolonTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.SecondSemicolonToken.Kind());
                var mSecondSemicolonTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.SecondSemicolonToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oSecondSemicolonTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mSecondSemicolonTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oSecondSemicolonTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mSecondSemicolonTokenLabel).ToList()[1].GtID());

                var oCloseParenTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.CloseParenToken.Kind());
                var mCloseParenTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.CloseParenToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oCloseParenTokenLabel)
                    .Attribute("mLb").Value == mCloseParenTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oCloseParenTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mCloseParenTokenLabel).GtID());

                // Insert
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: new XElement[]
                     {
                         new XElement("Insert",
                             new XAttribute("eId", mElement.GtID()),
                             new XAttribute("eLb", mElement.Label()),
                             new XAttribute("eVl", "##"),
                             new XAttribute("pId", mElement.GtID()),
                             new XAttribute("pLb", mElement.Label()),
                             new XAttribute("pos", "-1"))
                     }));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
                    .Attribute("pId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mForKeywordLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mForKeywordLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mOpenParenTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mOpenParenTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mFirstSemicolonTokenLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mFirstSemicolonTokenLabel).ToList()[0].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSecondSemicolonTokenLabel).ToList()[1]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mSecondSemicolonTokenLabel).ToList()[1].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mCloseParenTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mCloseParenTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                // Delete
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: new XElement[]
                     {
                         new XElement("Delete",
                             new XAttribute("eId", oElement.GtID()),
                             new XAttribute("eLb", oElement.Label()),
                             new XAttribute("eVl", "##"))
                     }));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedOriginalProperties);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
                    .Attribute("eLb").Value == oElement.Label());

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oForKeywordLabel).GtID())
                    .Attribute("eLb").Value == oForKeywordLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oOpenParenTokenLabel).GtID())
                    .Attribute("eLb").Value == oOpenParenTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oFirstSemicolonTokenLabel).ToList()[0].GtID())
                    .Attribute("eLb").Value == oFirstSemicolonTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oSecondSemicolonTokenLabel).ToList()[1].GtID())
                    .Attribute("eLb").Value == oSecondSemicolonTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oCloseParenTokenLabel).GtID())
                    .Attribute("eLb").Value == oCloseParenTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Any(e => e.Label() == mForKeywordLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mForKeywordLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mOpenParenTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mOpenParenTokenLabel).Value = "v1";

                if (mFullElement1.Elements().Count(e => e.Label() == mFirstSemicolonTokenLabel) > 0)
                    mFullElement1.Elements().Where(e => e.Label() == mFirstSemicolonTokenLabel).ToList()[0].Value = "v2";

                if (mFullElement1.Elements().Count(e => e.Label() == mSecondSemicolonTokenLabel) > 1)
                    mFullElement1.Elements().Where(e => e.Label() == mSecondSemicolonTokenLabel).ToList()[1].Value = "v3";

                if (mFullElement1.Elements().Any(e => e.Label() == mCloseParenTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mCloseParenTokenLabel).Value = "v4";

                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement1 },
                    (Matches: new XElement[]
                    {
                        new XElement("Match",
                            new XAttribute("oId", oElement.GtID()),
                            new XAttribute("oLb", oElement.Label()),
                            new XAttribute("mId", mElement.GtID()),
                            new XAttribute("mLb", mElement.Label()))
                    },
                    Actions: new XElement[0]));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oForKeywordLabel)
                    .Attribute("mLb").Value == mForKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oForKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mForKeywordLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oForKeywordLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oForKeywordLabel).GtID())
                    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oOpenParenTokenLabel)
                    .Attribute("mLb").Value == mOpenParenTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oOpenParenTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mOpenParenTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oOpenParenTokenLabel)
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oOpenParenTokenLabel).GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oFirstSemicolonTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mFirstSemicolonTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oFirstSemicolonTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mFirstSemicolonTokenLabel).ToList()[0].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oFirstSemicolonTokenLabel).ToList()[0]
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oFirstSemicolonTokenLabel).ToList()[0].GtID())
                    .Attribute("val").Value == "v2");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oSecondSemicolonTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mSecondSemicolonTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oSecondSemicolonTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mSecondSemicolonTokenLabel).ToList()[1].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oSecondSemicolonTokenLabel).ToList()[1]
                        .Attribute("val").Value == "v3");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oSecondSemicolonTokenLabel).ToList()[1].GtID())
                    .Attribute("val").Value == "v3");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oCloseParenTokenLabel)
                    .Attribute("mLb").Value == mCloseParenTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oCloseParenTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mCloseParenTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oCloseParenTokenLabel)
                        .Attribute("val").Value == "v4");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oCloseParenTokenLabel).GtID())
                    .Attribute("val").Value == "v4");

                // Update
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                    Actions: new XElement[]
                    {
                        new XElement("Update",
                            new XAttribute("eId", oFullElement.GtID()),
                            new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                            new XAttribute("eVl", mFullElement.GtID()),
                            new XAttribute("val", "t#v"))
                    }));
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oExpectedLabel)
                        .Attribute("val").Value == "t#v");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == oFullElement.GtID())
                    .Attribute("val").Value == "t#v");

                // Move
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: new XElement[]
                     {
                         new XElement("Move",
                             new XAttribute("eId", oElement.GtID()),
                             new XAttribute("eLb", oElement.Label()),
                             new XAttribute("pId", mFullElement.GtID()),
                             new XAttribute("pLb", mFullElement.Label()),
                             new XAttribute("pos", "-1"))
                     }));
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Move" && a.Attribute("eId").Value == oElement.GtID())
                    .Attribute("pId").Value == mFullElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Move" && a.Attribute("eLb").Value == oExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);
            }
        }

        partial void ParenthesizedExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"), (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"))
            };
        }

        partial void PrefixUnaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"), (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"))
            };
        }

        partial void AwaitExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AwaitExpressionSyntax, AwaitExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"), (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"))
            };
        }

        partial void PostfixUnaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"), (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"))
            };
        }

        partial void MemberAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"), (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"))
            };
        }

        partial void ConditionalAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"), (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"))
            };
        }

        partial void MemberBindingExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull,
                 (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull)
            };
        }

        partial void ElementBindingExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull,
                 (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull)
            };
        }

        partial void ImplicitElementAccessServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)> nodeRevisionPairs)
        {
            Func<string, ImplicitElementAccessSyntax> getElementBinding = delegate (string s)
            {
                var objectCreation = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression(s);
                var assigment = (AssignmentExpressionSyntax)objectCreation.Initializer.Expressions[0];
                return (ImplicitElementAccessSyntax)assigment.Left;
            };

            nodeRevisionPairs = new[]
            {
                (getElementBinding("new A { [\"a\"] = { a = 0} }"),
                 getElementBinding("new A { [\"a\"] = { a = 0} }"))
            };
        }

        partial void BinaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BinaryExpressionSyntax, BinaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"),
                 (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"))
            };
        }

        partial void AssignmentExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AssignmentExpressionSyntax, AssignmentExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"),
                 (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"))
            };
        }

        partial void ConditionalExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ConditionalExpressionSyntax, ConditionalExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"),
                 (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"))
            };
        }

        partial void ThisExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ThisExpressionSyntax, ThisExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"),
                 (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"))
            };
        }

        partial void BaseExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BaseExpressionSyntax, BaseExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"),
                 (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"))
            };
        }

        partial void LiteralExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LiteralExpressionSyntax, LiteralExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"),
                 (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"))
            };
        }

        partial void MakeRefExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MakeRefExpressionSyntax, MakeRefExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"),
                 (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"))
            };
        }

        partial void RefTypeExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(RefTypeExpressionSyntax, RefTypeExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"),
                 (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"))
            };
        }

        partial void RefValueExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(RefValueExpressionSyntax, RefValueExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"),
                 (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"))
            };
        }

        partial void CheckedExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CheckedExpressionSyntax, CheckedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)")),
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"))
            };
        }

        partial void DefaultExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(DefaultExpressionSyntax, DefaultExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"),
                 (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"))
            };
        }

        partial void TypeOfExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeOfExpressionSyntax, TypeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"),
                 (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"))
            };
        }

        partial void SizeOfExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SizeOfExpressionSyntax, SizeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"),
                 (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"))
            };
        }

        partial void InvocationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InvocationExpressionSyntax, InvocationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"),
                 (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"))
            };
        }

        partial void ElementAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"),
                 (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"))
            };
        }

        partial void CastExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CastExpressionSyntax, CastExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"),
                 (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"))
            };
        }

        partial void AnonymousMethodExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("delegate { return 4; }"))
            };
        }

        partial void SimpleLambdaExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"))
            };
        }

        partial void ParenthesizedLambdaExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"))
            };
        }

        partial void InitializerExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InitializerExpressionSyntax, InitializerExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer,
                  ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer),
                 (((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer,
                  ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer),
                 (((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer,
                  ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer),
                 (((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer,
                  ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer)
            };
        }

        partial void ObjectCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"))
            };
        }

        partial void AnonymousObjectCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"),
                  (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"))
            };
        }

        partial void ArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"),
                  (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"))
            };
        }

        partial void ImplicitArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"),
                  (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"))
            };
        }

        partial void StackAllocArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"),
                  (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"))
            };
        }

        partial void QueryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(QueryExpressionSyntax, QueryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"),
                  (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"))
            };
        }

        partial void InterpolatedStringExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""),
                  (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""))
            };
        }

        partial void InterpolatedStringTextServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0],
                  (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0])
            };
        }

        partial void InterpolationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationSyntax, InterpolationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1])
            };
        }

        partial void InterpolationAlignmentClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause)
            };
        }

        partial void InterpolationFormatClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause)
            };
        }

        partial void ArgumentListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArgumentListSyntax, ArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList,
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList)
            };
        }

        partial void BracketedArgumentListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BracketedArgumentListSyntax, BracketedArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList,
                  ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList)
            };
        }

        partial void ArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArgumentSyntax, ArgumentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0])
            };
        }

        partial void NameColonServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(NameColonSyntax, NameColonSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon,
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon)
            };
        }

        partial void NameEqualsServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(NameEqualsSyntax, NameEqualsSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals,
                  ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals)
            };
        }

        partial void AnonymousObjectMemberDeclaratorServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0],
                  ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0])
            };
        }

        partial void QueryBodyServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(QueryBodySyntax, QueryBodySyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body)
            };
        }

        partial void FromClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(FromClauseSyntax, FromClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause),
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause)
            };
        }

        partial void LetClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LetClauseSyntax, LetClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]),
                  ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]))
            };
        }

        partial void JoinClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(JoinClauseSyntax, JoinClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]),
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0])),
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0]),
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0])),
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]),
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0])),
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0]),
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]))
            };
        }

        partial void JoinIntoClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(JoinIntoClauseSyntax, JoinIntoClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into,
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into)
            };
        }

        partial void WhereClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(WhereClauseSyntax, WhereClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]),
                  ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]))
            };
        }

        partial void OrderByClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(OrderByClauseSyntax, OrderByClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]),
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]))
            };
        }

        partial void OrderingServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(OrderingSyntax, OrderingSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0],
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0]),
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0],
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0]),
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0],
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y ascending")).Body.Clauses[0]).Orderings[0]),
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y ascending")).Body.Clauses[0]).Orderings[0],
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0])
            };
        }

        partial void SelectClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SelectClauseSyntax, SelectClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup),
                  ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup))
            };
        }

        partial void GroupClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(GroupClauseSyntax, GroupClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup),
                  ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup))
            };
        }

        partial void QueryContinuationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(QueryContinuationSyntax, QueryContinuationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation)
            };
        }

        partial void PredefinedTypeServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PredefinedTypeSyntax, PredefinedTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int"),
                  (PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int"))
            };
        }

        partial void ArrayTypeServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArrayTypeSyntax, ArrayTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]"),
                  (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")),
                 ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]"),
                  (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")),
                 ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]"),
                  (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")),
                 ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]"),
                  (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]"))
            };
        }

        partial void PointerTypeServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PointerTypeSyntax, PointerTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*"),
                  (PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*"))
            };
        }

        partial void NullableTypeServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(NullableTypeSyntax, NullableTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?"),
                  (NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?"))
            };
        }

        partial void OmittedTypeArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0],
                  (OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0])
            };
        }

        partial void QualifiedNameServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(QualifiedNameSyntax, QualifiedNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((QualifiedNameSyntax)SyntaxFactory.ParseName("a.x"),
                  (QualifiedNameSyntax)SyntaxFactory.ParseName("a.x"))
            };
        }

        partial void AliasQualifiedNameServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c"),
                  (AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c"))
            };
        }

        partial void IdentifierNameServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(IdentifierNameSyntax, IdentifierNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((IdentifierNameSyntax)SyntaxFactory.ParseName("c"),
                  (IdentifierNameSyntax)SyntaxFactory.ParseName("c"))
            };
        }

        partial void GenericNameServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(GenericNameSyntax, GenericNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>"),
                  (GenericNameSyntax)SyntaxFactory.ParseName("a<,>"))
            };
        }

        partial void TypeArgumentListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeArgumentListSyntax, TypeArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList,
                  ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList)
            };
        }

        partial void ArrayRankSpecifierServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0],
                  ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0]),
                 (((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0],
                  ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0]),
                 (((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0],
                  ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0]),
                 (((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0],
                  ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0])
            };
        }

        partial void OmittedArraySizeExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0],
                  (OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0])
            };
        }

        partial void BlockServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BlockSyntax, BlockSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }"),
                  (BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }"))
            };
        }

        partial void LocalDeclarationStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0],
                  (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0]),
                 ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0],
                  (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0]),
                 ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0],
                  (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0]),
                 ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0],
                  (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0])
            };
        }

        partial void ExpressionStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ExpressionStatementSyntax, ExpressionStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3"),
                  (ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3"))
            };
        }

        partial void EmptyStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(EmptyStatementSyntax, EmptyStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((EmptyStatementSyntax)SyntaxFactory.ParseStatement(";"),
                  (EmptyStatementSyntax)SyntaxFactory.ParseStatement(";"))
            };
        }

        partial void LabeledStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LabeledStatementSyntax, LabeledStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3"),
                  (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3"))
            };
        }

        partial void GotoStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(GotoStatementSyntax, GotoStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;")),

                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;")),
                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;")),
                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;")),

                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;")),
                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;")),
                 ((GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;"),
                  (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;"))
            };
        }

        partial void BreakStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BreakStatementSyntax, BreakStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((BreakStatementSyntax)SyntaxFactory.ParseStatement("break;"),
                  (BreakStatementSyntax)SyntaxFactory.ParseStatement("break;"))
            };
        }

        partial void ContinueStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ContinueStatementSyntax, ContinueStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;"),
                  (ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;"))
            };
        }

        partial void ReturnStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ReturnStatementSyntax, ReturnStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;"),
                  (ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;"))
            };
        }

        partial void ThrowStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ThrowStatementSyntax, ThrowStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;"),
                  (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;"))
            };
        }

        partial void YieldStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(YieldStatementSyntax, YieldStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;"),
                  (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;")),
                 ((YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;"),
                  (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;"))
            };
        }

        partial void WhileStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(WhileStatementSyntax, WhileStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;"),
                  (WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;"))
            };
        }

        partial void DoStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(DoStatementSyntax, DoStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);"),
                  (DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);"))
            };
        }

        partial void ForStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(a = 0, b = 4; a < 0; a++, --b);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(a = 0, b = 4; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(; a < 0; a++, --b);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0;);")),
                 ((ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0;);"),
                  (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);"))
            };
        }

        partial void ForEachStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ForEachStatementSyntax, ForEachStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);"),
                  (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);"))
            };
        }

        partial void UsingStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(UsingStatementSyntax, UsingStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);"),
                  (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);")),
                 ((UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);"),
                  (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);")),
                 ((UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);"),
                  (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);")),
                 ((UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);"),
                  (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);"))
            };
        }

        partial void FixedStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(FixedStatementSyntax, FixedStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);"),
                  (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);"))
            };
        }

        partial void CheckedStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CheckedStatementSyntax, CheckedStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}"),
                  (CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}"))
            };
        }

        partial void UnsafeStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(UnsafeStatementSyntax, UnsafeStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}"),
                  (UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}"))
            };
        }

        partial void LockStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LockStatementSyntax, LockStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);"),
                  (LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);"))
            };
        }

        partial void IfStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(IfStatementSyntax, IfStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);"),
                  (IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);"))
            };
        }

        partial void SwitchStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SwitchStatementSyntax, SwitchStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }"),
                  (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }")),
                 ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }"),
                  (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }"))
            };
        }

        partial void TryStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TryStatementSyntax, TryStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")),
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}")),
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}")),
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")),

                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}")),
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}")),
                 ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}"),
                  (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")),
            };
        }

        partial void VariableDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(VariableDeclarationSyntax, VariableDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration,
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration)
            };
        }

        partial void VariableDeclaratorServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(VariableDeclaratorSyntax, VariableDeclaratorSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2);")).Declaration.Variables[0],
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2);")).Declaration.Variables[0]),
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a);")).Declaration.Variables[0],
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a);")).Declaration.Variables[0]),
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2);")).Declaration.Variables[0],
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a);")).Declaration.Variables[0]),
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a);")).Declaration.Variables[0],
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2);")).Declaration.Variables[0])
            };
        }

        partial void EqualsValueClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(EqualsValueClauseSyntax, EqualsValueClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer,
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer)
            };
        }

        partial void ElseClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ElseClauseSyntax, ElseClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else,
                  ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else)
            };
        }

        partial void SwitchSectionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SwitchSectionSyntax, SwitchSectionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0],
                  ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0])
            };
        }

        partial void CaseSwitchLabelServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0],
                  (CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0])
            };
        }

        partial void DefaultSwitchLabelServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0],
                  (DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0])
            };
        }

        partial void CatchClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CatchClauseSyntax, CatchClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0]),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0],
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0])
            };
        }

        partial void CatchDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CatchDeclarationSyntax, CatchDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration),
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration)
            };
        }

        partial void CatchFilterClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CatchFilterClauseSyntax, CatchFilterClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter)
            };
        }

        partial void FinallyClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(FinallyClauseSyntax, FinallyClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally)
            };
        }

        partial void IncompleteMemberServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(IncompleteMemberSyntax, IncompleteMemberSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0]),
                 ((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0],
                  (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0])
            };
        }

        partial void GlobalStatementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(GlobalStatementSyntax, GlobalStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++")),
                  Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++")))
            };
        }

        partial void DelegateDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(DelegateDeclarationSyntax, DelegateDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0],
                  (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0])
            };
        }

        partial void EnumDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(EnumDeclarationSyntax, EnumDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0],
                  (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0]),
                 ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0],
                  (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0]),
                 ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0],
                  (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0]),
                 ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0],
                  (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0])
            };
        }

        partial void ClassDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ClassDeclarationSyntax, ClassDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0]),
                 ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0])
            };
        }

        partial void StructDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(StructDeclarationSyntax, StructDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0]),
                 ((StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0])
            };
        }

        partial void InterfaceDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0]),
                 ((InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0],
                  (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0]),
                 ((InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0],
                  (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0])
            };
        }

        partial void EnumMemberDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1],
                  ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1])
            };
        }

        partial void TypeParameterListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeParameterListSyntax, TypeParameterListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList,
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList)
            };
        }

        partial void TypeParameterServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeParameterSyntax, TypeParameterSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0]),
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}").Members[0]).TypeParameterList.Parameters[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}").Members[0]).TypeParameterList.Parameters[0]),
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}").Members[0]).TypeParameterList.Parameters[0]),
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] B, in C> {}").Members[0]).TypeParameterList.Parameters[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0])
            };
        }

        partial void TypeParameterConstraintClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0])
            };
        }
    }
}
