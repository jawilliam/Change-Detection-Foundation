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
    public sealed class MatchingCoefficientUnitTests {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double MatchingCoefficientMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.MatchingCoefficientMatchLevel = Convert.ToDouble(letters[16], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region SimpleMatchingCoefficientSimetric Tests

        [TestMethod]
        [TestCategory("SimpleMatchingCoefficientSimetric Test")]
        public void MatchingCoefficient_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.MatchingCoefficientMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _mySimpleMatchingCoefficientSimetric.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with SimpleMatchingCoefficientSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        #endregion

        private SimpleMatchingCoefficientSimetric<char> _mySimpleMatchingCoefficientSimetric;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _mySimpleMatchingCoefficientSimetric = new SimpleMatchingCoefficientSimetric<char>();
        }
    }
}