///*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
//  namespaces, code guidelines (naming and mode...)
  
//  Removing tests related with descriptions*/

//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using Jawilliam.Data.Mining.Simetric;
//using Jawilliam.Data.Simetric;
//using Jawilliam.Data.Mining.Tests.Properties;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Jawilliam.Data.Simetric.Tests
//{
//    [TestClass]
//    public class SmithWatermanUnitTests
//    {
//        #region Test Data Setup
//        struct SwTestRecord
//        {
//            public string NameOne;
//            public string NameTwo;
//            public double SwDefault;
//            public double SwCost;
//            public double SwCostFunction;
//            public double SwCostAndCostFunction;
//        }

//        struct SwgTestRecord
//        {
//            public string NameOne;
//            public string NameTwo;
//            public double SwgDefault;
//            public double SwgGapCostFunction;
//            public double SwgCostFunction;
//            public double SwgGapCostAndCostFunctions;
//        }

//        struct SwgaTestRecord
//        {
//            public string NameOne;
//            public string NameTwo;
//            public double SwgaDefault;
//            public double SwgaWindowSize;
//            public double SwgaGapCostFunction;
//            public double SwgaGapCostFunctionAndWindowSize;
//            public double SwgaGapCostAndCostFunctions;
//            public double SwgaGapCostAndCostFunctionsAndWindowSize;
//            public double SwgaCostFunction;
//            public double SwgaCostFunctionAndWindowSize;
//        }

//        private readonly Settings _addressSettings = Settings.Default;
//        private readonly List<SwTestRecord> _swTestNames = new List<SwTestRecord>(26);
//        private readonly List<SwgTestRecord> _swgTestNames = new List<SwgTestRecord>(26);
//        private readonly List<SwgaTestRecord> _swgaTestNames = new List<SwgaTestRecord>(26);

//        void swAddNames(string addChars)
//        {
//            if (addChars != null)
//            {
//                string[] letters = addChars.Split(',');
//                SwTestRecord testName;
//                testName.NameOne = letters[0];
//                testName.NameTwo = letters[1];
//                testName.SwDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
//                testName.SwCost = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
//                testName.SwCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
//                testName.SwCostAndCostFunction = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
//                _swTestNames.Add(testName);
//            }
//        }

//        void swgAddNames(string addChars)
//        {
//            if (addChars != null)
//            {
//                string[] letters = addChars.Split(',');
//                SwgTestRecord testName;
//                testName.NameOne = letters[0];
//                testName.NameTwo = letters[1];
//                testName.SwgDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
//                testName.SwgGapCostFunction = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
//                testName.SwgCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
//                testName.SwgGapCostAndCostFunctions = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
//                _swgTestNames.Add(testName);
//            }
//        }

//        void swgaAddNames(string addChars)
//        {
//            if (addChars != null)
//            {
//                string[] letters = addChars.Split(',');
//                SwgaTestRecord testName;
//                testName.NameOne = letters[0];
//                testName.NameTwo = letters[1];
//                testName.SwgaDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
//                testName.SwgaWindowSize = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
//                testName.SwgaGapCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
//                testName.SwgaGapCostFunctionAndWindowSize = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
//                testName.SwgaGapCostAndCostFunctions = Convert.ToDouble(letters[6], CultureInfo.InvariantCulture);
//                testName.SwgaGapCostAndCostFunctionsAndWindowSize = Convert.ToDouble(letters[7], CultureInfo.InvariantCulture);
//                testName.SwgaCostFunction = Convert.ToDouble(letters[8], CultureInfo.InvariantCulture);
//                testName.SwgaCostFunctionAndWindowSize = Convert.ToDouble(letters[9], CultureInfo.InvariantCulture);
//                _swgaTestNames.Add(testName);
//            }
//        }

//        void LoadData()
//        {
//            swAddNames(_addressSettings.swName1);
//            swAddNames(_addressSettings.swName2);
//            swAddNames(_addressSettings.swName3);
//            swAddNames(_addressSettings.swName4);
//            swAddNames(_addressSettings.swName5);
//            swAddNames(_addressSettings.swName6);
//            swAddNames(_addressSettings.swName7);

