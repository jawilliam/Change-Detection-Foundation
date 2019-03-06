using System;
using System.Collections.Generic;
using System.Linq;
using Jawilliam.CDF.Approach.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.Impl
{
    [TestClass]
    public class MyersLCSTests
    {
        [TestMethod]
        public void FindingLCS_abcabbaANDcbabac_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string A = "abcabba";
            string B = "cbabac";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_cbabacANDabcabba_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "abcabba";
            string A = "cbabac";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_xyANDcbabac_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string A = "xy";
            string B = "cbabac";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_cbabacANDxy_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "xy";
            string A = "cbabac";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_emptyANDxy_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string A = "";
            string B = "xy";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_emptyANDx_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string A = "";
            string B = "x";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_xANDempty_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "";
            string A = "x";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_xANDx_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "x";
            string A = "x";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_xyANDempty_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "";
            string A = "xy";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        [TestMethod]
        public void FindingLCS_emptyANDempty_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "";
            string A = "";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.AreEqual(path.Count(), 0);
        }

        [TestMethod]
        public void FindingLCS_xyANDxy_OK()
        {
            MyersLCS<char> lcs = new MyersLCS<char>();
            string B = "xy";
            string A = "xy";
            var path = lcs.Run(A, B);

            this.AssertSolution(A, B, path);
            Assert.IsTrue(path.Count() > 0);
        }

        private void AssertSolution(string A, string B, IEnumerable<MyersLCS<char>.Command> path)
        {
            IList<char> a = A.ToList();
            int deleted = 0;
            foreach (var command in path)
            {
                switch (command.Kind)
                {
                    case MyersLCS<char>.CommandKind.Insert:
                        Assert.AreEqual(command.Symbol, B[command.BIndex]);
                        int index = command.AIndex + 1 - deleted;
                        if (index < a.Count())
                            a.Insert(command.AIndex + 1 - deleted, command.Symbol);
                        else
                            a = (a.Aggregate("", (str, chr) => str + chr.ToString()) + command.Symbol).ToList();
                        deleted--;
                        break;
                    case MyersLCS<char>.CommandKind.Delete:
                        Assert.AreEqual(command.Symbol, A[command.AIndex]);
                        Assert.AreEqual(command.Symbol, a[command.AIndex - deleted]);
                        a.RemoveAt(command.AIndex - deleted);
                        deleted++;
                        break;
                    case MyersLCS<char>.CommandKind.Match:
                        Assert.AreEqual(command.Symbol, A[command.AIndex]);
                        Assert.AreEqual(command.Symbol, a[command.AIndex - deleted]);
                        Assert.AreEqual(command.Symbol, B[command.BIndex]);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Assert.AreEqual(a.Aggregate("", (str, chr) => str + chr.ToString()), B);
        }
    }
}
