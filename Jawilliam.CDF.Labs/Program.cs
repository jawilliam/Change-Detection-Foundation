using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Metrics.Quality;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Jawilliam.CDF.Labs.DBModel;
using System.IO;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Approach.Criterions.Simetric;

namespace Jawilliam.CDF.Labs
{
    class Program
    {
        /// <summary>
        /// Returns the project information.
        /// </summary>
        public static IEnumerable<Project> Projects => new[]
        {
            //new Project(),
            new Project{ Path = @"E:\Repositories\AjaxControlToolkit", Name = "AjaxControlToolkit" },
            new Project{ Path = @"E:\Repositories\akka.net", Name = "AkkaNET" },
            //new Project{ Path = @"E:\Repositories\albacore", Name = "Albacore" }, -- it does not have enought data
            new Project{ Path = @"E:\Repositories\allReady", Name = "AllReady" },
            new Project{ Path = @"E:\Repositories\ApplicationInsights-dotnet-server", Name = "ApplicationInsightsDotnetServer" },
            new Project{ Path = @"E:\Repositories\aspnetwebstack", Name = "AspnetWebStack" },
            new Project{ Path = @"E:\Repositories\AutoFixture", Name = "AutoFixture" },
            new Project{ Path = @"E:\Repositories\AutoMapper", Name = "AutoMapper" },
            new Project{ Path = @"E:\Repositories\Avalonia", Name = "Avalonia" },
            new Project{ Path = @"E:\Repositories\azure-powershell", Name = "AzurePowershell" },
            new Project{ Path = @"E:\Repositories\azure-sdk-for-net", Name = "AzureSdkForNet" },
            new Project{ Path = @"E:\Repositories\azure-webjobs-sdk", Name = "AzureWebJobsSdk" },
            new Project{ Path = @"E:\Repositories\BenchmarkDotNet", Name = "BenchmarkDotNet" },
            new Project{ Path = @"E:\Repositories\BotBuilder", Name = "BotBuilder" },
            new Project{ Path = @"E:\Repositories\Bridge", Name = "BridgeNET" },
            new Project{ Path = @"E:\Repositories\buildtools", Name = "Buildtools" },
            new Project{ Path = @"E:\Repositories\BusinessPlatformApps", Name = "BusinessPlatformApps" },
            new Project{ Path = @"E:\Repositories\cake", Name = "Cake" },
            new Project{ Path = @"E:\Repositories\cecil", Name = "Cecil" },
            new Project{ Path = @"E:\Repositories\CefSharp", Name = "CefSharp" },
            new Project{ Path = @"E:\Repositories\choco", Name = "Choco" },
            new Project{ Path = @"E:\Repositories\cli", Name = "Cli" },
            new Project{ Path = @"E:\Repositories\code-cracker", Name = "CodeCracker" },
            new Project{ Path = @"E:\Repositories\coreclr", Name = "CoreClr" },
            new Project{ Path = @"E:\Repositories\corefx", Name = "CoreFx" },
            new Project{ Path = @"E:\Repositories\corert", Name = "Corert" },
            new Project{ Path = @"E:\Repositories\couchbase-lite-net", Name = "CouchbaseLiteNet" },
            new Project{ Path = @"E:\Repositories\dafny", Name = "Dafny" },
            new Project{ Path = @"E:\Repositories\Dapper", Name = "Dapper" },
            new Project{ Path = @"E:\Repositories\Dnn.Platform", Name = "Dnn" },
            new Project{ Path = @"E:\Repositories\docfx", Name = "Docfx" },
            new Project{ Path = @"E:\Repositories\DotNetOpenAuth", Name = "DotNetOpenAuth" },
            new Project{ Path = @"E:\Repositories\duality", Name = "Duality" },
            new Project{ Path = @"E:\Repositories\elasticsearch-net", Name = "ElasticsearchNet" },
            new Project{ Path = @"E:\Repositories\Emby", Name = "Emby" },
            new Project{ Path = @"E:\Repositories\EntityFramework", Name = "Ef7" },
            new Project{ Path = @"E:\Repositories\FakeItEasy", Name = "FakeItEasy" },
            new Project{ Path = @"E:\Repositories\FileHelpers", Name = "FileHelpers" },
            new Project{ Path = @"E:\Repositories\Force.com-Toolkit-for-NET", Name = "ForcecomToolkitForNET" },
            //new Project{ Path = @"E:\Repositories\hadoopsdk", Name = "HadoopSdk" },
            new Project{ Path = @"E:\Repositories\Hangfire", Name = "Hangfire" },
            new Project{ Path = @"E:\Repositories\Hearthstone-Deck-Tracker", Name = "HDT" },
            new Project{ Path = @"E:\Repositories\Humanizer", Name = "Humanizer" },
            new Project{ Path = @"E:\Repositories\IdentityManager", Name = "IdentityManager" },
            new Project{ Path = @"E:\Repositories\IdentityServer3", Name = "IdentityServer3" },
            new Project{ Path = @"E:\Repositories\ILSpy", Name = "ILSpy" },
            new Project{ Path = @"E:\Repositories\ImageProcessor", Name = "ImageProcessor" },
            new Project{ Path = @"E:\Repositories\katanaproject", Name = "Katana" },
            new Project{ Path = @"E:\Repositories\KestrelHttpServer", Name = "KestrelHttpServer" },
            new Project{ Path = @"E:\Repositories\kudu", Name = "Kudu" },
            new Project{ Path = @"E:\Repositories\libgit2sharp", Name = "Libgit2sharp" },
            new Project{ Path = @"E:\Repositories\MahApps.Metro", Name = "MahAppsMetro" },
            new Project{ Path = @"E:\Repositories\MailKit", Name = "MailKit" },
            new Project{ Path = @"E:\Repositories\Marten", Name = "Marten" },
            new Project{ Path = @"E:\Repositories\MimeKit", Name = "MimeKit" },
            new Project{ Path = @"E:\Repositories\mobile-center-sdk-dotnet", Name = "MobileCenterSdkDotnet" },
            new Project{ Path = @"E:\Repositories\MoneyFox", Name = "MoneyFox" },
            new Project{ Path = @"E:\Repositories\mono", Name = "mono" },
            new Project{ Path = @"E:\Repositories\MonoGame", Name = "MonoGame" },
            new Project{ Path = @"E:\Repositories\msbuild", Name = "Msbuild" },
            new Project{ Path = @"E:\Repositories\MvvmCross", Name = "MvvmCross" },
            new Project{ Path = @"E:\Repositories\Nancy", Name = "Nancy" },
            new Project{ Path = @"E:\Repositories\netmf-interpreter", Name = "NetmfInterpreter" },
            new Project{ Path = @"E:\Repositories\Newtonsoft.Json", Name = "NewtonsoftJson" },
            new Project{ Path = @"E:\Repositories\nhibernate-core", Name = "NhibernateCore" },
            new Project{ Path = @"E:\Repositories\NLog", Name = "NLog" },
            new Project{ Path = @"E:\Repositories\nodejstools", Name = "Nodejstools" },
            new Project{ Path = @"E:\Repositories\npgsql", Name = "Npgsql" },
            new Project{ Path = @"E:\Repositories\NuGet.Client", Name = "NuGetClient" },
            new Project{ Path = @"E:\Repositories\NuGetGallery", Name = "NuGetGallery" },
            new Project{ Path = @"E:\Repositories\OpenRA", Name = "OpenRA" },
            new Project{ Path = @"E:\Repositories\Open-XML-SDK", Name = "OpenXmlSdk" },
            new Project{ Path = @"E:\Repositories\OptiKey", Name = "OptiKey" },
            new Project{ Path = @"E:\Repositories\Orchard", Name = "Orchard" },
            new Project{ Path = @"E:\Repositories\orleans", Name = "Orleans" },
            new Project{ Path = @"E:\Repositories\pickles", Name = "Pickles" },
            new Project{ Path = @"E:\Repositories\PnP-PowerShell", Name = "PnPPowerShell" },
            new Project{ Path = @"E:\Repositories\Polly", Name = "Polly" },
            new Project{ Path = @"E:\Repositories\PowerShell", Name = "PowerShell" },
            new Project{ Path = @"E:\Repositories\Prism", Name = "Prism" },
            new Project{ Path = @"E:\Repositories\Protobuild", Name = "Protobuild" },
            new Project{ Path = @"E:\Repositories\PTVS", Name = "PTVS" },
            new Project{ Path = @"E:\Repositories\QuickGraph", Name = "QuickGraph" },
            new Project{ Path = @"E:\Repositories\Rebus", Name = "Rebus" },
            new Project{ Path = @"E:\Repositories\roslyn", Name = "Roslyn" },
            new Project{ Path = @"E:\Repositories\RTVS", Name = "RTVS" },
            new Project{ Path = @"E:\Repositories\Rubberduck", Name = "Rubberduck" },
            new Project{ Path = @"E:\Repositories\Rx.NET", Name = "RxNET" },
            new Project{ Path = @"E:\Repositories\sdk", Name = "Sdk" },
            new Project{ Path = @"E:\Repositories\serilog", Name = "Serilog" },
            new Project{ Path = @"E:\Repositories\ServiceStack", Name = "ServiceStack" },
            new Project{ Path = @"E:\Repositories\ShareX", Name = "ShareX" },
            new Project{ Path = @"E:\Repositories\SignalR", Name = "SignalR" },
            new Project{ Path = @"E:\Repositories\Sonarr", Name = "Sonarr" },
            new Project{ Path = @"E:\Repositories\SparkleShare", Name = "SparkleShare" },
            new Project{ Path = @"E:\Repositories\SpecFlow", Name = "SpecFlow" },
            new Project{ Path = @"E:\Repositories\templating", Name = "Templating" },
            new Project{ Path = @"E:\Repositories\Umbraco-CMS", Name = "UmbracoCms" },
            new Project{ Path = @"E:\Repositories\UWPCommunityToolkit", Name = "UWPCommunityToolkit" },
            new Project{ Path = @"E:\Repositories\vs-mef", Name = "VsMef" },
            new Project{ Path = @"E:\Repositories\vsts-agent", Name = "VstsAgent" },
            new Project{ Path = @"E:\Repositories\VsVim", Name = "VsVim" },
            new Project{ Path = @"E:\Repositories\wcf", Name = "Wcf" },
            new Project{ Path = @"E:\Repositories\WealthEconomy", Name = "WealthEconomy" },
            new Project{ Path = @"E:\Repositories\Wox", Name = "Wox" },
            new Project{ Path = @"E:\Repositories\Wyam", Name = "Wyam" },
            new Project{ Path = @"E:\Repositories\Xamarin.Auth", Name = "XamarinAuth" },
            new Project{ Path = @"E:\Repositories\Xamarin.Mobile", Name = "XamarinMobile" },
            new Project{ Path = @"E:\Repositories\xunit", Name = "XUnit" },
        };

        /// <summary>
        /// Contains the project info.
        /// </summary>
        public class Project
        {
            /// <summary>
            /// Gets or sets the path of the corresponding local repository.
            /// </summary>
            public virtual string Path { get; set; }

            /// <summary>
            /// Gets or sets the name of the project, e.g., to localize the connection string.
            /// </summary>
            public virtual string Name { get; set; }
        }

        static void Main(string[] args)
        {
            #region Deploying the projects...
            //var deployer = new FromLocalGitToSqlDbDeployment();
            //foreach (var project in Projects)
            //{
            //    deployer.Warnings = new StringBuilder();

            //    var localRepository = new Repository(project.Path);
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };

            //    deployer.Deploy(localRepository, dbRepository);

            //    System.IO.File.WriteAllText($@"E:\Repositories\{project.Name}Warnings.txt", deployer.Warnings.ToString());
            //} 
            #endregion

            #region Repairing the commits indexing...
            //var deployer = new FromLocalGitToSqlDbDeployment();
            //foreach (var project in Projects)
            //{
            //    deployer.Warnings = new StringBuilder();

            //    var localRepository = new Repository(project.Path);
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;

            //    deployer.RepairCommitIndexes(localRepository, dbRepository);

            //    System.IO.File.WriteAllText($@"E:\Repositories\RepairingIndexes{project.Name}Warnings.txt", deployer.Warnings.ToString());
            //}
            #endregion

            #region Collecting file content summaries
            //var summarizer = new FileContentSummarizer();
            //foreach (var project in Projects)
            //{
            //    summarizer.Warnings = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
            //    summarizer.Analyze(dbRepository, fv => fv.Content.SourceCode != null && fv.ContentSummary.SyntaxKindAnnotations == null);
            //    System.IO.File.WriteAllText($@"E:\Repositories\{project.Name}FileContentSummaryWarnings.txt", summarizer.Warnings.ToString());
            //}
            #endregion

            #region Collecting statistics...
            //StringBuilder report = new StringBuilder();
            ////report.AppendLine("Project;Period;#Commits;#Contributors;#Branches;#FileVersions;#FileChanges;#FileAdded;#FileDeleted;#FileModified;#FileRenamed");
            //report.AppendLine("\\textbf{Project}&\\textbf{Period}\\\\\\hline");

