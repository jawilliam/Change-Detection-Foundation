using System;
using Jawilliam.CDF.Labs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.GumTree
{
    [TestClass]
    public class FileRevisionPairAnalyzerTests
    {
        //[TestMethod]
        //public void ElementTree_PostOrder_OK()
        //{
        //    Delta d = new Delta
        //    {
        //        ma
        //    };
        //    "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
        //    "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
        //    "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
        //    "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
        //    "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
        //    "   </Item>" +
        //    "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
        //    "</Item>";

        //    var tree = ElementTree.Read(content, Encoding.Unicode);
        //    var order = tree.PostOrder(t => t.Children).ToArray();

        //    Assert.AreEqual(order[0].Root.Id, "1");
        //    Assert.AreEqual(order[1].Root.Id, "3");
        //    Assert.AreEqual(order[2].Root.Id, "2");
        //    Assert.AreEqual(order[3].Root.Id, "4");
        //    Assert.AreEqual(order[4].Root.Id, "0");

        //    int index = 0;
        //    tree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
        //    Assert.AreEqual(order[0].Root.Id, "0");
        //    Assert.AreEqual(order[1].Root.Id, "1");
        //    Assert.AreEqual(order[2].Root.Id, "2");
        //    Assert.AreEqual(order[3].Root.Id, "3");
        //    Assert.AreEqual(order[4].Root.Id, "4");
        //}
    }
}
