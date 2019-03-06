/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
  namespaces, code guidelines (naming and mode...)
  
  Removing tests related with descriptions*/

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Tests.Properties;

namespace Jawilliam.CDF.Tests.Approach.Criterions.Simetric
{
    [TestClass]
    public class BlockDistanceUnitTests {
        #region Test Data Setup
        struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double BlockDistanceMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.BlockDistanceMatchLevel = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
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
        [TestCategory("BlockDistance Test")]
        public void BlockDistanceTestData()
        {
            _myBlockDistance.GetComponents = VectorComponents.ByTermFrequency;
            foreach (TestRecord testRecord in _testNames)
            {
                double? distance;
                var similarity = _myBlockDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo, out distance);

                var total = testRecord.NameOne.Length + testRecord.NameTwo.Length;
                var similarity2 = 1 - distance.Value / total;

                Assert.AreEqual(testRecord.BlockDistanceMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                similarity2.ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with BlockDistance test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private BlockDistanceSimetric<char> _myBlockDistance;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myBlockDistance = new BlockDistanceSimetric<char>();
        }
    }
}