            ////report.AppendLine("\\textbf{Project}&\\textbf{\\#Commits}&\\textbf{\\#Contributors}&\\textbf{\\#Branches}&" +
            ////                  "\\textbf{\\#FileVersions}&\\textbf{\\#FileChanges}&\\textbf{\\#FileAdded}&" +
            ////                  "\\textbf{\\#FileDeleted}&\\textbf{\\#FileModified}&\\textbf{\\#FileRenamed}\\\\\\hline");
            //foreach (var project in Projects)
            //{
            //    Console.Out.WriteLine($"Collecting the report of {project.Name}");
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    var minDate = dbRepository.RepositoryObjects.OfType<Commit>().Min(c => c.Date);
            //    var maxDate = dbRepository.RepositoryObjects.OfType<Commit>().Max(c => c.Date);
            //    report.AppendLine($"{project.Name}&" + 
            //                      $"{minDate.Date.ToString("MMM dd, yyyy", new CultureInfo("en-US", false))}" +
            //                      $" - {maxDate.Date.ToString("MMM dd, yyyy", new CultureInfo("en-US", false))}" +
            //                      $"(>{(int) ((maxDate - minDate).TotalDays/365.2425)} years)\\\\\\hline"/* +
            //                      $" {dbRepository.RepositoryObjects.OfType<Commit>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<Contributor>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<Branch>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileVersion>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileChange>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileAddedChange>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileDeletedChange>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileModifiedChange>().Count()}&" +
            //                      $" {dbRepository.RepositoryObjects.OfType<FileRenamedChange>().Count()}"*/);
            //}
            //Console.Out.WriteLine($"Report collected!!!");
            //System.IO.File.WriteAllText($@"E:\Repositories\InitialCountsOfModifiedPairs.txt", report.ToString());
            #endregion

            #region Detecting not real source code changes
            //DetectingNotRealSourceCodeChanges();
            #endregion

            #region Diff characterization in according to Levenshtein
            //DetectingLevenshteinDiff("Levenshtein", (f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null && f.Deltas.All(d => d.Approach != ChangeDetectionApproaches.Simetrics)));
            //DetectingLevenshteinDiff("LevenshteinWithoutComments",
            //    f => f.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.Simetrics),
            //    delegate (FileModifiedChange change)
            //    {
            //        var ann = change.XAnnotations;
            //        return !ann.SourceCodeChanges || change.XAnnotations.OnlyCommentChanges;
            //    },
            //    new SourceCodeCleaner
            //    {
            //        Normalize = false,
            //        RemoveComments = true
            //    });
            #endregion

            #region Diff GumTree[native] deltas
            //DetectingNativeGumTreeDiff(ChangeDetectionApproaches.NativeGumTree);
            //DetectingNativeGumTreeDiff(ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //    change => change.XAnnotations.OnlyCommentChanges,
            //    new SourceCodeCleaner
            //    {
            //        Normalize = false,
            //        RemoveComments = true
            //    });
            //DetectingNativeGumTreeDiff(ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //   change => change.Principal.XAnnotations.OnlyCommentChanges,
            //   new SourceCodeCleaner
            //   {
            //       Normalize = false,
            //       RemoveComments = true
            //   });
            //ComplementDeltaInfos(ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //    null,
            //    new SourceCodeCleaner
            //    {
            //        Normalize = false,
            //        RemoveComments = true
            //});
            //SaveNativeTreesOfNativeGumTree(ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //   change => change.Principal.XAnnotations.OnlyCommentChanges,
            //   new SourceCodeCleaner
            //   {
            //       Normalize = false,
            //       RemoveComments = true
            //   });

            //SaveNativeTreesOfNativeGumTree(ChangeDetectionApproaches.NativeGumTree,
            //   change => change.Principal.XAnnotations.OnlyCommentChanges/*,
            //   new SourceCodeCleaner
            //   {
            //       Normalize = false,
            //       RemoveComments = true
            //   }*/);
            #endregion

            #region GumTree-Levenshtein Diff GumTree[native] deltas
            //// Reporting GumTree vs. Levenshtein (rejecting the files over which the changes involve comments)
            //ReportGumTreeAndLevenshtein(delegate (FileModifiedChange change)
            //{
            //    var ann = change.XAnnotations;
            //    return ann.SourceCodeChanges && !ann.OnlyCommentChanges;
            //}, "RejectOnlyCommentChanges", ChangeDetectionApproaches.NativeGumTree, "Levenshtein");

            //Reporting GumTree vs.Levenshtein(ignoring the comment changes) - Count of actions
            //ReportGumTreeAndLevenshtein(delegate (FileModifiedChange change)
            //{
            //    var ann = change.XAnnotations;
            //    return ann.SourceCodeChanges && !ann.OnlyCommentChanges;
            //}, "UniquePairsIgnoringCommentChanges",
            //ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //"LevenshteinWithoutComments",
            //new EditDistance<ActionDescriptor>());
            //Reporting GumTree vs.Levenshtein(ignoring the comment changes) - #Additions
            //ReportGumTreeAndLevenshtein(delegate (FileModifiedChange change)
            //{
            //    var ann = change.XAnnotations;
            //    return ann.SourceCodeChanges && !ann.OnlyCommentChanges;
            //}, "UniquePairsIgnoringCommentChangesJustMoves",
            //ChangeDetectionApproaches.NativeGumTreeWithoutComments,
            //"LevenshteinWithoutComments",
            //new EditDistance<ActionDescriptor> { CostModel = descriptor => descriptor.Action == ActionKind.Move ? 1 : 0 });
            #endregion

            #region Reviewing revision pairs
            //ReviewRevisionPairs(@"E:\Phd\Analysis\AjaxControlToolkitOutliersIgnoringCommentChanges.csv", @"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs", "Ratio-LevenshteinGumTree-RejectOnlyCommentChangesOutliers");
            //            ReviewRevisionPairs(@"E:\Phd\Analysis\AjaxControlToolkit"+
            // /*AkkaNET*/"OutliersIgnoringCommentChanges.csv",
            //                @"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs",
            //                "Ratio-LevenshteinGumTree-IgnoringCommentChangesLocalOutliers"/*,
            //                new SourceCodeCleaner
            //                {
            //                    Normalize = true,
            //                    Indentation = "   ",
            //                    RemoveComments = true
            //                }*/);

            //ReviewRevisionPairs2(@"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs",
            //    ReviewKind.Ratio_LevenshteinGumTreeAdditions_LocalOutliers/*,
            //                new SourceCodeCleaner
            //                {
            //                    Normalize = true,
            //                    Indentation = "",
            //                    //RemoveComments = true
            //                }*/);

            //ReviewRevisionPairs2(@"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs",
            //    ReviewKind.Ratio_LevenshteinGumTreeAdditions_LocalOutliers, 
            //    (s, s1, arg3, arg4, arg5, arg6, arg7) => ReviewRevisionPair(s, s1, arg3, arg4, arg5, arg6, arg7),
            //                /*,
            //                            new SourceCodeCleaner
            //                            {
            //                                Normalize = true,
            //                                Indentation = "",
            //                                //RemoveComments = true
            //                            }*/);

            //ReviewRevisionPairs2(@"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs",
            //    ReviewKind.Ratio_LevenshteinGumTreeDeletions_LocalOutliers,
            //    ReviewRevisionPair
            //                                        /*,
            //                                                    new SourceCodeCleaner
            //                                                    {
            //                                                        Normalize = true,
            //                                                        Indentation = "",
            //                                                        //RemoveComments = true
            //                                                    }*/);

            //ReviewRevisionPairs2(@"E:\Phd\Analysis\Original.cs", @"E:\Phd\Analysis\Modified.cs",
            //   ReviewKind.Ratio_LevenshteinGumTree_IgnoringCommentChanges_LocalOutliers,
            //   ReviewRevisionPair
            //*,
            //            new SourceCodeCleaner
            //            {
            //                Normalize = true,
            //                Indentation = "",
            //                //RemoveComments = true
            //            } */);

            //var redundantNameAnalyzer = new RedundantNameChecking();
            //redundantNameAnalyzer.AutoConfig();
            //foreach (var project in Projects.Where(p => p.Name == "OpenRA")/*.Skip(2)*/)
            //{
            //    analyzer.Warnings = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

            //    analyzer.RateSpuriositySymptoms(dbRepository,
            //        ChangeDetectionApproaches.NativeGumTree, null,
            //        @"E:\Phd\Analysis\Original.cs",
            //        @"E:\Phd\Analysis\Modified.cs");
            //    //analyzer.RateIncompatibleMatchingSymptoms(dbRepository,
            //    //    ChangeDetectionApproaches.NativeGumTree, null,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");//CoreFx

            //    //redundantNameAnalyzer.Rate(dbRepository);

            //    //analyzer.FindSpuriousElements(dbRepository, () => { },
            //    //        ChangeDetectionApproaches.NativeGumTree, null);

            //    //analyzer.RateIncompatibleMatchingSymptoms(dbRepository,
            //    //    ChangeDetectionApproaches.NativeGumTree, null,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");
            //}

            //var analyzer = new DeltaAnalyzer();
            //var sc = new SourceCodeCleaner();
            //foreach (var project in Projects/*.Skip(2)*/)
            //{
            //    analyzer.Warnings = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

            //    analyzer.SummarizeSpuriosity(dbRepository, () => { },
            //        ChangeDetectionApproaches.NativeGumTree, null);

            //    //analyzer.AnalyzingSpuriosity(dbRepository, () => { },
            //    //    ChangeDetectionApproaches.NativeGumTree, null, sc,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");

            //    //analyzer.RateIncompatibleMatchingSymptoms(dbRepository,
            //    //    ChangeDetectionApproaches.NativeGumTree, null,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");
            //}

            //var analyzer = new DeltaAnalyzer();
            //var sc = new SourceCodeCleaner();
            ////var syntaxTypes = new HashSet<string>();
            //bool rowNames = true;
            //var syntaxTypes = new List<string>(System.IO.File.ReadAllLines(@"C:\CDF\Analysis\TypesOfSpuriositySummaryWarnings.csv"));
            //foreach (var project in Projects/*.Skip(2)*/)
            //{
            //    analyzer.Warnings = new StringBuilder();
            //    analyzer.Report = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

            //    analyzer.ReportSpuriositySummariesPerElementTypes(dbRepository, () => { },
            //        ChangeDetectionApproaches.NativeGumTree, null, syntaxTypes, rowNames);
            //    rowNames = false;
            //    //analyzer.AnalyzingSpuriosity(dbRepository, () => { },
            //    //    ChangeDetectionApproaches.NativeGumTree, null, sc,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");

            //    //analyzer.RateIncompatibleMatchingSymptoms(dbRepository,
            //    //    ChangeDetectionApproaches.NativeGumTree, null,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");
            //    System.IO.File.AppendAllText(@"C:\CDF\Analysis\TypesOfSpuriositySummaryWarnings.csv", analyzer.Warnings.ToString());
            //}

            //var analyzer = new DeltaAnalyzer();
            //var sc = new SourceCodeCleaner();
            ////var syntaxTypes = new HashSet<string>();
            //bool rowNames = true;
            //var syntaxTypes = new List<string>(System.IO.File.ReadAllLines(@"C:\CDF\Analysis\TypesOfSpuriositySummaryWarnings.csv"));
            //foreach (var project in Projects/*.Skip(2)*/)
            //{
            //    analyzer.Warnings = new StringBuilder();
            //    analyzer.Report = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

            //    analyzer.ReportSpuriositySummariesPerElementTypes(dbRepository, () => { },
            //        ChangeDetectionApproaches.NativeGumTree, null, syntaxTypes, rowNames);
            //    rowNames = false;
            //    //analyzer.AnalyzingSpuriosity(dbRepository, () => { },
            //    //    ChangeDetectionApproaches.NativeGumTree, null, sc,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");

            //    //analyzer.RateIncompatibleMatchingSymptoms(dbRepository,
            //    //    ChangeDetectionApproaches.NativeGumTree, null,
            //    //    @"E:\Phd\Analysis\Original.cs",
            //    //    @"E:\Phd\Analysis\Modified.cs");
            //    System.IO.File.AppendAllText(@"C:\CDF\Analysis\TypesOfSpuriositySummaryWarnings.csv", analyzer.Warnings.ToString());
            //}
            //System.IO.File.WriteAllText(@"C:\CDF\Analysis\TypesOfSpuriositySummary.csv", analyzer.Report.ToString());
            #endregion

            #region Summarize Symptoms
            //var analyzer = new DeltaAnalyzer { Report = new StringBuilder() };
            //bool rowNames = true;
            //foreach (var project in Projects)
            //{
            //    analyzer.Report = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

            //    analyzer.SummarizeSubcorpusSelection(dbRepository, ChangeDetectionApproaches.NativeGumTree, ChangeDetectionApproaches.NativeGumTreeWithoutComments, rowNames);
            //    rowNames = false;
            //    Console.WriteLine($"{dbRepository.Name} - DONE");
            //}
            //System.IO.File.WriteAllText(@"C:\CDF\Analysis\SubcorpusSummary.csv", analyzer.Report.ToString());
            #endregion

            #region Detecting not real source code changes
            //DetectingOnlyCommentChanges();
            #endregion

            #region Deploying file revision pairs
            //DeployFileRevisionPairs();
            //CheckFileRevisionPairs();
            //DeployReviewsForFileRevisionPairs();
            #endregion

            #region Diff GumTree[native] and Levenshtein by methods deltas
            //DetectingNativeGumTreeDiff(ChangeDetectionApproaches.NativeGumTree);
            //DetectingNativeGumTreeAndLevenshteinDiffByMethods(ChangeDetectionApproaches.NativeGumTreeMethodsWithoutComments,
            //    "LevenshteinWithoutComments",
            //    change => change.XAnnotations.OnlyCommentChanges,
            //    new SourceCodeCleaner
            //    {
            //        Normalize = false,
            //        RemoveComments = true
            //    });
            #endregion

            //ReportMissedMatchesAOfNamedElements(ChangeDetectionApproaches.NativeGumTree);
            //SummarizeFileRevisionPairs();
            //ReportConfusingRenames(ChangeDetectionApproaches.NativeGumTree);

