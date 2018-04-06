using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Jawilliam.CDF.Labs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jawilliam.CDF.Labs.DBModel;

namespace Jawilliam.CDF.Tests.Labs
{
    /// <summary>
    /// Summary description for BetweenComparisonTests
    /// </summary>
    [TestClass]
    public class BetweenComparisonTests
    {
        [TestMethod]
        public void LRMatchInfoGumTreeAndReverse_WithoutCounterpart_OK()
        {
            var recognizer = new BetweenComparison();
            recognizer.ConfigGumTreeVsReversedGumTree();
            var leftDelta = new Delta
            {
                Id = Guid.Parse("43C1AD04-1FBD-486E-8C49-0021D5437DF1"),
                Approach = recognizer.Config.Left,
                Matching = "<Matches>" +
                                "<Match oId=\"301\" mId=\"326\" oLb=\"type\" mLb=\"type\"/>" +
                                "<Match oId=\"302\" mId=\"327\" oLb=\"name\" oVl=\"sender\" mLb=\"name\" mVl=\"sender\"/>" +
                           "</Matches>",
                Differencing = "<Actions/>",
                OriginalTree = "<Item eId=\"301\" eLb=\"unit\">" +
                                    "<Item eId=\"302\" eLb=\"using\"/>" +
                               "</Item>",
                ModifiedTree = "<Item eId=\"326\" eLb=\"unit\">" +
                                    "<Item eId=\"327\" eLb=\"using\"/>" +
                               "</Item>"
            };
            var rightDelta = new Delta
            {
                Id = Guid.Parse("43C1AD04-1FBD-486E-8C49-0025D5437DF1"),
                Approach = recognizer.Config.Right,
                Matching = "<Matches>" +
                                "<Match oId=\"326\" mId=\"301\" oLb=\"type\" mLb=\"type\"/>" +
                                "<Match oId=\"328\" mId=\"302\" oLb=\"name\" oVl=\"sender\" mLb=\"name\" mVl=\"sender\"/>" +
                           "</Matches>",
                Differencing = "<Actions/>",
                ModifiedTree = "<Item eId=\"301\" eLb=\"unit\">" +
                                    "<Item eId=\"302\" eLb=\"using\"/>" +
                               "</Item>",
                OriginalTree = "<Item eId=\"326\" eLb=\"unit\">" +
                                    "<Item eId=\"328\" eLb=\"using\"/>" +
                               "</Item>"
            };
            var result = recognizer.Compare(leftDelta, rightDelta, new CancellationToken()).ToList();
            Assert.AreEqual(result.Count, 2);

            Assert.AreEqual(((LRMatchSymptom)result[0]).Left.PartName, recognizer.Config.LeftName);
            Assert.AreEqual(((LRMatchSymptom)result[0]).Left.Original.Element.Id, "302");
            Assert.AreEqual(((LRMatchSymptom)result[0]).Left.Modified.Element.Id, "327");
            Assert.AreEqual(((LRMatchSymptom)result[0]).OriginalAtRight.PartName, recognizer.Config.RightName);
            Assert.AreEqual(((LRMatchSymptom)result[0]).OriginalAtRight.Original.Element.Id, "328");
            Assert.AreEqual(((LRMatchSymptom)result[0]).OriginalAtRight.Modified.Element.Id, "302");
            Assert.AreEqual(((LRMatchSymptom)result[0]).ModifiedAtRight.PartName, recognizer.Config.RightName);
            Assert.AreEqual(((LRMatchSymptom)result[0]).ModifiedAtRight.Original.Element.Id, "-1");
            Assert.AreEqual(((LRMatchSymptom)result[0]).ModifiedAtRight.Modified.Element.Id, "-1");

            Assert.AreEqual(((RLMatchSymptom)result[1]).Right.PartName, recognizer.Config.RightName);
            Assert.AreEqual(((RLMatchSymptom)result[1]).Right.Original.Element.Id, "328");
            Assert.AreEqual(((RLMatchSymptom)result[1]).Right.Modified.Element.Id, "302");
            Assert.AreEqual(((RLMatchSymptom)result[1]).OriginalAtLeft.PartName, recognizer.Config.LeftName);
            Assert.AreEqual(((RLMatchSymptom)result[1]).OriginalAtLeft.Original.Element.Id, "-1");
            Assert.AreEqual(((RLMatchSymptom)result[1]).OriginalAtLeft.Modified.Element.Id, "-1");
            Assert.AreEqual(((RLMatchSymptom)result[1]).ModifiedAtLeft.PartName, recognizer.Config.LeftName);
            Assert.AreEqual(((RLMatchSymptom)result[1]).ModifiedAtLeft.Original.Element.Id, "302");
            Assert.AreEqual(((RLMatchSymptom)result[1]).ModifiedAtLeft.Modified.Element.Id, "327");
        }
    }
}
