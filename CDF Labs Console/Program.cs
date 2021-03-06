﻿using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using Jawilliam.CDF.Approach.GumTree;
using System.Xml.Linq;

namespace CDF_Labs_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                    break;

                string[] command = (input ?? "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (command.Length == 0)
                {
                    Console.WriteLine("Specify a command.");
                }
                else
                {
                    switch (command[0])
                    {
                        case "RoslynML":
                            if (command.Length < 2)
                                Console.WriteLine("RoslynML command takes at least 1 argument.");
                            else
                                HandleRoslynMLCommand(command[1], command.Length > 2 ? command.Skip(2).ToArray() : null);
                            break;
                        case "BetweenComparison":
                            if (command.Length < 3)
                                Console.WriteLine("BetweenComparison command takes at least 2 arguments (information of interest and project name).");
                            else
                                HandleBetweenComparisonCommand(options: command.Skip(1).ToArray());
                            break;
                        case "GetFileRevisionPair":
                            if (command.Length != 4)
                                Console.WriteLine("GetFileRevisionPair command takes 3 arguments (-saveToPrefix='pathPrefix', PrincipalID of the file revision pair, and the project name).");
                            else
                                GetFileRevisionPairCommand(options: command.Skip(1).ToArray());
                            break;
                        case "SaveTrees":
                            if (command.Length < 7)
                                Console.WriteLine("SaveTrees command takes, at least, 6 arguments (Project name or ALL, original path, modified path, gumtree approach, file format kind, and prune selector, and optionally --IncludeTrivia).");
                            else
                                SaveTreesCommand(options: command.Skip(1).ToArray());
                            break;
                        default:
                            Console.WriteLine("Unknown command.");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the RoslynML command.
        /// </summary>
        /// <param name="fullPath">the full path from which loading the content.</param>
        private static void HandleRoslynMLCommand(string fullPath, params string[] options)
        {
            try
            {
                var loader = new RoslynML();
                var xElement = loader.Load(fullPath, true);

                var opts = options ?? new string[0];

                var pruningOpt = opts.FirstOrDefault(o => o.StartsWith("-pruning"));
                if (pruningOpt != null)
                {
                    string pruningType = pruningOpt?.Replace("-pruning=", "") ?? "";
                    Func<XElement, bool> pruneSelector = null;
                    switch (pruningType)
                    {
                        case "Basic":
                            var selector = new RoslynMLPruneSelector();
                            pruneSelector = e => selector.PruneSelector(e);
                            break;
                        default: throw new ArgumentException(pruningType);
                    }
                    loader.Prune(xElement, pruneSelector);
                }

                if (opts.Any(o => o == "-gumtreefy"))
                    xElement = loader.Gumtreefy(xElement);

                loader.SetRoslynMLIDs(xElement);
                loader.SetGumTreefiedIDs(xElement);

                var saveToFile = opts.SingleOrDefault(o => o.StartsWith("-saveToFile="));
                if (saveToFile != null)
                {
                    var path = saveToFile.Replace("-saveToFile=", "");
                    System.IO.File.WriteAllText(path, xElement.ToString());
                }
                else
                {
                    Console.WriteLine(xElement.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the BetweenComparison command.
        /// </summary>
        private static void HandleBetweenComparisonCommand(bool head = true, params string[] options)
        {
            string path = null;
            var lastOption = options.Last();
            if (lastOption.StartsWith("\\file="))
            {
                path = lastOption.Split(new[] { "\\file=" }, StringSplitOptions.RemoveEmptyEntries).Single();
            }
            int leftApproach, rightApproach;

            try
            {
                switch (options[0])
                {
                    case "statistics":
                        if (options.Length < 4)
                            throw new ApplicationException("statistics command requires, at leat, 3 arguments (project name, left approach , and right approach).");

                        ReadApproaches(options, out leftApproach, out rightApproach);
                        if (options[1] == "ALL")
                        {
                            bool header = true;
                            foreach (var p in Projects)
                            {
                                var pOptions = (string[])options.Clone();
                                pOptions[1] = p.Name;
                                HandleBetweenComparisonCommand(header, pOptions);
                                header = false;
                            }
                        }
                        else
                        {
                            using (var dbRepository = new GitRepository(options[1]) { Name = options[1] })
                            {
                                ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                                var recognizer = new BetweenComparison()
                                {
                                    MillisecondsTimeout = 600000,
                                    SqlRepository = dbRepository,
                                    Cancel = null
                                };
                                recognizer.ConfigForwardVsBackward(((ChangeDetectionApproaches)leftApproach, null), ((ChangeDetectionApproaches)rightApproach, null));
                                var output = recognizer.ReportBetweenMatches();

                                string line = null;
                                if (head)
                                {
                                    line = "Project;TotalFrps;" +
                                           "AffectedFrps(#LR);AffectedFrps(%LR);" +
                                           "AffectedFrps(#RL);AffectedFrps(%RL);" +
                                           "AffectedFrps(#ALL);AffectedFrps(%ALL);" +
                                           "Symptoms(LR);Symptoms(RL);Symptoms(ALL)";
                                    if (path == null)
                                        Console.WriteLine(line);
                                    else
                                        System.IO.File.AppendAllLines(path, new[] { line });
                                }

                                line = $"{output.Project};{output.TotalOfFileRevisionPairs};" +
                                    $"{output.TotalOfAffectedFileRevisionPairs.LR};{output.PercentageOfAffectedFileRevisionPairs.LR:F2};" +
                                    $"{output.TotalOfAffectedFileRevisionPairs.RL};{output.PercentageOfAffectedFileRevisionPairs.RL:F2};" +
                                    $"{output.TotalOfAffectedFileRevisionPairs.All};{output.PercentageOfAffectedFileRevisionPairs.All:F2};" +
                                    $"{output.TotalOfSymptoms.LR};{output.TotalOfSymptoms.RL};{output.TotalOfSymptoms.All}";
                                if (path == null)
                                    Console.WriteLine(line);
                                else
                                    System.IO.File.AppendAllLines(path, new[] { line });
                            }
                        }
                        break;

                    case "data":
                        using (var dbRepository = new GitRepository(options[1]) { Name = options[1] })
                        {
                            ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                            var recognizer = new BetweenComparison()
                            {
                                MillisecondsTimeout = 600000,
                                SqlRepository = dbRepository,
                                Cancel = null
                            };
                            ReadApproaches(options, out leftApproach, out rightApproach);
                            recognizer.ConfigForwardVsBackward(((ChangeDetectionApproaches)leftApproach, null), ((ChangeDetectionApproaches)rightApproach, null));
                            recognizer.ReportData();
                            System.IO.File.AppendAllText(path, recognizer.Report.ToString());
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ReadApproaches(string[] options, out int leftApproach, out int rightApproach)
        {
            try { leftApproach = int.Parse(options[2], CultureInfo.InvariantCulture); } catch (Exception) { throw new ApplicationException("Bad left approach."); }
            try { rightApproach = int.Parse(options[3], CultureInfo.InvariantCulture); } catch (Exception) { throw new ApplicationException("Bad right approach."); }
        }

        /// <summary>
        /// Handles the GetFileRevisionPair command.
        /// </summary>
        private static void GetFileRevisionPairCommand(params string[] options)
        {
            try
            {
                var option = options[0];
                if (option.StartsWith("-saveToPrefix="))
                {
                    var path = option.Replace("-saveToPrefix=", "");

                    Guid principalID;
                    try
                    {
                        principalID = Guid.Parse(options[1]);
                    }
                    catch (Exception) { throw new ApplicationException("Error parsing the PrincipalID Guid."); }

                    using (var dbRepository = new GitRepository(options[2]) { Name = options[2] })
                    {
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 180;

                        var revisionPair = dbRepository.FileRevisionPairs.Include(frp => frp.Principal.FileVersion.Content)
                                                                         .Include(frp => frp.Principal.FromFileVersion.Content)
                                                                         .Single(frp => frp.Principal.Id == principalID);

                        var original = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                        var modified = SyntaxFactory.ParseCompilationUnit(revisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

                        //var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                        //var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                        System.IO.File.WriteAllText($"{path}Original.cs", original.ToFullString(), Encoding.Default);
                        System.IO.File.WriteAllText($"{path}Modified.cs", modified.ToFullString(), Encoding.Default);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the GetFileRevisionPair command.
        /// </summary>
        /// <remarks>e.g., SaveTrees ALL E:\SourceCode\O01.cs E:\SourceCode\M02.cs 10 13 Basic</remarks>
        private static void SaveTreesCommand(params string[] options)
        {
            Func<XElement, bool> pruneSelector = null;
            switch (options[5])
            {
                case "Basic":
                    var selector = new RoslynMLPruneSelector();
                    pruneSelector = e => selector.PruneSelector(e);
                    break;
                default: throw new ArgumentException(options[5]);
            }
            var Info = new Func<string[], (string ProjectName, 
                                           string Original, 
                                           string Modified, 
                                           ChangeDetectionApproaches GumTreeApproach,
                                           FileFormatKind FileFormatKind,
                                           Func<XElement, bool> PruneSelector, 
                                           bool IncludeTrivia)> (
                o => (o[0], o[1], o[2],
                      (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), o[3]),
                      (FileFormatKind)Enum.Parse(typeof(FileFormatKind), o[4]), pruneSelector,
                      o.Any(o1 => o1 == "--IncludeTrivia"))
            );

            var info = Info(options);
            try
            {
                var analyzer = new NativeGumTreeCollector { MillisecondsTimeout = 300000 };
                var gumTree = new GumTreeNativeApproach();
                if (info.ProjectName == "ALL")
                {
                    foreach (var p in Projects)
                    {
                        var pOptions = (string[])options.Clone();
                        pOptions[0] = p.Name;
                        SaveProjectTreesCommand(p, analyzer, gumTree, Info(pOptions));
                    }
                }
                else
                {
                    SaveProjectTreesCommand(Projects.Single(p => p.Name == info.ProjectName), analyzer, gumTree, Info(options));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the GetFileRevisionPair command.
        /// </summary>
        private static void SaveProjectTreesCommand((string Path, string Name) project, NativeGumTreeCollector analyzer, GumTreeNativeApproach gumTree, 
          (string ProjectName, string Original, string Modified, 
           ChangeDetectionApproaches GumTreeApproach, FileFormatKind FileFormatKind, Func<XElement, bool> PruneSelector, bool IncludeTrivia) info)
        {
            var interopArgs = new InteropArgs() { GumTreePath = null, Original = info.Original, Modified = info.Modified };
            try
            {
                analyzer.Warnings = new StringBuilder();
                using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
                {
                    ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600000;
                    analyzer.SqlRepository = dbRepository;
                    analyzer.SaveRoslynMLTrees(gumTree, interopArgs, info.GumTreeApproach, 
                                               null, info.FileFormatKind, null, info.PruneSelector,
                                               info.IncludeTrivia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns the project information.
        /// </summary>
        public static IEnumerable<(string Path, string Name)> Projects => new[]
        {
            (@"E:\Repositories\AjaxControlToolkit", "AjaxControlToolkit" ),
            (@"E:\Repositories\akka.net", "AkkaNET"),
            (@"E:\Repositories\allReady", "AllReady"),
            (@"E:\Repositories\ApplicationInsights-dotnet-server", "ApplicationInsightsDotnetServer"),
            (@"E:\Repositories\aspnetwebstack", "AspnetWebStack"),
            (@"E:\Repositories\AutoFixture", "AutoFixture"),
            (@"E:\Repositories\AutoMapper", "AutoMapper"),
            (@"E:\Repositories\Avalonia", "Avalonia"),
            (@"E:\Repositories\azure-powershell", "AzurePowershell"),
            (@"E:\Repositories\azure-sdk-for-net", "AzureSdkForNet"),
            (@"E:\Repositories\azure-webjobs-sdk", "AzureWebJobsSdk"),
            (@"E:\Repositories\BenchmarkDotNet", "BenchmarkDotNet"),
            (@"E:\Repositories\BotBuilder", "BotBuilder"),
            (@"E:\Repositories\Bridge", "BridgeNET"),
            (@"E:\Repositories\buildtools", "Buildtools"),
            (@"E:\Repositories\BusinessPlatformApps", "BusinessPlatformApps"),
            (@"E:\Repositories\cake", "Cake"),
            (@"E:\Repositories\cecil", "Cecil"),
            (@"E:\Repositories\CefSharp", "CefSharp"),
            (@"E:\Repositories\choco", "Choco"),
            (@"E:\Repositories\cli", "Cli"),
            (@"E:\Repositories\code-cracker", "CodeCracker"),
            (@"E:\Repositories\coreclr", "CoreClr"),
            (@"E:\Repositories\corefx", "CoreFx"),
            (@"E:\Repositories\corert", "Corert"),
            (@"E:\Repositories\couchbase-lite-net", "CouchbaseLiteNet"),
            (@"E:\Repositories\dafny", "Dafny"),
            (@"E:\Repositories\Dapper", "Dapper"),
            (@"E:\Repositories\Dnn.Platform", "Dnn"),
            (@"E:\Repositories\docfx", "Docfx"),
            (@"E:\Repositories\DotNetOpenAuth", "DotNetOpenAuth"),
            (@"E:\Repositories\duality", "Duality"),
            (@"E:\Repositories\elasticsearch-net", "ElasticsearchNet"),
            (@"E:\Repositories\Emby", "Emby"),
            (@"E:\Repositories\EntityFramework", "Ef7"),
            (@"E:\Repositories\FakeItEasy", "FakeItEasy"),
            (@"E:\Repositories\FileHelpers", "FileHelpers"),
            (@"E:\Repositories\Force.com-Toolkit-for-NET", "ForcecomToolkitForNET"),
            (@"E:\Repositories\Hangfire", "Hangfire"),
            (@"E:\Repositories\Hearthstone-Deck-Tracker", "HDT"),
            (@"E:\Repositories\Humanizer", "Humanizer"),
            (@"E:\Repositories\IdentityManager", "IdentityManager"),
            (@"E:\Repositories\IdentityServer3", "IdentityServer3"),
            (@"E:\Repositories\ILSpy", "ILSpy"),
            (@"E:\Repositories\ImageProcessor", "ImageProcessor"),
            (@"E:\Repositories\katanaproject", "Katana"),
            (@"E:\Repositories\KestrelHttpServer", "KestrelHttpServer"),
            (@"E:\Repositories\kudu", "Kudu"),
            (@"E:\Repositories\libgit2sharp", "Libgit2sharp"),
            (@"E:\Repositories\MahApps.Metro", "MahAppsMetro"),
            (@"E:\Repositories\MailKit", "MailKit"),
            (@"E:\Repositories\Marten", "Marten"),
            (@"E:\Repositories\MimeKit", "MimeKit"),
            (@"E:\Repositories\mobile-center-sdk-dotnet", "MobileCenterSdkDotnet"),
            (@"E:\Repositories\MoneyFox", "MoneyFox"),
            (@"E:\Repositories\mono", "mono"),
            (@"E:\Repositories\MonoGame", "MonoGame"),
            (@"E:\Repositories\msbuild", "Msbuild"),
            (@"E:\Repositories\MvvmCross", "MvvmCross"),
            (@"E:\Repositories\Nancy", "Nancy"),
            (@"E:\Repositories\netmf-interpreter", "NetmfInterpreter"),
            (@"E:\Repositories\Newtonsoft.Json", "NewtonsoftJson"),
            (@"E:\Repositories\nhibernate-core", "NhibernateCore"),
            (@"E:\Repositories\NLog", "NLog"),
            (@"E:\Repositories\nodejstools", "Nodejstools"),
            (@"E:\Repositories\npgsql", "Npgsql"),
            (@"E:\Repositories\NuGet.Client", "NuGetClient"),
            (@"E:\Repositories\NuGetGallery", "NuGetGallery"),
            (@"E:\Repositories\OpenRA", "OpenRA"),
            (@"E:\Repositories\Open-XML-SDK", "OpenXmlSdk"),
            (@"E:\Repositories\OptiKey", "OptiKey"),
            (@"E:\Repositories\Orchard", "Orchard"),
            (@"E:\Repositories\orleans", "Orleans"),
            (@"E:\Repositories\pickles", "Pickles"),
            (@"E:\Repositories\PnP-PowerShell", "PnPPowerShell"),
            (@"E:\Repositories\Polly", "Polly"),
            (@"E:\Repositories\PowerShell", "PowerShell"),
            (@"E:\Repositories\Prism", "Prism"),
            (@"E:\Repositories\Protobuild", "Protobuild"),
            (@"E:\Repositories\PTVS", "PTVS"),
            (@"E:\Repositories\QuickGraph", "QuickGraph"),
            (@"E:\Repositories\Rebus", "Rebus"),
            (@"E:\Repositories\roslyn", "Roslyn"),
            (@"E:\Repositories\RTVS", "RTVS"),
            (@"E:\Repositories\Rubberduck", "Rubberduck"),
            (@"E:\Repositories\Rx.NET", "RxNET"),
            (@"E:\Repositories\sdk", "Sdk"),
            (@"E:\Repositories\serilog", "Serilog"),
            (@"E:\Repositories\ServiceStack", "ServiceStack"),
            (@"E:\Repositories\ShareX", "ShareX"),
            (@"E:\Repositories\SignalR", "SignalR"),
            (@"E:\Repositories\Sonarr", "Sonarr"),
            (@"E:\Repositories\SparkleShare", "SparkleShare"),
            (@"E:\Repositories\SpecFlow", "SpecFlow"),
            (@"E:\Repositories\templating", "Templating"),
            (@"E:\Repositories\Umbraco-CMS", "UmbracoCms"),
            (@"E:\Repositories\UWPCommunityToolkit", "UWPCommunityToolkit"),
            (@"E:\Repositories\vs-mef", "VsMef"),
            (@"E:\Repositories\vsts-agent", "VstsAgent"),
            (@"E:\Repositories\VsVim", "VsVim"),
            (@"E:\Repositories\wcf", "Wcf"),
            (@"E:\Repositories\WealthEconomy", "WealthEconomy"),
            (@"E:\Repositories\Wox", "Wox"),
            (@"E:\Repositories\Wyam", "Wyam"),
            (@"E:\Repositories\Xamarin.Auth", "XamarinAuth"),
            (@"E:\Repositories\Xamarin.Mobile", "XamarinMobile"),
            (@"E:\Repositories\xunit", "XUnit")
        };
    }
}
