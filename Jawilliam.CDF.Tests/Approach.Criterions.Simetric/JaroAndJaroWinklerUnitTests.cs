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
    public sealed class JaroAndJaroWinklerUnitTests {
        #region Test Data Setup
        /// Test Data is taken from
        /// Approximate string Comparison and its Effect on an Advanced Record Linkage System
        /// Porter and Winkler 1997
        /// Chapter 6.
        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double JaroMatchLevel;
            public double JaroWinklerMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.JaroMatchLevel = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
                testName.JaroWinklerMatchLevel = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.jaroName1);
            AddNames(_addressSettings.jaroName2);
            AddNames(_addressSettings.jaroName3);
            AddNames(_addressSettings.jaroName4);
            AddNames(_addressSettings.jaroName5);
            AddNames(_addressSettings.jaroName6);
            AddNames(_addressSettings.jaroName7);
        }
        #endregion

        #region JaroSimetric Tests

        [TestMethod]
        [TestCategory("JaroSimetric Test")]
        public void JaroTestData() {
            foreach (TestRecord testRecord in _testNames) {
                Assert.AreEqual(testRecord.JaroMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myJaroSimetric.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with JaroSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        #region JaroWinklerSimetric tests

        [TestMethod]
        [TestCategory("JaroWinklerSimetric Test")]
        public void JaroWinklerTestData() {
            foreach (TestRecord testRecord in _testNames) {
                Assert.AreEqual(testRecord.JaroWinklerMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myJaroWinkler.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with JaroWinklerSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private JaroSimetric<char> _myJaroSimetric;
        private JaroWinklerSimetric<char> _myJaroWinkler;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myJaroSimetric = new JaroSimetric<char>();
            _myJaroWinkler = new JaroWinklerSimetric<char>();
        }
    }
}