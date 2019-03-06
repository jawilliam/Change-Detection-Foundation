/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
  namespaces, code guidelines (naming and mode...)
  
  Removing tests related with descriptions*/

using System;
using System.Collections.Generic;
using System.Globalization;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.Data.Simetric.Tests
{
    [TestClass]
    public class ChapmanLengthDeviationUnitTests
    {
        #region Test Data Setup

        private struct TestRecord {
            public string NameOne;
            public string NameTwo;
            public double ChapmanLengthMatchLevel;
        }

        Settings addressSettings = Settings.Default;
        List<TestRecord> testNames = new List<TestRecord>(26);

        void AddNames(string addChars) {
            if (addChars != null) {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.ChapmanLengthMatchLevel = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
                testNames.Add(testName);
            }
        }

        void LoadData() {
            AddNames(addressSettings.blockDistance1);
            AddNames(addressSettings.blockDistance2);
            AddNames(addressSettings.blockDistance3);
            AddNames(addressSettings.jaroName1);
            AddNames(addressSettings.jaroName2);
            AddNames(addressSettings.jaroName3);
            AddNames(addressSettings.jaroName4);
            AddNames(addressSettings.jaroName5);
            AddNames(addressSettings.jaroName6);
            AddNames(addressSettings.jaroName7);
        }
        #endregion

        #region Chapman Deviation Tests

        [TestMethod]
        [TestCategory("Chapman Length Deviation Test")]
        public void ChapmanLengthDeviation_TestData() {
            foreach (TestRecord testRecord in testNames) {
                Assert.AreEqual(testRecord.ChapmanLengthMatchLevel.ToString("F3", CultureInfo.InvariantCulture),
                                _myChapmanLengthDeviation.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
                                "Problem with Chapman Length Deviation test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        private ChapmanLengthDeviation<char> _myChapmanLengthDeviation;

        [TestInitialize]
        public void SetUp() {
            LoadData();
            _myChapmanLengthDeviation = new ChapmanLengthDeviation<char>();
        }
    }
}