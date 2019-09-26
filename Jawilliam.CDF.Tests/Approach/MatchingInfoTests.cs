using System.Collections.Generic;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Jawilliam.CDF.Tests.Approach.Base.FrameworkApproachTests;

namespace Jawilliam.CDF.Tests.Approach.Base
{
    [TestClass]
    public class MatchingInfoTests
    {
        [TestMethod]
        public void MatchingInfo_ConstructorEmpty_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();

            Assert.AreEqual(originalAnnotations.Annotations.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations.Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_ConstructorWithCapacity_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();

            Assert.AreEqual(originalAnnotations.Annotations.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations.Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_RemoveMatch_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5 });

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Unpair(3, 5);
            Assert.IsFalse(matchingSet.Paired(3, 5));

            Assert.IsNotNull(originalAnnotations);
            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 0);

            Assert.IsNotNull(modifiedAnnotations);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_Clear_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5 });

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Unpair(3, 5);
            Assert.IsFalse(matchingSet.Paired(3, 5));
            originalAnnotations.EndDetection();
            modifiedAnnotations.EndDetection();

            Assert.AreEqual(originalAnnotations.Annotations.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations.Count, 0);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedOriginalWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Originals.Unpaired(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedOriginalWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Originals.Unmatched(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedModifiedWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Modifieds.Unpaired(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedModifiedWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Modifieds.Unmatched(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedOriginalForNonOriginal_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            matchingSet.Originals.Unpaired(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedOriginalForNonOriginal_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            matchingSet.Originals.Unmatched(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedModifiedForNonModified_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            matchingSet.Modifieds.Unpaired(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedModifiedForNonModified_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            matchingSet.Modifieds.Unmatched(3);
        }

        [TestMethod]
        public void MatchingInfo_UnpairUndoesPair_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5 });

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            Assert.IsFalse(matchingSet.Originals.Unpaired(3));
            Assert.IsTrue(matchingSet.Originals.Unmatched(3));
            Assert.IsFalse(matchingSet.Modifieds.Unpaired(5));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(5));
            matchingSet.Unpair(3, 5);
            Assert.IsTrue(matchingSet.Originals.Unpaired(3));
            Assert.IsTrue(matchingSet.Originals.Unmatched(3));
            Assert.IsTrue(matchingSet.Modifieds.Unpaired(5));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(5));

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 0);
        }

        [TestMethod]
        public void MatchingInfo_MultiplePairs_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5, 6 });

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 6 });
            Assert.IsTrue(matchingSet.Paired(3, 6));
            Assert.IsFalse(matchingSet.Originals.Unpaired(3));
            Assert.IsTrue(matchingSet.Originals.Unmatched(3));
            Assert.IsFalse(matchingSet.Modifieds.Unpaired(5));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(5));
            Assert.IsFalse(matchingSet.Modifieds.Unpaired(6));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 2);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Candidates.Count, 1);
        }

        [TestMethod]
        public void MatchingInfo_MultiplePairsThenNewPartner_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5, 6, 4 });

            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 5 });
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 6 });
            Assert.IsTrue(matchingSet.Paired(3, 6));
            matchingSet.Partners(new MatchInfo<int>(-1) { Original = 3, Modified = 4 });
            Assert.IsTrue(matchingSet.Paired(3, 4));
            Assert.IsFalse(matchingSet.Paired(3, 5));
            Assert.IsFalse(matchingSet.Paired(3, 6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Candidates.Count, 1);

            Assert.IsFalse(matchingSet.Originals.Unmatched(3));
            Assert.IsFalse(matchingSet.Originals.Unpaired(3));
            Assert.IsFalse(matchingSet.Modifieds.Unmatched(4));
            Assert.IsFalse(matchingSet.Modifieds.Unpaired(4));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(5));
            Assert.IsTrue(matchingSet.Modifieds.Unpaired(5));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(6));
            Assert.IsTrue(matchingSet.Modifieds.Unpaired(6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Partner<int, Annotation<int>>(true), 4);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Partner<int, Annotation<int>>(false), 3);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Partner<int, Annotation<int>>(false), 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Partner<int, Annotation<int>>(false), 0);
        }

        [TestMethod]
        public void MatchingInfo_MultiplePairsThenExistingPartner_OK()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            originalAnnotations.Init(new[] { 3 });
            modifiedAnnotations.Init(new[] { 5, 6, 4 });

            var match = new MatchInfo<int>(-1) { Original = 3, Modified = 5 };
            matchingSet.Pair(match);
            matchingSet.Pair(new MatchInfo<int>(-1) { Original = 3, Modified = 6 });
            matchingSet.Partners(match);

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Candidates.Count, 0);

            Assert.IsFalse(matchingSet.Originals.Unmatched(3));
            Assert.IsFalse(matchingSet.Originals.Unpaired(3));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(4));
            Assert.IsTrue(matchingSet.Modifieds.Unpaired(4));
            Assert.IsFalse(matchingSet.Modifieds.Unmatched(5));
            Assert.IsFalse(matchingSet.Modifieds.Unpaired(5));
            Assert.IsTrue(matchingSet.Modifieds.Unmatched(6));
            Assert.IsTrue(matchingSet.Modifieds.Unpaired(6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Partner<int, Annotation<int>>(true), 5);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Partner<int, Annotation<int>>(false), 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Partner<int, Annotation<int>>(false), 3);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Partner<int, Annotation<int>>(false), 0);
        }
    }
}
