/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
  namespaces, code guidelines (naming and mode...)
  
  Removing tests related with descriptions*/

using System;
using System.Collections.Generic;
using System.Globalization;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.Data.Simetric.Tests {
    [TestClass]
    public class QGramDistanceUnitTests {
        #region Test Data Setup
        struct TestRecord {
            public TestRecord(string firstName, string secondNamem, double scoreOne, double scoreTwo, double scoreThree,
                              double scoreFour) {
                NameOne = firstName;
                NameTwo = secondNamem;
                TrigramExtendedDistanceMatchLevel = scoreOne;
                TrigramDistanceMatchLevel = scoreTwo;
                BigramExtendedDistanceMatchLevel = scoreThree;
                BigramDistanceMatchLevel = scoreFour;
            }

            public override string ToString() {
                return
                    NameOne + " : " + NameTwo + " : " + TrigramExtendedDistanceMatchLevel + " : " + TrigramDistanceMatchLevel +
                    " : " + BigramExtendedDistanceMatchLevel + " : " + BigramDistanceMatchLevel;
            }

            public string NameOne { get; }
            public string NameTwo { get; }
            public double TrigramExtendedDistanceMatchLevel { get; }
            public double TrigramDistanceMatchLevel { get; }
            public double BigramExtendedDistanceMatchLevel { get; }
            public double BigramDistanceMatchLevel { get; }
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName =
                    new TestRecord(letters[0], 
                    letters[1], 
                    Convert.ToDouble(letters[12], CultureInfo.InvariantCulture), 
                    Convert.ToDouble(letters[7], CultureInfo.InvariantCulture),
                    Convert.ToDouble(letters[8], CultureInfo.InvariantCulture), 
                    Convert.ToDouble(letters[9], CultureInfo.InvariantCulture));
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        //#region TrigramExtendedDistance Tests
        //[TestMethod]
        //[TestCategory("TrigramExtendedDistance Test")]
        //public void TrigramExtendedDistance_TestData()
        //{
        //    foreach (TestRecord testRecord in _testNames)
        //    {
        //        Assert.AreEqual(testRecord.TrigramExtendedDistanceMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
        //                        _myTrigramExtendedDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
        //                        string.Format("{0} TrigramExtendedDistance {1} {2}{3}{4}", Environment.NewLine,
        //                                      Environment.NewLine, testRecord.NameOne, Environment.NewLine, testRecord.NameTwo));
        //    }
        //}
        //#endregion

        #region TrigramDistance Tests
        [TestMethod]
        [TestCategory("TrigramDistance Test")]
        public void TrigramDistance_TestData() {
            foreach (TestRecord testRecord in _testNames) {
                Assert.AreEqual(testRecord.TrigramDistanceMatchLevel
                        .ToString("F3", CultureInfo.InvariantCulture),
                                _myTrigramDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo)
                                    .ToString("F3", CultureInfo.InvariantCulture),
                                string.Format("{0} TrigramDistance {1} {2}{3}{4}", 
                                    Environment.NewLine, Environment.NewLine,
                                              testRecord.NameOne,
                                              Environment.NewLine,
                                              testRecord.NameTwo));
            }
        }
        #endregion

        //#region BigramExtendedDistance Tests
        //[TestMethod]
        //[TestCategory("BigramExtendedDistance Test")]
        //public void BigramExtendedDistance_TestData()
        //{
        //    foreach (TestRecord testRecord in _testNames)
        //    {
        //        Assert.AreEqual(testRecord.BigramExtendedDistanceMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
        //                        _myBigramExtendedDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
        //                        string.Format("{0} BigramExtendedDistance {1} {2}{3}{4}", Environment.NewLine,
        //                                      Environment.NewLine, testRecord.NameOne, Environment.NewLine, testRecord.NameTwo));
        //    }
        //}
        //#endregion

        #region BigramDistance Tests
        [TestMethod]
        [TestCategory("BigramDistance Test")]
        public void BigramDistance_TestData() {
            foreach (TestRecord testRecord in _testNames) {
                Assert.AreEqual(testRecord.BigramDistanceMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myBigramDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                string.Format("{0} BigramDistance {1} {2}{3}{4}", Environment.NewLine, Environment.NewLine,
                                              testRecord.NameOne, Environment.NewLine, testRecord.NameTwo));
            }
        }
        #endregion

        //private NGramsSimetric<char> _myTrigramExtendedDistance;
        private NGramsSimetric<char> _myTrigramDistance;
        private NGramsSimetric<char> _myBigramExtendedDistance;
        private NGramsSimetric<char> _myBigramDistance;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            // default is TokenizerQGram3Extended
            //_myTrigramExtendedDistance = new NGramsSimetric<char>();
            _myTrigramDistance = new NGramsSimetric<char>(3);
            //_myBigramExtendedDistance = new NGramsSimetric<char>(new TokenizerQGram2Extended<char>());
            _myBigramDistance = new NGramsSimetric<char>(2);
        }
    }
}