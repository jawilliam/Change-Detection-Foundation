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
using System.Data.Entity;
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
            [ApplicationMetadata(Name = "rate", Description = "Rate...")]
            public virtual void RateMismatches(RateArgs args)
            {
                //this.Download(args);
                var revisionPairId = Guid.Parse(args.RevisionPairId);

                var project = Projects.Single(p => p.Name == args.Project);
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                    dbRepository.Deltas.Where(d => d.RevisionPair.Id == revisionPairId && d.Approach == ChangeDetectionApproaches.Manually).Load();
                    var delta = dbRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == revisionPairId && d.Approach == ChangeDetectionApproaches.Manually);
                    if (delta == null)
                    {
                        delta = new Delta { Id = Guid.NewGuid(), Approach = ChangeDetectionApproaches.Manually };
                        dbRepository.Deltas.Add(delta);
                    }

                    var dr = (DetectionResult)delta.DetectionResult;
                    var relatedMatches = dr.Matches.Where(m => m.Original.Id == args.OriginalId || m.Modified.Id == args.ModifiedId);
                    if (relatedMatches.Any())
                    {
                        Console.WriteLine($"There are related matches...");
                        foreach (var relatedMatch in relatedMatches)
                        {
                            Console.WriteLine($"({args.OriginalId},{args.ModifiedId})");
                        }

                        string answer = null;
                        do
                        {
                            Console.WriteLine("Want you overrite them?");
                            answer = Console.ReadLine();
                            if (answer == "YES")
                            {
                                dr.Matches.Add(new MatchDescriptor
                                {
                                    Original = new ElementVersion
                                    {
                                        
                                    },
                                    });
                            }
                        }
                        while (answer == "YES" || answer == "NO");
                    }

                    //System.IO.File.WriteAllText(args.OriginalPath, originalContentNode.ToFullString());
                    //System.IO.File.WriteAllText(args.ModifiedPath, modifiedContentNode.ToFullString());
                }
                Console.Out.WriteLine($"DONE!!!");
            }

            ///// <summary>
            ///// 
            ///// </summary>
            ///// <param name="args"></param>
            ///// <example></example>
            //[ApplicationMetadata(Name = "review", Description = "Rate...")]
            //public virtual void ReviewMismatches(ReviewArgs args)
            //{
            //    this.Download(args);
            //    var revisionPairId = Guid.Parse(args.RevisionPairId);

            //    var project = Projects.Single(p => p.Name == args.Project);
            //    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
            //    {
            //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

            //        var fileRevisionPair = dbRepository.FileRevisionPairs
            //            .Include("Principal.FileVersion.Content")
            //            .Include("Principal.FromFileVersion.Content")
            //            .AsNoTracking().Single(frp => frp.Principal.Id == revisionPairId);

            //        var originalRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            //        var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);
            //        var modifiedRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            //        var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

            //        System.IO.File.WriteAllText(args.OriginalPath, originalContentNode.ToFullString());
            //        System.IO.File.WriteAllText(args.ModifiedPath, modifiedContentNode.ToFullString());
            //    }
            //    Console.Out.WriteLine($"DONE!!!");
            //}
        }
    }

    public class ReviewArgs : DownloadArgs
    {
        [Argument(Name = "leftApproach")]
        public string LeftApproach { get; set; }

        [Argument(Name = "rightFileFormat")]
        public string RightFileFormat { get; set; }

        [Option(ShortName = "direction")]
        public string Direction { get; set; }
    }

    public class RateArgs : DownloadArgs
    {
        [Argument(Name = "originalId")]
        public string OriginalId { get; set; }

        [Argument(Name = "modifiedId")]
        public string ModifiedId { get; set; }

        [Argument(Name = "fileFormat")]
        public string FileFormat { get; set; }
    }
}
