using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.GumTree
{
    [TestClass]
    public class GumTreeNativeApproachTests
    {
        [TestMethod]
        public void GumTreeNativeApproach_ActionsConversion_OK()
        {
            XElement actions = XElement.Parse(
                "<root><actions type=\"array\">" +
                   "<item type=\"object\">" +
                      "<action type=\"string\">insert</action>" +
                      "<tree type=\"number\">89</tree>" +
                      "<parent type=\"number\">196</parent>" +
                      "<at type=\"number\">3</at>" +
                   "</item>" +
                   "<item type=\"object\">" +
                      "<action type=\"string\">delete</action>" +
                      "<tree type=\"number\">90</tree>" +
                   "</item>" +
                   "<item type=\"object\">" +
                      "<action type=\"string\">update</action>" +
                      "<tree type=\"number\">91</tree>" +
                      "<label type=\"string\">new value</label>" +
                   "</item>" +
                   "<item type=\"object\">" +
                      "<action type=\"string\">move</action>" +
                      "<tree type=\"number\">92</tree>" +
                      "<parent type=\"number\">197</parent>" +
                      "<at type=\"number\">2</at>" +
                   "</item>" +
                "</actions></root>");

            var gt = new GumTreeNativeApproach();
            DetectionResult dr = new DetectionResult();
            dr.Actions = gt.ToActionDescriptors(new XDocument(actions)).ToList();

            var serialization = dr.WriteXmlColumn();
            dr = DetectionResult.Read(serialization, Encoding.Unicode);

            var insert = (InsertOperationDescriptor)dr.Actions[0];
            Assert.AreEqual(insert.Action, ActionKind.Insert);
            Assert.AreEqual(insert.Element.Id, "89");
            Assert.AreEqual(insert.Element.Label, null);
            Assert.AreEqual(insert.Parent.Id, "196");
            Assert.AreEqual(insert.Parent.Label, null);
            Assert.AreEqual(insert.Position, 3);

            var delete = (DeleteOperationDescriptor)dr.Actions[1];
            Assert.AreEqual(delete.Action, ActionKind.Delete);
            Assert.AreEqual(delete.Element.Id, "90");
            Assert.AreEqual(delete.Element.Label, null);

            var update = (UpdateOperationDescriptor)dr.Actions[2];
            Assert.AreEqual(update.Action, ActionKind.Update);
            Assert.AreEqual(update.Element.Id, "91");
            Assert.AreEqual(update.Element.Label, null);
            Assert.AreEqual(update.Value, "new value");

            var move = (MoveOperationDescriptor)dr.Actions[3];
            Assert.AreEqual(move.Action, ActionKind.Move);
            Assert.AreEqual(move.Element.Id, "92");
            Assert.AreEqual(move.Element.Label, null);
            Assert.AreEqual(move.Parent.Id, "197");
            Assert.AreEqual(move.Parent.Label, null);
            Assert.AreEqual(move.Position, 2);
        }

        //[TestMethod]
        //public void GumTreeNativeApproach_ParseTree_OK()
        //{
        //    var gt = new GumTreeNativeApproach();
        //    var args = new InteropArgs()
        //    {
        //        Original = @"E:\Phd\Analysis\Original.cs",
        //        Modified = @"E:\Phd\Analysis\Modified.cs"
        //    };

        //    var r = gt.ParseTree(args);
        //}

        [TestMethod]
        public void ElementTree_XMLSerialization_OK()
        {
            string content =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";

            var tree = ElementTree.Read(content, Encoding.Unicode);
            Assert.AreEqual(tree.Root.Id, "0");
            Assert.AreEqual(tree.Root.Label, "A");
            Assert.AreEqual(tree.Root.Value, "B");
            Assert.AreEqual(tree.Children.Count(), 3);

            var children = tree.Children.ToArray();
            Assert.AreEqual(children[0].Root.Id, "1");
            Assert.AreEqual(children[0].Root.Label, "A1");
            Assert.AreEqual(children[0].Root.Value, "B1");
            Assert.AreEqual(children[0].Children.Count(), 0);
            Assert.AreEqual(children[1].Root.Id, "2");
            Assert.AreEqual(children[1].Root.Label, "A2");
            Assert.AreEqual(children[1].Root.Value, "B2");
            Assert.AreEqual(children[1].Children.Count(), 1);
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Id, "3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Label, "A3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Value, "B3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Children.Count(), 0);
            Assert.AreEqual(children[2].Root.Id, "4");
            Assert.AreEqual(children[2].Root.Label, "A4");
            Assert.AreEqual(children[2].Root.Value, "B4");
            Assert.AreEqual(children[2].Children.Count(), 0);

            var backup = tree.WriteXmlColumn();

            var restoredTree = ElementTree.Read(backup, Encoding.Unicode);

            Assert.AreEqual(restoredTree.Root.Id, "0");
            Assert.AreEqual(restoredTree.Root.Label, "A");
            Assert.AreEqual(restoredTree.Root.Value, "B");
            Assert.AreEqual(restoredTree.Children.Count(), 3);

            children = restoredTree.Children.ToArray();
            Assert.AreEqual(children[0].Root.Id, "1");
            Assert.AreEqual(children[0].Root.Label, "A1");
            Assert.AreEqual(children[0].Root.Value, "B1");
            Assert.AreEqual(children[0].Children.Count(), 0);
            Assert.AreEqual(children[1].Root.Id, "2");
            Assert.AreEqual(children[1].Root.Label, "A2");
            Assert.AreEqual(children[1].Root.Value, "B2");
            Assert.AreEqual(children[1].Children.Count(), 1);
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Id, "3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Label, "A3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Root.Value, "B3");
            Assert.AreEqual(children[1].Children.ToArray()[0].Children.Count(), 0);
            Assert.AreEqual(children[2].Root.Id, "4");
            Assert.AreEqual(children[2].Root.Label, "A4");
            Assert.AreEqual(children[2].Root.Value, "B4");
            Assert.AreEqual(children[2].Children.Count(), 0);
        }

        [TestMethod]
        public void ElementTree_PreOrder_OK()
        {
            string content =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";

            var tree = ElementTree.Read(content, Encoding.Unicode);
            var order = tree.PreOrder(t => t.Children).ToArray();

            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "3");
            Assert.AreEqual(order[4].Root.Id, "4");

            int index = 0;
            tree.PreOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "3");
            Assert.AreEqual(order[4].Root.Id, "4");
        }

        [TestMethod]
        public void ElementTree_PostOrder_OK()
        {
            string content =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";

            var tree = ElementTree.Read(content, Encoding.Unicode);
            var order = tree.PostOrder(t => t.Children).ToArray();

            Assert.AreEqual(order[0].Root.Id, "1");
            Assert.AreEqual(order[1].Root.Id, "3");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "4");
            Assert.AreEqual(order[4].Root.Id, "0");

            int index = 0;
            tree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "3");
            Assert.AreEqual(order[4].Root.Id, "4");
        }

        [TestMethod]
        public void ElementTree_BreadthFirstOrder_OK()
        {
            string content =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";

            var tree = ElementTree.Read(content, Encoding.Unicode);
            var order = tree.BreadthFirstOrder(t => t.Children).ToArray();

            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "4");
            Assert.AreEqual(order[4].Root.Id, "3");

            int index = 0;
            tree.BreadthFirstOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[3].Root.Id, "3");
            Assert.AreEqual(order[4].Root.Id, "4");
        }

        [TestMethod]
        public void ElementTree_Ancestors_OK()
        {
            string content =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";

            var tree = ElementTree.Read(content, Encoding.Unicode);
            var order = tree.BreadthFirstOrder(t => t.Children).ToArray();

            Assert.AreEqual(order[0].Root.Id, "0");
            Assert.AreEqual(order[0].Ancestors().Aggregate("", (s, elementTree) => s+ elementTree.Root.Id), "");
            Assert.AreEqual(order[1].Root.Id, "1");
            Assert.AreEqual(order[1].Ancestors().Aggregate("", (s, elementTree) => s + elementTree.Root.Id), "0");
            Assert.AreEqual(order[2].Root.Id, "2");
            Assert.AreEqual(order[2].Ancestors().Aggregate("", (s, elementTree) => s + elementTree.Root.Id), "0");
            Assert.AreEqual(order[3].Root.Id, "4");
            Assert.AreEqual(order[3].Ancestors().Aggregate("", (s, elementTree) => s + elementTree.Root.Id), "0");
            Assert.AreEqual(order[4].Root.Id, "3");
            Assert.AreEqual(order[4].Ancestors().Aggregate("", (s, elementTree) => s + elementTree.Root.Id), "20");
        }

        [TestMethod]
        public void ElementTree_NameOf1_OK()
        {
            string content = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"name\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"A2\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";
            var tree = ElementTree.Read(content, Encoding.Unicode);
            Assert.IsFalse(tree.LabelOf(t => t.Parent, t => t.Root.Label == "name").Any());

            content = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"A\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"name\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"A3\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";
            tree = ElementTree.Read(content, Encoding.Unicode);
            var order = tree.BreadthFirstOrder(t => t.Children).ToArray();
            order = order[2].LabelOf(t => t.Parent, t => t.Root.Label == "name").ToArray();
            Assert.IsFalse(order.Single().Root.Id == "A1");

            content = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<Item eId=\"0\" eLb=\"name\" eVl=\"B\">" +
            "   <Item eId=\"1\" eLb=\"A1\" eVl=\"B1\"/>" +
            "   <Item eId=\"2\" eLb=\"name\" eVl=\"B2\">" +
            "       <Item eId=\"3\" eLb=\"name\" eVl=\"B3\"/>" +
            "   </Item>" +
            "   <Item eId=\"4\" eLb=\"A4\" eVl=\"B4\"/>" +
            "</Item>";
            tree = ElementTree.Read(content, Encoding.Unicode);
            order = tree.BreadthFirstOrder(t => t.Children).ToArray();
            order = order[4].LabelOf(t => t.Parent, t => t.Root.Label == "name").ToArray();
            Assert.IsTrue(order.Length == 2);
            Assert.IsFalse(order[0].Root.Id == "name");
            Assert.IsFalse(order[1].Root.Id == "A1");
        }
    }
}
