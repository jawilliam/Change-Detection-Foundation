﻿using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        [ApplicationMetadata(Name = "gumtree", Description = "GumTree")]
        [SubCommand]
        public partial class GumTree
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            /// <example>gumtree detect D:\ExperimentLogs\RunningOriginal38to49.cs D:\ExperimentLogs\RunningModified38to49.cs NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_generate_38to49.txt -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_TBL -name:NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_TBL -name:NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_TBL -name:NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_TBL -name:NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling -runtime=D:\GT_Runtimes\gumtree_RML_IT_TBL -name:NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_IT_TBL -name:NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_TBL_0mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_TBL_0mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_TBL_0mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_TBL_0mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_TBL -name:NativeGTtreefiedRoslynMLAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLAndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_TBL -name:NativeGTtreefiedRoslynMLAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLAndPermissiveLabeling -direction:Backward -to=25</example>
            [ApplicationMetadata(Name = "detect", Description = "Detects ...")]
            public virtual void Detect(DetectCommandArgs args)
            {
                var configurations = args.Runtimes.Select((r, i) => new
                {
                    Path = r,
                    Name = i < args.Names.Count ? args.Names[i] : null,
                    Approach = i < args.Approaches.Count 
                        ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i]) 
                        : default(ChangeDetectionApproaches),
                    Direction = i < args.Directions.Count ? args.Directions[i] : null
                });

                var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
                var gumTree = new GumTreeNativeApproach();
                var interopArgs = new InteropArgs()
                {
                    GumTreePath = null,
                    Original = args.OriginalPath,
                    Modified = args.ModifiedPath
                };

                (string project, Guid frpId)[] frpPerProjects = null;
                if (args.OnThese != null)
                {
                    frpPerProjects = System.IO.File.ReadAllLines(args.OnThese).Skip(1)
                        .Select<string, (string project, Guid frpId)>(delegate(string line, int i)
                        {
                            var values = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (values == null || values.Length != 2)
                                throw new ApplicationException($"Bad formed entry: line {i}.");

                            return (values[1], Guid.Parse(values[0]));
                        }).ToArray();
                }

                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        analyzer.Warnings = new StringBuilder();
                        analyzer.SqlRepository = dbRepository;
                        analyzer.Cancel = () => gumTree.Cancel();

                        Func<FileRevisionPair, bool> skipThese = null;
                        if (frpPerProjects != null)
                        {
                            skipThese = delegate (FileRevisionPair frp)
                            {
                                return !frpPerProjects.Any(fpp => fpp.project == project.Name && fpp.frpId == frp.Principal.Id);
                            };
                        }

                        interopArgs.GumTreePath = configuration.Path;
                        var rApproach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.RefApproach);
                        switch (configuration.Direction)
                        {
                            case "Forward":
                                if (args.Trace != null)
                                    System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"{configuration.Name} Forward (collection) started " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                                analyzer.NativeGumTreeDiff(gumTree, interopArgs, configuration.Approach, skipThese, null, rApproach);
                                if(args.Trace != null)
                                    System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"{configuration.Name} Forward (collection) completed " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                                break;
                            case "Backward":
                                if (args.Trace != null)
                                    System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"{configuration.Name} Backward (collection) starting " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                                analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, configuration.Approach, skipThese, null, rApproach);
                                if (args.Trace != null)
                                    System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"{configuration.Name} Backward (collection) completed " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                                break;
                            default: throw new ArgumentException($"Unknown direction value: {configuration.Direction}");
                        }
                    }
                }
                Console.Out.WriteLine($"DONE!!!");
            }
        }
    }

    public class DetectCommandArgs : IArgumentModel
    {
        [Argument(Name = "originalPath")]
        public string OriginalPath { get; set; }

        [Argument(Name = "modifiedPath")]
        public string ModifiedPath { get; set; }

        //[Argument(Name = "refName")]
        //public string RefName { get; set; }

        [Argument(Name = "refApproach")]
        public string RefApproach { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        [Option(ShortName = "runtime")]
        public List<string> Runtimes { get; set; }

        [Option(ShortName = "name")]
        public List<string> Names { get; set; }

        [Option(ShortName = "approach")]
        public List<string> Approaches { get; set; }

        [Option(ShortName = "direction")]
        public List<string> Directions { get; set; }

        [Option(ShortName = "onThese")]
        public string OnThese { get; set; }

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;
    }
}
