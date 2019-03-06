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
    public sealed class EuclideanDistanceUnitTests {
        #region Test Data Setup
        struct TestRecord {
            public string nameOne;
            public string nameTwo;
            public double euclideanDistanceMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.nameOne = letters[0];
                testName.nameTwo = letters[1];
                testName.euclideanDistanceMatchLevel = Convert.ToDouble(letters[14], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region EuclideanDistance Tests

        [TestMethod]
        [TestCategory("EuclideanDistance Test")]
        public void EuclideanDistance_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.euclideanDistanceMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myEuclideanDistance.GetSimilarity(testRecord.nameOne, testRecord.nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with EuclideanDistance test - " + testRecord.nameOne + ' ' + testRecord.nameTwo);
            }
        }
        #endregion

        private EuclideanDistanceSimetric<char> _myEuclideanDistance;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myEuclideanDistance = new EuclideanDistanceSimetric<char>();
        }
    }
}