            //var analyzer = new DeltaAnalyzer();
            //var namesRow = true;
            //foreach (var project in Projects)
            //{
            //    //analyzer.Warnings = new StringBuilder();
            //    analyzer.Report = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 3600;

            //    analyzer.SummarizeSymptoms(dbRepository, ChangeDetectionApproaches.NativeGumTree, namesRow);
            //    namesRow = false;
            //    Console.Out.WriteLine($"{project.Name}");
            //    System.IO.File.AppendAllText(@"E:\Phd\Analysis\UniquePairs\SymptomsSummaryEnumValueNotNullAndArgNot2.csv", analyzer.Report.ToString());
            //    //System.IO.File.AppendAllText(@"E:\Phd\Analysis\UniquePairs\WarningsGhost.csv", analyzer.Warnings.ToString());
            //}
            //var syntaxTypes = new List<string>(System.IO.File.ReadAllLines(@"E:\Phd\Analysis\UniquePairs\TypesOfSpuriositySummary.csv"));
            //var medianTails = new List<string>(System.IO.File.ReadAllLines(@"E:\Phd\Analysis\UniquePairs\MedianTailThs.csv"));
            //analyzer.Report = new StringBuilder();
            //var projects = Projects.Where(p => p.Name != "HadoopSdk").Select(project =>
            //{
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 3600;
            //    return dbRepository;
            //});
            //analyzer.CalculateRelativeThresholds(projects, syntaxTypes, medianTails.Select(s =>
            //{
            //    var v = s.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //    return new KeyValuePair<string, double>(v[0], double.Parse(v[1], CultureInfo.InvariantCulture));
            //}));
            //System.IO.File.WriteAllText(@"E:\Phd\Analysis\UniquePairs\RelativeThresholds.csv", analyzer.Report.ToString());
            //MigrateRoslynMLTreesOfNativeGumTree(ChangeDetectionApproaches.InverseOfNativeGumTree);
            //SaveRoslynMLTreesOfNativeGumTree(ChangeDetectionApproaches.NativeGTtreefiedRoslynML);
            //DetectingNativeGumTreeWithGumtreefiedRoslynML();
            //DetectingNativeGumTreeWithGumtreefiedRoslynMLOnMultipleConfigurations();
            //DetectingInverseNativeGumTreeWithGumtreefiedRoslynML();
            //DetectingNativeGumTreeDiffWithCustomMatchers();
            //ComparisonBetweenGumTreeAndCDGumTree();
            //ComparisonBetweenGumTreeAndReverseGumTree();
            //ComparisonBetweenGumTreeWithMultipleConfigurations();
            //ReportBetweenMatches();
            //StructureBetweenMatches();
            //Interruptions();
            //ReportInstructionsVsSize();
            //var analyzer = new BetweenComparison();
            //analyzer.ConfigGumTreeVsReversedGumTree();
            //foreach (var project in Projects)
            //{
            //    analyzer.Warnings = new StringBuilder();
            //    analyzer.Report = new StringBuilder();
            //    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
            //    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 3600;

            //    analyzer.SqlRepository = dbRepository;
            //    analyzer.MillisecondsTimeout = 3600;

            //    analyzer.Recognize();
            //    //namesRow = false;
            //    Console.Out.WriteLine($"{project.Name}");
            //    System.IO.File.AppendAllText(@"E:\Phd\Analysis\UniquePairs\SymptomsSummaryEnumValueNotNullAndArgNot2.csv", analyzer.Report.ToString());
            //    //System.IO.File.AppendAllText(@"E:\Phd\Analysis\UniquePairs\WarningsGhost.csv", analyzer.Warnings.ToString());
            //}           

            //ExploringRDSL();
            //int fragments = 0, frps = 0; 
            //foreach (var project in Projects)
            //{
            //    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
            //    {
            //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
            //        Console.Out.WriteLine($"{project.Name}");

            //        fragments += dbRepository.Reviews.AsNoTracking().Where(r => r.Kind == ReviewKind.Redundancy_MissedName ||
            //                                                     r.Kind == ReviewKind.Spuriosity_IncompatibleMatches ||
            //                                                     r.Kind == ReviewKind.Spuriosity_SpuriousElements).Count();

            //        frps += dbRepository.Reviews.AsNoTracking().Where(r => r.Kind == ReviewKind.Redundancy_MissedName ||
            //                                                     r.Kind == ReviewKind.Spuriosity_IncompatibleMatches ||
            //                                                     r.Kind == ReviewKind.Spuriosity_SpuriousElements).Select(r => r.RevisionPair.Id).Distinct().Count();
            //    }
            //}
            //RedundancyComparisonGumTreeWithMultipleConfigurations();
            
                //--DetectingInverseOfNativeGumTreeWithGumtreefiedRoslynMLOnMultipleConfigurations();
            
            //ReviewRevisionPairs2(@"E:\Phd\Analysis\OriginalForReversibilityExample.cs", @"E:\Phd\Analysis\ModifiedForReversibilityExample.cs",
            //    ReviewKind.Ratio_LevenshteinGumTreeAdditions_LocalOutliers, ReviewRevisionPair/*,
            //                new SourceCodeCleaner
            //                {
            //                    Normalize = true,
            //                    Indentation = "",
            //                    //RemoveComments = true
            //                }*/);

            Console.Out.WriteLine($"DONE");
            //int i = 0; // the warning reports!!!
            System.Console.ReadKey();
        }

