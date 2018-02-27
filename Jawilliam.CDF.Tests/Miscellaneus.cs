using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests
{
    [TestClass]
    public class Miscellaneus
    {
        [TestMethod]
        public void TestMethod1()
        {
            var v = typeof (Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode);
            var x = new XElement("das");
            x.Add(new XText("sd"));
            x.Add(new XElement("g"));
            x.Add(new XText("df"));
        }
    }
}