//            swgAddNames(_addressSettings.swgName1);
//            swgAddNames(_addressSettings.swgName2);
//            swgAddNames(_addressSettings.swgName3);
//            swgAddNames(_addressSettings.swgName4);
//            swgAddNames(_addressSettings.swgName5);
//            swgAddNames(_addressSettings.swgName6);
//            swgAddNames(_addressSettings.swgName7);

//            swgaAddNames(_addressSettings.swgaName1);
//            swgaAddNames(_addressSettings.swgaName2);
//            swgaAddNames(_addressSettings.swgaName3);
//            swgaAddNames(_addressSettings.swgaName4);
//            swgaAddNames(_addressSettings.swgaName5);
//            swgaAddNames(_addressSettings.swgaName6);
//            swgaAddNames(_addressSettings.swgaName7);
//            swgaAddNames(_addressSettings.swgaName8);
//        }
//        #endregion

//        #region SmithWatermanSimetric Tests

//        [TestMethod]
//        [TestCategory("SmithWatermanSimetric")]
//        public void SmithWatermanDefaultTestData()
//        {
//            foreach (SwTestRecord testRecord in _swTestNames)
//            {
//                Assert.AreEqual(testRecord.SwDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanSimetric")]
//        public void SmithWatermanCostTestData()
//        {
//            foreach (SwTestRecord testRecord in _swTestNames)
//            {
//                Assert.AreEqual(testRecord.SwDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanCost.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanSimetric")]
//        public void SmithWatermanCostFunctionTestData()
//        {
//            foreach (SwTestRecord testRecord in _swTestNames)
//            {
//                Assert.AreEqual(testRecord.SwDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanSimetric")]
//        public void SmithWatermanCostAndCostFunctionTestData()
//        {
//            foreach (SwTestRecord testRecord in _swTestNames)
//            {
//                Assert.AreEqual(testRecord.SwDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanCostAndCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
//                                    ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanSimetric test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }
//        #endregion

//        #region SmithWatermanGotoh tests

//        [TestMethod]
//        [TestCategory("SmithWatermanGotoh")]
//        public void SmithWatermanGotohDefaultTestData()
//        {
//            foreach (SwgTestRecord testRecord in _swgTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanGotohDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanGotoh")]
//        public void SmithWatermanGotoGapCostFunctionTestData()
//        {
//            foreach (SwgTestRecord testRecord in _swgTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgGapCostFunction.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanGotohGapCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
//                                    ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanGotoh")]
//        public void SmithWatermanGotoCostFunctionTestData()
//        {
//            foreach (SwgTestRecord testRecord in _swgTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgCostFunction.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanGotohCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
//                                    "F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SmithWatermanGotoh")]
//        public void SmithWatermanGotoGapCostAndCostFunctionsTestData()
//        {
//            foreach (SwgTestRecord testRecord in _swgTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgGapCostAndCostFunctions.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySmithWatermanGotohGapCostAndCostFunctions.GetSimilarity(testRecord.NameOne, testRecord.NameTwo)
//                                    .ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }
//        #endregion

//        #region SmithWatermanGotohWindowedAffine tests

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWADefaultTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaDefault.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWAWindowSizeTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaWindowSize.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWAGapCostFunctionTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaGapCostFunction.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaGapCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWAGapCostFunctionAndWindowSizeTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaGapCostFunctionAndWindowSize.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaGapCostFunctionAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
//                                    ToString("F3", CultureInfo.InvariantCulture), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWAGapCostAndCostFunctionsTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaGapCostAndCostFunctions.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaGapCostAndCostFunctions.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
//                                    "F3", CultureInfo.InvariantCulture), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWAGapCostAndCostFunctionsAndWindowSizeTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaGapCostAndCostFunctionsAndWindowSize.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaGapCostAndCostFunctionsAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo)
//                                    .ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWACostFunctionTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaCostFunction.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3", CultureInfo.InvariantCulture),
//                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }

//        [TestMethod]
//        [TestCategory("SWGWA")]
//        public void SWGWACostFunctionAndWindowSizeTestData()
//        {
//            foreach (SwgaTestRecord testRecord in _swgaTestNames)
//            {
//                Assert.AreEqual(testRecord.SwgaCostFunctionAndWindowSize.ToString("F3", CultureInfo.InvariantCulture),
//                                _mySwgwaCostFunctionAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
//                                    "F3", CultureInfo.InvariantCulture), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
//            }
//        }
//        #endregion

//        #region private fields
//        private SmithWatermanSimetric<char> _mySmithWatermanDefault;
//        private SmithWatermanSimetric<char> _mySmithWatermanCost;
//        private SmithWatermanSimetric<char> _mySmithWatermanCostFunction;
//        private SmithWatermanSimetric<char> _mySmithWatermanCostAndCostFunction;

//        private SmithWatermanGotoh<char> _mySmithWatermanGotohDefault;
//        private SmithWatermanGotoh<char> _mySmithWatermanGotohGapCostFunction;
//        private SmithWatermanGotoh<char> _mySmithWatermanGotohCostFunction;
//        private SmithWatermanGotoh<char> _mySmithWatermanGotohGapCostAndCostFunctions;

//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaDefault;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaWindowSize;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaGapCostFunction;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaGapCostFunctionAndWindowSize;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaGapCostAndCostFunctions;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaGapCostAndCostFunctionsAndWindowSize;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaCostFunction;
//        private SmithWatermanGotohWindowedAffine<char> _mySwgwaCostFunctionAndWindowSize;
//        #endregion

//        [TestInitialize]
//        public void SetUp()
//        {
//            LoadData();

//            # region SmithWatermanSimetric classes
//            // 0.5F and SubCostRange1ToMinus2 are the values used for the default constructor
//            _mySmithWatermanDefault = new SmithWatermanSimetric<char>();
//            _mySmithWatermanCost = new SmithWatermanSimetric<char> { GapCost = 0.5D };
//            _mySmithWatermanCostFunction = new SmithWatermanSimetric<char> { GapCost = 0.5D, DCostFunction = new SubCostRange1ToMinus2<char>()};
//            _mySmithWatermanCostAndCostFunction = new SmithWatermanSimetric<char> { GapCost = 0.5D, DCostFunction = new SubCostRange1ToMinus2<char>()};
//            #endregion

//            // we also need to check running a different set of tests

//            #region SmithWatermanGotoh classes
//            _mySmithWatermanGotohDefault = new SmithWatermanGotoh<char>();
//            //_mySmithWatermanGotohGapCostFunction = new SmithWatermanGotoh<char>(new AffineGapRange5To0Multiplier1<char>());
//            //_mySmithWatermanGotohCostFunction = new SmithWatermanGotoh<char>(new SubCostRange5ToMinus3<char>());
//            //_mySmithWatermanGotohGapCostAndCostFunctions = new SmithWatermanGotoh<char>(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3<char>());
//            #endregion

//            #region SmithWatermanGotohWindowedAffine classes
//            //_mySwgwaDefault = new SmithWatermanGotohWindowedAffine<char>();
//            //_mySwgwaWindowSize = new SmithWatermanGotohWindowedAffine<char>(100);
//            //_mySwgwaGapCostFunction = new SmithWatermanGotohWindowedAffine<char>(new AffineGapRange5To0Multiplier1<char>());
//            //_mySwgwaGapCostFunctionAndWindowSize = new SmithWatermanGotohWindowedAffine<char>(new AffineGapRange5To0Multiplier1<char>(), 100);
//            //_mySwgwaGapCostAndCostFunctions = new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3<char>());
//            //_mySwgwaGapCostAndCostFunctionsAndWindowSize = new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3<char>(), 100);
//            //_mySwgwaCostFunction = new SmithWatermanGotohWindowedAffine(new SubCostRange5ToMinus3<char>());
//            //_mySwgwaCostFunctionAndWindowSize = new SmithWatermanGotohWindowedAffine(new SubCostRange5ToMinus3<char>(), 100);
//            #endregion
//        }
//    }
//}