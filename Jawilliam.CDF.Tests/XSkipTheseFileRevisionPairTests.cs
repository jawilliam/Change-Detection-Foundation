using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jawilliam.CDF.Labs;

namespace Jawilliam.CDF.Tests
{
    /// <summary>
    /// Summary description for XSkipTheseFileRevisionPairTests
    /// </summary>
    [TestClass]
    public class XSkipTheseFileRevisionPairTests
    {
        [TestMethod]
        public void XSkipTheseFileRevisionPair_WriteRead_OK()
        {
            XSkipTheseFileRevisionPairs skipThese = new XSkipTheseFileRevisionPairs
            {
                Projects = new XSkipTheseFileRevisionPairs.ProjectInfo[]
                {
                    new XSkipTheseFileRevisionPairs.ProjectInfo
                    {
                        Name = "Project1",
                        FileRevisionPairs = new XSkipTheseFileRevisionPairs.FileRevisionPairInfo[]
                        {
                            new XSkipTheseFileRevisionPairs.FileRevisionPairInfo { Guid = "xyz1" },
                            new XSkipTheseFileRevisionPairs.FileRevisionPairInfo { Guid = "abcd1" }
                        }
                    },
                    new XSkipTheseFileRevisionPairs.ProjectInfo
                    {
                        Name = "Project2",
                        FileRevisionPairs = new XSkipTheseFileRevisionPairs.FileRevisionPairInfo[]
                        {
                            new XSkipTheseFileRevisionPairs.FileRevisionPairInfo { Guid = "xyz2" },
                            new XSkipTheseFileRevisionPairs.FileRevisionPairInfo { Guid = "abcd2" }
                        }
                    }
                }
            };

            string content = skipThese.WriteXmlColumn();

            XSkipTheseFileRevisionPairs skipThese2 = XSkipTheseFileRevisionPairs.Read(content, Encoding.Unicode);
            Assert.AreEqual(skipThese.Projects.Length, skipThese2.Projects.Length);
            Assert.AreEqual(skipThese.Projects[0].Name, skipThese2.Projects[0].Name);
            Assert.AreEqual(skipThese.Projects[0].FileRevisionPairs.Length, skipThese2.Projects[0].FileRevisionPairs.Length);
            Assert.AreEqual(skipThese.Projects[0].FileRevisionPairs[0].Guid, skipThese2.Projects[0].FileRevisionPairs[0].Guid);
            Assert.AreEqual(skipThese.Projects[0].FileRevisionPairs[1].Guid, skipThese2.Projects[0].FileRevisionPairs[1].Guid);

            Assert.AreEqual(skipThese.Projects[1].Name, skipThese2.Projects[1].Name);
            Assert.AreEqual(skipThese.Projects[1].FileRevisionPairs.Length, skipThese2.Projects[1].FileRevisionPairs.Length);
            Assert.AreEqual(skipThese.Projects[1].FileRevisionPairs[0].Guid, skipThese2.Projects[1].FileRevisionPairs[0].Guid);
            Assert.AreEqual(skipThese.Projects[1].FileRevisionPairs[1].Guid, skipThese2.Projects[1].FileRevisionPairs[1].Guid);

            XSkipTheseFileRevisionPairs skipThese3 = new XSkipTheseFileRevisionPairs();
            var content3 = skipThese3.WriteXmlColumn();
        }
    }
}
