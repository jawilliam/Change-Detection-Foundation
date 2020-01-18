using CommandDotNet;
using CommandDotNet.Attributes;
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
            /// <example>gumtree expand Forward 20 -trace=D:\ExperimentLogs\gumtree_expansion_FW38to57.txt -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia -fileFormat=28 -direction=Forward -name:NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling_Forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling -fileFormat=12 -direction=Forward -name:NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling_Forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling -fileFormat=28 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1_Forward  -approach=NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 -fileFormat=44 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia_Forward  -approach=NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia -fileFormat=60 -direction=Forward -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling_Forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling -fileFormat=44 -direction:Forward -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling_Forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling -fileFormat=60 -direction:Forward -from=1 -to=23</example>
            [ApplicationMetadata(Name = "expand", Description = "Expands ...")]
            public virtual void Expand(ExpandCommandArgs args)
            {
                var configurations = args.Names.Select((n, i) => new
                {
                    Name = n,
                    Approach = i < args.Approaches.Count 
                        ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i]) 
                        : default(ChangeDetectionApproaches),
                    Direction = i < args.Directions.Count ? args.Directions[i] : null,
                    FileFormat = i < args.FileFormats.Count
                        ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                        : default(FileFormatKind),
                });

                var fullConfiguration = new 
                {
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FullFileFormat),
                    Direction = args.FullDirection
                };

                var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };

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

                var expander = new DeltaExpander();
                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        var deltaIds = (from d in dbRepository.Deltas
                                        where d.Report == null && d.Approach == configuration.Approach
                                        select d.Id).ToList();

                        if (args.Trace != null)
                        {
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{configuration.Name} expanding " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                        }
                        int counter = 0;
                        foreach (var deltaId in deltaIds)
                        {
                            counter++;
                            var delta = dbRepository.Deltas
                                .Include("RevisionPair.FromFileVersion.Content")
                                .Include("RevisionPair.FileVersion.Content")
                                .AsNoTracking()
                                .Single(d => d.Id == deltaId);

                            var detectionResult = (DetectionResult)delta.DetectionResult;
                            if (!detectionResult.Matches.Any() && !detectionResult.Actions.Any())
                                continue;

                            var fullOriginal = fullConfiguration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullConfiguration.FileFormat && 
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullConfiguration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                            var fullModified = fullConfiguration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullConfiguration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullConfiguration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);

                            var seedOriginal = configuration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                            var seedModified = configuration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);

                            if (fullOriginal == null || fullModified == null || seedOriginal == null || seedModified == null)
                                continue;

                            var xFullOriginal = XElement.Load(new StringReader(fullOriginal.XmlTree));
                            var xFullModified = XElement.Load(new StringReader(fullModified.XmlTree));
                            var xSeedOriginal = XElement.Load(new StringReader(seedOriginal.XmlTree));
                            var xSeedModified = XElement.Load(new StringReader(seedModified.XmlTree));

                            var expandedApproach = configuration.Approach + 1000;
                            var expandedDelta = dbRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == delta.RevisionPair.Id && d.Approach == expandedApproach);
                            if (expandedDelta == null)
                            {
                                var rp = dbRepository.RepositoryObjects.OfType<FileModifiedChange>().Single(frp => frp.Id == delta.RevisionPair.Id);
                                expandedDelta = new Delta { Id = Guid.NewGuid(), Approach = expandedApproach, RevisionPair = rp  };
                                dbRepository.Deltas.Add(expandedDelta);
                            }

                            if (args.Trace != null)
                            {
                                Console.WriteLine(
                                      $"{configuration.Name} expanding " +
                                      $"{project.Name} - ({counter} of {deltaIds.Count}) {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)}");
                            }
                            try
                            {
                                var annotations = expandedDelta.XAnnotations;
                                var start = Environment.TickCount;
                                expander.Expand(
                                    new RevisionPair<XElement> { Original = xSeedOriginal, Modified = xSeedModified },
                                    new RevisionPair<XElement> { Original = xFullOriginal, Modified = xFullModified },
                                    (Matches: XElement.Parse(delta.Matching ?? "<Matches/>").Elements().Where(d => d is XNode),
                                     Actions: XElement.Parse(delta.Differencing ?? "<Actions/>").Elements().Where(d => d is XNode)));
                                annotations.RunTime = (Environment.TickCount - start).ToString(CultureInfo.InvariantCulture);
                                expandedDelta.XAnnotations = annotations;
                                

                                if (args.Trace != null)
                                {
                                    Console.WriteLine(
                                          $"{configuration.Name} expanded " +
                                          $"{project.Name} - ({counter} of {deltaIds.Count}) {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)}");
                                }

                                var xMatches = new XElement("Matches", expander.FullDelta.Matches);
                                var xActions = new XElement("Actions", expander.FullDelta.Actions);

                                expandedDelta.Matching = Delta.AsSqlXColumn(xMatches);
                                expandedDelta.Differencing = Delta.AsSqlXColumn(xActions);
                            }
                            catch (Exception ex)
                            {
                                expandedDelta.Report = ex.ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><");
                            }
                            finally
                            {
                                dbRepository.Flush(true); ///TODO: run it first, save it later.
                            }
                        }
                        if (args.Trace != null)
                        {
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{configuration.Name} expanded " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                        }
                    }
                }
                Console.Out.WriteLine($"DONE!!!");
            }
        }
    }

    public class ExpandCommandArgs : IArgumentModel
    {
        //[Argument(Name = "originalPath")]
        //public string OriginalPath { get; set; }

        //[Argument(Name = "modifiedPath")]
        //public string ModifiedPath { get; set; }

        [Argument(Name = "fullDirection")]
        public string FullDirection { get; set; } = "Forward";

        [Argument(Name = "fullFileFormat")]
        public string FullFileFormat { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        [Option(ShortName = "name")]
        public List<string> Names { get; set; }

        [Option(ShortName = "approach")]
        public List<string> Approaches { get; set; }

        [Option(ShortName = "direction")]
        public List<string> Directions { get; set; }

        [Option(ShortName = "fileFormat")]
        public List<string> FileFormats { get; set; }

        [Option(ShortName = "onThese")]
        public string OnThese { get; set; }

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;
    }
}
