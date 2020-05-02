using System.Xml.Linq;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Jawilliam.CDF.Labs.VSIXProject
{
    [TestClass]
    public class TestXAstRevisionPair
    {
        [TestMethod]
        public void AstRevisionPair_LoadDictionaries()
        {
            var xElement = XElement.Parse(
           "<QualifiedName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"7\" endLine=\"1\" endColumn=\"34\" part=\"Left\" RmID=\"6\" GtID=\"6\">"
          + "<IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"7\" endLine=\"1\" endColumn=\"24\" part=\"Left\" RmID=\"2\" GtID=\"2\">"
          + " <Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"7\" endLine=\"1\" endColumn=\"24\" part=\"Identifier\" RmID=\"1\" GtID=\"1\">AjaxControlToolkit</Token>"
          + "</IdentifierName>"
          + "<Token kind=\"DotToken\" Operator=\"true\" startLine=\"1\" startColumn=\"25\" endLine=\"1\" endColumn=\"25\" part=\"DotToken\" RmID=\"3\" GtID=\"3\">.</Token>"
          + "<IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"26\" endLine=\"1\" endColumn=\"34\" part=\"Right\" RmID=\"5\" GtID=\"5\">"
          + "  <Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"26\" endLine=\"1\" endColumn=\"34\" part=\"Identifier\" RmID=\"4\" GtID=\"34\">Reference</Token>"
          + "</IdentifierName>"
       + " </QualifiedName>");

            var arp = new XAstRevisionPair();
            Assert.IsNull(arp.Original);
            Assert.IsNull(arp.RoslynOriginals);
            Assert.IsNull(arp.GumTreeOriginals);
            Assert.IsNull(arp.Modified);
            Assert.IsNull(arp.RoslynModifieds);
            Assert.IsNull(arp.GumTreeModifieds);

            arp.Original = xElement;
            Assert.IsNotNull(arp.Original);
            Assert.IsNotNull(arp.RoslynOriginals);
            Assert.IsNotNull(arp.GumTreeOriginals);
            Assert.IsNull(arp.Modified);
            Assert.IsNull(arp.RoslynModifieds);
            Assert.IsNull(arp.GumTreeModifieds);
            Assert.AreEqual(arp.RoslynOriginals["4"], arp.GumTreeOriginals["34"]);
            Assert.AreEqual(arp.RoslynOriginals["4"].Name, "Token");
            Assert.AreEqual(arp.RoslynOriginals["4"].Value, "Reference");

            arp.Original = null;
            Assert.IsNull(arp.Original);
            Assert.IsNull(arp.RoslynOriginals);
            Assert.IsNull(arp.GumTreeOriginals);
            Assert.IsNull(arp.Modified);
            Assert.IsNull(arp.RoslynModifieds);
            Assert.IsNull(arp.GumTreeModifieds);

            arp.Modified = xElement;
            Assert.IsNull(arp.Original);
            Assert.IsNull(arp.RoslynOriginals);
            Assert.IsNull(arp.GumTreeOriginals);
            Assert.IsNotNull(arp.Modified);
            Assert.IsNotNull(arp.RoslynModifieds);
            Assert.IsNotNull(arp.GumTreeModifieds);
            Assert.AreEqual(arp.RoslynModifieds["4"], arp.GumTreeModifieds["34"]);
            Assert.AreEqual(arp.RoslynModifieds["4"].Name, "Token");
            Assert.AreEqual(arp.RoslynModifieds["4"].Value, "Reference");

            arp.Modified = null;
            Assert.IsNull(arp.Original);
            Assert.IsNull(arp.RoslynOriginals);
            Assert.IsNull(arp.GumTreeOriginals);
            Assert.IsNull(arp.Modified);
            Assert.IsNull(arp.RoslynModifieds);
            Assert.IsNull(arp.GumTreeModifieds);
        }
    }
}
