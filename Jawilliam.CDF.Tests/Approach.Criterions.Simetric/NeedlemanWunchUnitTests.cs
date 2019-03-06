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
    public sealed class NeedlemanWunchUnitTests {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double NeedlemanWunchMatchLevel;
        }

        private readonly Settings _addressSettings = Settings.Default;
        private readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.NeedlemanWunchMatchLevel = Convert.ToDouble(letters[11], CultureInfo.InvariantCulture);
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

        #region NeedlemanWunschSimetric Tests

        [TestMethod]
        [TestCategory("NeedlemanWunschSimetric Test")]
        public void NeedlemanWunch_TestData() {
            foreach (TestRecord testRecord in _testNames) {
                Assert.AreEqual(testRecord.NeedlemanWunchMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myNeedlemanWunschSimetric.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with NeedlemanWunschSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private NeedlemanWunschSimetric<char> _myNeedlemanWunschSimetric;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myNeedlemanWunschSimetric = new NeedlemanWunschSimetric<char>();
        }
    }
}