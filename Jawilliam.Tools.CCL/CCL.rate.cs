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

                        string answer;
                        do
                        {
                            answer = null;
                            var confirmed = false;

                            Console.WriteLine("Want you overrite them (y|n)?");
                            answer = Console.ReadLine();

                            if (answer?.ToLowerInvariant() != "y" && answer?.ToLowerInvariant() != "n")
                                continue;

                            Console.WriteLine(answer.ToLowerInvariant() == "y" 
                                ? "Confirm that you want to override them (ok||any else)"
                                : "Confirm that you do not want to override them (ok|any else)");

                            confirmed = Console.ReadLine()?.ToLowerInvariant() == "ok";

                            if (!confirmed)
                                continue;

                            if (answer?.ToLowerInvariant() == "y")
                            {
                                relatedMatches.ForEach(rm => dr.Matches.Remove(rm));
                            }
                        }
                        while (answer?.ToLowerInvariant() == "y" || answer?.ToLowerInvariant() == "n");
                    }

                    relatedMatches = 

                    //System.IO.File.WriteAllText(args.OriginalPath, originalContentNode.ToFullString());
                    //System.IO.File.WriteAllText(args.ModifiedPath, modifiedContentNode.ToFullString());
                }
                Console.Out.WriteLine($"DONE!!!");
            }

            protected virtual void RateMismatches(RateArgs args, DetectionResult detectionResult, BetweenSymptom mismatch, Dictionary<string, ElementTree> original, Dictionary<string, ElementTree> modified)
            {
                List<BetweenMatchInfo> candidateMatches = new List<BetweenMatchInfo>(3);
                if (mismatch is LRMatchSymptom lrMismatch)
                {
                    candidateMatches.Add(lrMismatch.Left);

                    if (lrMismatch.OriginalAtRight?.Original?.Element?.Id != "-1" || lrMismatch.OriginalAtRight?.Modified?.Element?.Id != "-1")
                        candidateMatches.Add(lrMismatch.OriginalAtRight);

                    if (lrMismatch.ModifiedAtRight?.Original?.Element?.Id != "-1" || lrMismatch.ModifiedAtRight?.Modified?.Element?.Id != "-1")
                        candidateMatches.Add(lrMismatch.ModifiedAtRight);
                }
                else
                {
                    var rlMismatch = (RLMatchSymptom)mismatch;
                    candidateMatches.Add(rlMismatch.Right);

                    if (rlMismatch.OriginalAtLeft?.Original?.Element?.Id != "-1" || rlMismatch.OriginalAtLeft?.Modified?.Element?.Id != "-1")
                        candidateMatches.Add(rlMismatch.OriginalAtLeft);

                    if (rlMismatch.ModifiedAtLeft?.Original?.Element?.Id != "-1" || rlMismatch.ModifiedAtLeft?.Modified?.Element?.Id != "-1")
                        candidateMatches.Add(rlMismatch.ModifiedAtLeft);
                }
                Console.WriteLine($"Are any of these matches correct?");
                for (int i = 0; i < candidateMatches.Count; i++)
                {
                    var o = candidateMatches[i].Original?.Element?.Id != null 
                        ? original[candidateMatches[i].Original.Element.Id.ToString(CultureInfo.InvariantCulture)]
                        : null;
                    var m = candidateMatches[i].Modified?.Element?.Id != null
                        ? modified[candidateMatches[i].Modified.Element.Id.ToString(CultureInfo.InvariantCulture)]
                        : null;

                    Console.WriteLine($"{i}) - ({o?.Root?.GlobalId ?? "NULL"},{m?.Root?.GlobalId ?? "NULL"})");
                }
                Console.WriteLine($"{candidateMatches.Count}) - NONE");
                var expectedMatchIndex = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null input"));
                if (expectedMatchIndex < 0 || expectedMatchIndex > candidateMatches.Count)
                    throw new ApplicationException("Unexpected answer");

                (string RoslynId, string SrcmlId) originalVersion, modifiedVersion;
                if (expectedMatchIndex < candidateMatches.Count)
                {
                    var cMatch = candidateMatches[expectedMatchIndex];
                    originalVersion = (cMatch.Original.Element.Id, this.ReadElementVersion(true, false).SrcmlId);
                    modifiedVersion = (cMatch.Modified.Element.Id, this.ReadElementVersion(false, false).SrcmlId);
                }
                else
                {
                    originalVersion = this.ReadElementVersion(true);
                    modifiedVersion = this.ReadElementVersion(false);
                }

                var expectedMatch = new MatchDescriptor
                {
                    Original = new ElementVersion { Id = originalVersion.RoslynId, GlobalId = originalVersion.SrcmlId },
                    Modified = new ElementVersion { Id = modifiedVersion.RoslynId, GlobalId = modifiedVersion.SrcmlId },
                };

                var relatedMatches = detectionResult.Matches.Where(m => m.Original.Id == args.OriginalId || m.Modified.Id == args.ModifiedId);
                if (relatedMatches.Any())
                {
                    Console.WriteLine($"There are related matches...");
                    foreach (var relatedMatch in relatedMatches)
                    {
                        Console.WriteLine($"({args.OriginalId},{args.ModifiedId})");
                    }

                    string answer;
                    do
                    {
                        answer = null;
                        var confirmed = false;

                        Console.WriteLine("Want you overrite them (y|n)?");
                        answer = Console.ReadLine();

                        if (answer?.ToLowerInvariant() != "y" && answer?.ToLowerInvariant() != "n")
                            continue;

                        Console.WriteLine(answer.ToLowerInvariant() == "y"
                            ? "Confirm that you want to override them (ok||any else)"
                            : "Confirm that you do not want to override them (ok|any else)");

                        confirmed = Console.ReadLine()?.ToLowerInvariant() == "ok";

                        if (!confirmed)
                            continue;

                        if (answer?.ToLowerInvariant() == "y")
                        {
                            relatedMatches.ForEach(rm => detectionResult.Matches.Remove(rm));
                        }
                    }
                    while (answer?.ToLowerInvariant() == "y" || answer?.ToLowerInvariant() == "n");
                }
            }

            private string ReadString(string message, string[] expectedValues = null)
            {
                string input = null;
                do
                {
                    Console.WriteLine(message);
                    input = Console.ReadLine();
                } while (input == null || (!expectedValues?.Contains(input) ?? true));

                return input;
            }

            private (string RoslynId, string SrcmlId)  ReadElementVersion(bool originalIfTrueOtherwiseModified, bool fullyIfTrueOtherwisePartially = true)
            {
                string input = null, roslynId = null, srcmlId = null;
                do
                {
                    var version = originalIfTrueOtherwiseModified ? "Original" : "Modified";
                    if (fullyIfTrueOtherwisePartially)
                        roslynId = ReadString($"Characterize the correct match: {version} Roslyn ID");

                    input = this.ReadString("Do you know its srcML ID (y/n)?", new []{"y", "n"});
                    if (input == "y")
                        srcmlId = ReadString($"Characterize the correct match: {version} srcML ID");
                }
                while (input == null);

                return (roslynId, srcmlId);
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
