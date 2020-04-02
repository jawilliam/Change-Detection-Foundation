using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    partial class GitRepository
    {
        /// <summary>
        /// Initializes the instance with a particular name or connection string.
        /// </summary>
        /// <param name="nameOrConnectionString">the connection string, or the name to localize it inside the settings, e.g., the connection strings in the app.config.</param>
        public GitRepository(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Save all the changes so far and detach all the entities.
        /// </summary>
        public virtual void Flush(bool saveChanges = true)
        {
            if(saveChanges)
                this.SaveChanges();

            foreach (var dbEntityEntry in this.ChangeTracker.Entries().ToArray())
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Detached;
            }
        }

        /// <summary>
        /// Gets or sets the name of the current repository.
        /// </summary>
        public virtual string Name { get; set; }

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
