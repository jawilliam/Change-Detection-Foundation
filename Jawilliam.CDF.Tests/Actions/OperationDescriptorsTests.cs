using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Actions
{
    [TestClass]
    public class OperationDescriptorsTests
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
    }
}
