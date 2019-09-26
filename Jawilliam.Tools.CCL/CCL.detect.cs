using CommandDotNet;
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

                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        analyzer.Warnings = new StringBuilder();
                        analyzer.SqlRepository = dbRepository;
                        analyzer.Cancel = () => gumTree.Cancel();

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
                                analyzer.NativeGumTreeDiff(gumTree, interopArgs, configuration.Approach, null, null, rApproach);
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
                                analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, configuration.Approach, null, null, rApproach);
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

        [Argument(Name = "refName")]
        public string RefName { get; set; }

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

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;
    }
}
