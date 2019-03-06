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
    public sealed class CosineSimilarityUnitTests {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double CosineSimilarityMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.CosineSimilarityMatchLevel = Convert.ToDouble(letters[6], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region Block Distance Tests

        [TestMethod]
        [TestCategory("CosineSimilarity Test")]
        public void CosineSimilarityTestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.CosineSimilarityMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myCosineSimilarity.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                string.Format("{0}CosineSimilarity{1}{2}{3}{4}", Environment.NewLine, Environment.NewLine,
                                              testRecord.NameOne, Environment.NewLine, testRecord.NameTwo));
            }
        }
        #endregion

        private CosineSimetric<char> _myCosineSimilarity;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myCosineSimilarity = new CosineSimetric<char>();
        }
    }
}