using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Metrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Metrics
{
    /// <summary>
    /// Summary description for RelativeThresholdTest
    /// </summary>
    [TestClass]
    public class RelativeThresholdTest
    {
        public RelativeThresholdTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void RelativeThreshold_Computing_OK()
        {
            var corpus = new[]
            {
                new KeyValuePair<string, double[]>("A", new double[]{1,2,3,4,5,6}),
                new KeyValuePair<string, double[]>("B", new double[]{2,2.5,3,4,5,6}),
                new KeyValuePair<string, double[]>("C", new double[]{2,2.7,3,4,5,6}),
                new KeyValuePair<string, double[]>("D", new double[]{2,2.3,3,4,5,6}),
                new KeyValuePair<string, double[]>("E", new double[]{6,7,8,9,10,11}),
                new KeyValuePair<string, double[]>("F", new double[]{3,4,5,6,7,8}),
                new KeyValuePair<string, double[]>("G", new double[]{3,4,5,6,7,8}),
                new KeyValuePair<string, double[]>("H", new double[]{3,4,5,6,7,8}),
                new KeyValuePair<string, double[]>("I", new double[]{3,4,5,6,7,8}),
                new KeyValuePair<string, double[]>("J", new double[]{3,4,5,6,7,8}),
            };
            var rt = new RelativeThreshold
            {
                Corpus = corpus,
                DoPercentageOfProjectIsLessThanOrEqualToThreshold = delegate(string id, double percent, double threshold)
                {
                    var project = corpus.Single(s => s.Key == id);
                    var targetPercentile = (int)(project.Value.Count() * percent / 100);
                    return project.Value[targetPercentile] <= threshold;
                },
                Tail = id => corpus.Single(s => s.Key == id).Value[5],
                MedianTail = 8
            };

            double winnerPercent;
            var winnerThreshold = rt.ComputeThreshold(new double[]{1,2,3,4,5,6,7,8,9,10}, new double[] {10,20,30,40,50,60,70,80,90}, 7, out winnerPercent);

            Assert.AreEqual(winnerThreshold, 7);
            Assert.AreEqual(winnerPercent, 80);
        }
    }
}
