using System;
using System.Collections.Generic;
using Jawilliam.CDF.Approach;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.Base
{
    [TestClass]
    public class MatchingInfoTests
    {
        [TestMethod]
        public void MatchingInfo_ConstructorEmpty_OK()
        {
            var matchingInfo = new MatchingInfo<int>();

            Assert.IsNotNull(matchingInfo.OriginalMatches);
            Assert.AreEqual(matchingInfo.OriginalMatches.Count, 0);

            Assert.IsNotNull(matchingInfo.ModifiedMatches);
            Assert.AreEqual(matchingInfo.ModifiedMatches.Count, 0);

            Assert.AreEqual(matchingInfo.OriginalMatches.Count, matchingInfo.ModifiedMatches.Count);
        }

        [TestMethod]
        public void MatchingInfo_ConstructorWithCapacity_OK()
        {
            int capacity = 23;
            var matchingInfo = new MatchingInfo<int>(capacity);

            Assert.IsNotNull(matchingInfo.OriginalMatches);
            Assert.AreEqual(matchingInfo.OriginalMatches.Count, 0);

            Assert.IsNotNull(matchingInfo.ModifiedMatches);
            Assert.AreEqual(matchingInfo.ModifiedMatches.Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_RemoveMatch_OK()
        {
            var matchingInfo = new MatchingInfo<int>();

            matchingInfo.AddMatch(3, 5);
            matchingInfo.RemoveMatch(3, 5);

            Assert.IsNotNull(matchingInfo.OriginalMatches);
            Assert.AreEqual(matchingInfo.OriginalMatches[3].Count, 0);

            Assert.IsNotNull(matchingInfo.ModifiedMatches);
            Assert.AreEqual(matchingInfo.ModifiedMatches[5].Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_Clear_OK()
        {
            var matchingInfo = new MatchingInfo<int>();

            matchingInfo.AddMatch(3, 5);
            matchingInfo.RemoveMatch(3, 5);
            matchingInfo.Clear();

            Assert.IsNotNull(matchingInfo.OriginalMatches);
            Assert.AreEqual(matchingInfo.OriginalMatches.Count, 0);

            Assert.IsNotNull(matchingInfo.ModifiedMatches);
            Assert.AreEqual(matchingInfo.ModifiedMatches.Count, 0);
        }
    }
}
