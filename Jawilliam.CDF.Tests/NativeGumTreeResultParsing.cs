using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Labs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests
{
    [TestClass]
    public class NativeGumTreeResultParsing
    {
        [TestMethod]
        public void ParseDiffResults_OK()
        {
            var actionPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Insert ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[2], Label = captures[0]},
                        Parent = new ElementDescriptor {Id = captures[4], Label = captures[3]},
                        Position = int.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Insert (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[1], Label = captures[0]},
                        Parent = new ElementDescriptor {Id = captures[3], Label = captures[2]},
                        Position = int.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update ([^:]*): (.*)\((\d+)\) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0] },
                        Value = captures[3]
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update (.*)\((\d+)\) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Value = captures[2]
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Move ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[2], Label = captures[0]},
                        Parent = new ElementDescriptor {Id = captures[4], Label = captures[3]},
                        Position = Int32.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Move (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[1], Label = captures[0]},
                        Parent = new ElementDescriptor {Id = captures[3], Label = captures[2]},
                        Position = Int32.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Delete ([^:]*): (.*)\((\d+)\)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[2], Label = captures[0]}
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Delete (.*)\((\d+)\)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor {Id = captures[1], Label = captures[0]}
                    })
                }
            };

            var matchPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Match ([^:]*): (.*)\((\d+)\) to ([^:]*):? (.*)\((\d+)\)"),
                    Selector = new Func<string[], RevisionDescriptor>(captures => new RevisionDescriptor
                    {
                        Original = new ElementDescriptor {Id = captures[2], Label = captures[0]},
                        Modified = new ElementDescriptor {Id = captures[5], Label = captures[3]},
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Match (.*)\((\d+)\) to (.*)\((\d+)\)"),
                    Selector = new Func<string[], RevisionDescriptor>(captures => new RevisionDescriptor
                    {
                        Original = new ElementDescriptor {Id = captures[1], Label = captures[0]},
                        Modified = new ElementDescriptor {Id = captures[3], Label = captures[2]},
                    })
                }
            };

            var actionItems = new[]
            {
                "Insert operator: .(1675) into name(1677) at 1",
                "Insert argument(3063) into argument_list(3067) at 9",
                "Update op1: .(1675) to erer",
                "Update .(12) to n1",
                "Move decl_stmt(1228) into block(1237) at 10",
                "Move operator: decl_stmt3(1225) into block5(1327) at 23",
                "Delete expr(1245)",
                "Delete operator: )(1244)"
            }.Select(delegate(string s)
            {
                var pattern = actionPatterns.First(p => p.Pattern.IsMatch(s));
                var matches = pattern.Pattern.Matches(s)[0].Groups;
                var m = new Group[matches.Count];
                matches.CopyTo(m, 0);
                return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
            }).ToArray();
            Assert.IsTrue(actionItems[0].Action == ActionKind.Insert);
            Assert.IsTrue(actionItems[0].Element.Id == "1675");
            Assert.IsTrue(actionItems[0].Element.Label == "operator");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[0]).Parent.Id == "1677");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[0]).Parent.Label == "name");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[0]).Position == 1);
            Assert.IsTrue(actionItems[1].Action == ActionKind.Insert);
            Assert.IsTrue(actionItems[1].Element.Id == "3063");
            Assert.IsTrue(actionItems[1].Element.Label == "argument");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[1]).Parent.Id == "3067");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[1]).Parent.Label == "argument_list");
            Assert.IsTrue(((InsertOperationDescriptor) actionItems[1]).Position == 9);
            Assert.IsTrue(actionItems[2].Action == ActionKind.Update);
            Assert.IsTrue(actionItems[2].Element.Id == "1675");
            Assert.IsTrue(actionItems[2].Element.Label == "op1");
            Assert.IsTrue(((UpdateOperationDescriptor) actionItems[2]).Value == "erer");
            Assert.IsTrue(actionItems[3].Action == ActionKind.Update);
            Assert.IsTrue(actionItems[3].Element.Id == "12");
            Assert.IsTrue(actionItems[3].Element.Label == ".");
            Assert.IsTrue(((UpdateOperationDescriptor) actionItems[3]).Value == "n1");
            Assert.IsTrue(actionItems[4].Action == ActionKind.Move);
            Assert.IsTrue(actionItems[4].Element.Id == "1228");
            Assert.IsTrue(actionItems[4].Element.Label == "decl_stmt");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[4]).Parent.Id == "1237");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[4]).Parent.Label == "block");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[4]).Position == 10);
            Assert.IsTrue(actionItems[5].Action == ActionKind.Move);
            Assert.IsTrue(actionItems[5].Element.Id == "1225");
            Assert.IsTrue(actionItems[5].Element.Label == "operator");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[5]).Parent.Id == "1327");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[5]).Parent.Label == "block5");
            Assert.IsTrue(((MoveOperationDescriptor) actionItems[5]).Position == 23);
            Assert.IsTrue(actionItems[6].Action == ActionKind.Delete);
            Assert.IsTrue(actionItems[6].Element.Id == "1245");
            Assert.IsTrue(actionItems[6].Element.Label == "expr");
            Assert.IsTrue(actionItems[7].Action == ActionKind.Delete);
            Assert.IsTrue(actionItems[7].Element.Id == "1244");
            Assert.IsTrue(actionItems[7].Element.Label == "operator");

            var matchItems = new[]
            {
                "Match name1: List(2244) to name2: List(2235)",
                "Match expr1(1875) to expr2(1866)"
            }.Select(delegate(string s)
            {
                var pattern = matchPatterns.First(p => p.Pattern.IsMatch(s));
                var matches = pattern.Pattern.Matches(s)[0].Groups;
                var m = new Group[matches.Count];
                matches.CopyTo(m, 0);
                return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
            }).ToArray();
            Assert.IsTrue(matchItems[0].Original.Id == "2244");
            Assert.IsTrue(matchItems[0].Original.Label == "name1");
            Assert.IsTrue(matchItems[0].Modified.Id == "2235");
            Assert.IsTrue(matchItems[0].Modified.Label == "name2");
            Assert.IsTrue(matchItems[1].Original.Id == "1875");
            Assert.IsTrue(matchItems[1].Original.Label == "expr1");
            Assert.IsTrue(matchItems[1].Modified.Id == "1866");
            Assert.IsTrue(matchItems[1].Modified.Label == "expr2");
        }

        [TestMethod]
        public void GumTreeNativeApproach_CompleteDeltaInfo_OK()
        {
            var lines = new[]
            {
                "Insert operator: .(1675) into name(1677) at 1",
                "Insert argument(3063) into argument_list(3067) at 9",
                "Update op1: .(1675) to erer",
                "Update .(12) to n1",
                "Move decl_stmt(1228) into block(1237) at 10",
                "Move operator: decl_stmt3(1225) into block5(1327) at 23",
                "Delete expr(1245)",
                "Delete operator: )(1244)",
                "Match name1: List(2244) to name2: List(2235)",
                "Match expr1(1875) to expr2(1866)"
            };

            var d = new Delta
            {
                Matching = "<Matches><Match oId=\"2244\" mId=\"2235\"/><Match oId=\"1875\" mId=\"1866\"/></Matches>",
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
            var gumTree = new GumTreeNativeApproach();
            gumTree.CompleteDeltaInfo(detectionResult.Matches, detectionResult.Actions.OfType<OperationDescriptor>(), lines);

            Assert.IsTrue(detectionResult.Actions[0].Action == ActionKind.Insert);
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[0]).Element.Id == "1675");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[0]).Element.Label == "operator");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[0]).Parent.Id == "1677");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[0]).Parent.Label == "name");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[0]).Position == 1);
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Action == ActionKind.Insert);
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Element.Id == "3063");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Element.Label == "argument");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Parent.Id == "3067");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Parent.Label == "argument_list");
            Assert.IsTrue(((InsertOperationDescriptor)detectionResult.Actions[1]).Position == 9);
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[2]).Action == ActionKind.Update);
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[2]).Element.Id == "1675");
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[2]).Element.Label == "op1");
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[2]).Value == "erer");
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[3]).Action == ActionKind.Update);
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[3]).Element.Id == "12");
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[3]).Element.Label == ".");
            Assert.IsTrue(((UpdateOperationDescriptor)detectionResult.Actions[3]).Value == "n1");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Action == ActionKind.Move);
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Element.Id == "1228");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Element.Label == "decl_stmt");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Parent.Id == "1237");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Parent.Label == "block");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[4]).Position == 10);
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Action == ActionKind.Move);
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Element.Id == "1225");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Element.Label == "operator");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Parent.Id == "1327");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Parent.Label == "block5");
            Assert.IsTrue(((MoveOperationDescriptor)detectionResult.Actions[5]).Position == 23);
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[6]).Action == ActionKind.Delete);
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[6]).Element.Id == "1245");
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[6]).Element.Label == "expr");
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[7]).Action == ActionKind.Delete);
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[7]).Element.Id == "1244");
            Assert.IsTrue(((DeleteOperationDescriptor)detectionResult.Actions[7]).Element.Label == "operator");
            Assert.IsTrue(detectionResult.Matches[0].Original.Id == "2244");
            Assert.IsTrue(detectionResult.Matches[0].Original.Label == "name1");
            Assert.IsTrue(detectionResult.Matches[0].Modified.Id == "2235");
            Assert.IsTrue(detectionResult.Matches[0].Modified.Label == "name2");
            Assert.IsTrue(detectionResult.Matches[1].Original.Id == "1875");
            Assert.IsTrue(detectionResult.Matches[1].Original.Label == "expr1");
            Assert.IsTrue(detectionResult.Matches[1].Modified.Id == "1866");
            Assert.IsTrue(detectionResult.Matches[1].Modified.Label == "expr2");
        }

        [TestMethod]
        public void GumTreeNativeApproach_ExecuteDiffCommand_OK()
        {
            var interopArgs = new InteropArgs();
            var gumTree = new GumTreeNativeApproach();
            var result = gumTree.ExecuteDiffCommand(interopArgs);
            var lines = result.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
