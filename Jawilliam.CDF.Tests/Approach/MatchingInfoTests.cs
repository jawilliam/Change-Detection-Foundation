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

            matchingSet.Pair(3, 5);
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

            matchingSet.Pair(3, 5);
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

            matchingSet.UnpairedOriginal(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedOriginalWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.UnmatchedOriginal(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedModifiedWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.UnpairedModified(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedModifiedWithoutInit_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.UnmatchedModified(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedOriginalForNonOriginal_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(3, 5);
            matchingSet.UnpairedOriginal(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedOriginalForNonOriginal_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(3, 5);
            matchingSet.UnmatchedOriginal(5);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnpairedModifiedForNonModified_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(3, 5);
            matchingSet.UnpairedModified(3);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void MatchingInfo_UnmatchedModifiedForNonModified_Fails()
        {
            var approach = new MyApproach();
            var originalAnnotations = approach.Originals<int, Annotation<int>>();
            var modifiedAnnotations = approach.Modifieds<int, Annotation<int>>();
            var matchingSet = approach.GetServiceOrThrowsException<IMatchingSetService<int>>((int)ServiceId.MatchingSet);

            matchingSet.Pair(3, 5);
            matchingSet.UnmatchedModified(3);
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

            matchingSet.Pair(3, 5);
            Assert.IsFalse(matchingSet.UnpairedOriginal(3));
            Assert.IsTrue(matchingSet.UnmatchedOriginal(3));
            Assert.IsFalse(matchingSet.UnpairedModified(5));
            Assert.IsTrue(matchingSet.UnmatchedModified(5));
            matchingSet.Unpair(3, 5);
            Assert.IsTrue(matchingSet.UnpairedOriginal(3));
            Assert.IsTrue(matchingSet.UnmatchedOriginal(3));
            Assert.IsTrue(matchingSet.UnpairedModified(5));
            Assert.IsTrue(matchingSet.UnmatchedModified(5));

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

            matchingSet.Pair(3, 5);
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Pair(3, 6);
            Assert.IsTrue(matchingSet.Paired(3, 6));
            Assert.IsFalse(matchingSet.UnpairedOriginal(3));
            Assert.IsTrue(matchingSet.UnmatchedOriginal(3));
            Assert.IsFalse(matchingSet.UnpairedModified(5));
            Assert.IsTrue(matchingSet.UnmatchedModified(5));
            Assert.IsFalse(matchingSet.UnpairedModified(6));
            Assert.IsTrue(matchingSet.UnmatchedModified(6));

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

            matchingSet.Pair(3, 5);
            Assert.IsTrue(matchingSet.Paired(3, 5));
            matchingSet.Pair(3, 6);
            Assert.IsTrue(matchingSet.Paired(3, 6));
            matchingSet.Partners(3, 4);
            Assert.IsTrue(matchingSet.Paired(3, 4));
            Assert.IsFalse(matchingSet.Paired(3, 5));
            Assert.IsFalse(matchingSet.Paired(3, 6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Candidates.Count, 1);

            Assert.IsFalse(matchingSet.UnmatchedOriginal(3));
            Assert.IsFalse(matchingSet.UnpairedOriginal(3));
            Assert.IsFalse(matchingSet.UnmatchedModified(4));
            Assert.IsFalse(matchingSet.UnpairedModified(4));
            Assert.IsTrue(matchingSet.UnmatchedModified(5));
            Assert.IsTrue(matchingSet.UnpairedModified(5));
            Assert.IsTrue(matchingSet.UnmatchedModified(6));
            Assert.IsTrue(matchingSet.UnpairedModified(6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Partner, 4);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Partner, 3);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Partner, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Partner, 0);
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

            matchingSet.Pair(3, 5);
            matchingSet.Pair(3, 6);
            matchingSet.Partners(3, 5);

            Assert.AreEqual(originalAnnotations.Annotations[3].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Candidates.Count, 1);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Candidates.Count, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Candidates.Count, 0);

            Assert.IsFalse(matchingSet.UnmatchedOriginal(3));
            Assert.IsFalse(matchingSet.UnpairedOriginal(3));
            Assert.IsTrue(matchingSet.UnmatchedModified(4));
            Assert.IsTrue(matchingSet.UnpairedModified(4));
            Assert.IsFalse(matchingSet.UnmatchedModified(5));
            Assert.IsFalse(matchingSet.UnpairedModified(5));
            Assert.IsTrue(matchingSet.UnmatchedModified(6));
            Assert.IsTrue(matchingSet.UnpairedModified(6));

            Assert.AreEqual(originalAnnotations.Annotations[3].Partner, 5);
            Assert.AreEqual(modifiedAnnotations.Annotations[4].Partner, 0);
            Assert.AreEqual(modifiedAnnotations.Annotations[5].Partner, 3);
            Assert.AreEqual(modifiedAnnotations.Annotations[6].Partner, 0);
        }
    }
}
