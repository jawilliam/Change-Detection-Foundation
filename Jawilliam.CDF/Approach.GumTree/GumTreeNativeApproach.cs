using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
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
        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        public override void Proceed(InteropArgs args)
        {
            base.Proceed(args);
            this.Result = new DetectionResult();

            string header = "Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\nE:\\MyRepositories\\Change-Detection-Foundation\\Jawilliam.CDF.Labs\\bin\\Debug>E:\r\n\r\nE:\\MyRepositories\\Change-Detection-Foundation\\Jawilliam.CDF.Labs\\bin\\Debug>cd E:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin\r\n\r\nE:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\nE:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin>gumtree.bat axmldiff E:\\SourceCode\\OriginalAbstractBoardGame.cs E:\\SourceCode\\ModifiedAbstractBoardGame.cs\r\n";
            string output = ExecuteCommand(args, header, $"gumtree.bat axmldiff {args.Original} {args.Modified}", "\n");
            XDocument axmlDiff = XDocument.Parse(output);

            header = "Microsoft Windows [Versión 10.0.10586]\r\n(c) 2015 Microsoft Corporation. Todos los derechos reservados.\r\n\r\nE:\\MyRepositories\\Change-Detection-Foundation\\Jawilliam.CDF.Labs\\bin\\Debug>E:\r\n\r\nE:\\MyRepositories\\Change-Detection-Foundation\\Jawilliam.CDF.Labs\\bin\\Debug>cd E:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin\r\n\r\nE:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin>set PATH=%PATH%;C:\\Program Files (x86)\\srcML 0.9.5\\bin\r\n\r\nE:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin>gumtree.bat jsondiff E:\\SourceCode\\OriginalAbstractBoardGame.cs E:\\SourceCode\\ModifiedAbstractBoardGame.cs\r\n";
            output = ExecuteCommand(args, header, $"gumtree.bat jsondiff {args.Original} {args.Modified}", "");
            XDocument xjsonDiff;
            using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(output), XmlDictionaryReaderQuotas.Max))
            {
                var xml = XElement.Load(jsonReader);
                xjsonDiff = XDocument.Parse(xml.ToString());
            }

            this.Result.Matches = this.ToMatchingDescriptors(xjsonDiff, axmlDiff).ToList();
            this.Result.Actions = this.ToActionDescriptors(xjsonDiff).ToList();
        }

        private string ExecuteCommand(InteropArgs args, string header, string command, string sPrefix)
        {
            string result;
            using (var process = new Process())
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
                result = result.Replace($"{sPrefix}E:\\SourceCode\\gumtree-20170525-2.1.0-SNAPSHOT\\bin>", "");
                process.Close();
            }

            return result;
        }

        /// <summary>
        /// Converts the native XML-based matching result into 
        /// </summary>
        /// <param name="native"></param>
        /// <returns></returns>
        private IEnumerable<RevisionDescriptor> ToMatchingDescriptors(XDocument native, XDocument axmlDiff)
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

            //foreach (var matchingItem in axmlDiff.Elements())
            //{

            //}
            //var xMatches = native.Root.Element("actions");
        }

        /// <summary>
        /// Converts the native XML-based differencing result into standard elements.
        /// </summary>
        /// <param name="native"></param>
        /// <returns></returns>
        private IEnumerable<ActionDescriptor> ToActionDescriptors(XDocument native)
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

            //foreach (var matchingItem in this.MatchingResult)
            //{

            //}
            //var xMatches = native.Root.Element("actions");
        }
    }
}
