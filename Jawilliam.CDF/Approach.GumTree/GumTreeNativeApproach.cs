//#define SKIPELEMENT
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;

namespace Jawilliam.CDF.Approach.GumTree
{
    /// <summary>
    /// Implements a console call to a native GumTree snapshot.
    /// </summary>
    public class GumTreeNativeApproach : Procedure<InteropArgs, DetectionResult>, IApproach<InteropArgs>
    {
        private Process _process;

        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        public override void Proceed(InteropArgs args)
        {
            base.Proceed(args);
            this.Result = new DetectionResult();

#if SKIPELEMENT
            this.Result.Error = "Omitted element";
            throw new OperationCanceledException();
#endif

            //string header = $"Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\n{Environment.CurrentDirectory}>E:\r\n\r\n{Environment.CurrentDirectory}>cd {args.GumTreePath}\\bin\r\n\r\n{args.GumTreePath}\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\n{args.GumTreePath}\\bin>gumtree.bat axmldiff {args.Original} {args.Modified}\r\n";
            //string output = ExecuteCommand(args, header, $"gumtree.bat axmldiff {args.Original} {args.Modified}", "\n");
            //string header = $"Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\n{Environment.CurrentDirectory}>E:\r\n\r\n{Environment.CurrentDirectory}>cd {args.GumTreePath}\\bin\r\n\r\n{args.GumTreePath}\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\n{args.GumTreePath}\\bin>gumtree.bat jsondiff {args.Original} {args.Modified}\r\n";
            //string output = ExecuteCommand(args, header, $"gumtree.bat jsondiff {args.Original} {args.Modified}", "");
            var diff = this.ExecuteDiffCommand(args);
            var lines = diff.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var temp = "";
            var lines1 = lines;
            lines = lines.Select(delegate (string s, int p)
            {
                temp += s + "\n";
                if (p < lines1.Length - 1 &&
                    !lines1[p + 1].StartsWith("Match ") &&
                    !lines1[p + 1].StartsWith("Insert ") &&
                    !lines1[p + 1].StartsWith("Update ") &&
                    !lines1[p + 1].StartsWith("Delete ") &&
                    !lines1[p + 1].StartsWith("Move "))
                {
                    return null;
                }

                string g = temp.TrimEnd('\n');
                temp = "";
                return g;
            }).ToArray();
            lines = lines.Where(l => l != null).ToArray();

            if (lines.Any())
            {
                this.Result.Matches = this.GetMatches(lines).ToList();
                this.Result.Actions = this.GetActions(lines).Cast<ActionDescriptor>().ToList();
            }
            else
            {
                this.Result.Matches = new List<RevisionDescriptor>();
                this.Result.Actions = new List<ActionDescriptor>();
                this.Result.Error = "Error on the side of GumTree";
            }
        }

