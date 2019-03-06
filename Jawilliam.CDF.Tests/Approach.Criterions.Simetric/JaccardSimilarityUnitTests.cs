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
    public sealed class JaccardSimilarityUnitTests {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double JaccardSimilarityMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.JaccardSimilarityMatchLevel = Convert.ToDouble(letters[15], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region JaccardSimilarity Tests

        [TestMethod]
        [TestCategory("JaccardSimilarity Test")]
        public void JaccardSimilarity_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.JaccardSimilarityMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myJaccardSimetric.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with JaccardSimilarity test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        RuzickaSimetric<char> _myJaccardSimetric;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myJaccardSimetric = new RuzickaSimetric<char>();
        }
    }
}