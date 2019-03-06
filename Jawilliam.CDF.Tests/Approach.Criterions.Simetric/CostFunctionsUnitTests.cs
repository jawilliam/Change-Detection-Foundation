/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
  namespaces, code guidelines (naming and mode...)
  
  Removing tests related with descriptions*/

using System.Globalization;
using System.Linq;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.Data.Simetric;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.Data.Simetric.Tests
{
    [TestClass]
    public sealed class CostFunctionsUnitTests
    {
        #region AffineGapRange1To0Multiplier1Over3 Tests

        [TestMethod]
        [TestCategory("AffineGapRange1To0Multiplier1Over3 Test")]
        public void AffineGapRange1To0Multiplier1Over3PassTest() {
            double result = _myCostFunction1.GetCost("CHRIS", 1, 3);
            Assert.AreEqual("1.333", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with AffineGapRange1To0Multiplier1Over3 pass test.");
        }

        [TestMethod]
        [TestCategory("AffineGapRange1To0Multiplier1Over3 Test")]
        public void AffineGapRange1To0Multiplier1Over3FailTest() {
            double result = _myCostFunction1.GetCost("CHRIS", 4, 3);
            Assert.AreEqual("0.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with AffineGapRange1To0Multiplier1Over3 fail test.");
        }
        #endregion

        #region AffineGapRange5To0Multiplier1 Tests

        [TestMethod]
        [TestCategory("AffineGapRange5To0Multiplier1 Test")]
        public void AffineGapRange5To0Multiplier1PassTest() {
            double result = _myCostFunction2.GetCost("CHRIS", 1, 3);
            Assert.AreEqual("6.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with AffineGapRange5To0Multiplier1 pass test.");
        }

        [TestMethod]
        [TestCategory("AffineGapRange5To0Multiplier1 Test")]
        public void AffineGapRange5To0Multiplier1FailTest() {
            double result = _myCostFunction2.GetCost("CHRIS", 4, 3);
            Assert.AreEqual("0.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with AffineGapRange5To0Multiplier1 fail test.");
        }
        #endregion

        #region SubCostRange0To1 Tests

        [TestMethod]
        [TestCategory("SubCostRange0To1 Test")]
        public void SubCostRange0To1PassTest() {
            double result = _myCostFunction3.GetCost("CHRIS".ToList(), 1, "KRIS".ToList(), 3);
            Assert.AreEqual("1.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with SubCostRange0To1 pass test.");
        }

        [TestMethod]
        [TestCategory("SubCostRange0To1 Test")]
        public void SubCostRange0To1FailTest() {
            double result = _myCostFunction3.GetCost("CHRIS".ToList(), 4, "KRIS".ToList(), 3);
            Assert.AreEqual("0.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with SubCostRange0To1 fail test.");
        }
        #endregion

        #region SubCostRange1ToMinus2 Tests

        [TestMethod]
        [TestCategory("SubCostRange1ToMinus2 Test")]
        public void SubCostRange1ToMinus2PassTest() {
            double result = _myCostFunction4.GetCost("CHRIS".ToList(), 1, "CHRIS".ToList(), 1);
            Assert.AreEqual("1.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with SubCostRange1ToMinus2 pass test.");
        }

        [TestMethod]
        [TestCategory("SubCostRange1ToMinus2 Test")]
        public void SubCostRange1ToMinus2FailTest() {
            // fail due to first word index greater than word length
            Assert.AreEqual("-2.000", _myCostFunction4.GetCost("CHRIS".ToList(), 6, "CHRIS".ToList(), 3).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange1ToMinus2 fail test.");
            // fail due to second word index greater than word length
            Assert.AreEqual("-2.000", _myCostFunction4.GetCost("CHRIS".ToList(), 3, "CHRIS".ToList(), 6).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange1ToMinus2 fail test.");
            // fail to different chars
            Assert.AreEqual("-2.000", _myCostFunction4.GetCost("CHRIS".ToList(), 1, "KRIS".ToList(), 1).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange1ToMinus2 fail test.");
        }
        #endregion

        #region SubCostRange5ToMinus3 Tests

        [TestMethod]
        [TestCategory("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3PassTest() {
            double result = _myCostFunction5.GetCost("CHRIS".ToList(), 1, "CHRIS".ToList(), 1);
            Assert.AreEqual("5.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with SubCostRange5ToMinus3 pass test.");
        }

        [TestMethod]
        [TestCategory("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3FailTest() {
            // fail due to first word index greater than word length
            Assert.AreEqual("-3.000", _myCostFunction5.GetCost("CHRIS".ToList(), 6, "CHRIS".ToList(), 3).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange5ToMinus3 fail test.");
            // fail due to second word index greater than word length
            Assert.AreEqual("-3.000", _myCostFunction5.GetCost("CHRIS".ToList(), 3, "CHRIS".ToList(), 6).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange5ToMinus3 fail test.");
            // fail to different chars
            Assert.AreEqual("-3.000", _myCostFunction5.GetCost("CHRIS".ToList(), 1, "KRIS".ToList(), 1).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange5ToMinus3 fail test.");
        }

        [TestMethod]
        [TestCategory("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3ApproxTest() {
            Assert.AreEqual("3.000", _myCostFunction5.GetCost("GILL".ToList(), 0, "JILL".ToList(), 0).ToString("F3", CultureInfo.InvariantCulture),
                            "Problem with SubCostRange5ToMinus3 fail test.");
        }
        #endregion

        private AffineGapRange1To0Multiplier1Over3 _myCostFunction1;
        private AffineGapRange5To0Multiplier1 _myCostFunction2;
        private SubCostRange0To1<char> _myCostFunction3;
        private SubCostRange1ToMinus2<char> _myCostFunction4;
        private SubCostRange5ToMinus3<char> _myCostFunction5;

        [TestInitialize]
        public void SetUp() {
            _myCostFunction1 = new AffineGapRange1To0Multiplier1Over3();
            _myCostFunction2 = new AffineGapRange5To0Multiplier1();
            _myCostFunction3 = new SubCostRange0To1<char>();
            _myCostFunction4 = new SubCostRange1ToMinus2<char>();
            _myCostFunction5 = new SubCostRange5ToMinus3<char>();
        }
    }
}