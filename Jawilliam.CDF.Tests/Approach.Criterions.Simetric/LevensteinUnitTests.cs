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
    public class LevensteinUnitTests {
        #region Test Data Setup
        struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double LevensteinMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.LevensteinMatchLevel = Convert.ToDouble(letters[10], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
            AddNames(_addressSettings.jaroName1);
            AddNames(_addressSettings.jaroName2);
            AddNames(_addressSettings.jaroName3);
            AddNames(_addressSettings.jaroName4);
            AddNames(_addressSettings.jaroName5);
            AddNames(_addressSettings.jaroName6);
            AddNames(_addressSettings.jaroName7);
        }
        #endregion

        #region LevenshteinSimetric Tests

        [TestMethod]
        [TestCategory("LevenshteinSimetric Test")]
        public void Levenstein_TestData() {
            foreach (TestRecord testRecord in _testNames)
            {
                var similarity = _myLevenshteinSimetric.GetSimilarity(testRecord.NameOne, testRecord.NameTwo);
                Assert.AreEqual(testRecord.LevensteinMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                similarity.ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with LevenshteinSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private LevenshteinSimetric<char> _myLevenshteinSimetric;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myLevenshteinSimetric = new LevenshteinSimetric<char>();
        }
    }
}