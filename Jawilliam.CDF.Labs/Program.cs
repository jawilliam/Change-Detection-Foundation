using System;
using LibGit2Sharp;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Jawilliam.CDF.Similarity.Metrics;
using Microsoft.CodeAnalysis;

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
            new Project{ Path = @"E:\Repositories\albacore", Name = "Albacore" },
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
            new Project{ Path = @"E:\Repositories\hadoopsdk", Name = "HadoopSdk" },
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

            //#region Detecting not real source code changes
            //DetectingNotRealSourceCodeChanges();
            //#endregion

            #region Diff characterization in according to Levenshtein
            DetectingLevenshteinDiff();
            #endregion

            //int i = 0; // the warning reports!!!
            System.Console.ReadKey();
        }

        private static void DetectingNotRealSourceCodeChanges()
        {
            FileModifiedChangeAnalyzer analyzer = new FileModifiedChangeAnalyzer();
            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) {Name = project.Name};
                ((IObjectContextAdapter) dbRepository).ObjectContext.CommandTimeout = 180;
                analyzer.AnalyzeIfThereAreSourceCodeChanges(dbRepository);

                System.IO.File.WriteAllText($@"E:\Repositories\DetectingNonSourceChanges{project.Name}.txt",
                    analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"Report collected!!!");
        }

        private static void DetectingLevenshteinDiff()
        {
            var analyzer = new FileModifiedChangeAnalyzer { MillisecondsTimeout = 600000 };
            var levenshteinSimetric = new LevenshteinSimetric<SyntaxToken> { Comparer = new SyntaxTokenEqualityComparer() };

            foreach (var project in Projects)
            {
                analyzer.Warnings = new StringBuilder();
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;
                analyzer.SimetricDiff(dbRepository, "Levenshtein", levenshteinSimetric);

                System.IO.File.WriteAllText($@"E:\Repositories\DetectingLevenshteinDiff{project.Name}.txt", analyzer.Warnings.ToString());
            }
            Console.Out.WriteLine($"Report collected!!!");
        }
    }
}
