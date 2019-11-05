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
                        : default(ChangeDetectionApproaches),
                    FileFormat = i < args.FileFormats.Count
                        ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                        : default(FileFormatKind),
                    Direction = i < args.Directions.Count ? args.Directions[i] : null
                });

                var recognizer = new BetweenComparison { MillisecondsTimeout = 600000 };
                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

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

                        Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair pair)
                        {
                            var anyOriginal = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FromFileVersion.Id && ff.Kind == refApproach.FileFormat);
                            var anyModified = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FileVersion.Id && ff.Kind == configuration.FileFormat);

                            return !anyOriginal || !anyModified;
                        };

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
                                var o1 = oDict[match.Original.Id];
                                match.Original.Id = o1.Root.Id;
                                var m1 = mDict[match.Modified.Id];
                                match.Modified.Id = m1.Root.Id;
                            }
                        };

                        if (configuration.Direction == "Forward")
                        {
                            var innerMatchCompare = recognizer.Config.MatchCompare;
                            recognizer.Config.MatchCompare = delegate (string direction, MatchDescriptor leftMatch, DetectionResult leftDelta,
                                                                                         MatchDescriptor rightMatch, DetectionResult rightDelta)
                            {
                                if (!args.Limited && direction == "LR" && (!rOriginalTree.ContainsKey(leftMatch.Original.Id) || !rModifiedTree.ContainsKey(leftMatch.Modified.Id)))
                                    return true;

                                if (!args.Limited && direction == "RL" && (!lOriginalTree.ContainsKey(leftMatch.Original.Id) || !lModifiedTree.ContainsKey(leftMatch.Modified.Id)))
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
                recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) a)
                {
                    string filePath = null;
                    if (a.Delta.Approach == leftApproach.Approach)
                        filePath = a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;
                    else if (args.Direction == "Forward")
                        filePath = a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;
                    else // "Backward"
                                filePath = !a.TrueForOriginalOtherwiseModified ? args.OriginalPath : args.ModifiedPath;

                    var saveTreesArgs = new RoslynMLSaveTreesCommandArgs
                    {
                        FullPath = filePath.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0] + ".xml",
                        Defoliate = (leftApproach.FileFormat & FileFormatKind.Defoliation) != 0,
                        IncludeTrivia = (leftApproach.FileFormat & FileFormatKind.IncludeTrivia) != 0,
                        Pruning = (leftApproach.FileFormat & FileFormatKind.BasicPruning) != 0 ? "Basic" : null
                    };
                    CCL.SharedRoslynML(saveTreesArgs);

                    if (!args.Limited)
                    {
                        var xTree = XElement.Load(new StringReader(filePath));
                        var roslynMlServices = new RoslynML();

                        result = roslynMlServices.AsGumtreefiedElementTree(xTree, true);
                        if (a.Delta.Approach == leftApproach.Approach)
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
                        result = ElementTree.Read(filePath, Encoding.Unicode);
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
                    Original = args.OriginalPath,
                    Modified = args.ModifiedPath
                });
                var rDelta = new Delta { Approach = rightApproach.Approach, DetectionResult = gumTree.Result };

                recognizer.Warnings = new StringBuilder();
                recognizer.Compare(lDelta, rDelta, new FileRevisionPair { Id = Guid.Empty }, CancellationToken.None);

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
                        : default(ChangeDetectionApproaches),
                    FileFormat = i < args.FileFormats.Count
                        ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                        : default(FileFormatKind),
                    Direction = i < args.Directions.Count ? args.Directions[i] : null
                });

                this.WriteHeadLine(refApproach.Approach, configurations.Select(c => c.Approach), args.Trace);

                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                    {
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                        var revisionPairIds = (from d in dbRepository.Deltas.AsNoTracking()
                                               orderby d.RevisionPair.Id
                                               select d.RevisionPair.Id).Distinct().ToArray();
                        int counter = 0;
                        foreach (var revisionPairId in revisionPairIds)
                        {
                            Console.Out.WriteLine($"Starting {++counter}-{dbRepository.Name} ({revisionPairIds.Count()}) Guid-{revisionPairId}");

                            bool @continue = false;
                            var refDelta = dbRepository.Deltas.AsNoTracking()
                                .Include("RevisionPair.FromFileVersion").Include("RevisionPair.FileVersion")
                                .SingleOrDefault(d => d.Approach == refApproach.Approach &&
                                                      d.RevisionPair.Id == revisionPairId);
                            if (refDelta == null)
                                continue;
                            var refStats = this._AbsoluteStatsFor(dbRepository, refDelta, ref @continue);
                            if (@continue)
                                continue;
                            var refTreeRevisionPair = this._GetElementTrees(dbRepository, refDelta, refApproach.FileFormat, "Forward", ref @continue);
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
                                if (rightDelta == null)
                                    break;

                                treeRevisionPairList.Add(this._GetElementTrees(dbRepository, rightDelta, configuration.FileFormat, configuration.Direction, ref @continue));
                                if (@continue)
                                    continue;

                                var last = treeRevisionPairList.Last();
                                rightStatsList.Add(this._AbsoluteStatsFor(dbRepository, rightDelta, ref @continue));
                                lrStatsList.Add(this._RelativeStatsFor(dbRepository, refDelta, refTreeRevisionPair, last, args.Limited, ref @continue));
                                rlStatsList.Add(this._RelativeStatsFor(dbRepository, rightDelta,
                                    configuration.Direction == "Forward" ? last : (last.modified, last.original),
                                    configuration.Direction == "Forward" ? refTreeRevisionPair : (refTreeRevisionPair.modified, refTreeRevisionPair.original),
                                    args.Limited, ref @continue));
                                if (@continue)
                                    break;
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
                                line.Append($"{lrStatsList[i].matches};{lrStatsList[i].actions};" +
                                        $"{lrStatsList[i].inserts};{lrStatsList[i].deletes};" +
                                        $"{lrStatsList[i].updates};{lrStatsList[i].moves};");
                                line.Append($"{rlStatsList[i].matches};{rlStatsList[i].actions};" +
                                        $"{rlStatsList[i].inserts};{rlStatsList[i].deletes};" +
                                        $"{rlStatsList[i].updates};{rlStatsList[i].moves};");
                                line.Append($"{comparisonStatsList[i].total};{comparisonStatsList[i].lr};{comparisonStatsList[i].rl}");
                            }
                            line.Append($"{Environment.NewLine}");
                            System.IO.File.AppendAllText(args.Trace, line.ToString());

                            Console.Out.WriteLine($"Ending the {counter}-{dbRepository.Name} ({revisionPairIds.Count()}) Guid-{revisionPairId}");
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
                    @continue = true;
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

            private (int matches, int actions, int inserts, int deletes, int updates, int moves) _AbsoluteStatsFor(GitRepository dbRepository, Delta delta, ref bool @continue)
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

            private (int matches, int actions, int inserts, int deletes, int updates, int moves) _RelativeStatsFor(GitRepository dbRepository, Delta delta,
                (Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified) leftRevisionPair,
                (Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified) rightRevisionPair, bool limited, ref bool @continue)
            {
                var detectionResult = (DetectionResult)delta.DetectionResult;
                if (detectionResult.Actions.Count == 0)
                {
                    @continue = true;
                    return (matches: 0, actions: 0, inserts: 0, deletes: 0, updates: 0, moves: 0);
                }

                if (limited)
                {
                    return (matches: -1, actions: -1, inserts: -1, deletes: -1, updates: -1, moves: -1);
                }

                detectionResult.FromGlobalToIdDefinitions(leftRevisionPair.original.Values.Single(o => o.Parent == null), 
                                                          leftRevisionPair.modified.Values.Single(o => o.Parent == null));
                
                var matches = detectionResult.Matches.Where(m => 
                    rightRevisionPair.original.ContainsKey(m.Original.Id) &&
                    rightRevisionPair.modified.ContainsKey(m.Modified.Id)).ToArray();
                var matchOriginals = matches.ToDictionary(m => m.Original.Id);

                var inserts = detectionResult.Actions.OfType<InsertOperationDescriptor>().Count(a =>
                    rightRevisionPair.modified.ContainsKey(a.Element.Id));

                var deletes = detectionResult.Actions.OfType<DeleteOperationDescriptor>().Count(a =>
                    rightRevisionPair.original.ContainsKey(a.Element.Id));

                var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>().Count(m =>
                    matchOriginals.ContainsKey(m.Element.Id));

                var moves = detectionResult.Actions.OfType<MoveOperationDescriptor>().Count(m =>
                    matchOriginals.ContainsKey(m.Element.Id)) +
                            detectionResult.Actions.OfType<AlignOperationDescriptor>().Count(m =>
                    matchOriginals.ContainsKey(m.Element.Id));

                return (matches: matches.Count(), actions: inserts + deletes + updates + moves,
                        inserts: inserts,
                        deletes: deletes,
                        updates: updates,
                        moves: moves);
            }

            private (Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified) _GetElementTrees(GitRepository dbRepository, Delta delta, FileFormatKind fileFormatKind, string direction, ref bool @continue)
            {
                var originalVersion = dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormatKind && ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);
                var modifiedVersion = dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormatKind && ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);

                if (originalVersion == null || modifiedVersion == null)
                {
                    @continue = true;
                    return (null, null);
                }

                var xOriginalTree = XElement.Load(new StringReader(originalVersion.XmlTree));
                var xModifiedTree = XElement.Load(new StringReader(modifiedVersion.XmlTree));

                var roslynMLServices = new RoslynML();
                var originalTree = roslynMLServices.AsGumtreefiedElementTree(xOriginalTree, true);
                var modifiedTree = roslynMLServices.AsGumtreefiedElementTree(xModifiedTree, true);

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
        public string Direction { get; set; }

        [Option(LongName = "limited")]
        public bool Limited { get; set; }
    }
}
