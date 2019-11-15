using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <example>savetrees E:\SourceCode\RBPNT_Original.cs E:\SourceCode\RBPNT_Modified.cs 28 -trace=D:\ExperimentLogs\savetrees_RoslynML_BasicPruning_NoTrivia.txt --pruning:Basic --includeTrivia</example>
        [ApplicationMetadata(Name = "savetrees", Description = "...")]
        public virtual void SaveTrees(SaveTreesCommandArgs args)
        {
            try
            {
                var analyzer = new NativeGumTreeCollector { MillisecondsTimeout = 300000 };
                var gumTree = new GumTreeNativeApproach();
                var interopArgs = new InteropArgs() { GumTreePath = null, Original = args.OriginalPath, Modified = args.ModifiedPath };
                //var approach = (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.RefApproach);
                var fileFormat = (FileFormatKind)long.Parse(args.FileFormatKind, CultureInfo.InvariantCulture);
                var pruneSelector = args.Pruning != null
                    ? GetPruneSelector(args.Pruning)
                    : null;
                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {   
                    analyzer.Warnings = new StringBuilder();
                    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                    {
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                        analyzer.SqlRepository = dbRepository;

                        if (args.Trace != null)
                            System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"savetrees (collection) started " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");

                        analyzer.SaveRoslynMLTrees(gumTree, interopArgs, /*gumTreeApproach:-1,*/
                                                   null, fileFormat, null, pruneSelector,
                                                   args.IncludeTrivia, args.Defoliate);

                        if (args.Trace != null)
                            System.IO.File.AppendAllText(args.Trace,
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          $"savetrees (collection) completed " +
                                          $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileFormats"></param>
        /// <param name="trace"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <example>.\Jawilliam.Tools.CCL.exe fileformat-stats -fileFormat=1 -fileFormat=5 -fileFormat=12 -fileFormat=44 -fileFormat=20 -fileFormat=28 -fileFormat=60 -trace=D:\ExperimentLogs\fileformat-stats_1_5_12_44_20_28_60.txt</example>
        [ApplicationMetadata(Name = "fileformat-stats", Description = "...")]
        public virtual void FileFormatStatistics([Option(ShortName = "fileFormat")] List<int> fileFormats, [Option(ShortName = "trace")] string trace = null, [Option(ShortName = "from")]int from = 1, [Option(ShortName = "to")]int to = 107)
        {
            if ((fileFormats?.Count ?? 0) <= 0)
                throw new ApplicationException("Specify at least one file format.");

            var filter = fileFormats.Skip(1).Aggregate(
                $"Kind = {fileFormats[0].ToString(CultureInfo.InvariantCulture)}",
                (acc, ff) => $"{acc} OR Kind = {ff.ToString(CultureInfo.InvariantCulture)}");

            System.IO.File.AppendAllText(trace, $"PROJECT;FILEVERSION;#NODES" +
                $"{fileFormats.Aggregate("", (acc, ff) => $"{acc};{ff.ToString(CultureInfo.InvariantCulture)}")}" +
                $"{Environment.NewLine}");

            foreach (var project in Projects.Skip(from - 1).Take(to - (from - 1)))
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    var ids = dbRepository.Database.SqlQuery<Guid>($"SELECT distinct [FileVersion_Id] FROM [dbo].[FileFormats] where {filter}").ToList();
                    for (int i = 0; i < ids.Count; i++)
                    {
                        var id = ids[i];
                        StringBuilder line = new StringBuilder();
                        line.Append($"{project.Name};{id}");
                        var fileFormatInfos = dbRepository.Database.SqlQuery<FileFormat>($"SELECT [Id],[Kind],[Error],[XmlTree],[XTextTree],[TextTree],[Annotations],[FileVersion_Id] " +
                                                                                         $"FROM [dbo].[FileFormats] " +
                                                                                         $"WHERE ({filter}) AND ([FileVersion_Id] = '{id}')").ToList();
                        foreach (var fileFormat in fileFormats)
                        {
                            var fileFormatInfo = fileFormatInfos.SingleOrDefault(ffi => ffi.Kind == (FileFormatKind)fileFormat); 
                            var xTree = fileFormatInfo != null ? XElement.Load(new System.IO.StringReader(fileFormatInfo.XmlTree)) : null;
                            var nodeCount = xTree?.PostOrder(n => n.Elements().Where(e => e is XNode)).Count() ?? -1;
                            line.Append($";{nodeCount}");
                        }
                        System.IO.File.AppendAllText(trace, $"{line.ToString()}{Environment.NewLine}");
                        System.Console.WriteLine($"fileformat-stats - {project.Name} - {i + 1} of {ids.Count}");
                    }
                }
            }
        }


        public virtual void A()
        {
            foreach (var project in Projects/*.Skip(args.From - 1).Take(args.To - (args.From - 1))*/)
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    //analyzer.SqlRepository = dbRepository;

                    var ids = dbRepository.Database.SqlQuery<Guid>("SELECT distinct [Id] FROM [dbo].[FileFormats] where Kind = 5 or Kind = 12 or Kind = 20 or Kind = 28").ToList();
                    foreach (var id in ids)
                    {
                        System.Console.WriteLine(
                                      $"{Environment.NewLine}{Environment.NewLine}" +
                                      $"repairing trees (collection) started " +
                                      $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");

                        var fileFormat = dbRepository.FileFormats.Single(c => c.Id == id);
                        var xTree = XElement.Load(new System.IO.StringReader(fileFormat.XmlTree));

                        var roslynMlServices = new RoslynML();
                        roslynMlServices.ReassignGtIds(xTree);
                        fileFormat.XmlTree = xTree.ToString(SaveOptions.DisableFormatting);

                        dbRepository.Flush();

                        System.Console.WriteLine(
                                      $"{Environment.NewLine}{Environment.NewLine}" +
                                      $"repairing trees (collection) saved " +
                                      $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    }
                }
            }
        }
    }

    public class SaveTreesCommandArgs : IArgumentModel
    {
        [Argument(Name = "originalPath")]
        public string OriginalPath { get; set; }

        [Argument(Name = "modifiedPath")]
        public string ModifiedPath { get; set; }

        //[Argument(Name = "refApproach")]
        //public string RefApproach { get; set; }

        [Argument(Name = "format")]
        public string FileFormatKind { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;

        [Option(LongName = "pruning")]
        public string Pruning { get; set; }

        //[Option(LongName = "gumtreefy")]
        //public bool Gumtreefy { get; set; }

        [Option(LongName = "includeTrivia")]
        public bool IncludeTrivia { get; set; }

        [Option(LongName = "defoliate")]
        public bool Defoliate { get; set; }
    }
}
