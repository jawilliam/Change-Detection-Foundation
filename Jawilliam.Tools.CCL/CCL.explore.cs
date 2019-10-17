using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
            [ApplicationMetadata(Name = "download", Description = "Compares...")]
            public virtual void Download(DownloadArgs args)
            {
                var revisionPairId = Guid.Parse(args.RevisionPairId);
                //var configurations = args.OriginalPaths.Select((r, i) => new
                //{
                //    OriginalPath = i < args.OriginalPaths.Count ? args.OriginalPaths[i] : null,
                //    ModifiedPath = i < args.ModifiedPaths.Count ? args.ModifiedPaths[i] : null,
                //    Runtime = i < args.Runtimes.Count ? args.Runtimes[i] : null,
                //    //Approach = i < args.Approaches.Count 
                //    //    ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i]) 
                //    //    : default(ChangeDetectionApproaches),
                //    //FileFormat = i < args.FileFormats.Count
                //    //    ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                //    //    : default(FileFormatKind),
                //    Direction = i < args.Directions.Count ? args.Directions[i] : null
                //});

                var project = Projects.Single(p => p.Name == args.Project);
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                    var fileRevisionPair = dbRepository.FileRevisionPairs
                        .Include("Principal.FileVersion.Content")
                        .Include("Principal.FromFileVersion.Content")
                        .AsNoTracking().Single(frp => frp.Principal.Id == revisionPairId);

                    var originalRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);
                    var modifiedRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                    System.IO.File.WriteAllText(args.OriginalPath, originalContentNode.ToFullString());
                    System.IO.File.WriteAllText(args.ModifiedPath, modifiedContentNode.ToFullString());

                    //foreach (var configuration in configurations)
                    //{ 
                        

                    //    string result = null;
                    //    using (var _process = new Process())
                    //    {
                    //        var procStartInfo = new ProcessStartInfo($@"cmd.exe")
                    //        {
                    //            //RedirectStandardOutput = true,
                    //            RedirectStandardInput = true,
                    //            UseShellExecute = false,
                    //            //Arguments = $@"D:{Environment.NewLine}cd {configuration.Runtime}\bin{Environment.NewLine}set PATH=%PATH%;C:\Program Files (x86)\srcML 0.9.5\bin{Environment.NewLine}gumtree.bat swingdiff {configuration.OriginalPath} {configuration.ModifiedPath}"
                    //            //CreateNoWindow = false
                    //        };

                    //        var proc = new Process { StartInfo = procStartInfo };
                    //        proc.Start();

                    //        proc.StandardInput.WriteLine("D:");
                    //        proc.StandardInput.WriteLine($@"cd {configuration.Runtime}\bin");
                    //        proc.StandardInput.WriteLine(@"set PATH=%PATH%;C:\Program Files (x86)\srcML 0.9.5\bin");
                    //        proc.StandardInput.WriteLine($"gumtree.bat swingdiff {configuration.OriginalPath} {configuration.ModifiedPath}");
                    //        proc.StandardInput.Flush();
                    //        proc.StandardInput.Close();
                    //        //// Get the output into a string
                    //        proc.WaitForExit();
                    //        //result = proc.StandardOutput.ReadToEnd()/*.Replace(header, "")*/;
                    //        ////result = result.Replace($@"{sPrefix}{args.GumTreePath}\bin>", "")
                    //        ////               .Replace($@"{args.GumTreePath}\bin>", "");
                    //        _process.Close();
                    //    }
                    //}
                }
                Console.Out.WriteLine($"DONE!!!");
            }
        }
    }

    public class DownloadArgs : IArgumentModel
    {
        [Argument(Name = "project")]
        public string Project { get; set; }

        [Argument(Name = "revisionPairId")]
        public string RevisionPairId { get; set; }

        [Option(ShortName = "originalPath")]
        public string OriginalPath { get; set; }

        [Option(ShortName = "modifiedPath")]
        public string ModifiedPath { get; set; }
    }
}
