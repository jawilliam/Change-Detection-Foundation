using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;

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

        [TestMethod]
        public void XMatchingComparison_WriteRead_OK()
        {
            var deltaComparison = new DeltaComparison();
            var xMatching = new DeltaComparison.XMatchingComparison();
            xMatching.Matching = new List<BetweenSymptom>
            {
                new LRMatchSymptom
                {
                    Left = new BetweenMatchInfo
                    {
                        Approach = 1,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1Left", Type = "type1Left", Hint = "hint1Left" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2Left", Type = "type2Left", Hint = "hint2Left" } },
                        PartName = "pnLeft"
                    },
                    OriginalAtRight = new BetweenMatchInfo
                    {
                        Approach = 2,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1OriginalAtRight", Type = "type1OriginalAtRight", Hint = "hint1OriginalAtRight" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2OriginalAtRight", Type = "type2OriginalAtRight", Hint = "hint2OriginalAtRight" } },
                        PartName = "pnOriginalAtRight"
                    },
                    ModifiedAtRight = new BetweenMatchInfo
                    {
                        Approach = 3,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1ModifiedAtRight", Type = "type1ModifiedAtRight", Hint = "hint1ModifiedAtRight" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2ModifiedAtRight", Type = "type2ModifiedAtRight", Hint = "hint2ModifiedAtRight" } },
                        PartName = "pnModifiedAtRight"
                    }
                },
                new LRMatchSymptom
                {
                    Left = new BetweenMatchInfo
                    {
                        Approach = 4,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3Left", Type = "type3Left" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4Left", Type = "type4Left" } },
                        PartName = "pnLeft"
                    },
                    OriginalAtRight = new BetweenMatchInfo
                    {
                        Approach = 5,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3OriginalAtRight", Type = "type3OriginalAtRight" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4OriginalAtRight", Type = "type4OriginalAtRight" } },
                        PartName = "pnOriginalAtRight"
                    },
                    ModifiedAtRight = new BetweenMatchInfo
                    {
                        Approach = 6,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3ModifiedAtRight", Type = "type3ModifiedAtRight" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4ModifiedAtRight", Type = "type4ModifiedAtRight" } },
                        PartName = "pnModifiedAtRight"
                    }
                },
                new RLMatchSymptom
                {
                    Right = new BetweenMatchInfo
                    {
                        Approach = 7,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1Right", Type = "type1Right", Hint = "hint1Right" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2Right", Type = "type2Right", Hint = "hint2Right" } },
                        PartName = "pnRight"
                    },
                    OriginalAtLeft = new BetweenMatchInfo
                    {
                        Approach = 8,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1OriginalAtLeft", Type = "type1OriginalAtLeft", Hint = "hint1OriginalAtLeft" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2OriginalAtLeft", Type = "type2OriginalAtLeft", Hint = "hint2OriginalAtLeft" } },
                        PartName = "pnOriginalAtLeft"
                    },
                    ModifiedAtLeft = new BetweenMatchInfo
                    {
                        Approach = 9,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id1ModifiedAtLeft", Type = "type1ModifiedAtLeft", Hint = "hint1ModifiedAtLeft" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id2ModifiedAtLeft", Type = "type2ModifiedAtLeft", Hint = "hint2ModifiedAtLeft" } },
                        PartName = "pnModifiedAtLeft"
                    }
                },
                new RLMatchSymptom
                {
                    Right = new BetweenMatchInfo
                    {
                        Approach = 10,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3Right", Type = "type3Right" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4Right", Type = "type4Right" } },
                        PartName = "pnRight"
                    },
                    OriginalAtLeft = new BetweenMatchInfo
                    {
                        Approach = 11,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3OriginalAtLeft", Type = "type3OriginalAtLeft" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4OriginalAtLeft", Type = "type4OriginalAtLeft" } },
                        PartName = "pnOriginalAtLeft"
                    },
                    ModifiedAtLeft = new BetweenMatchInfo
                    {
                        Approach = 12,
                        Original = new ElementContext { Element = new ElementDescription { Id = "id3ModifiedAtLeft", Type = "type3ModifiedAtLeft" } },
                        Modified = new ElementContext { Element = new ElementDescription { Id = "id4ModifiedAtLeft", Type = "type4ModifiedAtLeft" } },
                        PartName = "pnModifiedAtLeft"
                    }
                }
            };

            var xMatchingCopy = xMatching; 

            deltaComparison.XMatching = xMatching;
            xMatching = deltaComparison.XMatching;

            Assert.AreNotSame(xMatchingCopy, xMatching);
            for (int i = 0; i < xMatching.Matching.Count; i++)
            {
                var xMatchCopy = xMatchingCopy.Matching[i];
                var xMatch = xMatching.Matching[i];

                Assert.AreNotSame(xMatchCopy, xMatch);
                Assert.AreEqual(xMatchCopy.GetType(), xMatch.GetType());

                if (xMatchCopy is LRMatchSymptom)
                {
                    var xLrMatchCopy = (LRMatchSymptom)xMatchCopy;
                    var xLrMatch = (LRMatchSymptom)xMatch;
                    Assert.AreNotSame(xLrMatchCopy, xLrMatch);

                    Assert.AreEqual(xLrMatchCopy.Left.Approach, xLrMatch.Left.Approach);
                    Assert.AreEqual(xLrMatchCopy.Left.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatch.Left.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatchCopy.Left.Original.Element.Id, xLrMatch.Left.Original.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.Left.Original.Element.Type, xLrMatch.Left.Original.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.Left.Original.Element.Hint, xLrMatch.Left.Original.Element.Hint);
                    Assert.AreEqual(xLrMatchCopy.Left.Modified.Element.Id, xLrMatch.Left.Modified.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.Left.Modified.Element.Type, xLrMatch.Left.Modified.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.Left.Modified.Element.Hint, xLrMatch.Left.Modified.Element.Hint);

                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Approach, xLrMatch.OriginalAtRight.Approach);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatch.OriginalAtRight.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Original.Element.Id, xLrMatch.OriginalAtRight.Original.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Original.Element.Type, xLrMatch.OriginalAtRight.Original.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Original.Element.Hint, xLrMatch.OriginalAtRight.Original.Element.Hint);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Modified.Element.Id, xLrMatch.OriginalAtRight.Modified.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Modified.Element.Type, xLrMatch.OriginalAtRight.Modified.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.OriginalAtRight.Modified.Element.Hint, xLrMatch.OriginalAtRight.Modified.Element.Hint);

                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Approach, xLrMatch.ModifiedAtRight.Approach);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatch.ModifiedAtRight.Original.ScopeHint, null);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Original.Element.Id, xLrMatch.ModifiedAtRight.Original.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Original.Element.Type, xLrMatch.ModifiedAtRight.Original.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Original.Element.Hint, xLrMatch.ModifiedAtRight.Original.Element.Hint);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Modified.Element.Id, xLrMatch.ModifiedAtRight.Modified.Element.Id);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Modified.Element.Type, xLrMatch.ModifiedAtRight.Modified.Element.Type);
                    Assert.AreEqual(xLrMatchCopy.ModifiedAtRight.Modified.Element.Hint, xLrMatch.ModifiedAtRight.Modified.Element.Hint);
                }
                else
                {
                    var xRlMatchCopy = (RLMatchSymptom)xMatchCopy;
                    var xRlMatch = (RLMatchSymptom)xMatch;
                    Assert.AreNotSame(xRlMatchCopy, xRlMatch);

                    Assert.AreEqual(xRlMatchCopy.Right.Approach, xRlMatch.Right.Approach);
                    Assert.AreEqual(xRlMatchCopy.Right.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatch.Right.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatchCopy.Right.Original.Element.Id, xRlMatch.Right.Original.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.Right.Original.Element.Type, xRlMatch.Right.Original.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.Right.Original.Element.Hint, xRlMatch.Right.Original.Element.Hint);
                    Assert.AreEqual(xRlMatchCopy.Right.Modified.Element.Id, xRlMatch.Right.Modified.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.Right.Modified.Element.Type, xRlMatch.Right.Modified.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.Right.Modified.Element.Hint, xRlMatch.Right.Modified.Element.Hint);

                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Approach, xRlMatch.OriginalAtLeft.Approach);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatch.OriginalAtLeft.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Original.Element.Id, xRlMatch.OriginalAtLeft.Original.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Original.Element.Type, xRlMatch.OriginalAtLeft.Original.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Original.Element.Hint, xRlMatch.OriginalAtLeft.Original.Element.Hint);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Modified.Element.Id, xRlMatch.OriginalAtLeft.Modified.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Modified.Element.Type, xRlMatch.OriginalAtLeft.Modified.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.OriginalAtLeft.Modified.Element.Hint, xRlMatch.OriginalAtLeft.Modified.Element.Hint);

                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Approach, xRlMatch.ModifiedAtLeft.Approach);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatch.ModifiedAtLeft.Original.ScopeHint, null);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Original.Element.Id, xRlMatch.ModifiedAtLeft.Original.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Original.Element.Type, xRlMatch.ModifiedAtLeft.Original.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Original.Element.Hint, xRlMatch.ModifiedAtLeft.Original.Element.Hint);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Modified.Element.Id, xRlMatch.ModifiedAtLeft.Modified.Element.Id);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Modified.Element.Type, xRlMatch.ModifiedAtLeft.Modified.Element.Type);
                    Assert.AreEqual(xRlMatchCopy.ModifiedAtLeft.Modified.Element.Hint, xRlMatch.ModifiedAtLeft.Modified.Element.Hint);
                }
            }
        }
    }
}
