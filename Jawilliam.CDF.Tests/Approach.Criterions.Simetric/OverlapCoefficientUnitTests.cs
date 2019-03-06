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
    public sealed class OverlapCoefficientUnitTests {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double OverlapCoefficientMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.OverlapCoefficientMatchLevel = Convert.ToDouble(letters[18], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region OverlapCoefficientSimetric Tests

        [TestMethod]
        [TestCategory("OverlapCoefficientSimetric Test")]
        public void OverlapCoefficient_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.OverlapCoefficientMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myOverlapCoefficient.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with OverlapCoefficientSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private OverlapCoefficientSimetric<char> _myOverlapCoefficient;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myOverlapCoefficient = new OverlapCoefficientSimetric<char>();
        }
    }
}