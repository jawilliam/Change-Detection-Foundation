using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        partial class GumTree
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            /// <example>gumtree compare 
            /// NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward
            /// NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia
            /// 28
            /// -trace=D:\ExperimentLogs\NativeGumtree_RMBPITF_VsRMBPITB_VsRMNPITF_VsRMBPNTF.txt
            /// -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward
            /// -approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia
            /// -fileFormat=28
            /// -direction=Backward
            /// -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward
            /// -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia
            /// -fileFormat=20
            /// -direction=Forward
            /// -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward
            /// -approach=NativeGTtreefiedRoslynMLWithBasicPruning
            /// -fileFormat=12
            /// -direction=Forward
            /// -to=25</example>
            [ApplicationMetadata(Name = "compare", Description = "Compares...")]
            public virtual void CompareCommand(RunCompareArgs args)
            {
                var refApproach = new
                {
                    Name = args.RefName,
                    Approach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.RefApproach),
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.RefFileFormat),
                };

                var configurations = args.Names.Select((r, i) => new
                {
                    Name = r,
                    Approach = i < args.Approaches.Count 
                        ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i]) 
                        : default,
                    FileFormat = i < args.FileFormats.Count
                        ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                        : default,
                    Direction = i < args.Directions.Count ? args.Directions[i] : null
                });

                var frpPerProjects = OnTheseConfig(args.OnThese)?.ToList();
                var skipThesefrpPerProjects = OnTheseConfig(args.SkipThese)?.ToList();

                var recognizer = new BetweenComparison { MillisecondsTimeout = 600000 };
                foreach (var project in ProjectsConfig(Projects, args.From, args.To, frpPerProjects))
                {
                    var frps = frpPerProjects?.Where(frp => frp.project == project.Name).ToDictionary(frp => frp.frpId);
                    var skipFrps = skipThesefrpPerProjects?.Where(frp => frp.project == project.Name).ToDictionary(frp => frp.frpId);

                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        //var deltaIds = DeltasConfig(project.Name,
                        //    from d in dbRepository.Deltas
                        //    where d.Report == null && d.Approach == configuration.Approach
                        //    select d.Id, frpPerProjects);

                        switch (configuration.Direction)
                        {
                            case "Forward":
                                recognizer.ConfigLeftVsRight((refApproach.Approach, refApproach.Name), (configuration.Approach, configuration.Name));
                                break;
                            case "Backward":
                                recognizer.ConfigForwardVsBackward((refApproach.Approach, refApproach.Name), (configuration.Approach, configuration.Name));
                                break;
                            default: throw new ArgumentException($"Unexpected value: {configuration.Direction}");
                        }

                        recognizer.SqlRepository = dbRepository;
                        recognizer.Cancel = null;

                        bool skipThese(FileRevisionPair pair)
                        {
                            if (skipFrps?.ContainsKey(pair.Principal.Id) ?? false)
                                return true;

                            var anyOriginal = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FromFileVersion.Id && ff.Kind == refApproach.FileFormat);
                            var anyModified = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FileVersion.Id && ff.Kind == configuration.FileFormat);

                            return !anyOriginal || !anyModified || (!frps?.ContainsKey(pair.Principal.Id) ?? false);
                        }

                        ElementTree result = null;
                        Dictionary<string, ElementTree> lOriginalTree = null, lModifiedTree = null, rOriginalTree = null, rModifiedTree = null;
                        recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) a)
                        {
                            FileFormat version = null;
                            if (a.Delta.Approach == refApproach.Approach)
                            {
                                version = a.TrueForOriginalOtherwiseModified
                                    ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == refApproach.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == refApproach.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
                            }
                            else if(configuration.Direction == "Forward")
                            {
                                version = a.TrueForOriginalOtherwiseModified
                                    ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == configuration.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == configuration.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
                            }
                            else // "Backward"
                            {
                                version = !a.TrueForOriginalOtherwiseModified
                                    ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == configuration.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == configuration.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
                            }

                            if (!args.Limited)
                            {
                                var xTree = XElement.Load(new StringReader(version.XmlTree));
                                var roslynMlServices = new RoslynML();

                                result = roslynMlServices.AsGumtreefiedElementTree(xTree, true);
                                if (a.Delta.Approach == refApproach.Approach)
                                {
                                    if (a.TrueForOriginalOtherwiseModified)
                                        lOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
                                    else
                                        lModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
                                }
                                else
                                {
                                    if (a.TrueForOriginalOtherwiseModified)
                                        rOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
                                    else
                                        rModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
                                }
                            }
                            else
                            {
                                result = ElementTree.Read(version.XmlTree, Encoding.Unicode);
                            }

                            return result;
                        };

                        recognizer.Config.Align = delegate (ElementTree o, ElementTree m, DetectionResult d, bool trueForLeftOtherwiseRight)
                        {
                            if (args.Limited) return;

                            var oDict = o.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);
                            var mDict = m.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);

                            foreach (var match in d.Matches)
                            {
                                if (!(match.Expanded ?? false))
                                {
                                    var o1 = oDict[match.Original.Id];
                                    match.Original.Id = o1.Root.Id;
                                    var m1 = mDict[match.Modified.Id];
                                    match.Modified.Id = m1.Root.Id;
                                }
                                else
                                {
                                    match.Original.Id = match.Original.GlobalId;
                                    match.Modified.Id = match.Modified.GlobalId;
                                }
                            }
                        };

                        if (configuration.Direction == "Forward")
                        {
                            var innerMatchCompare = recognizer.Config.MatchCompare;
                            recognizer.Config.MatchCompare = delegate (string direction, MatchDescriptor leftMatch, DetectionResult leftDelta,
                                                                                         MatchDescriptor rightMatch, DetectionResult rightDelta)
                            {
                                if (!args.Limited && direction == "LR" && !rOriginalTree.ContainsKey(leftMatch.Original.Id) && !rModifiedTree.ContainsKey(leftMatch.Modified.Id))
                                    return true;

                                if (!args.Limited && direction == "RL" && !lOriginalTree.ContainsKey(leftMatch.Original.Id) && !lModifiedTree.ContainsKey(leftMatch.Modified.Id))
                                    return true;

                                return innerMatchCompare(direction, leftMatch, leftDelta, rightMatch, rightDelta);
                            };
                        }

                        recognizer.Warnings = new StringBuilder();
                        if (args.Trace != null)
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{refApproach.Name}Vs{configuration.Name} {configuration.Direction} (comparison) started " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                        recognizer.Recognize(skipThese, /*false*/true);
                        if (args.Trace != null)
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{refApproach.Name}Vs{configuration.Name} {configuration.Direction} (comparison) completed " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    }
                }
                Console.Out.WriteLine($"DONE!!!");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            /// <example>
            /// GumTree compare-on-fly roslynml_bp NativeGTtreefiedRoslynMLWithBasicPruning D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia 12 roslynml_bpd NativeGTtreefiedRoslynMLWithBasicPruningDefoliation D:\GT_Runtimes\gumtree_RML_BP_NT_De_0mh 44 D:\Reports\a1_Original.cs D:\Reports\a1_Modified.cs
            /// GumTree compare-on-fly roslynml NativeGTtreefiedRoslynML D:\GT_Runtimes\gumtree_RML 5 roslynml_bp NativeGTtreefiedRoslynMLWithBasicPruning D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia 12 D:\Reports\a1_Original.cs D:\Reports\a1_Modified.cs</example>
            [ApplicationMetadata(Name = "compare-on-fly", Description = "Compares...")]
            public virtual void CompareOnFlyCommand(RunCompareOnFlyArgs args)
            {
                var leftApproach = new
                {
                    Name = args.LeftName,
                    Approach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.LeftApproach),
                    Runtime = args.LeftRuntime,
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.LeftFileFormat),
                };
                var rightApproach = new
                {
                    Name = args.RightName,
                    Approach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.RightApproach),
                    Runtime = args.RightRuntime,
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.RightFileFormat),
                };

                var recognizer = new BetweenComparison { MillisecondsTimeout = 600000 };
                switch (args.Direction)
                {
                    case "Forward":
                        recognizer.ConfigLeftVsRight((leftApproach.Approach, leftApproach.Name), (rightApproach.Approach, rightApproach.Name));
                        break;
                    case "Backward":
                        recognizer.ConfigForwardVsBackward((leftApproach.Approach, leftApproach.Name), (rightApproach.Approach, rightApproach.Name));
                        break;
                    default: throw new ArgumentException($"Unexpected value: {args.Direction}");
                }

                ElementTree result = null;
                Dictionary<string, ElementTree> lOriginalTree = null, lModifiedTree = null, rOriginalTree = null, rModifiedTree = null;
                Dictionary<string, XElement> xlOriginalTree = null, xlModifiedTree = null, xrOriginalTree = null, xrModifiedTree = null;
                recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) a)
                {
                    string filePath = null;
                    if (a.Delta.Approach == leftApproach.Approach)
                        filePath = a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;
                    else if (args.Direction == "Forward")
                        filePath = a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;
                    else // "Backward"
                        filePath = !a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;

                    var approach = a.Delta.Approach == leftApproach.Approach ? leftApproach : rightApproach;
                    var xmlPath = filePath.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0] + ".xml";
                    var saveTreesArgs = new RoslynMLSaveTreesCommandArgs
                    {
                        FullPath = filePath,
                        Defoliate = (approach.FileFormat & FileFormatKind.Defoliation) != 0,
                        IncludeTrivia = (approach.FileFormat & FileFormatKind.IncludeTrivia) != 0,
                        Pruning = (approach.FileFormat & FileFormatKind.BasicPruning) != 0 ? "Basic" : null,
                        //Gumtreefy = true,
                        SaveToFile = xmlPath,
                    };
                    CCL.SharedRoslynML(saveTreesArgs);

                    var roslynMlServices = new RoslynML();
                    var xTree = XElement.Load(new StringReader(System.IO.File.ReadAllText(xmlPath)));
                    roslynMlServices.ReassignGtIds(xTree);
                    System.IO.File.WriteAllText(xmlPath, xTree.ToString());

                    if (!args.Limited)
                    {
                        xTree = XElement.Load(new StringReader(System.IO.File.ReadAllText(xmlPath)));
                        result = roslynMlServices.AsGumtreefiedElementTree(xTree, true);
                        if (a.Delta.Approach == leftApproach.Approach)
                        {
                            if (a.TrueForOriginalOtherwiseModified)
                            {
                                lOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null)
                                    .ToDictionary(n => n.Root.Id);
                                xlOriginalTree = xTree.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                                    .ToDictionary(n => n.RmId());
                            }
                            else
                            {
                                lModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null)
                                    .ToDictionary(n => n.Root.Id);
                                xlModifiedTree = xTree.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                                    .ToDictionary(n => n.RmId());
                            }
                        }
                        else
                        {
                            if (a.TrueForOriginalOtherwiseModified)
                            {
                                rOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null)
                                    .ToDictionary(n => n.Root.Id);
                                xrOriginalTree = xTree.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                                    .ToDictionary(n => n.RmId());
                            }
                            else
                            {
                                rModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null)
                                    .ToDictionary(n => n.Root.Id);
                                xrModifiedTree = xTree.PostOrder(n => n.Elements().Where(ne => ne is XNode))
                                    .ToDictionary(n => n.RmId());
                            }
                        }
                    }
                    else
                    {
                        result = ElementTree.Read(xmlPath, Encoding.Unicode);
                    }

                    return result;
                };

                recognizer.Config.Align = delegate (ElementTree o, ElementTree m, DetectionResult d, bool trueForLeftOtherwiseRight)
                {
                    if (args.Limited) return;

                    var oDict = o.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);
                    var mDict = m.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);

                    foreach (var match in d.Matches)
                    {
                        var o1 = oDict[match.Original.Id];
                        match.Original.Id = o1.Root.Id;
                        var m1 = mDict[match.Modified.Id];
                        match.Modified.Id = m1.Root.Id;
                    }
                };

                if (args.Direction == "Forward")
                {
                    var innerMatchCompare = recognizer.Config.MatchCompare;
                    recognizer.Config.MatchCompare = delegate (string direction, MatchDescriptor leftMatch,
                        DetectionResult leftDelta,
                        MatchDescriptor rightMatch, DetectionResult rightDelta)
                    {
                        if (!args.Limited && direction == "LR" &&
                            (!rOriginalTree.ContainsKey(leftMatch.Original.Id) ||
                             !rModifiedTree.ContainsKey(leftMatch.Modified.Id)))
                            return true;

                        if (!args.Limited && direction == "RL" &&
                            (!lOriginalTree.ContainsKey(leftMatch.Original.Id) ||
                             !lModifiedTree.ContainsKey(leftMatch.Modified.Id)))
                            return true;

                        return innerMatchCompare(direction, leftMatch, leftDelta, rightMatch, rightDelta);
                    };
                }

                var gumTree = new GumTreeNativeApproach();
                gumTree.Run(new InteropArgs
                {
                    GumTreePath = leftApproach.Runtime,
                    Original = args.OriginalPath,
                    Modified = args.ModifiedPath
                });
                var lDelta = new Delta { Approach = leftApproach.Approach, DetectionResult = gumTree.Result };

                gumTree.Run(new InteropArgs
                {
                    GumTreePath = rightApproach.Runtime,
                    Original = args.Direction == "Forward" ? args.OriginalPath : args.ModifiedPath,
                    Modified = args.Direction == "Forward" ? args.ModifiedPath : args.OriginalPath
                });
                var rDelta = new Delta { Approach = rightApproach.Approach, DetectionResult = gumTree.Result };

                recognizer.Warnings = new StringBuilder();
                var betweenSymptoms = recognizer.Compare(lDelta, rDelta, new FileRevisionPair { Id = Guid.Empty }, CancellationToken.None).ToList();
                for (var i = 0; i < betweenSymptoms.Count; i++)
                {
                    var bs = betweenSymptoms[i];
                    if (bs is LRMatchSymptom lrMismatch)
                    {
                        var xLeftOriginal = xlOriginalTree[lrMismatch.Left.Original.Element.Id];
                        var xLeftModified = xlModifiedTree[lrMismatch.Left.Modified.Element.Id];
                        var xOriginalAtRightOriginal = lrMismatch.OriginalAtRight.Original.Element.Id != "-1"
                            ? xlOriginalTree[lrMismatch.OriginalAtRight.Original.Element.Id]
                            : null;
                        var xOriginalAtRightModified = lrMismatch.OriginalAtRight.Modified.Element.Id != "-1"
                            ? xlModifiedTree[lrMismatch.OriginalAtRight.Modified.Element.Id]
                            : null;
                        var xModifiedAtRightOriginal = lrMismatch.ModifiedAtRight.Original.Element.Id != "-1"
                            ? xlOriginalTree[lrMismatch.ModifiedAtRight.Original.Element.Id]
                            : null;
                        var xModifiedAtRightModified = lrMismatch.ModifiedAtRight.Modified.Element.Id != "-1"
                            ? xlModifiedTree[lrMismatch.ModifiedAtRight.Modified.Element.Id]
                            : null;
                        Console.WriteLine($"[#{i + 1}] " +
                            $"Left-({lrMismatch.Left.Original.Element.Id} " +
                            $"{lrMismatch.Left.Original.Element.Type} " +
                            $"{(lrMismatch.Left.Original.Element.Hint ?? "").Hint()} " +
                            $"{xLeftOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xLeftOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{lrMismatch.Left.Modified.Element.Id} " +
                            $"{lrMismatch.Left.Modified.Element.Type} " +
                            $"{(lrMismatch.Left.Modified.Element.Hint ?? "").Hint()} " +
                            $"{xLeftModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xLeftModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) " +
                            $"OriginalAtRight-({lrMismatch.OriginalAtRight?.Original?.Element?.Id ?? "NULL"} " +
                            $"{lrMismatch.OriginalAtRight?.Original?.Element?.Type ?? ""} " +
                            $"{(lrMismatch.OriginalAtRight?.Original?.Element?.Hint ?? "").Hint()} " +
                            $"{xOriginalAtRightOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xOriginalAtRightOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{lrMismatch.OriginalAtRight?.Modified?.Element?.Id ?? "NULL"} " +
                            $"{lrMismatch.OriginalAtRight?.Modified?.Element?.Type ?? ""} " +
                            $"{(lrMismatch.OriginalAtRight?.Modified?.Element?.Hint ?? "").Hint()} " +
                            $"{xOriginalAtRightModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xOriginalAtRightModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) " +
                            $"ModifiedAtRight-({lrMismatch.ModifiedAtRight?.Original?.Element?.Id ?? "NULL"} " +
                            $"{lrMismatch.ModifiedAtRight?.Original?.Element?.Type ?? ""} " +
                            $"{(lrMismatch.ModifiedAtRight?.Original?.Element?.Hint ?? "").Hint()} " +
                            $"{xModifiedAtRightOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xModifiedAtRightOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{lrMismatch.ModifiedAtRight?.Modified?.Element?.Id ?? "NULL"} " +
                            $"{lrMismatch.ModifiedAtRight?.Modified?.Element?.Type ?? ""} " +
                            $"{(lrMismatch.ModifiedAtRight?.Modified?.Element?.Hint ?? "").Hint()} " +
                            $"{xModifiedAtRightModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xModifiedAtRightModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) ");
                    }
                    else
                    {
                        var rlMismatch = (RLMatchSymptom)bs;
                        var xRightOriginal = xlOriginalTree[rlMismatch.Right.Original.Element.Id];
                        var xRightModified = xlModifiedTree[rlMismatch.Right.Modified.Element.Id];
                        var xOriginalAtLeftOriginal = rlMismatch.OriginalAtLeft.Original.Element.Id != "-1"
                            ? xlOriginalTree[rlMismatch.OriginalAtLeft.Original.Element.Id]
                            : null;
                        var xOriginalAtLeftModified = rlMismatch.OriginalAtLeft.Modified.Element.Id != "-1"
                            ? xlModifiedTree[rlMismatch.OriginalAtLeft.Modified.Element.Id]
                            : null;
                        var xModifiedAtLeftOriginal = rlMismatch.ModifiedAtLeft.Original.Element.Id != "-1"
                            ? xlOriginalTree[rlMismatch.ModifiedAtLeft.Original.Element.Id]
                            : null;
                        var xModifiedAtLeftModified = rlMismatch.ModifiedAtLeft.Modified.Element.Id != "-1"
                            ? xlModifiedTree[rlMismatch.ModifiedAtLeft.Modified.Element.Id]
                            : null;
                        Console.WriteLine($"[#{i + 1}] " +
                            $"Right-({rlMismatch.Right.Original.Element.Id} " +
                            $"{rlMismatch.Right.Original.Element.Type} " +
                            $"{(rlMismatch.Right.Original.Element.Hint ?? "").Hint()} " +
                            $"{xRightOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xRightOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{rlMismatch.Right.Modified.Element.Id} " +
                            $"{rlMismatch.Right.Modified.Element.Type} " +
                            $"{(rlMismatch.Right.Modified.Element.Hint ?? "").Hint()}) " +
                            $"{xRightModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xRightModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) " +
                            $"OriginalAtLeft-({rlMismatch.OriginalAtLeft?.Original?.Element?.Id ?? "NULL"} " +
                            $"{rlMismatch.OriginalAtLeft?.Original?.Element?.Type ?? ""} " +
                            $"{(rlMismatch.OriginalAtLeft?.Original?.Element?.Hint ?? "").Hint()} " +
                            $"{xOriginalAtLeftOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xOriginalAtLeftOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{rlMismatch.OriginalAtLeft?.Modified?.Element?.Id ?? "NULL"} " +
                            $"{rlMismatch.OriginalAtLeft?.Modified?.Element?.Type ?? ""} " +
                            $"{(rlMismatch.OriginalAtLeft?.Modified?.Element?.Hint ?? "").Hint()} " +
                            $"{xOriginalAtLeftModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xOriginalAtLeftModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) " +
                            $"ModifiedAtLeft-({rlMismatch.ModifiedAtLeft?.Original?.Element?.Id ?? "NULL"} " +
                            $"{rlMismatch.ModifiedAtLeft?.Original?.Element?.Type ?? ""} " +
                            $"{(rlMismatch.ModifiedAtLeft?.Original?.Element?.Hint ?? "").Hint()} " +
                            $"{xModifiedAtLeftOriginal?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xModifiedAtLeftOriginal?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}, " +
                            $"{rlMismatch.ModifiedAtLeft?.Modified?.Element?.Id ?? "NULL"} " +
                            $"{rlMismatch.ModifiedAtLeft?.Modified?.Element?.Type ?? ""} " +
                            $"{(rlMismatch.ModifiedAtLeft?.Modified?.Element?.Hint ?? "").Hint()} " +
                            $"{xModifiedAtLeftModified?.StartLine().ToString(CultureInfo.InvariantCulture) ?? ""} " +
                            $"{xModifiedAtLeftModified?.StartColumn().ToString(CultureInfo.InvariantCulture) ?? ""}) ");
                    }
                }

                Console.Out.WriteLine($"DONE!!!");
            }

            //internal static ElementTree GetTree((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) a, GitRepository dbRepository,
            //                      (FileFormatKind FileFormat, ChangeDetectionApproaches Approach) l, 
            //                      (FileFormatKind FileFormat, ChangeDetectionApproaches Approach, string Direction) r,
            //                      out ElementTree result,
            //                      ref Dictionary<string, ElementTree> lOriginalTree, 
            //                      ref Dictionary<string, ElementTree> lModifiedTree, 
            //                      ref Dictionary<string, ElementTree> rOriginalTree, 
            //                      ref Dictionary<string, ElementTree> rModifiedTree)
            //{
            //    FileFormat version = null;
            //    if (a.Delta.Approach == l.Approach)
            //    {
            //        version = a.TrueForOriginalOtherwiseModified
            //            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == l.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
            //            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == l.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
            //    }
            //    else if (r.Direction == "Forward")
            //    {
            //        version = a.TrueForOriginalOtherwiseModified
            //            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == r.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
            //            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == r.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
            //    }
            //    else // "Backward"
            //    {
            //        version = !a.TrueForOriginalOtherwiseModified
            //            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == r.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FromFileVersion.Id)
            //            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == r.FileFormat && ff.FileVersion.Id == a.Pair.Principal.FileVersion.Id);
            //    }

            //    var xTree = XElement.Load(new StringReader(version.XmlTree));
            //    var roslynMLServices = new RoslynML();

            //    result = roslynMLServices.AsGumtreefiedElementTree(xTree, true);
            //    if (a.Delta.Approach == l.Approach)
            //    {
            //        if (a.TrueForOriginalOtherwiseModified)
            //            lOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            //        else
            //            lModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            //    }
            //    else
            //    {
            //        if (a.TrueForOriginalOtherwiseModified)
            //            rOriginalTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            //        else
            //            rModifiedTree = result.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            //    }

            //    return result;
            //}
        }

        [ApplicationMetadata(Name = "Compare", Description = "...compare...")]
        [SubCommand]
        public class Compare
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            /// <example>
            /// Compare stats NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\ExperimentLogs\BetweenSymptomsStats2.txt -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward -approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia -fileFormat=28 -direction=Backward -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=1 -to=25
            /// Compare stats NativeGumTree_Forward NativeGumTree 1 -trace=D:\ExperimentLogs\BetweenSymptomsStats_2_5.txt -name=NativeGumTree_Backward -approach=InverseOfNativeGumTree -fileFormat=1 -direction=Backward -from=1 -to=25
            /// </example>
            [ApplicationMetadata(Name = "stats", Description = "Compares...")]
            public virtual void StatsCompareCommand(RunCompareArgs args)
            {
                var refApproach = new
                {
                    Name = args.RefName,
                    Approach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.RefApproach),
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.RefFileFormat),
                };

                var configurations = args.Names.Select((r, i) => new
                {
                    Name = r,
                    Approach = i < args.Approaches.Count
                        ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i])
                        : default,
                    FileFormat = i < args.FileFormats.Count
                        ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                        : default,
                    Direction = i < args.Directions.Count ? args.Directions[i] : null
                });

                this.WriteHeadLine(refApproach.Approach, configurations.Select(c => c.Approach), args.Trace);

                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                    {
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                        var revisionPairIds = (from d in dbRepository.Deltas.AsNoTracking()
                                               where d.Report == null
                                               orderby d.RevisionPair.Id
                                               select d.RevisionPair.Id).Distinct().ToArray();
                        int counter = 0;
                        foreach (var revisionPairId in revisionPairIds)
                        {
                            Console.Out.WriteLine($"Starting {++counter}-{dbRepository.Name} ({revisionPairIds.Count()}) Guid-{revisionPairId}");
                            try
                            {
                                bool @continue = false;
                                var refDelta = dbRepository.Deltas.AsNoTracking()
                                    .Include("RevisionPair.FromFileVersion").Include("RevisionPair.FileVersion")
                                    .SingleOrDefault(d => d.Approach == refApproach.Approach &&
                                                          d.RevisionPair.Id == revisionPairId);
                                if (refDelta == null || refDelta.Matching == null || refDelta.Differencing == null)
                                    continue;

                                ElementTree originalTree = null, modifiedTree = null;
                                var refTreeRevisionPair = this._GetElementTrees(dbRepository, refDelta, refApproach.FileFormat,
                                    "Forward", ref @continue, ref originalTree, ref modifiedTree);
                                if (@continue)
                                    continue;
                                var refStats = this._AbsoluteStatsFor2(dbRepository, refDelta, originalTree, modifiedTree, ref @continue);
                                if (@continue)
                                    continue;

                                var rightStatsList = new List<(int matches, int actions, int inserts, int deletes, int updates, int moves)>(configurations.Count());
                                var lrStatsList = new List<(int matches, int actions, int inserts, int deletes, int updates, int moves)>(configurations.Count());
                                var rlStatsList = new List<(int matches, int actions, int inserts, int deletes, int updates, int moves)>(configurations.Count());
                                var comparisonStatsList = new List<(int lr, int rl, int total)>(configurations.Count());
                                var treeRevisionPairList = new List<(Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified)>(configurations.Count());
                                foreach (var configuration in configurations)
                                {
                                    var rightDelta = dbRepository.Deltas.AsNoTracking()
                                        .Include("RevisionPair.FromFileVersion").Include("RevisionPair.FileVersion")
                                        .SingleOrDefault(d => d.Approach == configuration.Approach &&
                                                              d.RevisionPair.Id == revisionPairId);
                                    if (rightDelta == null || rightDelta.Matching == null || rightDelta.Differencing == null)
                                        break;

                                    originalTree = null; modifiedTree = null;
                                    treeRevisionPairList.Add(this._GetElementTrees(dbRepository, rightDelta, configuration.FileFormat,
                                        configuration.Direction, ref @continue, ref originalTree, ref modifiedTree));
                                    if (@continue)
                                        continue;

                                    var last = treeRevisionPairList.Last();
                                    var rStats = this._AbsoluteStatsFor2(dbRepository, rightDelta, originalTree, modifiedTree, ref @continue);
                                    //lrStatsList.Add(this._RelativeStatsFor2(dbRepository, refDelta, refTreeRevisionPair, last, args.Limited, ref @continue));
                                    //rlStatsList.Add(this._RelativeStatsFor2(dbRepository, rightDelta,
                                    //    configuration.Direction == "Forward" ? last : (last.modified, last.original),
                                    //    configuration.Direction == "Forward" ? refTreeRevisionPair : (refTreeRevisionPair.modified, refTreeRevisionPair.original),
                                    //    args.Limited, ref @continue));
                                    if (@continue)
                                        break;
                                    rightStatsList.Add(rStats);
                                    comparisonStatsList.Add(this._StatsOfComparisonFor(dbRepository, refDelta, rightDelta, ref @continue));
                                    if (@continue)
                                        break;
                                }

                                if (rightStatsList.Count != configurations.Count() || comparisonStatsList.Count != configurations.Count())
                                    continue;

                                StringBuilder line = new StringBuilder();
                                line.Append($"{dbRepository.Name};{revisionPairId};");
                                line.Append($"{refStats.matches};{refStats.actions};{refStats.inserts};" +
                                    $"{refStats.deletes};{refStats.updates};{refStats.moves}");
                                for (int i = 0; i < rightStatsList.Count; i++)
                                {
                                    line.Append($";{rightStatsList[i].matches};{rightStatsList[i].actions};" +
                                            $"{rightStatsList[i].inserts};{rightStatsList[i].deletes};" +
                                            $"{rightStatsList[i].updates};{rightStatsList[i].moves};");
                                    line.Append($";;" +
                                           $";;" +
                                           $";;");
                                    line.Append($";;" +
                                            $";;" +
                                            $";;");
                                    //line.Append($";;");
                                    //line.Append($"{lrStatsList[i].matches};{lrStatsList[i].actions};" +
                                    //        $"{lrStatsList[i].inserts};{lrStatsList[i].deletes};" +
                                    //        $"{lrStatsList[i].updates};{lrStatsList[i].moves};");
                                    //line.Append($"{rlStatsList[i].matches};{rlStatsList[i].actions};" +
                                    //        $"{rlStatsList[i].inserts};{rlStatsList[i].deletes};" +
                                    //        $"{rlStatsList[i].updates};{rlStatsList[i].moves};");
                                    line.Append($"{comparisonStatsList[i].total};{comparisonStatsList[i].lr};{comparisonStatsList[i].rl}");
                                }

                                line.Append($"{Environment.NewLine}");
                                System.IO.File.AppendAllText(args.Trace, line.ToString());

                                Console.Out.WriteLine($"Ending the {counter}-{dbRepository.Name} ({revisionPairIds.Count()}) Guid-{revisionPairId}");
                            }
                            catch (Exception ex)
                            {
                                Console.Out.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }

            private void WriteHeadLine(ChangeDetectionApproaches refApproach, IEnumerable<ChangeDetectionApproaches> configurationApproaches, string trace)
            {
                var headLine = new StringBuilder();
                headLine.Append("Project;PrincipalRevisionPair;");
                headLine.Append($"#matches_{(int)refApproach};" +
                                $"#actions_{(int)refApproach};" +
                                $"#inserts_{(int)refApproach};" +
                                $"#deletes_{(int)refApproach};" +
                                $"#updates_{(int)refApproach};" +
                                $"#moves_{(int)refApproach}");

                foreach (var configurationApproach in configurationApproaches)
                {
                    headLine.Append($";#matches_{(int)configurationApproach};" +
                                    $"#actions_{(int)configurationApproach};" +
                                    $"#inserts_{(int)configurationApproach};" +
                                    $"#deletes_{(int)configurationApproach};" +
                                    $"#updates_{(int)configurationApproach};" +
                                    $"#moves_{(int)configurationApproach}");
                    headLine.Append($";#matches_{(int)refApproach}Vs{(int)configurationApproach};" +
                                    $"#actions_{(int)refApproach}Vs{(int)configurationApproach};" +
                                    $"#inserts_{(int)refApproach}Vs{(int)configurationApproach};" +
                                    $"#deletes_{(int)refApproach}Vs{(int)configurationApproach};" +
                                    $"#updates_{(int)refApproach}Vs{(int)configurationApproach};" +
                                    $"#moves_{(int)refApproach}Vs{(int)configurationApproach}");
                    headLine.Append($";#matches_{(int)configurationApproach}Vs{(int)refApproach};" +
                                    $"#actions_{(int)configurationApproach}Vs{(int)refApproach};" +
                                    $"#inserts_{(int)configurationApproach}Vs{(int)refApproach};" +
                                    $"#deletes_{(int)configurationApproach}Vs{(int)refApproach};" +
                                    $"#updates_{(int)configurationApproach}Vs{(int)refApproach};" +
                                    $"#moves_{(int)configurationApproach}Vs{(int)refApproach}");
                    headLine.Append($";#all_mismatches_{(int)refApproach}Vs{(int)configurationApproach}" +
                                    $";#mismatches_{(int)refApproach}Vs{(int)configurationApproach}" +
                                    $";#mismatches_{(int)configurationApproach}Vs{(int)refApproach}");
                }
                headLine.Append($"{Environment.NewLine}");
                System.IO.File.AppendAllText(trace, headLine.ToString());
            }

            private (int lr, int rl, int total) _StatsOfComparisonFor(GitRepository dbRepository, Delta refDelta, Delta rightDelta, ref bool @continue)
            {
                var deltaComparison = dbRepository.DeltaComparisonSet.AsNoTracking().SingleOrDefault(s => 
                    (s.Left.Id == refDelta.Id && s.Right.Id == rightDelta.Id) || 
                    (s.Right.Id == refDelta.Id && s.Left.Id == rightDelta.Id));

                if (deltaComparison == null)
                {
                    //@continue = true;
                    return (0, 0, 0);
                }

                var xComparison = deltaComparison.XMatching;

                var lr = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)refDelta.Approach) ?? 0) + 
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)refDelta.Approach) ?? 0);
                var rl = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)rightDelta.Approach) ?? 0) + 
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)rightDelta.Approach) ?? 0);
                var total = lr + rl;

                return (lr: lr, rl: rl, total: total);
            }

            private (int matches, int actions, int inserts, int deletes, int updates, int moves) _AbsoluteStatsFor(
                GitRepository dbRepository, Delta delta, ElementTree originalTree, ElementTree modifiedTree, ref bool @continue)
            {
                var detectionResult = (DetectionResult)delta.DetectionResult;
                if (detectionResult.Actions.Count == 0)
                {
                    @continue = true;
                    return (matches: 0, actions: 0, inserts: 0, deletes: 0, updates: 0, moves: 0);
                }

                var matches = detectionResult.Matches.Count();
                var inserts = detectionResult.Actions.OfType<InsertOperationDescriptor>().Count();
                var deletes = detectionResult.Actions.OfType<DeleteOperationDescriptor>().Count();
                var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count();
                var moves = detectionResult.Actions.OfType<MoveOperationDescriptor>().Count() +
                            detectionResult.Actions.OfType<AlignOperationDescriptor>().Count();

                return (matches: matches, actions: inserts + deletes + updates + moves,
                        inserts: inserts,
                        deletes: deletes,
                        updates: updates,
                        moves: moves);
            }

            private (int matches, int actions, int inserts, int deletes, int updates, int moves) _AbsoluteStatsFor2(
               GitRepository dbRepository, Delta delta, ElementTree originalTree, ElementTree modifiedTree, ref bool @continue)
            {
                var detectionResult = (DetectionResult)delta.DetectionResult;
                if (detectionResult.Actions.Count == 0)
                {
                    @continue = true;
                    return (matches: 0, actions: 0, inserts: 0, deletes: 0, updates: 0, moves: 0);
                }

                var inserts = detectionResult.Actions.OfType<InsertOperationDescriptor>().Count();
                var deletes = detectionResult.Actions.OfType<DeleteOperationDescriptor>().Count();
                var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count();
                var moves = detectionResult.Actions.OfType<MoveOperationDescriptor>().Count();

                return (matches: detectionResult.Matches.Count(), 
                        actions: inserts + deletes + updates + moves,
                        inserts: inserts,
                        deletes: deletes,
                        updates: updates,
                        moves: moves);
            }



            //private (int matches, int actions, int inserts, int deletes, int updates, int moves) _AbsoluteStatsFor2(
            //   GitRepository dbRepository, Delta delta, ElementTree originalTree, ElementTree modifiedTree, ref bool @continue)
            //{
            //    var maxNonTriviaOriginalRmlId = int.Parse(originalTree.Root.Id);
            //    var maxNonTriviaModifiedRmlId = int.Parse(modifiedTree.Root.Id);

            //    var detectionResult = (DetectionResult)delta.DetectionResult;
            //    if (detectionResult.Actions.Count == 0)
            //    {
            //        @continue = true;
            //        return (matches: 0, actions: 0, inserts: 0, deletes: 0, updates: 0, moves: 0);
            //    }

            //    //if (delta.Approach != ChangeDetectionApproaches.NativeGumTree && delta.Approach != ChangeDetectionApproaches.InverseOfNativeGumTree)
            //    //{
            //    //    detectionResult.FromGlobalToIdDefinitions(leftRevisionPair.original.Values.Single(o => o.Parent == null),
            //    //                                              leftRevisionPair.modified.Values.Single(o => o.Parent == null));
            //    //}

            //    var expandedMatches = detectionResult.Matches.Where(m =>
            //        m.Expanded ?? false &&
            //        int.Parse(m.Original.Id) <= maxNonTriviaOriginalRmlId &&
            //        int.Parse(m.Modified.Id) <= maxNonTriviaModifiedRmlId).ToArray();
            //    var expandedMatchOriginals = expandedMatches.ToDictionary(m => m.Original.Id);

            //    var matches = detectionResult.Matches.Where(m =>
            //        !(m.Expanded ?? false) &&
            //        int.Parse(m.Original.Id) <= maxNonTriviaOriginalRmlId &&
            //        int.Parse(m.Modified.Id) <= maxNonTriviaModifiedRmlId).ToArray();
            //    var matchOriginals = matches.ToDictionary(m => m.Original.Id);

            //    var inserts = detectionResult.Actions.OfType<InsertOperationDescriptor>().Count(a =>
            //        int.Parse(a.Element.Id) <= maxNonTriviaModifiedRmlId) +
            //        detectionResult.Matches.Count(m =>
            //            int.Parse(m.Original.Id) > maxNonTriviaOriginalRmlId &&
            //            int.Parse(m.Modified.Id) <= maxNonTriviaModifiedRmlId);

            //    var deletes = detectionResult.Actions.OfType<DeleteOperationDescriptor>().Count(a =>
            //        int.Parse(a.Element.Id) <= maxNonTriviaOriginalRmlId) +
            //        detectionResult.Matches.Count(m =>
            //            int.Parse(m.Original.Id) <= maxNonTriviaOriginalRmlId &&
            //            int.Parse(m.Modified.Id) > maxNonTriviaModifiedRmlId);

            //    var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count(m =>
            //        expandedMatchOriginals.ContainsKey(m.Element.Id)) +
            //                  detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count(m =>
            //        matchOriginals.ContainsKey(m.Element.Id));

            //    var moves = detectionResult.Actions.OfType<MoveOperationDescriptor>().Count(m =>
            //        expandedMatchOriginals.ContainsKey(m.Element.Id)) +
            //                detectionResult.Actions.OfType<AlignOperationDescriptor>().Count(m =>
            //        expandedMatchOriginals.ContainsKey(m.Element.Id)) +
            //                detectionResult.Actions.OfType<MoveOperationDescriptor>().Count(m =>
            //        matchOriginals.ContainsKey(m.Element.Id)) +
            //                detectionResult.Actions.OfType<AlignOperationDescriptor>().Count(m =>
            //        matchOriginals.ContainsKey(m.Element.Id));

            //    //var matches = detectionResult.Matches.Count(m => m.Original.Id);
            //    //var inserts = detectionResult.Actions.OfType<InsertOperationDescriptor>().Count();
            //    //var deletes = detectionResult.Actions.OfType<DeleteOperationDescriptor>().Count();
            //    //var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count();
            //    //var moves = detectionResult.Actions.OfType<MoveOperationDescriptor>().Count() +
            //    //            detectionResult.Actions.OfType<AlignOperationDescriptor>().Count();

            //    return (matches: matches.Count() + expandedMatches.Count(),
            //            actions: inserts + deletes + updates + moves,
            //            inserts: inserts,
            //            deletes: deletes,
            //            updates: updates,
            //            moves: moves);
            //}

            private (Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified) _GetElementTrees(
                GitRepository dbRepository, Delta delta, FileFormatKind fileFormatKind, string direction,
                ref bool @continue, ref ElementTree originalTree, ref ElementTree modifiedTree)
            {
                var originalVersion = dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormatKind && ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);
                var modifiedVersion = dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormatKind && ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);

                if (originalVersion == null || modifiedVersion == null)
                {
                    @continue = true;
                    return (null, null);
                }

                //ElementTree originalTree, modifiedTree;
                if (fileFormatKind != FileFormatKind.Gumtreefied)
                {
                    var xOriginalTree = XElement.Load(new StringReader(originalVersion.XmlTree));
                    var xModifiedTree = XElement.Load(new StringReader(modifiedVersion.XmlTree));

                    var roslynMLServices = new RoslynML();
                    originalTree = roslynMLServices.AsGumtreefiedElementTree(xOriginalTree, true);
                    modifiedTree = roslynMLServices.AsGumtreefiedElementTree(xModifiedTree, true);
                }
                else
                {
                    originalTree = ElementTree.Read(originalVersion.XmlTree, Encoding.Unicode);
                    modifiedTree = ElementTree.Read(modifiedVersion.XmlTree, Encoding.Unicode);
                }

                var originalResult = originalTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
                var modifiedResult = modifiedTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);

                return (originalResult, modifiedResult);
            }
        }
    }

    public class RunCompareArgs : IArgumentModel
    {
        [Argument(Name = "refName")]
        public string RefName { get; set; }

        [Argument(Name = "refApproach")]
        public string RefApproach { get; set; }

        [Argument(Name = "refFileFormat")]
        public string RefFileFormat { get; set; }

        [Option(ShortName = "name")]
        public List<string> Names { get; set; }

        [Option(ShortName = "approach")]
        public List<string> Approaches { get; set; }

        [Option(ShortName = "fileFormat")]
        public List<string> FileFormats { get; set; }

        [Option(ShortName = "direction")]
        public List<string> Directions { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        [Option(LongName = "limited")]
        public bool Limited { get; set; }

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;

        [Option(ShortName = "onThese")]
        public string OnThese { get; set; }

        [Option(ShortName = "skipThese")]
        public string SkipThese { get; set; }        
    }

    public class RunCompareOnFlyArgs : IArgumentModel
    {
        [Argument(Name = "leftName")]
        public string LeftName { get; set; }

        [Argument(Name = "leftApproach")]
        public string LeftApproach { get; set; }

        [Argument(Name = "leftRuntime")]
        public string LeftRuntime { get; set; }

        [Argument(Name = "leftFileFormat")]
        public string LeftFileFormat { get; set; }

        [Argument(Name = "rightName")]
        public string RightName { get; set; }

        [Argument(Name = "rightApproach")]
        public string RightApproach { get; set; }

        [Argument(Name = "rightRuntime")]
        public string RightRuntime { get; set; }

        [Argument(Name = "rightFileFormat")]
        public string RightFileFormat { get; set; }

        [Argument(Name = "originalPath")]
        public string OriginalPath { get; set; }

        [Argument(Name = "modifiedPath")]
        public string ModifiedPath { get; set; }

        [Option(ShortName = "direction")]
        public string Direction { get; set; } = "Forward";

        [Option(LongName = "limited")]
        public bool Limited { get; set; }
    }
}
