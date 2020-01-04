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
        partial void ForStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void ForStatementServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            ForStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
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

        partial void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((PragmaChecksumDirectiveTriviaSyntax Original, PragmaChecksumDirectiveTriviaSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 7;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oHashTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.HashToken.Kind());
                var mHashTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.HashToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oHashTokenLabel)
                    .Attribute("mLb").Value == mHashTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oHashTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mHashTokenLabel).GtID());

                var oPragmaKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.PragmaKeyword.Kind());
                var mPragmaKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.PragmaKeyword.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oPragmaKeywordLabel)
                    .Attribute("mLb").Value == mPragmaKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oPragmaKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mPragmaKeywordLabel).GtID());

                var oChecksumKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.ChecksumKeyword.Kind());
                var mChecksumKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.ChecksumKeyword.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oChecksumKeywordLabel)
                    .Attribute("mLb").Value == mChecksumKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oChecksumKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mChecksumKeywordLabel).GtID());

                var oFileLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.File.Kind());
                var mFileLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.File.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oFileLabel).ToList()[0]
                    .Attribute("mLb").Value == mFileLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oFileLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mFileLabel).ToList()[0].GtID());

                var oGuidLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Guid.Kind());
                var mGuidLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Guid.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGuidLabel).ToList()[1]
                    .Attribute("mLb").Value == mGuidLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oGuidLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mGuidLabel).ToList()[1].GtID());

                var oBytesLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Bytes.Kind());
                var mBytesLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Bytes.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oBytesLabel).ToList()[2]
                    .Attribute("mLb").Value == mBytesLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oBytesLabel).ToList()[2].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mBytesLabel).ToList()[2].GtID());

                var oEndOfDirectiveTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndOfDirectiveToken.Kind());
                var mEndOfDirectiveTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndOfDirectiveToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEndOfDirectiveTokenLabel)
                    .Attribute("mLb").Value == mEndOfDirectiveTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndOfDirectiveTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndOfDirectiveTokenLabel).GtID());

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
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mHashTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mHashTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mPragmaKeywordLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mPragmaKeywordLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mChecksumKeywordLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mChecksumKeywordLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mFileLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mFileLabel).ToList()[0].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mGuidLabel).ToList()[1]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mGuidLabel).ToList()[1].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mBytesLabel).ToList()[2]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mBytesLabel).ToList()[2].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEndOfDirectiveTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEndOfDirectiveTokenLabel).GtID())
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
                        oFullElement.Elements().Single(e => e.Label() == oHashTokenLabel).GtID())
                    .Attribute("eLb").Value == oHashTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oPragmaKeywordLabel).GtID())
                    .Attribute("eLb").Value == oPragmaKeywordLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oChecksumKeywordLabel).GtID())
                    .Attribute("eLb").Value == oChecksumKeywordLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oFileLabel).ToList()[0].GtID())
                    .Attribute("eLb").Value == oFileLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oGuidLabel).ToList()[1].GtID())
                    .Attribute("eLb").Value == oGuidLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oBytesLabel).ToList()[2].GtID())
                    .Attribute("eLb").Value == oBytesLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndOfDirectiveTokenLabel).GtID())
                    .Attribute("eLb").Value == oEndOfDirectiveTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Any(e => e.Label() == mHashTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mHashTokenLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mPragmaKeywordLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mPragmaKeywordLabel).Value = "v1";

                if (mFullElement1.Elements().Any(e => e.Label() == mChecksumKeywordLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mChecksumKeywordLabel).Value = "v2";

                if (mFullElement1.Elements().Any(e => e.Label() == mFileLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mFileLabel).ToList()[0].Value = "v3";

                if (mFullElement1.Elements().Any(e => e.Label() == mGuidLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mGuidLabel).ToList()[1].Value = "v4";

                if (mFullElement1.Elements().Any(e => e.Label() == mBytesLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mBytesLabel).ToList()[2].Value = "v5";

                if (mFullElement1.Elements().Any(e => e.Label() == mEndOfDirectiveTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mEndOfDirectiveTokenLabel).Value = "v6";

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

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oHashTokenLabel)
                    .Attribute("mLb").Value == mHashTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oHashTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mHashTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oHashTokenLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oHashTokenLabel).GtID())
                    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oPragmaKeywordLabel)
                    .Attribute("mLb").Value == mPragmaKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oPragmaKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mPragmaKeywordLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oPragmaKeywordLabel)
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oPragmaKeywordLabel).GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oChecksumKeywordLabel)
                    .Attribute("mLb").Value == mChecksumKeywordLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oChecksumKeywordLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mChecksumKeywordLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oChecksumKeywordLabel)
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oChecksumKeywordLabel).GtID())
                    .Attribute("val").Value == "v2");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oFileLabel).ToList()[0]
                    .Attribute("mLb").Value == mFileLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oFileLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mFileLabel).ToList()[0].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oFileLabel).ToList()[0]
                        .Attribute("val").Value == "v3");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oFileLabel).ToList()[0].GtID())
                    .Attribute("val").Value == "v3");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGuidLabel).ToList()[1]
                    .Attribute("mLb").Value == mGuidLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oGuidLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mGuidLabel).ToList()[1].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oGuidLabel).ToList()[1]
                        .Attribute("val").Value == "v4");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oGuidLabel).ToList()[1].GtID())
                    .Attribute("val").Value == "v4");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oBytesLabel).ToList()[2]
                    .Attribute("mLb").Value == mBytesLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oBytesLabel).ToList()[2].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mBytesLabel).ToList()[2].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oBytesLabel).ToList()[2]
                        .Attribute("val").Value == "v5");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oBytesLabel).ToList()[2].GtID())
                    .Attribute("val").Value == "v5");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEndOfDirectiveTokenLabel)
                    .Attribute("mLb").Value == mEndOfDirectiveTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndOfDirectiveTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndOfDirectiveTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEndOfDirectiveTokenLabel)
                        .Attribute("val").Value == "v6");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndOfDirectiveTokenLabel).GtID())
                    .Attribute("val").Value == "v6");

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

        partial void XmlCrefAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlCrefAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlCrefAttributeSyntax Original, XmlCrefAttributeSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlCrefAttributeSyntax, XmlCrefAttributeSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 4;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;

                Assert.IsTrue(expander.FullDelta.Matches.Count() > matchedProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Name.Kind());
                var mNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Name.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oNameLabel)
                    .Attribute("mLb").Value == mNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID());

                var oLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Name.LocalName.Kind());
                var mLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Name.LocalName.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oLocalNameLabel)
                    .Attribute("mLb").Value == mLocalNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).GtID());

                var oEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EqualsToken.Kind());
                var mEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EqualsToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());

                var oStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartQuoteToken.Kind());
                var mStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());

                var oEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndQuoteToken.Kind());
                var mEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mEndQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID());

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
                Assert.IsTrue(expander.FullDelta.Actions.Count() > matchedProperties + 1 + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
                    .Attribute("pId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mNameLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mLocalNameLabel)
                        .Attribute("pLb").Value == mNameLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEqualsTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mStartQuoteTokenLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEndQuoteTokenLabel).ToList()[1]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID())
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
                Assert.IsTrue(expander.FullDelta.Actions.Count() > matchedProperties + 1 + unmatchedOriginalProperties);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
                    .Attribute("eLb").Value == oElement.Label());

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                    .Attribute("eLb").Value == oNameLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("eLb").Value == oLocalNameLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("eLb").Value == oEqualsTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("eLb").Value == oStartQuoteTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("eLb").Value == oEndQuoteTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Any(e => e.Label() == mNameLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mNameLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mEqualsTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mEqualsTokenLabel).Value = "v1";

                if (mFullElement1.Elements().Any(e => e.Label() == mStartQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].Value = "v2";

                if (mFullElement1.Elements().Any(e => e.Label() == mEndQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].Value = "v3";

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
                Assert.IsTrue(expander.FullDelta.Actions.Count() > matchedProperties + unmatchedOriginalProperties + unmatchedModifiedProperties - 1); // name is not updatable

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                //Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oNameLabel)
                //    .Attribute("mLb").Value == mNameLabel);
                //Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                //    oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                //    .Attribute("mId").Value ==
                //    mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID());
                //Assert.IsTrue(expander.FullDelta.Actions
                //        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oNameLabel)
                //        .Attribute("val").Value == "v0");
                //Assert.IsTrue(expander.FullDelta.Actions
                //    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                //        oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                //    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEqualsTokenLabel)
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oStartQuoteTokenLabel).ToList()[0]
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("val").Value == "v2");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mEndQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEndQuoteTokenLabel).ToList()[1]
                        .Attribute("val").Value == "v3");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("val").Value == "v3");

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

        partial void XmlElementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlElementSyntax, XmlElementSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void XmlElementServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlElementSyntax, XmlElementSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlElementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlElementSyntax Original, XmlElementSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlElementSyntax, XmlElementSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 2;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;
                var relevantDescendants = 2;

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 4 + relevantDescendants); // 2 from endtag and 2 from starttag
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oStartTagLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartTag.Kind());
                var mStartTagLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartTag.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oStartTagLabel)
                    .Attribute("mLb").Value == mStartTagLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).GtID());

                var oLessThanTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartTag.LessThanToken.Kind());
                var mLessThanTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartTag.LessThanToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oLessThanTokenLabel)
                    .Attribute("mLb").Value == mLessThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oLessThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).Elements().Single(e => e.Label() == mLessThanTokenLabel).GtID());

                var oGreaterThanTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartTag.GreaterThanToken.Kind());
                var mGreaterThanTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartTag.GreaterThanToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGreaterThanTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mGreaterThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID());

                var oEndTagLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndTag.Kind());
                var mEndTagLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndTag.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEndTagLabel)
                    .Attribute("mLb").Value == mEndTagLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).GtID());

                var oLessThanSlashTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndTag.LessThanSlashToken.Kind());
                var mLessThanSlashTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndTag.LessThanSlashToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oLessThanSlashTokenLabel)
                    .Attribute("mLb").Value == mLessThanSlashTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oLessThanSlashTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).Elements().Single(e => e.Label() == mLessThanSlashTokenLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGreaterThanTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mGreaterThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID());

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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedModifiedProperties + 4 + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
                    .Attribute("pId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mStartTagLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mLessThanTokenLabel)
                        .Attribute("pLb").Value == mStartTagLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mStartTagLabel)
                        .Elements().Single(e => e.Label() == mLessThanTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mGreaterThanTokenLabel).ToList()[0]
                        .Attribute("pLb").Value == mStartTagLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mStartTagLabel)
                        .Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEndTagLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mLessThanSlashTokenLabel)
                        .Attribute("pLb").Value == mEndTagLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEndTagLabel)
                        .Elements().Single(e => e.Label() == mLessThanSlashTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mGreaterThanTokenLabel).ToList()[1]
                        .Attribute("pLb").Value == mEndTagLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEndTagLabel)
                        .Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).GtID());

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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedOriginalProperties + 4 + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
                    .Attribute("eLb").Value == oElement.Label());

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).GtID())
                    .Attribute("eLb").Value == oStartTagLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oStartTagLabel)
                        .Elements().Single(e => e.Label() == oLessThanTokenLabel).GtID())
                    .Attribute("eLb").Value == oLessThanTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oStartTagLabel)
                        .Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("eLb").Value == oGreaterThanTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).GtID())
                    .Attribute("eLb").Value == oEndTagLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndTagLabel)
                        .Elements().Single(e => e.Label() == oLessThanSlashTokenLabel).GtID())
                    .Attribute("eLb").Value == oLessThanSlashTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndTagLabel)
                        .Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("eLb").Value == oGreaterThanTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Any(e => e.Label() == mLessThanTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == mLessThanTokenLabel).Value = "v0";

                if (mFullElement1.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Any(e => e.Label() == mGreaterThanTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).Value = "v1";

                if (mFullElement1.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Any(e => e.Label() == mLessThanSlashTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == mLessThanSlashTokenLabel).Value = "v2";

                if (mFullElement1.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Any(e => e.Label() == mGreaterThanTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).Value = "v3";

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

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 4 + relevantDescendants);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 4);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oLessThanTokenLabel)
                    .Attribute("mLb").Value == mLessThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oLessThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).Elements().Single(e => e.Label() == mLessThanTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oLessThanTokenLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oLessThanTokenLabel).GtID())
                    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGreaterThanTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mGreaterThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mStartTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oGreaterThanTokenLabel).ToList()[0]
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oStartTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oLessThanSlashTokenLabel)
                    .Attribute("mLb").Value == mLessThanSlashTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oLessThanSlashTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).Elements().Single(e => e.Label() == mLessThanSlashTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oLessThanSlashTokenLabel)
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oLessThanSlashTokenLabel).GtID())
                    .Attribute("val").Value == "v2");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oGreaterThanTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mGreaterThanTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEndTagLabel).Elements().Single(e => e.Label() == mGreaterThanTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oGreaterThanTokenLabel).ToList()[1]
                        .Attribute("val").Value == "v3");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEndTagLabel).Elements().Single(e => e.Label() == oGreaterThanTokenLabel).GtID())
                    .Attribute("val").Value == "v3");

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

        partial void XmlNameAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlNameAttributeSyntax, XmlNameAttributeSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void XmlNameAttributeServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlNameAttributeSyntax, XmlNameAttributeSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlNameAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlNameAttributeSyntax Original, XmlNameAttributeSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlNameAttributeSyntax, XmlNameAttributeSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 4;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;
                var relevantDescendants = 2;

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 1 + relevantDescendants); //the identifier within the XmlName
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Name.Kind());
                var mNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Name.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oNameLabel)
                    .Attribute("mLb").Value == mNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID());

                var oLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Name.LocalName.Kind());
                var mLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Name.LocalName.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oLocalNameLabel).ToList()[0]
                    .Attribute("mLb").Value == mLocalNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).GtID());

                var oEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EqualsToken.Kind());
                var mEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EqualsToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());

                var oStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartQuoteToken.Kind());
                var mStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());

                var oEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndQuoteToken.Kind());
                var mEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mEndQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID());

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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedModifiedProperties + 1 + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
                    .Attribute("pId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mNameLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mLocalNameLabel).ToList()[0]
                        .Attribute("pLb").Value == mNameLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).GtID())
                    .Attribute("pId").Value == mFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEqualsTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mStartQuoteTokenLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEndQuoteTokenLabel).ToList()[1]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID())
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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedOriginalProperties + 1 + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
                    .Attribute("eLb").Value == oElement.Label());

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                    .Attribute("eLb").Value == oNameLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("eLb").Value == oLocalNameLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("eLb").Value == oEqualsTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("eLb").Value == oStartQuoteTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("eLb").Value == oEndQuoteTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                //if (mFullElement1.Elements().Any(e => e.Label() == mNameLabel))
                //    mFullElement1.Elements().Single(e => e.Label() == mNameLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mEqualsTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mEqualsTokenLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mStartQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].Value = "v1";

                if (mFullElement1.Elements().Any(e => e.Label() == mEndQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].Value = "v2";

                if (mFullElement1.Elements().Single(e => e.Label() == mNameLabel).Elements().Any(e => e.Label() == mLocalNameLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).Value = "v3";

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

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 1 + relevantDescendants);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + unmatchedOriginalProperties + unmatchedModifiedProperties + 1 - 1); // Name is not a leaf and therefore it is not updatable.

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                //Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oNameLabel)
                //    .Attribute("mLb").Value == mNameLabel);
                //Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                //    oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                //    .Attribute("mId").Value ==
                //    mFullElement.Elements().Single(e => e.Label() == mNameLabel).GtID());
                //Assert.IsTrue(expander.FullDelta.Actions
                //        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oNameLabel)
                //        .Attribute("val").Value == "v0");
                //Assert.IsTrue(expander.FullDelta.Actions
                //    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                //        oFullElement.Elements().Single(e => e.Label() == oNameLabel).GtID())
                //    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oLocalNameLabel).ToList()[0]
                    .Attribute("mLb").Value == mLocalNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mNameLabel).Elements().Single(e => e.Label() == mLocalNameLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oLocalNameLabel)
                        .Attribute("val").Value == "v3");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oNameLabel).Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("val").Value == "v3");

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEqualsTokenLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oStartQuoteTokenLabel).ToList()[0]
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEndQuoteTokenLabel).ToList()[1]
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("val").Value == "v2");

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

                if (mElement.Elements().Count(n => n is XNode) == 0)
                {
                    mFullElement.Elements()
                        .Single(n => n.Attribute("part").Value == "Identifier").Elements()
                        .Single(n => n.Attribute("part").Value == "Identifier")
                        .Value = "v4";

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
                    Actions: new XElement[]
                    {
                        new XElement("Update",
                            new XAttribute("eId", oElement.GtID()),
                            new XAttribute("eLb", oElement.Attribute("kind")?.Value ?? oElement.Name.LocalName),
                            new XAttribute("eVl", mElement.GtID()),
                            new XAttribute("val", "t#v"))
                    }));
                    Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 1 + relevantDescendants);
                    Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);

                    Assert.IsTrue(expander.FullDelta.Actions
                            .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == "IdentifierToken")
                            .Attribute("val").Value == "v4");
                }
            }
        }

        partial void XmlTextAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlTextAttributeSyntax, XmlTextAttributeSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void XmlTextAttributeServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlTextAttributeSyntax, XmlTextAttributeSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlTextAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlTextAttributeSyntax Original, XmlTextAttributeSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlTextAttributeSyntax, XmlTextAttributeSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 3;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EqualsToken.Kind());
                var mEqualsTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EqualsToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());

                var oStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.StartQuoteToken.Kind());
                var mStartQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.StartQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());

                var oEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.EndQuoteToken.Kind());
                var mEndQuoteTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.EndQuoteToken.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mEndQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID());

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
                        .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEqualsTokenLabel)
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mStartQuoteTokenLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("pId").Value == mFullElement.GtID());

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mEndQuoteTokenLabel).ToList()[1]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID())
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
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("eLb").Value == oEqualsTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("eLb").Value == oStartQuoteTokenLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("eLb").Value == oEndQuoteTokenLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Any(e => e.Label() == mEqualsTokenLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mEqualsTokenLabel).Value = "v0";

                if (mFullElement1.Elements().Any(e => e.Label() == mStartQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].Value = "v1";

                if (mFullElement1.Elements().Any(e => e.Label() == mEndQuoteTokenLabel))
                    mFullElement1.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].Value = "v2";

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

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oEqualsTokenLabel)
                    .Attribute("mLb").Value == mEqualsTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mEqualsTokenLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEqualsTokenLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oEqualsTokenLabel).GtID())
                    .Attribute("val").Value == "v0");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oStartQuoteTokenLabel).ToList()[0]
                    .Attribute("mLb").Value == mStartQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mStartQuoteTokenLabel).ToList()[0].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oStartQuoteTokenLabel).ToList()[0]
                        .Attribute("val").Value == "v1");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oStartQuoteTokenLabel).ToList()[0].GtID())
                    .Attribute("val").Value == "v1");

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oEndQuoteTokenLabel).ToList()[1]
                    .Attribute("mLb").Value == mEndQuoteTokenLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Where(e => e.Label() == mEndQuoteTokenLabel).ToList()[1].GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oEndQuoteTokenLabel).ToList()[1]
                        .Attribute("val").Value == "v2");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Where(e => e.Label() == oEndQuoteTokenLabel).ToList()[1].GtID())
                    .Attribute("val").Value == "v2");

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


        partial void XmlNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlNameSyntax, XmlNameSyntax)> nodeRevisionPairs);

        [TestMethod]
        public void XmlNameServiceProvider_RoslynMLDeltaExpander_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlNameSyntax, XmlNameSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlNameSyntax Original, XmlNameSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlNameSyntax, XmlNameSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 1;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;

                var relevantDescendants = 0;
                if (oFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix") &&
                   mFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix"))
                {
                    relevantDescendants = oFullElement.Elements().Single(e => e.Attribute("part").Value == "Prefix")
                        .PreOrder(n => n.Elements().Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .Count();
                }
                else if (!oFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix") &&
                         mFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix"))
                {
                    unmatchedModifiedProperties += mFullElement.Elements().Single(e => e.Attribute("part").Value == "Prefix")
                        .PreOrder(n => n.Elements().Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .Count();
                }
                else if (oFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix") &&
                         !mFullElement.Elements().Any(e => e.Attribute("part").Value == "Prefix"))
                {
                    unmatchedOriginalProperties += oFullElement.Elements().Single(e => e.Attribute("part").Value == "Prefix")
                        .PreOrder(n => n.Elements().Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .Count();
                }

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + relevantDescendants);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                var oLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.LocalName.Kind());
                var mLocalNameLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.LocalName.Kind());
                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oLocalNameLabel).ToList()[0]
                    .Attribute("mLb").Value == mLocalNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mLocalNameLabel).GtID());

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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedModifiedProperties + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
                    .Attribute("pId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
                    .Attribute("pLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Actions
                        .Where(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mLocalNameLabel).ToList()[0]
                        .Attribute("pLb").Value == mExpectedLabel);
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value ==
                        mFullElement.Elements().Single(e => e.Label() == mLocalNameLabel).GtID())
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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedOriginalProperties + relevantDescendants);

                Assert.IsTrue(expander.FullDelta.Actions
                    .Where(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID()).ToList()[0]
                    .Attribute("eLb").Value == oElement.Label());

                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("eLb").Value == oLocalNameLabel);

                // Update
                var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
                converter.SetGumTreefiedIDs(mFullElement1, ref mId);
                converter.SetRoslynMLIDs(mFullElement1, ref mId);

                if (mFullElement1.Elements().Any(e => e.Label() == mLocalNameLabel))
                    mFullElement1.Elements().Single(e => e.Label() == mLocalNameLabel).Value = "v0";

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

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + relevantDescendants);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + unmatchedOriginalProperties + unmatchedModifiedProperties);

                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
                    .Attribute("mId").Value == mElement.GtID());
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
                    .Attribute("mLb").Value == mExpectedLabel);

                Assert.IsTrue(expander.FullDelta.Matches.Where(m => m.Attribute("oLb").Value == oLocalNameLabel).ToList()[0]
                    .Attribute("mLb").Value == mLocalNameLabel);
                Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value ==
                    oFullElement.Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("mId").Value ==
                    mFullElement.Elements().Single(e => e.Label() == mLocalNameLabel).GtID());
                Assert.IsTrue(expander.FullDelta.Actions
                        .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oLocalNameLabel)
                        .Attribute("val").Value == "v0");
                Assert.IsTrue(expander.FullDelta.Actions
                    .Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value ==
                        oFullElement.Elements().Single(e => e.Label() == oLocalNameLabel).GtID())
                    .Attribute("val").Value == "v0");

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

        public void XmlNameServiceProvider_RoslynMLDeltaExpanderReplaceUpdate_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            int id = 0;

            IEnumerable<(XmlNameSyntax, XmlNameSyntax)> nodeRevisionPairs = null;
            string oExpectedLabel = null, mExpectedLabel = null;
            XmlNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
            foreach (((XmlNameSyntax Original, XmlNameSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
                .SelectMany(n => new List<((XmlNameSyntax, XmlNameSyntax), Action<RoslynML, XElement>)>
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

                var totalProperties = 1;
                var matchedProperties = totalProperties;
                var unmatchedOriginalProperties = 0;
                var unmatchedModifiedProperties = 0;
                var relevantDescendants = oFullElement.Elements().Single(e => e.Attribute("part").Value == "Prefix")
                    .PreOrder(n => n.Elements().Where(ne => ne is XNode))
                    .Where(ne => ne.Attribute("GtID")?.Value != null)
                    .Count();

                DeltaExpander expander = new DeltaExpander();
                if (mElement.Elements().Count(n => n is XNode) == 0)
                {
                    mFullElement.Elements()
                        .Single(n => n.Attribute("part").Value == "Identifier").Elements()
                        .Single(n => n.Attribute("part").Value == "Identifier")
                        .Value = "v4";

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
                    Actions: new XElement[]
                    {
                        new XElement("Update",
                            new XAttribute("eId", oElement.GtID()),
                            new XAttribute("eLb", oElement.Attribute("kind")?.Value ?? oElement.Name.LocalName),
                            new XAttribute("eVl", mElement.GtID()),
                            new XAttribute("val", "t#v"))
                    }));
                    Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + 1 + relevantDescendants);
                    Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);

                    Assert.IsTrue(expander.FullDelta.Actions
                            .Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == "IdentifierToken")
                            .Attribute("val").Value == "v4");
                }

            }
        }

        partial void ParenthesizedExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"), (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"))
            };
        }

        partial void PrefixUnaryExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"), (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"))
            };
        }

        partial void AwaitExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AwaitExpressionSyntax, AwaitExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"), (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"))
            };
        }

        partial void PostfixUnaryExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"), (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"))
            };
        }

        partial void MemberAccessExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"), (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"))
            };
        }

        partial void ConditionalAccessExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"), (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"))
            };
        }

        partial void MemberBindingExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull,
                 (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull)
            };
        }

        partial void ElementBindingExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull,
                 (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull)
            };
        }

        partial void ImplicitElementAccessServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)> nodeRevisionPairs)
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

        partial void BinaryExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BinaryExpressionSyntax, BinaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"),
                 (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"))
            };
        }

        partial void AssignmentExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AssignmentExpressionSyntax, AssignmentExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"),
                 (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"))
            };
        }

        partial void ConditionalExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConditionalExpressionSyntax, ConditionalExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"),
                 (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"))
            };
        }

        partial void ThisExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ThisExpressionSyntax, ThisExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"),
                 (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"))
            };
        }

        partial void BaseExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BaseExpressionSyntax, BaseExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"),
                 (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"))
            };
        }

        partial void LiteralExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LiteralExpressionSyntax, LiteralExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"),
                 (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"))
            };
        }

        partial void MakeRefExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(MakeRefExpressionSyntax, MakeRefExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"),
                 (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"))
            };
        }

        partial void RefTypeExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(RefTypeExpressionSyntax, RefTypeExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"),
                 (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"))
            };
        }

        partial void RefValueExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(RefValueExpressionSyntax, RefValueExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"),
                 (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"))
            };
        }

        partial void CheckedExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CheckedExpressionSyntax, CheckedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)")),
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"))
            };
        }

        partial void DefaultExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DefaultExpressionSyntax, DefaultExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"),
                 (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"))
            };
        }

        partial void TypeOfExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeOfExpressionSyntax, TypeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"),
                 (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"))
            };
        }

        partial void SizeOfExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SizeOfExpressionSyntax, SizeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"),
                 (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"))
            };
        }

        partial void InvocationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InvocationExpressionSyntax, InvocationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"),
                 (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"))
            };
        }

        partial void ElementAccessExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"),
                 (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"))
            };
        }

        partial void CastExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CastExpressionSyntax, CastExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"),
                 (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"))
            };
        }

        partial void AnonymousMethodExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)> nodeRevisionPairs)
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

        partial void SimpleLambdaExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)> nodeRevisionPairs)
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

        partial void ParenthesizedLambdaExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)> nodeRevisionPairs)
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

        partial void InitializerExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InitializerExpressionSyntax, InitializerExpressionSyntax)> nodeRevisionPairs)
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

        partial void ObjectCreationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)> nodeRevisionPairs)
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

        partial void AnonymousObjectCreationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"),
                  (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"))
            };
        }

        partial void ArrayCreationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"),
                  (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"))
            };
        }

        partial void ImplicitArrayCreationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"),
                  (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"))
            };
        }

        partial void StackAllocArrayCreationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"),
                  (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"))
            };
        }

        partial void QueryExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(QueryExpressionSyntax, QueryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"),
                  (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"))
            };
        }

        partial void InterpolatedStringExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""),
                  (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""))
            };
        }

        partial void InterpolatedStringTextServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0],
                  (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0])
            };
        }

        partial void InterpolationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterpolationSyntax, InterpolationSyntax)> nodeRevisionPairs)
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

        partial void InterpolationAlignmentClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause)
            };
        }

        partial void InterpolationFormatClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause)
            };
        }

        partial void ArgumentListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArgumentListSyntax, ArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList,
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList)
            };
        }

        partial void BracketedArgumentListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BracketedArgumentListSyntax, BracketedArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList,
                  ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList)
            };
        }

        partial void ArgumentServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArgumentSyntax, ArgumentSyntax)> nodeRevisionPairs)
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

        partial void NameColonServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(NameColonSyntax, NameColonSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon,
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon)
            };
        }

        partial void NameEqualsServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(NameEqualsSyntax, NameEqualsSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals,
                  ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals)
            };
        }

        partial void AnonymousObjectMemberDeclaratorServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AnonymousObjectMemberDeclaratorSyntax, AnonymousObjectMemberDeclaratorSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0],
                  ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0])
            };
        }

        partial void QueryBodyServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(QueryBodySyntax, QueryBodySyntax)> nodeRevisionPairs)
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

        partial void FromClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(FromClauseSyntax, FromClauseSyntax)> nodeRevisionPairs)
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

        partial void LetClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LetClauseSyntax, LetClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]),
                  ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]))
            };
        }

        partial void JoinClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(JoinClauseSyntax, JoinClauseSyntax)> nodeRevisionPairs)
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

        partial void JoinIntoClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(JoinIntoClauseSyntax, JoinIntoClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into,
                  ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into)
            };
        }

        partial void WhereClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(WhereClauseSyntax, WhereClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]),
                  ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]))
            };
        }

        partial void OrderByClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OrderByClauseSyntax, OrderByClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]),
                  ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]))
            };
        }

        partial void OrderingServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OrderingSyntax, OrderingSyntax)> nodeRevisionPairs)
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

        partial void SelectClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SelectClauseSyntax, SelectClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup),
                  ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup))
            };
        }

        partial void GroupClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(GroupClauseSyntax, GroupClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup),
                  ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup))
            };
        }

        partial void QueryContinuationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(QueryContinuationSyntax, QueryContinuationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation,
                  ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation)
            };
        }

        partial void PredefinedTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PredefinedTypeSyntax, PredefinedTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int"),
                  (PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int"))
            };
        }

        partial void ArrayTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArrayTypeSyntax, ArrayTypeSyntax)> nodeRevisionPairs)
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

        partial void PointerTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PointerTypeSyntax, PointerTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*"),
                  (PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*"))
            };
        }

        partial void NullableTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(NullableTypeSyntax, NullableTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?"),
                  (NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?"))
            };
        }

        partial void OmittedTypeArgumentServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0],
                  (OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0])
            };
        }

        partial void QualifiedNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(QualifiedNameSyntax, QualifiedNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((QualifiedNameSyntax)SyntaxFactory.ParseName("a.x"),
                  (QualifiedNameSyntax)SyntaxFactory.ParseName("a.x"))
            };
        }

        partial void AliasQualifiedNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AliasQualifiedNameSyntax, AliasQualifiedNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c"),
                  (AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c"))
            };
        }

        partial void IdentifierNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IdentifierNameSyntax, IdentifierNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((IdentifierNameSyntax)SyntaxFactory.ParseName("c"),
                  (IdentifierNameSyntax)SyntaxFactory.ParseName("c"))
            };
        }

        partial void GenericNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(GenericNameSyntax, GenericNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>"),
                  (GenericNameSyntax)SyntaxFactory.ParseName("a<,>"))
            };
        }

        partial void TypeArgumentListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeArgumentListSyntax, TypeArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList,
                  ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList)
            };
        }

        partial void ArrayRankSpecifierServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArrayRankSpecifierSyntax, ArrayRankSpecifierSyntax)> nodeRevisionPairs)
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

        partial void OmittedArraySizeExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OmittedArraySizeExpressionSyntax, OmittedArraySizeExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0],
                  (OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0])
            };
        }

        partial void BlockServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BlockSyntax, BlockSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }"),
                  (BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }"))
            };
        }

        partial void LocalDeclarationStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LocalDeclarationStatementSyntax, LocalDeclarationStatementSyntax)> nodeRevisionPairs)
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

        partial void ExpressionStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ExpressionStatementSyntax, ExpressionStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3"),
                  (ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3"))
            };
        }

        partial void EmptyStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EmptyStatementSyntax, EmptyStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((EmptyStatementSyntax)SyntaxFactory.ParseStatement(";"),
                  (EmptyStatementSyntax)SyntaxFactory.ParseStatement(";"))
            };
        }

        partial void LabeledStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LabeledStatementSyntax, LabeledStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3"),
                  (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3"))
            };
        }

        partial void GotoStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(GotoStatementSyntax, GotoStatementSyntax)> nodeRevisionPairs)
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

        partial void BreakStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BreakStatementSyntax, BreakStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((BreakStatementSyntax)SyntaxFactory.ParseStatement("break;"),
                  (BreakStatementSyntax)SyntaxFactory.ParseStatement("break;"))
            };
        }

        partial void ContinueStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ContinueStatementSyntax, ContinueStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;"),
                  (ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;"))
            };
        }

        partial void ReturnStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ReturnStatementSyntax, ReturnStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;"),
                  (ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;"))
            };
        }

        partial void ThrowStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ThrowStatementSyntax, ThrowStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;"),
                  (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;"))
            };
        }

        partial void YieldStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(YieldStatementSyntax, YieldStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;"),
                  (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;")),
                 ((YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;"),
                  (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;"))
            };
        }

        partial void WhileStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(WhileStatementSyntax, WhileStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;"),
                  (WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;"))
            };
        }

        partial void DoStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DoStatementSyntax, DoStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);"),
                  (DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);"))
            };
        }

        partial void ForStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ForStatementSyntax, ForStatementSyntax)> nodeRevisionPairs)
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

        partial void ForEachStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ForEachStatementSyntax, ForEachStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);"),
                  (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);"))
            };
        }

        partial void UsingStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(UsingStatementSyntax, UsingStatementSyntax)> nodeRevisionPairs)
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

        partial void FixedStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(FixedStatementSyntax, FixedStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);"),
                  (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);"))
            };
        }

        partial void CheckedStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CheckedStatementSyntax, CheckedStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}"),
                  (CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}"))
            };
        }

        partial void UnsafeStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(UnsafeStatementSyntax, UnsafeStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}"),
                  (UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}"))
            };
        }

        partial void LockStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LockStatementSyntax, LockStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);"),
                  (LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);"))
            };
        }

        partial void IfStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IfStatementSyntax, IfStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);"),
                  (IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);"))
            };
        }

        partial void SwitchStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SwitchStatementSyntax, SwitchStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }"),
                  (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }")),
                 ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }"),
                  (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }"))
            };
        }

        partial void TryStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TryStatementSyntax, TryStatementSyntax)> nodeRevisionPairs)
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

        partial void VariableDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(VariableDeclarationSyntax, VariableDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration,
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration)
            };
        }

        partial void VariableDeclaratorServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(VariableDeclaratorSyntax, VariableDeclaratorSyntax)> nodeRevisionPairs)
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

        partial void EqualsValueClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EqualsValueClauseSyntax, EqualsValueClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer,
                  ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer)
            };
        }

        partial void ElseClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ElseClauseSyntax, ElseClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else,
                  ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else)
            };
        }

        partial void SwitchSectionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SwitchSectionSyntax, SwitchSectionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0],
                  ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0])
            };
        }

        partial void CaseSwitchLabelServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CaseSwitchLabelSyntax, CaseSwitchLabelSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0],
                  (CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0])
            };
        }

        partial void DefaultSwitchLabelServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DefaultSwitchLabelSyntax, DefaultSwitchLabelSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0],
                  (DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0])
            };
        }

        partial void CatchClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CatchClauseSyntax, CatchClauseSyntax)> nodeRevisionPairs)
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

        partial void CatchDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CatchDeclarationSyntax, CatchDeclarationSyntax)> nodeRevisionPairs)
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

        partial void CatchFilterClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CatchFilterClauseSyntax, CatchFilterClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter)
            };
        }

        partial void FinallyClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(FinallyClauseSyntax, FinallyClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally,
                  ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally)
            };
        }

        partial void IncompleteMemberServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IncompleteMemberSyntax, IncompleteMemberSyntax)> nodeRevisionPairs)
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

        partial void GlobalStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(GlobalStatementSyntax, GlobalStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++")),
                  Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++")))
            };
        }

        partial void DelegateDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DelegateDeclarationSyntax, DelegateDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0],
                  (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0])
            };
        }

        partial void EnumDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EnumDeclarationSyntax, EnumDeclarationSyntax)> nodeRevisionPairs)
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

        partial void ClassDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ClassDeclarationSyntax, ClassDeclarationSyntax)> nodeRevisionPairs)
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

        partial void StructDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(StructDeclarationSyntax, StructDeclarationSyntax)> nodeRevisionPairs)
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

        partial void InterfaceDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(InterfaceDeclarationSyntax, InterfaceDeclarationSyntax)> nodeRevisionPairs)
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

        partial void EnumMemberDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EnumMemberDeclarationSyntax, EnumMemberDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1],
                  ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1])
            };
        }

        partial void TypeParameterListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeParameterListSyntax, TypeParameterListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList,
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList)
            };
        }

        partial void TypeParameterServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeParameterSyntax, TypeParameterSyntax)> nodeRevisionPairs)
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

        partial void TypeParameterConstraintClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0],
                  ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0])
            };
        }

        partial void TypeConstraintServiceProvider_RoslynMLDeltaExpander_DataToTest(
            ref IEnumerable<(TypeConstraintSyntax, TypeConstraintSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TypeConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A {};").Members[0]).ConstraintClauses[0].Constraints[0],
                    (TypeConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A {};").Members[0]).ConstraintClauses[0].Constraints[0])
            };
        }

        partial void ConstructorConstraintServiceProvider_RoslynMLDeltaExpander_DataToTest(
            ref IEnumerable<(ConstructorConstraintSyntax, ConstructorConstraintSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConstructorConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};").Members[0]).ConstraintClauses[0].Constraints[0],
                    (ConstructorConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};").Members[0]).ConstraintClauses[0].Constraints[0])
            };
        }

        partial void ClassOrStructConstraintServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ClassOrStructConstraintSyntax, ClassOrStructConstraintSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};").Members[0]).ConstraintClauses[0].Constraints[0],
                    (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};").Members[0]).ConstraintClauses[0].Constraints[0])
            };
        }

        partial void BaseListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BaseListSyntax, BaseListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList,
                    ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList)
            };
        }

        partial void SimpleBaseTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SimpleBaseTypeSyntax, SimpleBaseTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SimpleBaseTypeSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList.Types[0],
                    (SimpleBaseTypeSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList.Types[0])
            };
        }

        partial void FieldDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(FieldDeclarationSyntax, FieldDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}").Members[0]).Members[0],
                    (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}").Members[0]).Members[0])
            };
        }

        partial void EventFieldDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EventFieldDeclarationSyntax, EventFieldDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}").Members[0]).Members[0],
                    (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}").Members[0]).Members[0])
            };
        }

        partial void ExplicitInterfaceSpecifierServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ExplicitInterfaceSpecifierSyntax, ExplicitInterfaceSpecifierSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier,
                    ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier)
            };
        }

        partial void MethodDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(MethodDeclarationSyntax, MethodDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0],
                    (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0]),
                ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0],
                    (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0]),
                ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0],
                    (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0]),
                ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0],
                    (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0])
            };
        }

        partial void OperatorDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OperatorDeclarationSyntax, OperatorDeclarationSyntax)> nodeRevisionPairs)
        {
               nodeRevisionPairs = new[]
               {
                ((OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0],
                    (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0]),
                ((OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0],
                    (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0]),
                ((OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0],
                    (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0]),
                ((OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0],
                    (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0])
            };
        }

        partial void ConversionOperatorDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConversionOperatorDeclarationSyntax, ConversionOperatorDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0],
                    (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0]),
                ((ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0],
                    (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0]),
                ((ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0],
                    (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0]),
                ((ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0],
                    (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0])
            };
        }

        partial void ConstructorDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConstructorDeclarationSyntax, ConstructorDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b){} }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b){} }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b){} }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b){} }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b); }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b); }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b); }").Members[0]).Members[0]),
                ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b); }").Members[0]).Members[0],
                    (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0])
            };
        }

        partial void ConstructorInitializerServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConstructorInitializerSyntax, ConstructorInitializerSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]).Initializer,
                    ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]).Initializer)
            };
        }

        partial void DestructorDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DestructorDeclarationSyntax, DestructorDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A();}").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A();}").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A();}").Members[0]).Members[0]),
                ((DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A();}").Members[0]).Members[0],
                    (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0])
            };
        }

        partial void PropertyDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PropertyDeclarationSyntax, PropertyDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0]),
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0]),
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0]),
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0]),

                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]),
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0]),
                ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get; set; }").Members[0],
                    (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0])
            };
        }

        partial void ArrowExpressionClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ArrowExpressionClauseSyntax, ArrowExpressionClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]).ExpressionBody,
                    ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]).ExpressionBody)
            };
        }

        partial void EventDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EventDeclarationSyntax, EventDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{} remove{} }").Members[0],
                    (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{} remove{} }").Members[0]),
                ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0],
                    (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0]),
                ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{} remove{} }").Members[0],
                    (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0]),
                ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0],
                    (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{} remove{} }").Members[0])
            };
        }

        partial void IndexerDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IndexerDeclarationSyntax, IndexerDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } = 5;").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } = 5;").Members[0]),
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0]),
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } = 5;").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } ").Members[0]),
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } = 5;").Members[0]),

                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } => 5;").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } => 5;").Members[0]),
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } => 5;").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0]),
                ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0],
                    (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{} set{} } => 5;").Members[0])
            };
        }

        partial void AccessorListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AccessorListSyntax, AccessorListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0]).AccessorList,
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0]).AccessorList)
            };
        }

        partial void AccessorDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AccessorDeclarationSyntax, AccessorDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0]),
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0]),
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0]),
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0]),

                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0]),
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0]),
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0],
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0])
            };
        }

        partial void ParameterListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ParameterListSyntax, ParameterListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList,
                    ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList)
            };
        }

        partial void BracketedParameterListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BracketedParameterListSyntax, BracketedParameterListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList,
                    ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList)
            };
        }

        partial void ParameterServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ParameterSyntax, ParameterSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0],
                    ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0]),
                (((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0],
                    ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0]),
                (((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0],
                    ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0]),
                (((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0],
                    ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0])
            };
        }

        partial void SkippedTokensTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SkippedTokensTriviaSyntax, SkippedTokensTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.SkippedTokensTrivia(((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual a").Members[0]).Modifiers),
                    SyntaxFactory.SkippedTokensTrivia(((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual a").Members[0]).Modifiers))
            };
        }

        partial void DocumentationCommentTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DocumentationCommentTriviaSyntax, DocumentationCommentTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo />").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure(),
                    (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo />").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()),
                ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree(@"/// <summary>" + Environment.NewLine +
                                                                                    "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + Environment.NewLine +
                                                                                    "/// </summary>" + Environment.NewLine +
                                                                                    "/// <param name=\"node\">node of interest.</param>" + Environment.NewLine +
                                                                                    "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>")
                                                                                    .GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure(),
                    (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree(@"/// <summary>" + Environment.NewLine +
                                                                                    "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + Environment.NewLine +
                                                                                    "/// </summary>" + Environment.NewLine +
                                                                                    "/// <param name=\"node\">node of interest.</param>" + Environment.NewLine +
                                                                                    "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>")
                                                                                    .GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure())
            };
        }

        partial void EndIfDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EndIfDirectiveTriviaSyntax, EndIfDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.EndIfDirectiveTrivia(true),
                    SyntaxFactory.EndIfDirectiveTrivia(true))
            };
        }

        partial void RegionDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(RegionDirectiveTriviaSyntax, RegionDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.RegionDirectiveTrivia(true),
                    SyntaxFactory.RegionDirectiveTrivia(true))
            };
        }

        partial void EndRegionDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(EndRegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.EndRegionDirectiveTrivia(true),
                    SyntaxFactory.EndRegionDirectiveTrivia(true))
            };
        }

        partial void ErrorDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ErrorDirectiveTriviaSyntax, ErrorDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ErrorDirectiveTrivia(true),
                    SyntaxFactory.ErrorDirectiveTrivia(true))
            };
        }

        partial void WarningDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(WarningDirectiveTriviaSyntax, WarningDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.WarningDirectiveTrivia(true),
                    SyntaxFactory.WarningDirectiveTrivia(true))
            };
        }

        partial void BadDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(BadDirectiveTriviaSyntax, BadDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true),
                    SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true))
            };
        }

        partial void DefineDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DefineDirectiveTriviaSyntax, DefineDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true),
                    SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true))
            };
        }

        partial void UndefDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(UndefDirectiveTriviaSyntax, UndefDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true),
                    SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true))
            };
        }

        partial void LineDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LineDirectiveTriviaSyntax, LineDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true),
                    SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true))
            };
        }

        partial void PragmaWarningDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PragmaWarningDirectiveTriviaSyntax, PragmaWarningDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            var separatedSyntaxList = SyntaxFactory.SeparatedList(new ExpressionSyntax[] { SyntaxFactory.IdentifierName("warning-list"), SyntaxFactory.IdentifierName("CS3021") });
            var node = SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), separatedSyntaxList, true);
            nodeRevisionPairs = new[]
            {
                (node, node)
            };
        }

        partial void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(PragmaChecksumDirectiveTriviaSyntax, PragmaChecksumDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true),
                    SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true))
            };
        }

        partial void ReferenceDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ReferenceDirectiveTriviaSyntax, ReferenceDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true),
                    SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true))
            };
        }

        partial void LoadDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LoadDirectiveTriviaSyntax, LoadDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true),
                    SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true))
            };
        }

        partial void ShebangDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ShebangDirectiveTriviaSyntax, ShebangDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ShebangDirectiveTrivia(true),
                    SyntaxFactory.ShebangDirectiveTrivia(true))
            };
        }

        partial void ElseDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ElseDirectiveTriviaSyntax, ElseDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ElseDirectiveTrivia(true, true),
                    SyntaxFactory.ElseDirectiveTrivia(true, true))
            };
        }

        partial void IfDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IfDirectiveTriviaSyntax, IfDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure(),
                    (IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure())
            };
        }

        partial void ElifDirectiveTriviaServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ElifDirectiveTriviaSyntax, ElifDirectiveTriviaSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true),
                    SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true))
            };
        }

        partial void TypeCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TypeCrefSyntax, TypeCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"int\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<TypeCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node)
            };
        }

        partial void QualifiedCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(QualifiedCrefSyntax, QualifiedCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N.A\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<QualifiedCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node)
            };
        }

        partial void NameMemberCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(NameMemberCrefSyntax, NameMemberCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            var node1 = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node), (node1, node1), (node, node1), (node1, node)
            };
        }

        partial void IndexerMemberCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IndexerMemberCrefSyntax, IndexerMemberCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                         "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                         "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            var node1 = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node), (node1, node1), (node, node1), (node1, node)
            };
        }

        partial void OperatorMemberCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(OperatorMemberCrefSyntax, OperatorMemberCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();

            var text3 = "namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +\"/> </summary>" + Environment.NewLine +
                      "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            var node1 = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node), (node1, node1), (node, node1), (node1, node)
            };
        }

        partial void ConversionOperatorMemberCrefServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConversionOperatorMemberCrefSyntax, ConversionOperatorMemberCrefSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node1 = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();

            nodeRevisionPairs = new[]
            {
                (node, node), (node1, node1), (node, node1), (node1, node)
            };
        }

        partial void CrefParameterListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CrefParameterListSyntax, CrefParameterListSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;

            nodeRevisionPairs = new[]
            {
                (node, node)
            };
        }

        partial void CrefBracketedParameterListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CrefBracketedParameterListSyntax, CrefBracketedParameterListSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;

            nodeRevisionPairs = new[]
            {
                (node, node)
            };
        }

        partial void CrefParameterServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CrefParameterSyntax, CrefParameterSyntax)> nodeRevisionPairs)
        {
            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];

            text = "namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node1 = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];

            nodeRevisionPairs = new[]
            {
                (node, node), (node1, node1), (node, node1), (node1, node)
            };
        }

        partial void XmlElementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlElementSyntax, XmlElementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single(),
                 (XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single())
            };
        }

        partial void XmlElementStartTagServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlElementStartTagSyntax, XmlElementStartTagSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag)
            };
        }

        partial void XmlElementEndTagServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlElementEndTagSyntax, XmlElementEndTagSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag)
            };
        }

        partial void XmlEmptyElementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlEmptyElementSyntax, XmlEmptyElementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single()),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single()),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single()),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single())
            };
        }

        partial void XmlNameServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlNameSyntax, XmlNameSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name),
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name)
            };
        }

        partial void XmlPrefixServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlPrefixSyntax, XmlPrefixSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix,
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix)
            };
        }

        partial void XmlTextAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlTextAttributeSyntax, XmlTextAttributeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0],
                 (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0])
            };
        }

        partial void XmlCrefAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlCrefAttributeSyntax, XmlCrefAttributeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0],
                 (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0])
            };
        }

        partial void XmlNameAttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlNameAttributeSyntax, XmlNameAttributeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0],
                 (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0])
            };
        }

        partial void XmlTextServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlTextSyntax, XmlTextSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0],
                 (XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0])
            };
        }

        partial void XmlCDataSectionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlCDataSectionSyntax, XmlCDataSectionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single())
            };
        }

        partial void XmlProcessingInstructionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlProcessingInstructionSyntax, XmlProcessingInstructionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single())
            };
        }

        partial void XmlCommentServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(XmlCommentSyntax, XmlCommentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single(),
                 ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single())
            };
        }

        partial void CompilationUnitServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CompilationUnitSyntax, CompilationUnitSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};"),
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};"))
            };
        }

        partial void ExternAliasDirectiveServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ExternAliasDirectiveSyntax, ExternAliasDirectiveSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0],
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0])
            };
        }

        partial void UsingDirectiveServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(UsingDirectiveSyntax, UsingDirectiveSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0],
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0]),
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using a; [assembly: XAttribute] namespace c{};").Usings[0],
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using a; [assembly: XAttribute] namespace c{};").Usings[0]),
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0],
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using a; [assembly: XAttribute] namespace c{};").Usings[0]),
                (SyntaxFactory.ParseCompilationUnit("extern alias b; using a; [assembly: XAttribute] namespace c{};").Usings[0],
                    SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0])
            };
        }

        partial void NamespaceDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(NamespaceDeclarationSyntax, NamespaceDeclarationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0],
                    (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0]),
                ((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0],
                    (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0]),
                ((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0],
                    (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0]),
                ((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0],
                    (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0])
            };
        }

        partial void AttributeListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AttributeListSyntax, AttributeListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0])
            };
        }

        partial void AttributeTargetSpecifierServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AttributeTargetSpecifierSyntax, AttributeTargetSpecifierSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target,
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target)
            };
        }

        partial void AttributeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AttributeSyntax, AttributeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0])
            };
        }

        partial void AttributeArgumentListServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AttributeArgumentListSyntax, AttributeArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList,
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList)
            };
        }

        partial void AttributeArgumentServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(AttributeArgumentSyntax, AttributeArgumentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),

                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y= 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y= 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y= 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0]),
                (SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y= 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0],
                    SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0])
            };
        }

        partial void WhenClauseServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(WhenClauseSyntax, WhenClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause,
                    ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause)
            };
        }

        partial void TupleTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TupleTypeSyntax, TupleTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)"),
                    (TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)"))
            };
        }

        partial void TupleExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TupleExpressionSyntax, TupleExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)"),
                    (TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)"))
            };
        }

        partial void TupleElementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(TupleElementSyntax, TupleElementSyntax)> nodeRevisionPairs)
        {
            var type = SyntaxFactory.ParseTypeName("(string, int)");
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a")),
                    SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a"))),
                (SyntaxFactory.TupleElement(type),
                    SyntaxFactory.TupleElement(type)),
                (SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a")),
                    SyntaxFactory.TupleElement(type)),
                (SyntaxFactory.TupleElement(type),
                    SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a")))
            };
        }

        partial void ThrowExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ThrowExpressionSyntax, ThrowExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e"),
                    (ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e"))
            };
        }

        partial void SingleVariableDesignationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(SingleVariableDesignationSyntax, SingleVariableDesignationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")))
            };
        }


        partial void DiscardDesignationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DiscardDesignationSyntax, DiscardDesignationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken)),
                    SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken)))
            };
        }

        partial void ParenthesizedVariableDesignationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ParenthesizedVariableDesignationSyntax, ParenthesizedVariableDesignationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
           {
                (SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[]
                {
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                     SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken))
                }),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken)),
                    SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[]
                {
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                     SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken))
                }),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken)))
            };
        }

        partial void RefExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(RefExpressionSyntax, RefExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d")),
                    SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d")))
            };
        }

        partial void CasePatternSwitchLabelServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(CasePatternSwitchLabelSyntax, CasePatternSwitchLabelSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0],
                    (CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0])
            };
        }

        partial void IsPatternExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(IsPatternExpressionSyntax, IsPatternExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a"),
                    (IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a"))
            };
        }

        partial void DeclarationExpressionServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DeclarationExpressionSyntax, DeclarationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression,
                    (DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression)
            };
        }

        partial void ForEachVariableStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ForEachVariableStatementSyntax, ForEachVariableStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}"),
                    (ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}"))
            };
        }

        partial void DeclarationPatternServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(DeclarationPatternSyntax, DeclarationPatternSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern,
                    (DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern)
            };
        }

        partial void ConstantPatternServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(ConstantPatternSyntax, ConstantPatternSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern,
                    (ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern)
            };
        }

        partial void LocalFunctionStatementServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(LocalFunctionStatementSyntax, LocalFunctionStatementSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local<T>() where T: I => 0;
                    }").Members[0]).Body.Statements[0],
                (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local<T>() where T: I => 0;
                    }").Members[0]).Body.Statements[0]),
                ((LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local(){}
                    }").Members[0]).Body.Statements[0],
                (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local(){}
                    }").Members[0]).Body.Statements[0]),
                ((LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local<T>() where T: I => 0;
                    }").Members[0]).Body.Statements[0],
                (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local(){}
                    }").Members[0]).Body.Statements[0]),
                ((LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local(){}
                    }").Members[0]).Body.Statements[0],
                (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        const int local<T>() where T: I => 0;
                    }").Members[0]).Body.Statements[0])
            };
        }

        partial void RefTypeServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(RefTypeSyntax, RefTypeSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                (SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var")),
                    SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var"))),
                (SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var")),
                    SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"))),
                (SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var")),
                    SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"))),
                (SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var")),
                    SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var")))
            };
        }

        [TestMethod]
        public void RoslynMLDeltaExpander_OK()
        {
            var thisFilePath = $"{System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "")}\\Flad.Awareness\\RoslynMLDeltaExpanderTests.Custom.cs";

            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            foreach (Action<RoslynML, XElement> defoliate in new List<Action<RoslynML, XElement>> { (r, n1) => { }, (r, n1) => r.Defoliate(n1) })
            {
                var oElement = converter.GetTree(thisFilePath, true, false);
                converter.Prune(oElement, selector.PruneSelector);
                defoliate(converter, oElement);

                var elementCount = oElement.PostOrder(n => n.Elements()).Count(n => n.Attribute("GtID") != null);

                var mElement = converter.GetTree(thisFilePath, true, false);
                converter.Prune(mElement, selector.PruneSelector);
                defoliate(converter, mElement);

                var oFullElement = converter.GetTree(thisFilePath, true, false);
                var mFullElement = converter.GetTree(thisFilePath, true, false);
                var fullElementCount = oFullElement.PostOrder(n => n.Elements()).Count(n => n.Attribute("GtID") != null);

                DeltaExpander expander = new DeltaExpander();

                var matches = oFullElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                           new XElement("Match",
                               new XAttribute("oId", n.GtID()),
                               new XAttribute("oLb", n.Label()),
                               new XAttribute("mId", n.GtID()),
                               new XAttribute("mLb", n.Label()))
                ).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches,
                    Actions: new XElement[0]));
                Assert.AreEqual(expander.FullDelta.Matches.Count(), fullElementCount);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 0);

                var a = expander.FullDelta.Matches.Except(matches).ToList();
                var r = expander.FullDelta.Matches.Select(m => m.Attribute("oId").Value)
                    .Except(matches.Select(m => m.Attribute("oId").Value))
                    .Select(m => matches.Single(m1 => m1.Attribute("oId").Value == m))
                    .ToList();

                var matches1 = oElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                        new XElement("Match",
                            new XAttribute("oId", n.GtID()),
                            new XAttribute("oLb", n.Label()),
                            new XAttribute("mId", n.GtID()),
                            new XAttribute("mLb", n.Label()))
                ).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches1,
                    Actions: new XElement[0]));

                a = expander.FullDelta.Matches.Except(matches).ToList();
                r = matches.Select(m => m.Attribute("oId").Value)
                    .Except(expander.FullDelta.Matches.Select(m => m.Attribute("oId").Value))
                    .Select(m => matches.Single(m1 => m1.Attribute("oId").Value == m))
                    .ToList();

                Assert.AreEqual(expander.FullDelta.Matches.Count(), fullElementCount);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 0);

                IEnumerable<XElement> insertions = mFullElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                        new XElement("Insert",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"),
                           new XAttribute("pId", n.GtID()),
                           new XAttribute("pLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("pos", "-1"))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: insertions));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), fullElementCount);

                IEnumerable<XElement> insertions1 = mElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                        new XElement("Insert",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"),
                           new XAttribute("pId", n.GtID()),
                           new XAttribute("pLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("pos", "-1"))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: insertions1));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), fullElementCount);

                IEnumerable<XElement> deletions = oFullElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                        new XElement("Delete",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: deletions));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), fullElementCount);

                IEnumerable<XElement> deletions1 = oElement.PostOrder(n => n.Elements()).Where(n => n.Attribute("GtID") != null).Select(n =>
                        new XElement("Delete",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: new XElement[0],
                     Actions: deletions1));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), fullElementCount);

                IEnumerable<XElement> updates = oFullElement.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                    .Where(n => n.Elements().Count(ne => ne is XNode) == 0 && n.Attribute("GtID") != null && n.Value != null)
                    .Select((n, i) =>
                        new XElement("Update",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"),
                           new XAttribute("val", i.ToString()))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches,
                     Actions: updates));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matches.Count());
                Assert.AreEqual(expander.FullDelta.Actions.Count(), updates.Count());

                IEnumerable<XElement> updates1 = oElement.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                    .Where(n => n.Elements().Count(ne => ne is XNode) == 0 && n.Attribute("GtID") != null && n.Value != null)
                    .Select((n, i) =>
                        new XElement("Update",
                           new XAttribute("eId", n.GtID()),
                           new XAttribute("eLb", n.Attribute("kind")?.Value ?? n.Name.LocalName),
                           new XAttribute("eVl", "##"),
                           new XAttribute("val", i.ToString()))).ToList();
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches1,
                     Actions: updates1));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matches.Count());
                Assert.AreEqual(expander.FullDelta.Actions.Count(), updates1.Count());

                var elementsToModify = mFullElement.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                    .Where(n => n.Elements().Count(ne => ne is XNode) == 0 && n.Attribute("GtID") != null && n.Value != null)
                    .Select((n, i) => new { n, v = i.ToString() }).ToList();
                elementsToModify.ForEach(em => em.n.Value = em.v);

                expander.Expand(
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches,
                     Actions: updates));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matches.Count());
                Assert.AreEqual(expander.FullDelta.Actions.Count(), updates.Count());

                var elementsToModify1 = mElement.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                    .Where(n => n.Elements().Count(ne => ne is XNode) == 0 && n.Attribute("GtID") != null && n.Value != null)
                    .Select((n, i) => new { n, v = i.ToString() });
                elementsToModify1.ForEach(em => em.n.Value = em.v);
                expander.Expand(
                    new RevisionPair<XElement> { Original = oElement, Modified = mElement },
                    new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement },
                    (Matches: matches1,
                     Actions: updates1));

                Assert.AreEqual(expander.FullDelta.Matches.Count(), matches.Count());
                Assert.AreEqual(expander.FullDelta.Actions.Count(), updates.Count());
            }            
        }
    }
}
