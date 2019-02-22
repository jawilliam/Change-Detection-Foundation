using System;
using System.Text;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests
{
    [TestClass]
    public class Miscellaneus
    {
        [TestMethod]
        public void TestMethod1()
        {
            var v = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode);
            var x = new XElement("das");
            x.Add(new XText("sd"));
            x.Add(new XElement("g"));
            x.Add(new XText("df"));
        }

        [TestMethod]
        public void MatchDescriptor_Serializer_OK()
        {
            var d = new Delta
            {
                Matching = "<Matches>" +
                             "<Match oId=\"2244\" mId=\"2235\"/>" +
                             "<Match oId=\"1875\" mId=\"1866\" distance=\"1.23\"/>" +
                             "<Match oId=\"1876\" mId=\"1867\" similarity=\"5.67\"/>" +
                             "<Match oId=\"1877\" mId=\"1868\" distance=\"1.23\" similarity=\"5.67\"/>" +
                           "</Matches>",
                Differencing = "<Actions>" +
                                  "<Insert eId=\"1675\" pId=\"1677\" pos=\"1\" />" +
                                  "<Insert eId=\"3063\" pId=\"3067\" pos=\"9\" />" +
                                  "<Update eId=\"1675\" val=\"erer\"/>" +
                                  "<Update eId=\"12\" val=\"n1\"/>" +
                                  "<Move eId=\"1228\" pId=\"1237\" pos=\"10\"/>" +
                                  "<Move eId=\"1225\" pId=\"1327\" pos=\"23\"/>" +
                                  "<Delete eId=\"1245\"/>" +
                                  "<Delete eId=\"1244\"/>" +
                               "</Actions>"
            };

            var detectionResult = DetectionResult.Read($"<Result>{d.Matching}{d.Differencing}</Result>", Encoding.Unicode);

            Assert.AreEqual(detectionResult.Matches.Count, 4);
            Assert.IsTrue(detectionResult.Matches[0].Original.Id == "2244");
            Assert.IsTrue(detectionResult.Matches[0].Modified.Id == "2235");
            Assert.IsTrue(detectionResult.Matches[0].Distance == null);
            Assert.IsTrue(detectionResult.Matches[0].Similarity == null);
            Assert.IsTrue(detectionResult.Matches[1].Original.Id == "1875");
            Assert.IsTrue(detectionResult.Matches[1].Modified.Id == "1866");
            Assert.IsTrue(detectionResult.Matches[1].Distance == 1.23);
            Assert.IsTrue(detectionResult.Matches[1].Similarity == null);
            Assert.IsTrue(detectionResult.Matches[2].Original.Id == "1876");
            Assert.IsTrue(detectionResult.Matches[2].Modified.Id == "1867");
            Assert.IsTrue(detectionResult.Matches[2].Distance == null);
            Assert.IsTrue(detectionResult.Matches[2].Similarity == 5.67);
            Assert.IsTrue(detectionResult.Matches[3].Original.Id == "1877");
            Assert.IsTrue(detectionResult.Matches[3].Modified.Id == "1868");
            Assert.IsTrue(detectionResult.Matches[3].Distance == 1.23);
            Assert.IsTrue(detectionResult.Matches[3].Similarity == 5.67);

            string s = detectionResult.WriteXmlColumn();
        }

        public class T
        {
            public string Id { get; set; }
            public int Height { get; set; }
            public T[] Children { get; set; }
        };

        [TestMethod]
        public void Treeable_Height_OK()
        {
            var r0a = new T { Id = "0a", Height = 0, Children = new T[0] };
            var r0b = new T { Id = "0b", Height = 0, Children = new T[0] };
            var r1 = new T { Id = "1", Height = 1, Children = new T[] { r0a } };
            var r2 = new T { Id = "2", Height = 2, Children = new T[] { r1, r0b } };

            Assert.AreEqual(r0a.Height, r0a.Height(t => t.Children, t => t.Height));
            Assert.AreEqual(r0b.Height, r0b.Height(t => t.Children, t => t.Height));
            Assert.AreEqual(r1.Height, r1.Height(t => t.Children, t => t.Height));
            Assert.AreEqual(r2.Height, r2.Height(t => t.Children, t => t.Height));
        }
    }
}