        /// <summary>
        /// Returns structured descriptions of matches.
        /// </summary>
        /// <param name="diffOutput">informations to select from.</param>
        public virtual IEnumerable<RevisionDescriptor> GetMatches(string[] diffOutput)
        {
            var matchPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Match ([^:]*): (.*)\((\d+)\) to ([^:]*): (.*)\((\d+)\)", RegexOptions.Singleline),
                    Selector = new Func<string[], RevisionDescriptor>(captures => new RevisionDescriptor
                    {
                        Original = new ElementDescriptor {Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##"},
                        Modified = new ElementDescriptor {Id = captures[5], Label = captures[3], Value = captures[3] == "name" ? captures[4] : "##"},
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Match (.*)\((\d+)\) to (.*)\((\d+)\)", RegexOptions.Singleline),
                    Selector = new Func<string[], RevisionDescriptor>(captures => new RevisionDescriptor
                    {
                        Original = new ElementDescriptor {Id = captures[1], Label = captures[0]},
                        Modified = new ElementDescriptor {Id = captures[3], Label = captures[2]},
                    })
                }
            };
            return diffOutput.Where(l => l.StartsWith("Match ")).Select(delegate (string s)
            {
                try
                {
                    //foreach (var item in matchPatterns)
                    //{
                    //    var r = item.Pattern.Matches(s);
                    //    if (item.Pattern.IsMatch(s))
                    //        ;
                    //}
                    var pattern = matchPatterns.First(p => p.Pattern.IsMatch(s));
                    //var pattern = matchPatterns.First(p => p.Pattern.IsMatch(s.Replace("\"",  "").Replace("\n", "").Replace("@", "")));
                    var matchGroups = pattern.Pattern.Matches(s)[0].Groups;
                    var m = new Group[matchGroups.Count];
                    matchGroups.CopyTo(m, 0);
                    return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
                }
                catch (Exception e)
                {

                    throw;
                }
                //return new RevisionDescriptor
                //{
                //    Original = new ElementDescriptor { Id = "45", Label = "literal", Value = "##" },
                //    Modified = new ElementDescriptor { Id = "47", Label = "literal", Value = "##" }
                //};
            });
        }

        /// <summary>
        /// Returns structured information of edit actions.
        /// </summary>
        /// <param name="diffOutput">informations to select from.</param>
        public virtual IEnumerable<OperationDescriptor> GetActions(string[] diffOutput)
        {
            var actionPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Insert ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##"},
                        Parent = new ElementDescriptor { Id = captures[4], Label = captures[3] },
                        Position = int.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Insert (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Parent = new ElementDescriptor { Id = captures[3], Label = captures[2] },
                        Position = int.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update ([^:]*): (.*)\((\d+)\) to (.*)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" },
                        Value = captures[3]
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update (.*)\((\d+)\) to (.*)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Value = captures[2]
                    })
                },/*,
                new
                {
                    Pattern = new Regex(@"^Update ([^:]*): (.*)\((\d+)\) (.*) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0] },
                        Value = captures[4]
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update (.*)\((\d+)\) (.*) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Value = captures[3]
                    })
                },*/
                new
                {
                    Pattern = new Regex(@"^Move ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" },
                        Parent = new ElementDescriptor { Id = captures[4], Label = captures[3] },
                        Position = Int32.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Move (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Parent = new ElementDescriptor { Id = captures[3], Label = captures[2] },
                        Position = Int32.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new { Pattern = new Regex(@"^Delete ([^:]*): (.*)\((\d+)\)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" }
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Delete (.*)\((\d+)\)", RegexOptions.Singleline),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] }
                    })
                }
            };
            return diffOutput.Where(l => !l.StartsWith("Match ")).Select(delegate (string s)
            {
                try
                {
                    var pattern = actionPatterns.First(p => p.Pattern.IsMatch(s));
                    var actionGroups = pattern.Pattern.Matches(s)[0].Groups;
                    var m = new Group[actionGroups.Count];
                    actionGroups.CopyTo(m, 0);
                    return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
                }
                catch (Exception)
                {

                    throw;
                }
                //return new InsertOperationDescriptor
                //{
                //    Element = new ElementDescriptor { Id = "179", Label = "literal", Value =  "##" },
                //    Parent = new ElementDescriptor { Id = "180", Label = "expr" },
                //    Position = 0
                //};
            });
        }

        public virtual void Cancel()
        {
            if (this.Result != null && !this.Result.Matches.Any() && !this.Result.Actions.Any())
            {
                this.Result.Error = "Omitted element > 10 min";

                this._process?.Close();
                throw new OperationCanceledException();
            }
        }

        public string ExecuteJsonDiffCommand(InteropArgs args)
        {
            //¢
            string header = $"Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\n{Environment.CurrentDirectory}>E:\r\n\r\n{Environment.CurrentDirectory}>cd {args.GumTreePath}\\bin\r\n\r\n{args.GumTreePath}\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\n{args.GumTreePath}\\bin>gumtree.bat jsondiff {args.Original} {args.Modified}\r\n";
            return ExecuteCommand(args, header, $"gumtree.bat jsondiff {args.Original} {args.Modified}", "");
        }

        public string ExecuteDiffCommand(InteropArgs args)
        {
            string header = $"Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\n{Environment.CurrentDirectory}>E:\r\n\r\n{Environment.CurrentDirectory}>cd {args.GumTreePath}\\bin\r\n\r\n{args.GumTreePath}\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\n{args.GumTreePath}\\bin>gumtree.bat diff {args.Original} {args.Modified}\r\n";
            return ExecuteCommand(args, header, $"gumtree.bat diff {args.Original} {args.Modified}", "");
        }

        public virtual ElementTree ParseTree(InteropArgs args, bool modified = false)
        {//¢
            var file = !modified ? args.Original : args.Modified;
            string header = $"Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\n{Environment.CurrentDirectory}>E:\r\n\r\n{Environment.CurrentDirectory}>cd {args.GumTreePath}\\bin\r\n\r\n{args.GumTreePath}\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\n{args.GumTreePath}\\bin>gumtree.bat parse {file}\r\n";
            var result = ExecuteCommand(args, header, $"gumtree.bat parse {file}", "");
            XDocument xjsonDiff;
            using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(result), XmlDictionaryReaderQuotas.Max))
            {
                var xml = XElement.Load(jsonReader);
                xjsonDiff = XDocument.Parse(xml.ToString());
            }

            return this.ToElementDescriptor(xjsonDiff.Root.Elements("root").Single());
        }

        private ElementTree ToElementDescriptor(XElement root)
        {
            var tree = new ElementTree
            {
                Root = new ElementDescriptor
                {
                    Label = root.Elements("typeLabel").Single().Value,
                    Value = root.Elements("label").SingleOrDefault()?.Value
                }
            };

            var xChildren = root.Elements("children").SingleOrDefault();
            if (xChildren != null)
            {
                var children = new List<ElementTree>(xChildren.Elements("item").Count());
                foreach (var child in xChildren.Elements("item").Select(this.ToElementDescriptor))
                {
                    child.Parent = tree;
                    children.Add(child);
                }
                tree.Children = children;
            }

            return tree;
        }

        public string ExecuteCommand(InteropArgs args, string header, string command, string sPrefix)
        {
            string result;
            using (_process = new Process())
            {
                var procStartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var proc = new Process { StartInfo = procStartInfo };
                proc.Start();
                proc.StandardInput.WriteLine("E:");
                proc.StandardInput.WriteLine($@"cd {args.GumTreePath}\bin");
                proc.StandardInput.WriteLine(@"set PATH=%PATH%;C:\Program Files (x86)\srcML 0.9.5\bin");
                proc.StandardInput.WriteLine(command);
                proc.StandardInput.Flush();
                proc.StandardInput.Close();
                // Get the output into a string
                //proc.WaitForExit();
                result = proc.StandardOutput.ReadToEnd().Replace(header, "");
                result = result.Replace($@"{sPrefix}{args.GumTreePath}\bin>", "")
                               .Replace($@"{args.GumTreePath}\bin>", "");
                _process.Close();
            }

            return result;
        }

        /// <summary>
        /// Converts the native XML-based matching result into 
        /// </summary>
        /// <param name="native"></param>
        /// <returns></returns>
        private IEnumerable<RevisionDescriptor> ToMatchingDescriptors(XDocument native)
        {
            var xMatches = native.Root?.Element("matches");
            if (xMatches != null)
            {
                foreach (var xItem in xMatches.Elements("item"))
                {
                    yield return new RevisionDescriptor
                    {
                        Original = new ElementDescriptor { Id = xItem.Element("src")?.Value },
                        Modified = new ElementDescriptor { Id = xItem.Element("dest")?.Value }
                    };
                }
            }
        }

        /// <summary>
        /// Converts the native XML-based differencing result into standard elements.
        /// </summary>
        /// <param name="native"></param>
        /// <returns></returns>
        public IEnumerable<ActionDescriptor> ToActionDescriptors(XDocument native)
        {
            var xActions = native.Root?.Element("actions");
            if (xActions != null)
            {
                foreach (var xItem in xActions.Elements("item"))
                {
                    switch (xItem.Element("action").Value)
                    {
                        case "insert":
                            yield return new InsertOperationDescriptor
                            {
                                Element = new ElementDescriptor { Id = xItem.Element("tree").Value },
                                Parent = new ElementDescriptor { Id = xItem.Element("parent").Value },
                                Position = XmlConvert.ToInt32(xItem.Element("at").Value)
                            };
                            break;
                        case "delete":
                            yield return new DeleteOperationDescriptor
                            {
                                Element = new ElementDescriptor { Id = xItem.Element("tree").Value }
                            };
                            break;
                        case "update":
                            yield return new UpdateOperationDescriptor
                            {
                                Element = new ElementDescriptor { Id = xItem.Element("tree").Value },
                                Value = xItem.Element("label").Value
                            };
                            break;
                        case "move":
                            yield return new MoveOperationDescriptor
                            {
                                Element = new ElementDescriptor { Id = xItem.Element("tree").Value },
                                Parent = new ElementDescriptor { Id = xItem.Element("parent").Value },
                                Position = XmlConvert.ToInt32(xItem.Element("at").Value)
                            };
                            break;
                        default:
                            throw new InvalidEnumArgumentException(xItem.Element("action").Value);
                    }
                }
            }
        }

        /// <summary>
        /// Completes the information of existing descriptions of matches and edit actions.
        /// </summary>
        /// <param name="matches">existing matches to complete.</param>
        /// <param name="actions">existing actions to complete.</param>
        /// <param name="diffOutput">informations to complete from.</param>
        public virtual void CompleteDeltaInfo(IEnumerable<RevisionDescriptor> matches, IEnumerable<OperationDescriptor> actions, string[] diffOutput)
        {
            var matchPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Match ([^:]*): (.*)\((\d+)\) to ([^:]*): (.*)\((\d+)\)"),
                    Selector = new Func<string[], RevisionDescriptor>(captures => new RevisionDescriptor
                    {
                        Original = new ElementDescriptor {Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##"},
                        Modified = new ElementDescriptor {Id = captures[5], Label = captures[3], Value = captures[3] == "name" ? captures[4] : "##"},
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
            var diffMatches = diffOutput.Where(l => l.StartsWith("Match ")).Select(delegate (string s)
            {
                try
                {
                    var pattern = matchPatterns.First(p => p.Pattern.IsMatch(s));
                    var matchGroups = pattern.Pattern.Matches(s)[0].Groups;
                    var m = new Group[matchGroups.Count];
                    matchGroups.CopyTo(m, 0);
                    return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
                }
                catch (Exception)
                {
                    
                    throw;
                }
                //return new RevisionDescriptor
                //{
                //    Original = new ElementDescriptor { Id = "45", Label = "literal", Value = "##" },
                //    Modified = new ElementDescriptor { Id = "47", Label = "literal", Value = "##" }
                //};
            }).ToArray();
            this.CompleteDeltaMatchesInfo(matches, diffMatches);

            var actionPatterns = new[]
            {
                new
                {
                    Pattern = new Regex(@"^Insert ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##"},
                        Parent = new ElementDescriptor { Id = captures[4], Label = captures[3] },
                        Position = int.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Insert (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new InsertOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Parent = new ElementDescriptor { Id = captures[3], Label = captures[2] },
                        Position = int.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update ([^:]*): (.*)\((\d+)\) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" },
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
                },/*,
                new
                {
                    Pattern = new Regex(@"^Update ([^:]*): (.*)\((\d+)\) (.*) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0] },
                        Value = captures[4]
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Update (.*)\((\d+)\) (.*) to (.*)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new UpdateOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Value = captures[3]
                    })
                },*/
                new
                {
                    Pattern = new Regex(@"^Move ([^:]*): (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" },
                        Parent = new ElementDescriptor { Id = captures[4], Label = captures[3] },
                        Position = Int32.Parse(captures[5], CultureInfo.InvariantCulture)
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Move (.*)\((\d+)\) into (.*)\((\d+)\) at (\d+)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new MoveOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] },
                        Parent = new ElementDescriptor { Id = captures[3], Label = captures[2] },
                        Position = Int32.Parse(captures[4], CultureInfo.InvariantCulture)
                    })
                },
                new { Pattern = new Regex(@"^Delete ([^:]*): (.*)\((\d+)\)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[2], Label = captures[0], Value = captures[0] == "name" ? captures[1] : "##" }
                    })
                },
                new
                {
                    Pattern = new Regex(@"^Delete (.*)\((\d+)\)"),
                    Selector = new Func<string[], OperationDescriptor>(captures => new DeleteOperationDescriptor
                    {
                        Element = new ElementDescriptor { Id = captures[1], Label = captures[0] }
                    })
                }
            };
            var diffActions = diffOutput.Where(l => !l.StartsWith("Match ")).Select(delegate (string s)
            {
                try
                {
                    var pattern = actionPatterns.First(p => p.Pattern.IsMatch(s));
                    var actionGroups = pattern.Pattern.Matches(s)[0].Groups;
                    var m = new Group[actionGroups.Count];
                    actionGroups.CopyTo(m, 0);
                    return pattern.Selector(m.Select(m1 => m1.Value).Where(m1 => m1 != s).ToArray());
                }
                catch (Exception)
                {
                    
                    throw;
                }
                //return new InsertOperationDescriptor
                //{
                //    Element = new ElementDescriptor { Id = "179", Label = "literal", Value =  "##" },
                //    Parent = new ElementDescriptor { Id = "180", Label = "expr" },
                //    Position = 0
                //};
            }).ToArray();
            this.CompleteDeltaActionsInfo(actions, diffActions);
        }

        /// <summary>
        /// Completes the information of existing descriptions of matches.
        /// </summary>
        /// <param name="matches">existing matches to complete.</param>
        /// <param name="diffMatches">informations to complete from.</param>
        public virtual void CompleteDeltaMatchesInfo(IEnumerable<RevisionDescriptor> matches, RevisionDescriptor[] diffMatches)
        {
            var matchesToComplete = matches as RevisionDescriptor[] ?? matches.ToArray();
            foreach (var revisionDescriptor in diffMatches)
            {
                var matchToComplete = matchesToComplete.Single(m => m.Original.Id == revisionDescriptor.Original.Id &&
                                                                    m.Modified.Id == revisionDescriptor.Modified.Id);

                matchToComplete.Original.Id = revisionDescriptor.Original.Id;
                matchToComplete.Original.Label = revisionDescriptor.Original.Label;
                matchToComplete.Original.Value = revisionDescriptor.Original.Value;
                matchToComplete.Modified.Id = revisionDescriptor.Modified.Id;
                matchToComplete.Modified.Label = revisionDescriptor.Modified.Label;
                matchToComplete.Modified.Value = revisionDescriptor.Modified.Value;
            }
        }

        /// <summary>
        /// Completes the information of existing descriptions of edit actions.
        /// </summary>
        /// <param name="actions">existing actions to complete.</param>
        /// <param name="diffActions">informations to complete from.</param>
        public virtual void CompleteDeltaActionsInfo(IEnumerable<OperationDescriptor> actions, OperationDescriptor[] diffActions)
        {
            var actionsToComplete = actions as OperationDescriptor[] ?? actions.ToArray();
            foreach (var diffAction in diffActions)
            {
                switch (diffAction.Action)
                {
                    case ActionKind.Update:
                        var update = (UpdateOperationDescriptor) diffAction;
                        var updateToComplete = actionsToComplete.OfType<UpdateOperationDescriptor>()
                            .Single(u => u.Element.Id == update.Element.Id && u.Value == update.Value);
                        updateToComplete.Element.Label = update.Element.Label;
                        updateToComplete.Element.Value = update.Element.Value;
                        break;
                    case ActionKind.Insert:
                        var insert = (InsertOperationDescriptor) diffAction;
                        var insertToComplete = actionsToComplete.OfType<InsertOperationDescriptor>()
                            .Single(i => i.Element.Id == insert.Element.Id &&
                                         i.Parent.Id == insert.Parent.Id &&
                                         i.Position == insert.Position);
                        insertToComplete.Element.Label = insert.Element.Label;
                        insertToComplete.Element.Value = insert.Element.Value;
                        insertToComplete.Parent.Label = insert.Parent.Label;
                        insertToComplete.Parent.Value = insert.Parent.Value;
                        break;
                    case ActionKind.Delete:
                        var delete = (DeleteOperationDescriptor) diffAction;
                        var deleteToComplete = actionsToComplete.OfType<DeleteOperationDescriptor>()
                            .Single(i => i.Element.Id == delete.Element.Id);
                        deleteToComplete.Element.Label = delete.Element.Label;
                        deleteToComplete.Element.Value = delete.Element.Value;
                        break;
                    case ActionKind.Move:
                        var move = (MoveOperationDescriptor) diffAction;
                        var moveToComplete = actionsToComplete.OfType<MoveOperationDescriptor>()
                            .Single(i => i.Element.Id == move.Element.Id &&
                                         i.Parent.Id == move.Parent.Id &&
                                         i.Position == move.Position);
                        moveToComplete.Element.Label = move.Element.Label;
                        moveToComplete.Parent.Label = move.Parent.Label;
                        moveToComplete.Element.Value = move.Element.Value;
                        moveToComplete.Parent.Value = move.Parent.Value;
                        break;
                    case ActionKind.Align:
                        var align = (AlignOperationDescriptor) diffAction;
                        var alignToComplete = actionsToComplete.OfType<AlignOperationDescriptor>()
                            .Single(i => i.Element.Id == align.Element.Id &&
                                         i.Position == align.Position);
                        alignToComplete.Element.Label = align.Element.Label;
                        alignToComplete.Element.Value = align.Element.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