        public static void ExploringRDSL()
        {
            var v = Enum.GetValues(typeof(Microsoft.CodeAnalysis.CSharp.SyntaxKind));
            //var x = Jawilliam.CDF.XObjects.RDSL.Syntax.Load(@"E:\Projects\Change-Detection-Foundation\Jawilliam.CDF.CSharp\RDSL.xml");
            var rdsl = Jawilliam.CDF.XObjects.RDSL.Syntax.Load(@"E:\MyRepositories\Change-Detection-Foundation\Jawilliam.CDF.CSharp\RDSL.xml");
            var nonAbstractTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();
            var abstractTypes = rdsl.Nodes.Type.Where(n => n.@abstract).ToArray();

            var symbolicTypes = nonAbstractTypes.Where(t => t.Properties.Property.Count == 1).ToArray();

            var assembly = typeof(RoslynML).Assembly;
            var elementTypeInfos = rdsl.Nodes.Type.Select((n, i) => new {
                ElementType = n,
                Id = i,
                ClassType = assembly.GetType($"Jawilliam.CDF.CSharp.{n.name}`1")
            }).ToArray();

            //var matchingPropagation = from t in nonAbstractTypes
            //                          let tProperties = from p1 in t.Properties.Property where p1.kind == "Token" select p1
            //                          let remainingProperties = t.Properties.Property.Except(tProperties)
            //                          where remainingProperties.Count() == 1 /*&& p.readOnly*/
            //                          select new { Type = t, Property = remainingProperties.Single() };

            var punctuationProperties1 = (from t in nonAbstractTypes
                                         from p in t.Properties.Property
                                         where p.kind == "Token"//(p.keyword ?? false) || (p.@operator ?? false) || (p.puntuaction ?? false) || (p.kind == "Token" && p.Rules?.Name != null)
                                          select new { Type = t, Property = p }).ToArray();

            var punctuationProperties2 = (from t in nonAbstractTypes
                                         from p in t.Properties.Property
                                         where (p.Rules?.Pairwise?.tunneling ?? false)
                                         select new { Type = t, Property = p }).ToArray();

            var r1 = punctuationProperties1.Except(punctuationProperties2).ToArray();
            var r2 = punctuationProperties2.Except(punctuationProperties1).ToArray();

            var operatorProperties = from t in nonAbstractTypes
                                        from p in t.Properties.Property
                                        where p.name.Contains("Operator")
                                        select new { Type = t, Property = p };
            StringBuilder sb = new StringBuilder();
            //foreach (var mp in r3)
            //{
            //    sb.AppendLine($"{mp.Property.name} in {mp.Type.name}");
            //}
            //System.IO.File.WriteAllText(@"D:\Reports\Exception Operator Properties.txt", sb.ToString());

            var puntuactionProperties = from t in nonAbstractTypes
                                        from p in t.Properties.Property
                                        where p.kind == "Token" && p.hashtags.Contains("#KEYWORD") && p.Rules.Name == null && p.Rules.Signature == null
                                        select new { Type = t, Property = p };
            sb = new StringBuilder();
            foreach (var mp in operatorProperties)
            {
                sb.AppendLine($"{mp.Property.name} in {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\Punctuation Properties.txt", sb.ToString());

            var testProperties = operatorProperties.Except(from t in nonAbstractTypes from p in t.Properties.Property where p.kind == "Token" select new { Type = t, Property = p });
            var testProperties2 = (from t in nonAbstractTypes from p in t.Properties.Property where p.kind == "Token" && p.hashtags.Contains("#KEYWORD") select new { Type = t, Property = p }).Except(operatorProperties);

            sb.Clear();
            foreach (var mp in testProperties2)
            {
                sb.AppendLine($"{mp.Property.name} in {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\Other Properties.txt", sb.ToString());

            var matchingPropagation1 = from t in nonAbstractTypes
                                       from p in t.Properties.Property
                                       where p.Rules.Pairwise?.tunneling ?? false /*&& p.readOnly*/
                                       select new { Type = t, Property = p };

            var b2 = operatorProperties.Except(matchingPropagation1).ToList();
            var b3 = matchingPropagation1.Except(operatorProperties).ToList();

            //System.IO.File.WriteAllText(@"D:\Reports\Pairwise Matching Propagation Properties.txt", sb.ToString());

            var members = rdsl.Nodes.Type.Where(n => n.name.Contains("Member")).ToArray();
            var declarations = rdsl.Nodes.Type.Where(n => n.name.Contains("DeclarationSyntax")).ToArray();
            var memberDeclarations = declarations.Where(n => n.name.Contains("Member")).ToArray();
            var abstractDeclarations = abstractTypes.Where(n => n.name.Contains("DeclarationSyntax") || n.name.Contains("DeclaratorSyntax")).ToArray();
            var nonAbstractDeclarations = nonAbstractTypes.Where(n => n.name.Contains("DeclarationSyntax") || n.name.Contains("DeclaratorSyntax")).ToArray();
            var typeDeclarations = nonAbstractDeclarations.Where(n => n.@base != null && n.@base.Contains("Type")).Union(nonAbstractDeclarations.Where(n => n.name == "DelegateDeclarationSyntax")).ToArray();
            var methodDeclarations = nonAbstractDeclarations.Where(n => n.@base != null && n.@base.Contains("Method")).Union(nonAbstractDeclarations.Where(n => n.name == "AccessorDeclarationSyntax")).ToArray();
            var propertyDeclarations = nonAbstractDeclarations.Where(n => n.@base != null && n.@base.Contains("Property")).Union(nonAbstractDeclarations.Where(n => n.name == "AnonymousObjectMemberDeclaratorSyntax")).ToArray();
            var fieldDeclarations = nonAbstractDeclarations.Where(n => (n.@base != null && n.@base.Contains("Field")) || n.name.Contains("EnumMember")).ToArray();
            var variableDeclarations = nonAbstractDeclarations.Where(n => (n.@base != null && n.@base.Contains("Variable")) || n.name.Contains("Variable")).ToArray();
            var otherDeclarations = nonAbstractDeclarations.Except(typeDeclarations.Union(methodDeclarations).Union(propertyDeclarations).Union(fieldDeclarations).Union(variableDeclarations)).ToArray();
            //var otherMembers = nonAbstractDeclarations.Except(typeDeclarations.Union(methodDeclarations).Union(propertyDeclarations).Union(fieldDeclarations)).ToArray();

            //var declarationTypes = x.Nodes.Type.Where(n => n.name.Contains("DeclarationSyntax")).ToArray();
            //var nonAbstractDeclarationElementTypes = declarationTypes.Where(n => !n.@abstract).ToArray();

            var statements = rdsl.Nodes.Type.Where(n => n.name.Contains("StatementSyntax")).ToArray();
            var nonAbstractStatements = nonAbstractTypes.Where(n => n.name.Contains("StatementSyntax")).ToArray();

            var expressionTypes = rdsl.Nodes.Type.Where(n => n.name.Contains("ExpressionSyntax")).ToArray();
            var nonAbstractExpressionTypes = nonAbstractTypes.Where(n => n.name.Contains("ExpressionSyntax")).ToArray();

            var elementTypesWithOperator = rdsl.Nodes.Type.Where(n => !n.@abstract && n.name.Contains("Operator")).ToArray();

            //NameKey
            var elementTypesWithIdentifier = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Identifier"))).ToArray();
            var elementTypesWithAName = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Name"))).ToArray();
            var indexerOrDocumentationRelatedElementTypes = rdsl.Nodes.Type.Where(n => !n.@abstract && n.name.Contains("Indexer")).ToArray(); 
            var comparisonOperatorsOrDocumentationRelatedElementTypes = rdsl.Nodes.Type.Where(n => !n.@abstract && n.name.Contains("Operator") && !n.name.Contains("Conversion")).ToArray();
            //var elementTypesWithDeclaration = x.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Declaration"))).ToArray();
            var variableDeclarationElementType = rdsl.Nodes.Type.Where(n => !n.@abstract && n.name == "VariableDeclarationSyntax").ToArray();

            // All
            var elementTypesSuitableForNameKeys = elementTypesWithIdentifier.Union(elementTypesWithAName)
                                                                            .Union(comparisonOperatorsOrDocumentationRelatedElementTypes)
                                                                            .Union(indexerOrDocumentationRelatedElementTypes)
                                                                            /*.Union(elementTypesWithDeclaration)*/
                                                                            .Union(variableDeclarationElementType).ToArray();
            // Navigable NameKeys
            var elementTypesWithNavigableNameKeys = elementTypeInfos.Where(eti => !eti.ElementType.@abstract && eti.ClassType.GetProperties().Any(p => elementTypesSuitableForNameKeys.Any(en => p.PropertyType.Name == en.name + "`1")/* ||
                                                                                                                                                       elementTypesSuitableForNameKeys.Any(en => p.Name == en.name)*/))
                                                                                                                                                       .Select(eti => eti.ElementType)
                                                                                                                                                       .ToArray();
            var newElementTypesWithName = elementTypesWithNavigableNameKeys.Except(elementTypesSuitableForNameKeys).ToArray();

            // 
            var totalElementTypesSuitableForNameKeys = elementTypesSuitableForNameKeys.Union(newElementTypesWithName).ToArray();

            var elementTypesWithDeclarationProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Declaration"))).ToArray();
            var elementTypesWithDeclarationProp2 = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Declaration"))).ToArray();

            var elementTypesWithTypeProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Type"))).ToArray();
            var elementTypesWithKeywordProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Keyword" && !p.readOnly))).ToArray();
            var elementTypesWithFileProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "File"))).ToArray();
            var elementTypesWithLocalNameProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "LocalName"))).ToArray();
            var elementTypesWithPrefixProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Prefix"))).ToArray();
            var elementTypesWithAliasProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Alias"))).ToArray();
            var elementTypesWithNameEqualsProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "NameEquals"))).ToArray();
            var elementTypesWithNameColonProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "NameColon"))).ToArray();
            var elementTypesWithExpressionProp = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "Expression"))).ToArray();

            var elementTypesWithOperatorKeyword = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && (n.Properties.Property.Any(p => p.name == "OperatorKeyword"))).ToArray();
            var elementTypesWithExplicitInterfaceSpecifier = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && n.Properties.Property.Any(p => p.name == "ExplicitInterfaceSpecifier")).ToArray();
            var elementTypesWithTypeParameterList = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && n.Properties.Property.Any(p => p.name == "TypeParameterList")).ToArray();
            var elementTypesWithParameterList = rdsl.Nodes.Type.Where(n => !n.@abstract && n.Properties != null && n.Properties.Property.Any(p => p.name == "ParameterList")).ToArray();

            var elementTypesWithSignature = elementTypesWithExplicitInterfaceSpecifier.Union(elementTypesWithTypeParameterList).Union(elementTypesWithParameterList).ToArray();
            // Navigable NameKeys
            var elementTypesWithNavigableSignatureKeys = elementTypeInfos.Where(eti => !eti.ElementType.@abstract && eti.ClassType.GetProperties().Any(p => elementTypesWithSignature.Any(en => p.PropertyType.Name == en.name + "`1")/* ||
                                                                                                                                                       elementTypesSuitableForNameKeys.Any(en => p.Name == en.name)*/))
                                                                                                                                                       .Select(eti => eti.ElementType)
                                                                                                                                                       .ToArray();

            var elementTypesWithKey = totalElementTypesSuitableForNameKeys.Union(elementTypesWithSignature).ToArray();
            var elementTypesWithNameTieBreaking = totalElementTypesSuitableForNameKeys.Intersect(elementTypesWithSignature).ToArray();
            
            var syntaxTokenType = assembly.GetType($"Jawilliam.CDF.CSharp.SyntaxToken`1");
            var syntaxTokenListType = assembly.GetType($"Jawilliam.CDF.CSharp.SyntaxTokenList`1");
            var csharpSyntaxNodeType = assembly.GetType($"Jawilliam.CDF.CSharp.CSharpSyntaxNode`1");
            var syntaxListType = assembly.GetType($"Jawilliam.CDF.CSharp.SyntaxList`2");
            var separatedSyntaxListType = assembly.GetType($"Jawilliam.CDF.CSharp.SeparatedSyntaxList`2");          

            

            var elementTypesWithNameExpressions2 = elementTypeInfos.Where(eti => !eti.ElementType.@abstract && eti.ClassType.GetProperties().Any(p => totalElementTypesSuitableForNameKeys.Any(en => p.PropertyType.Name == en.name + "`1") ||
                                                                                                                        totalElementTypesSuitableForNameKeys.Any(en => p.Name == en.name))).Select(eti => eti.ElementType).ToArray();
            var newElementTypesWithName2 = elementTypesWithNameExpressions2.Except(totalElementTypesSuitableForNameKeys).ToArray();

            var edges = new List<Edge>();
            foreach (var elemenTypeInfo in elementTypeInfos)
            {
                foreach (var property in elemenTypeInfo.ClassType.GetProperties())
                {
                    if (property.PropertyType.Name == syntaxListType.Name || property.PropertyType.Name == separatedSyntaxListType.Name)
                    {
                        var propertyElementType = elementTypeInfos.Single(n => n.ClassType.Name == property.PropertyType.GenericTypeArguments[1].Name);
                        if (!edges.Exists(n => n.StartNode == elemenTypeInfo.Id && n.EndNode == propertyElementType.Id))
                            edges.Add(new Edge { StartNode = elemenTypeInfo.Id, EndNode = propertyElementType.Id });
                        continue;
                    }

                    if (property.PropertyType.Name == csharpSyntaxNodeType.Name)
                        continue;

                    if (property.PropertyType.Name != syntaxTokenType.Name && property.PropertyType.Name != syntaxTokenListType.Name)
                    {
                        var propertyElementType = elementTypeInfos.Single(n => n.ClassType.Name == property.PropertyType.Name);
                        if (!edges.Exists(n => n.StartNode == elemenTypeInfo.Id && n.EndNode == propertyElementType.Id))
                            edges.Add(new Edge { StartNode = elemenTypeInfo.Id, EndNode = propertyElementType.Id });
                    }
                }
            }

            var spanningTrees = KruskalAlgorithm.Kruskal(elementTypeInfos.Length, edges).ToArray();
            var result = spanningTrees.Select(edge => new
            {
                Start = elementTypeInfos.Single(n => n.Id == edge.StartNode),
                End = elementTypeInfos.Single(n => n.Id == edge.EndNode)
        }).ToArray();

            // Leaf elements.
            var bLeafElements = nonAbstractTypes.Where(t => !t.Properties.Property.Any()); // doesn’t contain syntax properties
            var cLeafElements = from t in nonAbstractTypes
                                let p = t.Properties.Property.FirstOrDefault(p => (p.optional || !p.readOnly) && p.kind == "Token")
                                where t.Properties.Property.All(p1 => p1 == p || (!p1.optional && p1.readOnly && p1.kind == "Token"))
                                select t;
        }

        private static void ComparisonBetweenGumTreeAndCDGumTree()
        {
            var recognizer = new BetweenComparison() { MillisecondsTimeout = 600000 };
            recognizer.ConfigLeftVsRight((ChangeDetectionApproaches.NativeGumTree, "GumTree"), (ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher, "ChangeDistillerGumTree"));
            var connectionSettings = System.Configuration.ConfigurationManager.ConnectionStrings;

            foreach (var project in Projects.Reverse().Skip(17).Take(27))
            {
                //var connection = System.Configuration.ConfigurationManager.ConnectionStrings[project.Name];
                //var connectionString = connection.ConnectionString.Replace("res://*/GitRepository", ".\\GitRepository");
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                recognizer.SqlRepository = dbRepository;
                recognizer.Cancel = null;

                Func<FileRevisionPair, bool> skipThese = frp => dbRepository.Deltas.Any(d => d.RevisionPair.Id == frp.Id &&
                                                                             d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                                                                             d.OriginalTree != null && d.ModifiedTree != null);

                recognizer.Warnings = new StringBuilder();
                recognizer.Recognize(skipThese, true);
                System.IO.File.AppendAllText($@"C:\CDF\GT_CDGT.txt", $"{Environment.NewLine}{Environment.NewLine}Between comparison (recognition) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                                                                     $"{Environment.NewLine}{recognizer.Warnings.ToString()}");

                recognizer.Warnings = new StringBuilder();
                recognizer.ConnectMatchSymptoms(skipThese, true);
                System.IO.File.AppendAllText($@"C:\CDF\GT_CDGT.txt", $"{Environment.NewLine}{Environment.NewLine}Between comparison (structuring) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                                                                     $"{Environment.NewLine}{recognizer.Warnings.ToString()}");

            }
            Console.Out.WriteLine($"Change Distiller vs. GumTree - matches collected!!!");
        }

        public static void ReportInstructionsVsSize()
        {
            var recognizer = new CorpusInfo() { MillisecondsTimeout = 600000 };
            var reportPath = @"E:\SourceCode\InterruptionsVsSize.txt";

            var reportLine = new StringBuilder();
            reportLine.Append($"Project");
            reportLine.Append($";OCodeLines");
            reportLine.Append($";OCommentLines");
            reportLine.Append($";OStatementLines"); ;
            reportLine.Append($";MCodeLines");
            reportLine.Append($";MCommentLines");
            reportLine.Append($";MStatementLines");
            reportLine.Append($";OAstNodes");
            reportLine.Append($";MAstNodes");
            reportLine.Append($";GT_OMatches");
            reportLine.Append($";GT_OActions");
            reportLine.Append($";IGT_OMatches");
            reportLine.Append($";IGT_OActions");
            reportLine.Append($";GTCD_OMatches");
            reportLine.Append($";GTCD_OActions");
            reportLine.Append($";IGTCD_OMatches");
            reportLine.Append($";IGTCD_OActions");
            reportLine.Append($";GTXY_OMatches");
            reportLine.Append($";GTXY_OActions");
            reportLine.Append($";IGTXY_OMatches");
            reportLine.Append($";IGTXY_OActions");
            System.IO.File.AppendAllText(reportPath, reportLine.ToString());

            foreach (var project in Projects)
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;
                    recognizer.SaveInterruptionsVersusSize(reportPath, null);

                    Console.Out.WriteLine(project.Name);
                }
            }
            Console.Out.WriteLine($"InterruptionsVsSize!!!");
        }

        public static void Interruptions()
        {
            var recognizer = new FileRevisionPairAnalyzer() { MillisecondsTimeout = 600000 };
            System.IO.File.WriteAllText($@"E:\SourceCode\InterruptionsSummary.txt", "Project;#Frps;#GT;%GT;#IGT;%IGT;#CD;%CD;#ICD;%ICD;#XY;%XY;#IXY;%IXY");
            foreach (var project in Projects.Where(p => p.Name != "HadoopSdk"))
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;
                    var r = recognizer.GetInterruptions(new[] 
                    {
                        ChangeDetectionApproaches.NativeGumTree,
                        ChangeDetectionApproaches.InverseOfNativeGumTree,
                        ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher,
                        ChangeDetectionApproaches.InverseOfNativeGumTreeWithChangeDistillerMatcher,
                        ChangeDetectionApproaches.NativeGumTreeWithXyMatcher,
                        ChangeDetectionApproaches.InverseOfNativeGumTreeWithXyMatcher
                    });
                    var total = dbRepository.Database.SqlQuery<int>($"SELECT count([Id]) FROM [dbo].[Deltas] WHERE Approach = {(int)ChangeDetectionApproaches.NativeGumTree}").Single();
                    System.IO.File.AppendAllText($@"E:\SourceCode\InterruptionsSummary.txt",
                    $"{Environment.NewLine}{project.Name};" +
                    $"{total};" +
                    $"{r[0]};{(r[0] * 100d / total).ToString(CultureInfo.InvariantCulture)};" +
                    $"{r[1]};{(r[1] * 100d / total).ToString(CultureInfo.InvariantCulture)};" +
                    $"{r[2]};{(r[2] * 100d / total).ToString(CultureInfo.InvariantCulture)};" +
                    $"{r[3]};{(r[3] * 100d / total).ToString(CultureInfo.InvariantCulture)};" +
                    $"{r[4]};{(r[4] * 100d / total).ToString(CultureInfo.InvariantCulture)};" +
                    $"{r[5]};{(r[5] * 100d / total).ToString(CultureInfo.InvariantCulture)}");

                    Console.Out.WriteLine(project.Name);
                }
            }
            Console.Out.WriteLine($"InterruptionsSummary!!!");
        }

        public static void ReportBetweenMatches()
        {
            var recognizer = new BetweenComparison() { MillisecondsTimeout = 600000 };
            recognizer.ConfigGumTreeVsReversedGumTree();
            System.IO.File.WriteAllText($@"E:\SourceCode\BetweenMatchComparison_GT_RGT_TreeSummary.txt", "Project;#Frps;#LRMatches;#LRFrps;%LRFrps;RLMatches;#RLFrps;%RLFrps;TotalMatches;#TotalFrps;%TotalFrps");
            foreach (var project in Projects)
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;
                    var r = recognizer.ReportBetweenMatches();
                    System.IO.File.AppendAllText($@"E:\SourceCode\BetweenMatchComparison_GT_RGT_TreeSummary.txt", 
                    $"{Environment.NewLine}{project.Name};" +
                    $"{r.TotalOfFileRevisionPairs};" +
                    $"{r.TotalOfSymptoms.LR};{r.TotalOfAffectedFileRevisionPairs.LR};{r.PercentageOfAffectedFileRevisionPairs.LR.ToString(CultureInfo.InvariantCulture)};" +
                    $"{r.TotalOfSymptoms.RL};{r.TotalOfAffectedFileRevisionPairs.RL};{r.PercentageOfAffectedFileRevisionPairs.RL.ToString(CultureInfo.InvariantCulture)};" +
                    $"{r.TotalOfSymptoms.All};{r.TotalOfAffectedFileRevisionPairs.All};{r.PercentageOfAffectedFileRevisionPairs.All.ToString(CultureInfo.InvariantCulture)}");

                    Console.Out.WriteLine(project.Name);
                }
            }
            Console.Out.WriteLine($"BetweenMatchComparison_GT_RGT_Summary!!!");
        }

        public static void StructureBetweenMatches()
        {
            var recognizer = new BetweenComparison() { MillisecondsTimeout = 600000 };
            recognizer.ConfigGumTreeVsReversedGumTree();
            //System.IO.File.WriteAllText($@"E:\SourceCode\BetweenMatchComparison_GT_RGT_Summary.txt", "Project;#Frps;#LRMatches;#LRFrps;%LRFrps;RLMatches;#RLFrps;%RLFrps;TotalMatches;#TotalFrps;%TotalFrps");
            foreach (var project in Projects)
            {
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;
                    recognizer.ConnectMatchSymptoms();

                    Console.Out.WriteLine(project.Name);
                }
            }
            Console.Out.WriteLine($"BetweenMatchComparison_GT_RGT_Summary!!!");
        }

        //public static void SummarizeFileRevisionPairs()
        //{
        //    var analyzer = new FileRevisionPairAnalyzer();
        //    System.IO.File.WriteAllText(@"E:\Phd\Analysis\FileRevisionPairsSummary.txt",
        //                                $"Project;Frp;FrpSCC;FrpOCC;RelevantFrp{Environment.NewLine}");

        //    int allFrp = 0, allFrpScc = 0, allFrpOcc = 0; 
        //    foreach (var project in Projects)
        //    {
        //        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
        //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 360;

        //        var summary = analyzer.Summarize(dbRepository);
        //        allFrp += summary.Item1;
        //        allFrpScc += summary.Item2;
        //        allFrpOcc += summary.Item3;

        //        var projectSummary = $"{project.Name};" +
        //                $"{summary.Item1};" +
        //                $"{summary.Item2};" +
        //                $"{summary.Item3};" +
        //                $"{summary.Item2 - summary.Item3}";
        //        System.IO.File.AppendAllText($@"E:\Phd\Analysis\FileRevisionPairsSummary.txt", 
        //                                     projectSummary +
        //                                     $"{Environment.NewLine}");
        //        Console.Out.WriteLine(projectSummary);
        //    }

        //    var allSummary = $"ALL;" +
        //                   $"{allFrp};" +
        //                   $"{allFrpScc};" +
        //                   $"{allFrpOcc};" +
        //                   $"{allFrpScc - allFrpOcc}";
        //    System.IO.File.AppendAllText($@"E:\Phd\Analysis\FileRevisionPairsSummary.txt", allSummary);
        //    Console.Out.WriteLine(allSummary);
        //    Console.Out.WriteLine($"Report collected!!!");
        //}

        private static void DetectingInverseOfNativeGumTreeWithGumtreefiedRoslynMLOnMultipleConfigurations()
        {
            var configurations = new[]
            {
                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size100",
                      Forward = new { Name = @"gumtree_Minh2Sim0d5Size100", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 },
                      Backward = new { Name = @"inverse_gumtree_Minh2Sim0d5Size100", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 }},

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size325",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size325", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size325", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size550",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size550", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size550", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size775",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size775", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size775", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1225",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size1225", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size1225", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1450",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size1450", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size1450", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1675",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size1675", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size1675", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 } },

                new { Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1900",
                      Forward = new {  Name = @"gumtree_Minh2Sim0d5Size1900", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 },
                      Backward = new {  Name = @"inverse_gumtree_Minh2Sim0d5Size1900", Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 } }
            };

            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = null,
                Original = @"D:\ExperimentLogs\InverseForMultipleConfigurationsOriginal.cs",
                Modified = @"D:\ExperimentLogs\InverseForMultipleConfigurationsModified.cs"
            };
            var xSkipThesePath = $@"D:\ExperimentLogs\SkipThese.xml";
            var xSkipThese = XSkipTheseFileRevisionPairs.Read(System.IO.File.ReadAllText(xSkipThesePath), Encoding.Unicode);

            var recognizer = new BetweenComparison()
            {
                MillisecondsTimeout = 600000
            };

            foreach (var project in Projects.Skip(92))
            {
                foreach (var configuration in configurations.Where(c => project.Name == "SparkleShare" ? (int)c.Backward.Approach >= 24 : true))
                {
                    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                    analyzer.Warnings = new StringBuilder();
                    analyzer.SqlRepository = dbRepository;
                    analyzer.Cancel = () => gumTree.Cancel();

                    Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair pair)
                    {
                        var anyOriginal = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FromFileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));
                        var anyModified = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));

                        return !anyOriginal || !anyModified || (xSkipThese.Projects.Any(p => p.Name == project.Name && p.FileRevisionPairs.Any(frp => Guid.Parse(frp.Guid) == pair.Id)));
                    };

                    interopArgs.GumTreePath = configuration.Path;
                    //if (project.Name == "mono" && (int)configuration.Forward.Approach == 14)
                    //{
                    //    analyzer.NativeGumTreeDiff(gumTree, interopArgs, configuration.Forward.Approach, null, null);
                    ////analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);
                    //System.IO.File.AppendAllText($@"D:\ExperimentLogs\{configuration.Backward.Name}.txt",
                    //    $"{Environment.NewLine}{Environment.NewLine}GumTreefied RoslynML (forward collection) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    //    analyzer.Warnings = new StringBuilder();
                    //}

                    ///TODO: Hay que repetir el experimento para AzureSdkForNet
                    //if (!(project.Name == "SparkleShare" && (int)configuration.Backward.Approach == 25))
                    //{
                        analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, configuration.Backward.Approach, null, null);
                        //analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);
                        System.IO.File.AppendAllText($@"D:\ExperimentLogs\{configuration.Backward.Name}.txt",
                            $"{Environment.NewLine}{Environment.NewLine}GumTreefied RoslynML (collection) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    //}

                    recognizer.ConfigForwardVsBackward((configuration.Forward.Approach, configuration.Forward.Name), (configuration.Backward.Approach, configuration.Backward.Name));
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;
                    //frp => dbRepository.Deltas.Any(d => d.RevisionPair.Id == frp.Id &&
                    //                                                             d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                    //                                                             d.OriginalTree != null && d.ModifiedTree != null);

                    recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) args)
                    {
                        var version = args.TrueForOriginalOtherwiseModified
                            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FromFileVersion.Id)
                            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FileVersion.Id);

                        var xTree = XElement.Load(new StringReader(version.XmlTree));
                        var roslynMLServices = new RoslynML();
                        xTree = roslynMLServices.Gumtreefy(xTree);
                        roslynMLServices.SetRoslynMLIDs(xTree);

                        return roslynMLServices.AsGumtreefiedElementTree(xTree);
                    };

                    //if (!(project.Name == "MahAppsMetro" && (int)configuration.Forward.Approach == 18))
                    //{
                        recognizer.Warnings = new StringBuilder();
                        recognizer.Recognize(skipThese, true);
                        System.IO.File.AppendAllText($@"D:\ExperimentLogs\{configuration.Backward.Name}.txt",
                            $"{Environment.NewLine}{Environment.NewLine}Reversibility comparison (recognition) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                    //}

                    //recognizer.Warnings = new StringBuilder();
                    //recognizer.ConnectMatchSymptoms(skipThese, true);
                    //System.IO.File.AppendAllText($@"D:\ExperimentLogs\{configuration.Backward.Name}.txt",
                    //    $"{Environment.NewLine}{Environment.NewLine}Reversibility comparison (structuring) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                }
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        private static void DetectingNativeGumTreeWithGumtreefiedRoslynMLOnMultipleConfigurations()
        {
            var configurations = new[]
            {
                new { Name = @"gumtree_Minh2Sim0d5Size100", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size100", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 },
                new { Name = @"gumtree_Minh2Sim0d5Size325", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size325", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 },
                new { Name = @"gumtree_Minh2Sim0d5Size550", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size550", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 },
                new { Name = @"gumtree_Minh2Sim0d5Size775", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size775", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 },
                new { Name = @"gumtree_Minh2Sim0d5Size1225", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1225", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 },
                new { Name = @"gumtree_Minh2Sim0d5Size1450", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1450", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 },
                new { Name = @"gumtree_Minh2Sim0d5Size1675", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1675", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 },
                new { Name = @"gumtree_Minh2Sim0d5Size1900", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1900", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 }
            };

            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = null,
                Original = @"E:\SourceCode\Original.cs",
                Modified = @"E:\SourceCode\Modified.cs"
            };

            foreach (var project in Projects)
            {
                foreach (var configuration in configurations)
                {
                    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                    analyzer.Warnings = new StringBuilder();
                    analyzer.SqlRepository = dbRepository;
                    analyzer.Cancel = () => gumTree.Cancel();

                    interopArgs.GumTreePath = configuration.Path;

                    analyzer.NativeGumTreeDiff(gumTree, interopArgs, configuration.Approach, null, null);
                    //analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);
                    System.IO.File.AppendAllText($@"D:\ExperimentLogs\{configuration.Name}.txt",
                        $"{Environment.NewLine}{Environment.NewLine}GumTreefied RoslynML ({configuration.Name}) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                        $"{Environment.NewLine}{analyzer.Warnings.ToString()}");
                }
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        private static void RedundancyComparisonGumTreeWithMultipleConfigurations()
        {
            var configurations = new[]
            {
                new { Name = @"gumtree_Minh2Sim0d5Size100", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size100", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 },
                new { Name = @"gumtree_Minh2Sim0d5Size325", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size325", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 },
                new { Name = @"gumtree_Minh2Sim0d5Size550", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size550", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 },
                new { Name = @"gumtree_Minh2Sim0d5Size775", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size775", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 },
                new { Name = @"gumtree_Minh2Sim0d5Size1225", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1225", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 },
                new { Name = @"gumtree_Minh2Sim0d5Size1450", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1450", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 },
                new { Name = @"gumtree_Minh2Sim0d5Size1675", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1675", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 },
                new { Name = @"gumtree_Minh2Sim0d5Size1900", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1900", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 }
            };
            var xSkipThesePath = $@"D:\ExperimentLogs\SkipThese.xml";
            var xSkipThese = XSkipTheseFileRevisionPairs.Read(System.IO.File.ReadAllText(xSkipThesePath), Encoding.Unicode);

            var recognizer = new RedundancyComparison()
            {
                MillisecondsTimeout = 600000
            };

            var connectionSettings = System.Configuration.ConfigurationManager.ConnectionStrings;

            //var projects = Projects.Take(27).Skip(26);
            var projects = Projects.Skip(55);
            foreach (var project in projects)
            {
                foreach (var configuration in configurations.Take(1)/*/*.Where(a => project.Name == "KestrelHttpServer" ? (int)a.Approach >= (int)ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 : true)*/)
                {
                    xSkipThese = XSkipTheseFileRevisionPairs.Read(System.IO.File.ReadAllText(xSkipThesePath), Encoding.Unicode);
                    recognizer.ConfigLeftVsRight((ChangeDetectionApproaches.NativeGTtreefiedRoslynML, "gumtree_Minh2Sim0d5Size1000"), (configuration.Approach, configuration.Name));

                    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;

                    Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair pair)
                    {
                        var anyOriginal = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FromFileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));
                        var anyModified = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));

                        return !anyOriginal || !anyModified || (xSkipThese.Projects.Any(p => p.Name == project.Name && p.FileRevisionPairs.Any(frp => Guid.Parse(frp.Guid) == pair.Id)));
                    };

                    recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) args)
                    {
                        var version = args.TrueForOriginalOtherwiseModified
                            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FromFileVersion.Id)
                            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FileVersion.Id);

                        var xTree = XElement.Load(new StringReader(version.XmlTree));
                        var roslynMLServices = new RoslynML();
                        xTree = roslynMLServices.Gumtreefy(xTree);
                        roslynMLServices.SetRoslynMLIDs(xTree);

                        return roslynMLServices.AsGumtreefiedElementTree(xTree);
                    };

                    recognizer.Warnings = new StringBuilder();
                    recognizer.Recognize(skipThese, /*true*/false);
                    //System.IO.File.AppendAllText($@"D:\ExperimentLogs\gumtree_Minh2Sim0d5Size1000_VS_{configuration.Name}_RedundancySymptoms.txt",
                    //    $"{Environment.NewLine}{Environment.NewLine}Between comparison (recognition) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                    //    $"{Environment.NewLine}{recognizer.Warnings.ToString()}");
                }
            }
            Console.Out.WriteLine($"GumTree Minh2Sim0d5Size1000 - redundant symptoms collected!!!");
        }

        private static void ComparisonBetweenGumTreeWithMultipleConfigurations()
        {
            var configurations = new[]
            {
                new { Name = @"gumtree_Minh2Sim0d5Size100", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size100", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 },
                new { Name = @"gumtree_Minh2Sim0d5Size325", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size325", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 },
                new { Name = @"gumtree_Minh2Sim0d5Size550", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size550", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 },
                new { Name = @"gumtree_Minh2Sim0d5Size775", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size775", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 },
                new { Name = @"gumtree_Minh2Sim0d5Size1225", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1225", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 },
                new { Name = @"gumtree_Minh2Sim0d5Size1450", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1450", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 },
                new { Name = @"gumtree_Minh2Sim0d5Size1675", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1675", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 },
                new { Name = @"gumtree_Minh2Sim0d5Size1900", Path = @"D:\GT_Runtimes\gumtree_Minh2Sim0d5Size1900", Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 }
            };

            var recognizer = new BetweenComparison()
            {
                MillisecondsTimeout = 600000
            };            

            var connectionSettings = System.Configuration.ConfigurationManager.ConnectionStrings;

            //var projects = Projects.Take(72).Skip(26);
            var projects = Projects.Skip(82);
            foreach (var project in projects)
            {
                foreach (var configuration in configurations.Where(a => project.Name == "Roslyn" ? (int)a.Approach >= (int)ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 : true))
                {
                    recognizer.ConfigLeftVsRight((ChangeDetectionApproaches.NativeGTtreefiedRoslynML, "gumtree_Minh2Sim0d5Size1000"), (configuration.Approach, configuration.Name));

                    var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    recognizer.SqlRepository = dbRepository;
                    recognizer.Cancel = null;

                    Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair pair)
                    {
                        var anyOriginal = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FromFileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));
                        var anyModified = dbRepository.FileFormats.Any(ff => ff.FileVersion.Id == pair.Principal.FileVersion.Id && ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML));

                        return !anyOriginal || !anyModified;
                    };
                    //frp => dbRepository.Deltas.Any(d => d.RevisionPair.Id == frp.Id &&
                    //                                                             d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                    //                                                             d.OriginalTree != null && d.ModifiedTree != null);

                    recognizer.Config.GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) args)
                    {
                        var version = args.TrueForOriginalOtherwiseModified
                            ? dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FromFileVersion.Id)
                            : dbRepository.FileFormats.AsNoTracking().Single(ff => ff.Kind == (FileFormatKind.Gumtreefied | FileFormatKind.RoslynML) && ff.FileVersion.Id == args.Pair.Principal.FileVersion.Id);

                        var xTree = XElement.Load(new StringReader(version.XmlTree));
                        var roslynMLServices = new RoslynML();
                        xTree = roslynMLServices.Gumtreefy(xTree);
                        roslynMLServices.SetRoslynMLIDs(xTree);

                        return roslynMLServices.AsGumtreefiedElementTree(xTree);
                    };

                    recognizer.Warnings = new StringBuilder();
                    recognizer.Recognize(skipThese, true);
                    System.IO.File.AppendAllText($@"D:\ExperimentLogs\gumtree_Minh2Sim0d5Size1000_VS_{configuration.Name}.txt",
                        $"{Environment.NewLine}{Environment.NewLine}Between comparison (recognition) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                        $"{Environment.NewLine}{recognizer.Warnings.ToString()}");

                    recognizer.Warnings = new StringBuilder();
                    recognizer.ConnectMatchSymptoms(skipThese, true);
                    System.IO.File.AppendAllText($@"D:\ExperimentLogs\gumtree_Minh2Sim0d5Size1000_VS_{configuration.Name}.txt",
                        $"{Environment.NewLine}{Environment.NewLine}Between comparison (structuring) completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                        $"{Environment.NewLine}{recognizer.Warnings.ToString()}");

                    //analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);

                }

                //var connection = System.Configuration.ConfigurationManager.ConnectionStrings[project.Name];
                //var connectionString = connection.ConnectionString.Replace("res://*/GitRepository", ".\\GitRepository");
                

            }
            Console.Out.WriteLine($"Change Distiller vs. GumTree - matches collected!!!");
        }

        private static void DetectingNativeGumTreeWithGumtreefiedRoslynML()
        {
            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var gumTreeApproach = ChangeDetectionApproaches.NativeGTtreefiedRoslynML;
            var interopArgs = new InteropArgs()
            {
                GumTreePath = @"E:\SourceCode\gtfiedroslynml27418",
                Original = @"E:\SourceCode\Original.cs",
                Modified = @"E:\SourceCode\Modified.cs"
            };            

            foreach (var project in Projects.Skip(23))
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                analyzer.Warnings = new StringBuilder();
                analyzer.SqlRepository = dbRepository;
                analyzer.Cancel = () => gumTree.Cancel();

                Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair frp)
                {
                    var originalFileSummary = dbRepository.FileContentSummaries.AsNoTracking().SingleOrDefault(d => d.FileVersion.Id == frp.Principal.FromFileVersion.Id);
                    var modifiedFileSummary = dbRepository.FileContentSummaries.AsNoTracking().SingleOrDefault(d => d.FileVersion.Id == frp.Principal.FileVersion.Id);
                    if (originalFileSummary.StatementLines > 3000 || modifiedFileSummary.StatementLines > 3000)
                        return true;

                    var nativeGumTreeDelta = dbRepository.Deltas.AsNoTracking().SingleOrDefault(d => d.RevisionPair.Id == frp.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTree);
                    if (nativeGumTreeDelta != null)
                        return nativeGumTreeDelta.Differencing != null ? ((DetectionResult)nativeGumTreeDelta.DetectionResult).Actions.Count < 6 : false;

                    return false/* !dbRepository.Deltas.Any(d => d.RevisionPair.Id == frp.Principal.Id && d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTree)*/;
                };

                analyzer.NativeGumTreeDiff(gumTree, interopArgs , gumTreeApproach, null, null);
                //analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);
                System.IO.File.AppendAllText($@"E:\SourceCode\GT_GumtreefiedRoslynML.txt", 
                    $"{Environment.NewLine}{Environment.NewLine}GumTreefied RoslynML completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                    $"{Environment.NewLine}{analyzer.Warnings.ToString()}");
            }
            Console.Out.WriteLine($"GumTree gumtreefied RoslynML collected!!!");
        }

        private static void DetectingInverseNativeGumTreeWithGumtreefiedRoslynML()
        {
            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var gumTreeApproach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynML;
            var interopArgs = new InteropArgs()
            {
                GumTreePath = @"C:\CDF\gtfiedroslynml27418",
                Original = @"C:\CDF\Original.cs",
                Modified = @"C:\CDF\Modified.cs"
            };

            foreach (var project in Projects)
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                analyzer.Warnings = new StringBuilder();
                analyzer.SqlRepository = dbRepository;
                analyzer.Cancel = () => gumTree.Cancel();

                Func<FileRevisionPair, bool> skipThese = delegate (FileRevisionPair frp)
                {
                    var originalFileSummary = dbRepository.FileContentSummaries.AsNoTracking().SingleOrDefault(d => d.FileVersion.Id == frp.Principal.FromFileVersion.Id);
                    var modifiedFileSummary = dbRepository.FileContentSummaries.AsNoTracking().SingleOrDefault(d => d.FileVersion.Id == frp.Principal.FileVersion.Id);
                    if (originalFileSummary.StatementLines > 3000 || modifiedFileSummary.StatementLines > 3000)
                        return true;

                    var nativeGumTreeDelta = dbRepository.Deltas.AsNoTracking().SingleOrDefault(d => d.RevisionPair.Id == frp.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTree);
                    if (nativeGumTreeDelta != null)
                        return nativeGumTreeDelta.Differencing != null ? ((DetectionResult)nativeGumTreeDelta.DetectionResult).Actions.Count < 6 : false;

                    return !dbRepository.Deltas.Any(d => d.RevisionPair.Id == frp.Principal.Id && d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTree);
                };

                //analyzer.NativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, null);
                analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, null, null);
                System.IO.File.AppendAllText($@"C:\CDF\IGT_GumtreefiedRoslynML.txt",
                    $"{Environment.NewLine}{Environment.NewLine}GumTreefied RoslynML completed {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}" +
                    $"{Environment.NewLine}{analyzer.Warnings.ToString()}");
            }
            Console.Out.WriteLine($"Inverse GumTree gumtreefied RoslynML collected!!!");
        }

        private static void ComparisonBetweenGumTreeAndReverseGumTree()
        {
            var recognizer = new BetweenComparison() { MillisecondsTimeout = 600000 };
            recognizer.ConfigGumTreeVsReversedGumTree();
            var connectionSettings = System.Configuration.ConfigurationManager.ConnectionStrings;

            foreach (var project in Projects.Skip(100))
            {
                //var connection = System.Configuration.ConfigurationManager.ConnectionStrings[project.Name];
                //var connectionString = connection.ConnectionString.Replace("res://*/GitRepository", ".\\GitRepository");
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                recognizer.SqlRepository = dbRepository;
                recognizer.Cancel = null;

                recognizer.Warnings = new StringBuilder();
                recognizer.Recognize();
                System.IO.File.WriteAllText($@"E:\SourceCode\BetweenComparison_GT_RGT_{project.Name}.txt", recognizer.Warnings.ToString());
            }
            Console.Out.WriteLine($"GumTree native collected!!!");
        }


        private static void DetectingNotRealSourceCodeChanges()
        {
            FileModifiedChangeAnalyzer analyzer = new FileModifiedChangeAnalyzer();
            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) {Name = project.Name};
                ((IObjectContextAdapter) dbRepository).ObjectContext.CommandTimeout = 180;
                analyzer.AnalyzeIfThereAreSourceCodeChanges(dbRepository, null);

                System.IO.File.WriteAllText($@"E:\Repositories\DetectingNonSourceChanges{project.Name}.txt",
                    analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"Report collected!!!");
        }

        private static void DetectingOnlyCommentChanges()
        {
            FileModifiedChangeAnalyzer analyzer = new FileModifiedChangeAnalyzer();
            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
                analyzer.AnalyzeIfThereAreOnlyCommentChanges(dbRepository, null);

                System.IO.File.WriteAllText($@"E:\Repositories\DetectingOnlyCommentChanges{project.Name}.txt",
                    analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"Report collected!!!");
        }

        private static void DetectingLevenshteinDiff(string simetricName, Expression<Func<FileModifiedChange, bool>> onThese, Func<FileModifiedChange, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileModifiedChangeAnalyzer { MillisecondsTimeout = 600000 };
            var levenshteinSimetric = new LevenshteinSimetric<SyntaxToken> { AreEqual = new SyntaxTokenEqualityComparer().Equals };
            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                analyzer.SimetricDiff(dbRepository, simetricName, levenshteinSimetric, null, skipThese, onThese, cleaner);

                //System.IO.File.WriteAllText($@"E:\Repositories\DetectingLevenshteinWithoutCommentsDiff{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"Report collected!!!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void DetectingNativeGumTreeDiff(ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = @"C:\CDF\gumtree-20170525-2.1.0-SNAPSHOT",
                Original = @"C:\CDF\Original.cs",
                Modified = @"C:\CDF\Modified.cs"
            };

            foreach (var project in Projects)
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                analyzer.Warnings = new StringBuilder();
                analyzer.SqlRepository = dbRepository;
                analyzer.Cancel = () => gumTree.Cancel();
                
                //analyzer.NativeGumTreeDiff(gumTree, interopArgs , gumTreeApproach, skipThese, cleaner);
                //analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);

                System.IO.File.WriteAllText($@"C:\CDF\InverseOfNativeGumTreeDiff{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"GumTree native collected!!!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void MigrateRoslynMLTreesOfNativeGumTree(ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new NativeGumTreeCollector { MillisecondsTimeout = 300000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = null,
                Original = @"E:\SourceCode\O01.cs",//@"C:\CDF\O01.cs",
                Modified = @"E:\SourceCode\M02.cs"
            };

            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                analyzer.SqlRepository = dbRepository;
                analyzer.MigrateRoslynMLTrees(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner);

                //System.IO.File.WriteAllText($@"E:\Phd\Analysis\SaveNativeTrees33{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void SaveRoslynMLTreesOfNativeGumTree(ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new NativeGumTreeCollector { MillisecondsTimeout = 300000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = null,
                Original = @"E:\SourceCode\O01.cs",//@"C:\CDF\O01.cs",
                Modified = @"E:\SourceCode\M02.cs"
            };

            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                analyzer.SqlRepository = dbRepository;
                analyzer.SaveRoslynMLTrees(gumTree, interopArgs, gumTreeApproach, skipThese, FileFormatKind.Gumtreefied | FileFormatKind.RoslynML, cleaner);

                //System.IO.File.WriteAllText($@"E:\Phd\Analysis\SaveNativeTrees33{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void SaveNativeTreesOfNativeGumTree(ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 300000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                //GumTreePath = @"C:\CDF\gumtree-20170525-2.1.0-SNAPSHOT",
                //Original = @"C:\CDF\Original.cs",
                //Modified = @"C:\CDF\Modified.cs"
            };

            foreach (var project in Projects.Skip(84)/*.Take(15)*/)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                analyzer.SqlRepository = dbRepository;
                analyzer.SaveNativeTrees(gumTree, interopArgs, gumTreeApproach, skipThese, cleaner, true);

                System.IO.File.WriteAllText($@"E:\Phd\Analysis\SaveNativeTrees33{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        /// <summary>
        /// Collects left-right and right-left (i.e., inverse) deltas produced by the native gumtree using the change distiller matcher.
        /// </summary>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void DetectingNativeGumTreeDiffWithCustomMatchers(Func<FileRevisionPair, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                GumTreePath = @"E:\SourceCode\gt19218",
                Original = @"E:\SourceCode\Original.cs",
                Modified = @"E:\SourceCode\Modified.cs"
            };

            foreach (var project in Projects.Reverse().Take(44)/*.Reverse().Skip(27)*/)
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                analyzer.SqlRepository = dbRepository;
                analyzer.Cancel = () => gumTree.Cancel();

                interopArgs.Options = "-m change-distiller";
                analyzer.Warnings = new StringBuilder();
                analyzer.NativeGumTreeDiff(gumTree, interopArgs, ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher,
                    skipThese, cleaner);
                System.IO.File.WriteAllText($@"E:\SourceCode\GT_CD_LRDeltas{project.Name}.txt", analyzer.Warnings.ToString());

                analyzer.Warnings = new StringBuilder();
                analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, ChangeDetectionApproaches.InverseOfNativeGumTreeWithChangeDistillerMatcher,
                    skipThese, cleaner);
                System.IO.File.WriteAllText($@"E:\SourceCode\GT_CD_RLDeltas{project.Name}.txt", analyzer.Warnings.ToString());

                interopArgs.Options = "-m xy";
                analyzer.Warnings = new StringBuilder();
                analyzer.NativeGumTreeDiff(gumTree, interopArgs, ChangeDetectionApproaches.NativeGumTreeWithXyMatcher,
                    skipThese, cleaner);
                System.IO.File.WriteAllText($@"E:\SourceCode\GT_XY_LRDeltas{project.Name}.txt", analyzer.Warnings.ToString());

                analyzer.Warnings = new StringBuilder();
                analyzer.InverseNativeGumTreeDiff(gumTree, interopArgs, ChangeDetectionApproaches.InverseOfNativeGumTreeWithXyMatcher,
                    skipThese, cleaner);
                System.IO.File.WriteAllText($@"E:\SourceCode\GT_XY_RLDeltas{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"GumTree native collected!!!");
        }

        private static void ReportGumTreeAndLevenshtein(Func<FileModifiedChange, bool> filter, string postfix, ChangeDetectionApproaches gumTreeVariant, string levenshteinVariant, EditDistance<ActionDescriptor> editDistance)
        {
            var report = new StringBuilder();
            int nonExisting = 0;

            var header = "Project;RevisionPair;GtD;LvD;LvS;LvGt;GtLv;ScoreGtImprovedLv;iGtLv";
            report.AppendLine(header);
            System.IO.File.AppendAllText($@"E:\Phd\Analysis\UniquePairs\GumTreeLevenshtein{postfix ?? ""}.csv", report.ToString());
            report.Clear();

            var numberFormatInfo = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
            foreach (var project in Projects)
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                var fileModifiedChanges = from frp in dbRepository.FileRevisionPairs.AsNoTracking()
                    where frp.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.Simetrics && d.Annotations != null) &&
                          frp.Principal.Deltas.Any(d => d.Approach == gumTreeVariant && d.Report == null && 
                          d.Matching != null && d.Differencing != null)
                    select frp.Principal;
                var revisionPairs = from rp in fileModifiedChanges
                    select new
                    {
                        rp,
                        Levenstein = rp.Deltas.Where(d => d.Approach == ChangeDetectionApproaches.Simetrics),
                        NativeGumTree = rp.Deltas.Where(d => d.Approach == gumTreeVariant),
                        //GumTreeWithoutComments = rp.Deltas.Where(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithoutComments)
                    };

                int counter = 0;
                var items = new Tuple<string,string, double, Tuple<double, double>, double, double, Tuple<int,int>>[fileModifiedChanges.Count()];
                foreach (var rp in revisionPairs)
                {
                    if (filter?.Invoke(rp.rp) ?? true)
                    {
                        var lv = rp.Levenstein.Single(d => d.Approach == ChangeDetectionApproaches.Simetrics).XAnnotations.Simetrics.SingleOrDefault(d => d.Name == levenshteinVariant);
                        var gt = (DetectionResult)rp.NativeGumTree.Single(d => d.Approach == gumTreeVariant).DetectionResult;
                        if (lv == null)
                        {
                            nonExisting++;
                            continue;
                        }

                        var gtDistance = editDistance.Compute(gt.Actions);
                        items[counter] = new Tuple<string, string, double, Tuple<double, double>, double, double, Tuple<int, int>>(
                            project.Name, // Item1
                            rp.rp.Id.ToString("D"), // Item2 
                            gtDistance,  // Item3
                            new Tuple<double, double>(lv.Distance, Math.Round(lv.Similarity, 4)), // Item4
                            Math.Round(lv.Distance / gtDistance, 4), // Item5
                            Math.Round(gtDistance / lv.Distance, 4), // Item6
                            new Tuple<int, int>(0,0) // Item7
                        );
                    }

                    Console.WriteLine($"Collecting {++counter}-({items.Length}) of {project.Name}, {nonExisting}-skipped");
                }

                items = items.Where(it => it != null).ToArray();

                // Computing GumTree and Levenshtein indexes.
                Console.WriteLine($"Computing indexes of {project.Name}");
                var gtOrdering = items.OrderBy(i => i.Item3).ToList();
                var lvOrdering = items.OrderBy(i => i.Item4.Item1).ToList();
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = new Tuple<string, string, double, Tuple<double, double>, double, double, Tuple<int, int>>
                        (
                            items[i].Item1,
                            items[i].Item2,
                            items[i].Item3,
                            items[i].Item4,
                            items[i].Item5,
                            items[i].Item6,
                            new Tuple<int, int>(gtOrdering.IndexOf(items[i]) + 1, lvOrdering.IndexOf(items[i]) + 1)
                        );
                }

                Console.WriteLine($"Generating the report of {project.Name}");
                foreach (var item in items)
                {
                    report.AppendLine($"{item.Item1};" +
                                      $"{item.Item2};" +
                                      $"{item.Item3};" +
                                      $"{item.Item4.Item1.ToString(numberFormatInfo)};" +
                                      $"{item.Item4.Item2.ToString(numberFormatInfo)};" +
                                      $"{item.Item5.ToString(numberFormatInfo)};" +
                                      $"{item.Item6.ToString(numberFormatInfo)};" +
                                      $"{(item.Item3 < item.Item4.Item1 ? 1 : 0) - (item.Item3 > item.Item4.Item1 ? 1 : 0)};" +
                                      $"{Math.Abs(item.Item7.Item1 - item.Item7.Item2)}");
                }

                //System.IO.File.WriteAllText($@"{Environment.CurrentDirectory}\GumTreeLevenshtein{project.Name}{postfix ?? ""}.csv", header + Environment.NewLine + report);
                System.IO.File.AppendAllText($@"E:\Phd\Analysis\UniquePairs\GumTreeLevenshtein{postfix ?? ""}.csv", report.ToString());

                report.Clear();
            }
            Console.Out.WriteLine($"Report done!!!");
        }

        ///// <summary>
        ///// Inspecting revision pairs.
        ///// </summary>
        ///// <param name="revisionPairsCsvPath">file path of the CSV containing the revision pairs of interest.</param>
        ///// <param name="originalFilePath">file path where store the original source code.</param>
        ///// <param name="modifiedFilePath">file path where store the modified source code.</param>
        ///// <param name="currentReview"></param>
        //private static void ReviewRevisionPairs(string revisionPairsCsvPath, string originalFilePath, string modifiedFilePath, string currentReview, SourceCodeCleaner cleaner = null)
        //{
        //    string[] lines = System.IO.File.ReadAllLines(revisionPairsCsvPath);
        //    var loader = new RevisionPairReview();

        //    foreach (var line in lines.Skip(1))
        //    {
        //        string[] values = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //        values = values.Select(d => d.Trim('"')).ToArray();

        //        var project = Projects.Single(p => p.Name == values[0].Trim('"'));
        //        var gumTree = new GumTreeNativeApproach();
        //        var interopArgs = new InteropArgs { Original = originalFilePath, Modified  = modifiedFilePath };
        //        using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
        //        {
        //            ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
        //            var guid = Guid.Parse(values[1]);
        //            ReviewRevisionPair(originalFilePath, modifiedFilePath, currentReview, cleaner, loader, dbRepository, guid);
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        private static void DetectingNativeGumTreeAndLevenshteinDiffByMethods(ChangeDetectionApproaches gumTreeApproach, string simetricName, Func<FileModifiedChange, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileModifiedChangeAnalyzer { MillisecondsTimeout = int.MaxValue };
            var gumTree = new GumTreeNativeApproach();
            var levenshteinSimetric = new LevenshteinSimetric<SyntaxToken> { AreEqual = new SyntaxTokenEqualityComparer().Equals };

            var interopArgs = new InteropArgs()
            {
                //GumTreePath = @"C:\CDF\gumtree-20170525-2.1.0-SNAPSHOT",
                //Original = @"C:\CDF\Original.cs",
                //Modified = @"C:\CDF\Modified.cs"
            };

            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = int.MaxValue;
                analyzer.NativeGumTreeAndSimetricDiffByMethods(dbRepository, gumTree, simetricName, levenshteinSimetric, interopArgs, () => gumTree.Cancel(), gumTreeApproach, skipThese, cleaner);

                //System.IO.File.WriteAllText($@"C:\CDF\NativeGumTreeDiff{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"GumTree native collected!!!");
        }

        /// <summary>
        /// Inspecting revision pairs.
        /// </summary>
        /// <param name="originalFilePath">file path where store the original source code.</param>
        /// <param name="modifiedFilePath">file path where store the modified source code.</param>
        /// <param name="currentReview"></param>
        private static void ReviewRevisionPairs2(string originalFilePath, string modifiedFilePath, ReviewKind currentReview, Action<string, string, ReviewKind, SourceCodeCleaner, RevisionPairReview, GitRepository, Guid> action, SourceCodeCleaner cleaner = null)
        {
            //Action<string, string, ReviewKind, SourceCodeCleaner, RevisionPairReview, GitRepository, Guid> action;
            while (true)
            {
                var loader = new RevisionPairReview();

                var project = Projects.Single(p => p.Name == "AkkaNET");
                var gumTree = new GumTreeNativeApproach();
                var interopArgs = new InteropArgs { Original = originalFilePath, Modified = modifiedFilePath };
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
                    //var guid = Guid.Parse("cd6881d7-a572-46cc-9a92-bdea3c808694");
                    var guid = Guid.Parse("DC10379D-0EC1-4B3B-90C5-9452E98BE479");
                    action(originalFilePath, modifiedFilePath, currentReview, cleaner, loader, dbRepository, guid);
                    //ReviewRevisionPair(originalFilePath, modifiedFilePath, currentReview, cleaner, loader, dbRepository, guid);
                }
            }
        }

        private static void ReviewRevisionPair(string originalFilePath, string modifiedFilePath, ReviewKind currentReview,
            SourceCodeCleaner cleaner, RevisionPairReview loader, GitRepository dbRepository, Guid guid)
        {
            var revisionPair = dbRepository.FileRevisionPairs
                .Include(frp => frp.Principal.FileVersion.Content)
                .Include(frp => frp.Principal.FromFileVersion.Content)
                //.Include(frp => frp.Reviews)
                .Single(frp => frp.Principal.Id == guid);

            var original = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            var modified = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

            var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
            var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
            System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
            System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

            if (revisionPair.Reviews.Count > 0)
                ;
            //var gtOutput = gumTree.ExecuteCommand(interopArgs, " ", $"gumtree.bat jsondiff {interopArgs.Original} {interopArgs.Modified}", " ");
            ;

            foreach (var review in revisionPair.Reviews)
            {
                
            }

            //dbRepository.Flush();
        }

        private static void ReviewMissedMatches(string originalFilePath, string modifiedFilePath, ReviewKind currentReview,
            SourceCodeCleaner cleaner, RevisionPairReview loader, GitRepository dbRepository, Guid guid)
        {
            var revisionPair = dbRepository.FileRevisionPairs
                .Include(frp => frp.Principal.FileVersion.Content)
                .Include(frp => frp.Principal.FromFileVersion.Content)
                .Include(frp => frp.Reviews)
                .Single(frp => frp.Principal.Id == guid);

            var original = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            var modified = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

            var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
            var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
            System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
            System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

            if (revisionPair.Reviews.Count > 0)
                ;
            //var gtOutput = gumTree.ExecuteCommand(interopArgs, " ", $"gumtree.bat jsondiff {interopArgs.Original} {interopArgs.Modified}", " ");
            ;

            revisionPair.Reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                CaseKind = CaseKind.MissedMatchesM,
                Severity = ReviewSeverity.Bad,
                Subject = "Bad matches - the properties \"Toolbar\"-(ol:45) and \"ToolbarButtons\"-(ml:53) should not match.",
                Comments = "\"Toolbar\"-(ol:45) should match with \"Toolbar\"-(ml:73)" + Environment.NewLine +
                           "\"ToolbarButtons\"-(ol:53) was inserted",
                Kind = currentReview,
                Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            });
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesM,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Missed matches - the functions \"Index\"-(ol:35) and \"Index\"-(ml:16) should match.",
            //    Comments = null,
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});

            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesMI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the functions \"trigger\"-(ol:92) and \"asyncTrigger\"-(ml:92) should not match.",
            //    Comments = "\"trigger\"-(ol:92) should match with \"trigger\"-(ml:91)" + Environment.NewLine +
            //               "\"asyncTrigger\"-(ol:92) was inserted",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});

            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDM,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the formal argument \"t\"-(ol:89) and the variable \"typeFullName\"-(ml:78) should not match.",
            //    Comments = "\"typeFullName\"-(ol:97) should match with \"typeFullName\"-(ml:78)" + Environment.NewLine +
            //               "(ol:89) was deleted",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});


            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesUU,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the variables \"stylesDir\"-(ol:21) and \"samplesStylesDir\"-(ml:23) should not match.",
            //    Comments = "\"stylesDir\"-(ol:21) should match with \"stylesDir\"-(ml:19)" + Environment.NewLine +
            //               "\"samplesStylesDir\"-(ol:27) should match with \"fileContents\"-(ml:29)",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesUI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the functions \"OnInit\"-(ol:232) and \"AreFileUploadParamsPresent\"-(ml:250) should not match.",
            //    Comments = "\"OnInit\"-(ol:232) should match with \"OnInit\"-(ml:232)" + Environment.NewLine +
            //               "\"AreFileUploadParamsPresent\"-(ol:250) was inserted",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesUI,
            //    Severity = ReviewSeverity.Good,
            //    Subject = "False alarm, BUT - the variables \"dataOptions\"-(ol:61) and \"dataOptions\"-(ml:103) should not match.",
            //    Comments = "BUT - the variables \"dataOptions\"-(ol:61) and \"dataOptions\"-(ml:42) should match.",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});

            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDU,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Missed matches - the fields \"ContextKey\"-(ol:66) \"ContextKey\"-(ml:51) should match.",
            //    Comments = null,
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDU,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the functions \"EnsureScripts\"-(ol:281) and \"GetScriptReferences\"-(ml:271) should not match.",
            //    Comments = "\"GetScriptReferences\"-(ol:271) should match with \"GetScriptReferences\"-(ml:271)" + Environment.NewLine +
            //               "\"EnsureScripts\"-(ol:281) was deleted",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDU,
            //    Severity = ReviewSeverity.Good,
            //    Subject = "False alarm, BUT - the variables \"dataOptions\"-(ol:61) and \"dataOptions\"-(ml:103) should not match.",
            //    Comments = "BUT - the variables \"dataOptions\"-(ol:61) and \"dataOptions\"-(ml:42) should match.",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});


            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the methods \"Type\"-(ol:94) \"FillClientMembers\"-(ml:120) should not match.",
            //    Comments = "the functions \"Type\"-(ol:94) \"Type\"-(ml:95) should match" + Environment.NewLine +
            //               "Part of the method \"Type\"-(ol:94) was refactored into a new method \"FillClientMembers)\"-(ml:120)",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Missed matches - the variables \"dataOptions\"-(ol:31) \"dataOptions\"-(ml:43) should match.",
            //    Comments = null,
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDI,
            //    Severity = ReviewSeverity.Good,
            //    Subject = "False alarm - the variable \"typeFullName\"-(ol:97) and the formal argument \"typeFullName\"-(ml:107) should not match (but refers to a same conceptual element...).",
            //    Comments = null,
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "False alarm, BUT - the variable \"typeFullName\"-(ol:97) and the formal argument \"typeFullName\"-(ml:107) should not match (but refers to a same conceptual element...).",
            //    Comments = "NONETHELESS, the variables \"typeFullName\"-(ol:97) and \"typeFullName\"-(ml:78) should match" + Environment.NewLine +
            //               "BUT, the formal argument \"t\"-(ol:89) and the variable \"typeFullName\"-(ml:78) should not match",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesDU,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the fields \"TempDirectory\"-(ol:67) \"ContextKey\"-(ml:51) should not match.",
            //    Comments = "\"TempDirectory\"-(ol:67) should match with \"ContextKey\"-(ml:51)",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});
            //revisionPair.Reviews.Add(new Review
            //{
            //    Id = Guid.NewGuid(),
            //    CaseKind = CaseKind.MissedMatchesUI,
            //    Severity = ReviewSeverity.Bad,
            //    Subject = "Bad matches - the fields \"TempDirectory\"-(ol:67) \"ContextKey\"-(ml:51) should not match.",
            //    Comments = "\"TempDirectory\"-(ol:67) should match with \"ContextKey\"-(ml:51)",
            //    Kind = currentReview,
            //    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
            //});

            dbRepository.Flush();
        }

        /// <summary>
        /// Deploys the file revision pairs and their relation with the conceptual file.
        /// </summary> 
        public static void DeployFileRevisionPairs()
        {
            var deployer = new FromLocalGitToSqlDbDeployment();
            foreach (var project in Projects)
            {
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
                deployer.DeployFileRevisionPairs(dbRepository);

                Console.Out.WriteLine($@"File revision pairs deployed for {project.Name}");
            }
            Console.Out.WriteLine($"GumTree native collected!!!");
        }

        /// <summary>
        /// Checks some concerns about the file revision pairs, such as the fact that the principal contains all the required information.
        /// </summary> 
        public static void CheckFileRevisionPairs()
        {
            var deployer = new FromLocalGitToSqlDbDeployment();
            foreach (var project in Projects)
            {
                deployer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 60000;
                deployer.CheckFileRevisionPairs(dbRepository);

                if(deployer.Warnings.Length > 0)
                    System.IO.File.WriteAllText($@"E:\Troubles{project.Name}.txt", deployer.Warnings.ToString());
            }
           

            Console.Out.WriteLine($"GumTree native collected!!!");
        }

        /// <summary>
        /// Deploy the typed review notes for the new file revision pairs.
        /// </summary> 
        /// <param name="sqlRepository">the SQL database repository in which the initial deployment was done.</param>
        public static void DeployReviewsForFileRevisionPairs()
        {
            var deployer = new FromLocalGitToSqlDbDeployment();
            //foreach (var project in Projects.First())
            //{
            var project = Projects.First();
                deployer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
                deployer.DeployReviewsForFileRevisionPairs(dbRepository);
            //}
        }

        public static void ComplementDeltaInfos(ChangeDetectionApproaches gumTreeApproach, Func<FileModifiedChange, bool> skipThese = null, SourceCodeCleaner cleaner = null)
        {
            var analyzer = new FileModifiedChangeAnalyzer { MillisecondsTimeout = int.MaxValue };
            var gumTree = new GumTreeNativeApproach();
            var interopArgs = new InteropArgs()
            {
                //GumTreePath = @"C:\CDF\gumtree-20170525-2.1.0-SNAPSHOT",
                //Original = @"C:\CDF\Original.cs",
                //Modified = @"C:\CDF\Modified.cs"
            };

            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = int.MaxValue;
                analyzer.ComplementDeltaInfos(dbRepository, gumTree, interopArgs, () => gumTree.Cancel(), gumTreeApproach, skipThese, cleaner);

                //System.IO.File.WriteAllText($@"C:\CDF\NativeGumTreeDiff{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="approach"></param>
        //private static void ReportMissedMatchesAOfNamedElements(ChangeDetectionApproaches approach)
        //{
        //    var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
        //    var errorFilePath = $@"E:\Phd\Analysis\MissedMatchesAErrors.txt";
        //    foreach (var project in Projects)
        //    {
        //        //var reportFilePath = $@"E:\Phd\Analysis\MissedMatches{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}-{project.Name}.txt";
        //        //System.IO.File.AppendAllText(reportFilePath, 
        //        //    "Indicator;Project;FileRevisionPair;" +
        //        //    "Original;Modified;" +
        //        //    "OriginalType;ModifiedType;" +
        //        //    "OriginalReference;ModifiedReference;" +
        //        //    "OriginalPath;ModifiedPath" + Environment.NewLine);

        //        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
        //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

        //        analyzer.Warnings = new StringBuilder();
        //        analyzer.Report = new StringBuilder();
        //        analyzer.SaveMissedNames(dbRepository, () => {}, approach, pair => false);

        //        System.IO.File.AppendAllText(errorFilePath, analyzer.Warnings.ToString());
        //        System.IO.File.AppendAllText($@"E:\Phd\Analysis\MissedMatchesReportOfErrors.txt", analyzer.Report.ToString());
        //    }
        //    Console.Out.WriteLine($"DONE!!!");
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="approach"></param>
        //private static void ReportConfusingRenames(ChangeDetectionApproaches approach)
        //{
        //    var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
        //    var errorFilePath = $@"E:\Phd\Analysis\ConfusingRenames\Errors2.txt";
        //    foreach (var project in Projects)
        //    {
        //        //System.IO.File.AppendAllText($@"E:\Phd\Analysis\ConfusingRenames\{project.Name}.txt", 
        //        //    $"OriginalType;ModifiedType;OriginalName;ModifiedName;CoexistingOriginalName;Original;Modified;CoexistingOriginal;OriginalPath;ModifiedPath{Environment.NewLine}");

        //        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
        //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

        //        analyzer.Warnings = new StringBuilder();
        //        analyzer.Report = new StringBuilder();
        //        analyzer.SaveConfusingRenames(dbRepository, () => { }, approach, pair => false);

        //        System.IO.File.AppendAllText(errorFilePath, analyzer.Warnings.ToString());
        //        //System.IO.File.AppendAllText($@"E:\Phd\Analysis\ConfusingRenames\{project.Name}.txt", analyzer.Report.ToString());
        //    }
        //    Console.Out.WriteLine($"DONE!!!");
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="approach"></param>
        //private static void ReportMissedMatchesAOfKeyedElement(ChangeDetectionApproaches approach)
        //{
        //    var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
        //    var interopArgs = new InteropArgs()
        //    {
        //        //GumTreePath = @"C:\CDF\gumtree-20170525-2.1.0-SNAPSHOT",
        //        //Original = @"C:\CDF\Original.cs",
        //        //Modified = @"C:\CDF\Modified.cs"
        //    };

        //    Func<ElementTree, string> getName = tree => !string.IsNullOrEmpty(tree.Root.Value) &&
        //                                                !string.IsNullOrWhiteSpace(tree.Root.Value) &&
        //                                                tree.Root.Value != "##"
        //                                                ? $"{tree.Root.Label}({tree.Root.Value})"
        //                                                : tree.Root.Label;

        //    Func<ElementTree, string> getBreadcrum = delegate (ElementTree element)
        //    {
        //        string elementName = null;
        //        if (element.Root.Label == "block")
        //        {
        //            var blockOf = element.LabelOf(t => t.Parent, t => t.Root.Label == "block")
        //                                 .First(t => t.Root.Label != "block");

        //            elementName = blockOf.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
        //            return elementName != null
        //                ? $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label}-{elementName})"
        //                : $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label})";
        //        }

        //        elementName = element.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
        //        return elementName != null
        //            ? $"{element.Root.Label}:{element.Root.Id}({elementName})"
        //            : $"{element.Root.Label}:{element.Root.Id}";
        //    };


        //    Func<IEnumerable<ElementTree>, string> getPath = trees =>  trees.Aggregate("", (s, ancestor) => s != "" 
        //        ? $"{s}##{getBreadcrum(ancestor)}" 
        //        : getBreadcrum(ancestor));

        //   //int counter = 0;
        //    foreach (var project in Projects.Take(1))
        //    {
        //        System.IO.File.AppendAllText($@"E:\Phd\Analysis\MissedMatches{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}-{project.Name}.txt", //;InsertionScopes;DeletionScopes
        //       "Indicator;Project;FileRevisionPair;Original;Modified;OriginalType;ModifiedType;OriginalReference;ModifiedReference;OriginalPath;ModifiedPath" + Environment.NewLine);

        //        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
        //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
        //        try
        //        {
        //            analyzer.ForEach(dbRepository, project.Name, pair => pair.Principal.Deltas.Any(d => d.Approach == approach), delegate(FileRevisionPair pair)
        //            {
        //                analyzer.Warnings = new StringBuilder();

        //                    dbRepository.Deltas.Where(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach).Load();
        //                    var delta = pair.Principal.Deltas.Single(d => d.Approach == approach);
        //                    var missedMatchesA = analyzer.FindMissedMatchesAOfKeyedElement(delta);

        //                    foreach (var missedMatchA in missedMatchesA)
        //                    {
        //                        analyzer.Warnings.AppendLine($"{missedMatchA.Case};" +
        //                                                     $"{project.Name};" +
        //                                                     $"{pair.Principal.Id};" +
        //                                                     $"{missedMatchA.Original.Element.Root.Label}:{missedMatchA.Original.Element.Root.Id}({missedMatchA.Original.Element.Root.Value});" +
        //                                                     $"{missedMatchA.Modified.Element.Root.Label}:{missedMatchA.Modified.Element.Root.Id}({missedMatchA.Modified.Element.Root.Value});" +
        //                                                     $"{missedMatchA.Original.Type};" +
        //                                                     $"{missedMatchA.Modified.Type};" +
        //                                                     //$"{missedMatchA.Modified.MatchedReference.Root.Label}:{missedMatchA.Modified.MatchedReference.Root.Id}({missedMatchA.Modified.MatchedReference.Root.Value});" +
        //                                                     //$"{missedMatchA.Original.MatchedReference.Root.Label}:{missedMatchA.Original.MatchedReference.Root.Id}({missedMatchA.Original.MatchedReference.Root.Value});" +
        //                                                     $"{getBreadcrum(missedMatchA.Original.MatchedReference)};" +
        //                                                     $"{getBreadcrum(missedMatchA.Modified.MatchedReference)};" +
        //                                                     //$"{getPath(missedMatchA.Modified.Scopes)};" +
        //                                                     //$"{getPath(missedMatchA.Original.Scopes)};" +
        //                                                     $"{getPath(missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())};" +
        //                                                     $"{getPath(missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())}");
        //                   }

        //                    System.IO.File.AppendAllText($@"E:\Phd\Analysis\MissedMatches{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}-{project.Name}.txt", analyzer.Warnings.ToString());
        //            }, "Principal");
        //        }
        //        catch (OutOfMemoryException e)
        //        {
        //            System.IO.File.AppendAllText($@"E:\Phd\Analysis\MissedMatchesAErrors.txt", $"OOM;{project.Name}" + Environment.NewLine);
        //        }
        //        catch (Exception e)
        //        {
        //            System.IO.File.AppendAllText($@"E:\Phd\Analysis\MissedMatchesAErrors.txt", $"ERROR;{project.Name}" + Environment.NewLine);
        //        }
        //        //System.IO.File.AppendAllText($@"E:\Phd\Analysis\BadRenamesFor{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}.txt", analyzer.Warnings.ToString());
        //    }
        //    Console.Out.WriteLine($"DONE!!!");
        //}
    }
}
