using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jawilliam.Tools.CCL
{
    /// <summary>
    /// Implements the command logic of the CDF Command Line (CCL).
    /// </summary>
    public partial class CCL
    {
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



        internal static IEnumerable<(string project, Guid frpId)> OnTheseConfig(string onThesePath)
        {
            if (onThesePath == null)
                return null;

            return System.IO.File.ReadAllLines(onThesePath).Skip(1)
                .Select<string, (string project, Guid frpId)>(delegate (string line, int i)
                {
                    var values = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values == null || values.Length != 2)
                        throw new ApplicationException($"Bad formed entry: line {i}.");

                    return (values[1], Guid.Parse(values[0]));
                });
        }

        internal static IEnumerable<(string Path, string Name)> ProjectsConfig(IEnumerable<(string Path, string Name)> projects,
            int from, int to,
            IEnumerable<(string project, Guid frpId)> onTheseConfig)
        {
            return projects.Skip(from - 1).Take(to - (from - 1))
                .Where(p => onTheseConfig?.Any(f => f.project == p.Name) ?? true);
        }

        internal static List<Guid> DeltasConfig(string projectName, IEnumerable<Guid> deltaIds,
            IEnumerable<(string project, Guid frpId)> onTheseConfig)
        {
            return onTheseConfig?
                        .Where(f => f.project == projectName)
                        .Select(f => f.frpId)
                        .ToList()
                        ?? deltaIds.ToList();
        }
    }
}
