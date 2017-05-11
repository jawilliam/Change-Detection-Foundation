using LibGit2Sharp;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jawilliam.CDF.Labs
{
    class Program
    {
        /// <summary>
        /// Returns the project information.
        /// </summary>
        public static IEnumerable<Project> Projects => new[]
        {
            new Project(), 
            //new Project{ Path = @"E:\Repositories\Force.com-Toolkit-for-NET", Name = "ForcecomToolkitForNET" },
            //new Project{ Path = @"E:\Repositories\Xamarin.Auth", Name = "XamarinAuth" },
            //new Project{ Path = @"E:\Repositories\netmf-interpreter", Name = "NetmfInterpreter" },
            //new Project{ Path = @"E:\Repositories\Xamarin.Mobile", Name = "XamarinMobile" },
            //new Project{ Path = @"E:\Repositories\IdentityManager", Name = "IdentityManager" },
            //new Project{ Path = @"E:\Repositories\hadoopsdk", Name = "HadoopSdk" },
            //new Project{ Path = @"E:\Repositories\Protobuild", Name = "Protobuild" },
            //new Project{ Path = @"E:\Repositories\Open-XML-SDK", Name = "OpenXmlSdk" },
            //new Project{ Path = @"E:\Repositories\MailKit", Name = "MailKit" },
            //new Project{ Path = @"E:\Repositories\cecil", Name = "Cecil" },
            //new Project{ Path = @"E:\Repositories\AjaxControlToolkit", Name = "AjaxControlToolkit" },
            //new Project{ Path = @"E:\Repositories\Prism", Name = "Prism" },
            //new Project{ Path = @"E:\Repositories\MimeKit", Name = "MimeKit" },
            //new Project{ Path = @"E:\Repositories\kudu", Name = "Kudu" },
            //new Project{ Path = @"E:\Repositories\wcf", Name = "Wcf" },
            //new Project{ Path = @"E:\Repositories\cake", Name = "Cake" },
            //new Project{ Path = @"E:\Repositories\azure-webjobs-sdk", Name = "AzureWebJobsSdk" },
            //new Project{ Path = @"E:\Repositories\katanaproject", Name = "Katana" },
            //new Project{ Path = @"E:\Repositories\couchbase-lite-net", Name = "CouchbaseLiteNet" },
            //new Project{ Path = @"E:\Repositories\msbuild", Name = "Msbuild" },
            //new Project{ Path = @"E:\Repositories\aspnetwebstack", Name = "AspnetWebStack" },
            //new Project{ Path = @"E:\Repositories\SignalR", Name = "SignalR" },
            //new Project{ Path = @"E:\Repositories\IdentityServer3", Name = "IdentityServer3" },
            //new Project{ Path = @"E:\Repositories\orleans", Name = "Orleans" },
            //new Project{ Path = @"E:\Repositories\EntityFramework", Name = "Ef7" },
            //new Project{ Path = @"E:\Repositories\Orchard", Name = "Orchard" },
            //new Project{ Path = @"E:\Repositories\azure-sdk-for-net", Name = "AzureSdkForNet" },
            //new Project{ Path = @"E:\Repositories\roslyn", Name = "Roslyn" },
            //new Project{ Path = @"E:\Repositories\xunit", Name = "XUnit" },
            //new Project{ Path = @"E:\Repositories\UWPCommunityToolkit", Name = "UWPCommunityToolkit" },
            //new Project{ Path = @"E:\Repositories\Rx.NET", Name = "RxNET" },
            //new Project{ Path = @"E:\Repositories\Polly", Name = "Polly" },
            //new Project{ Path = @"E:\Repositories\Nancy", Name = "Nancy" },
            //new Project{ Path = @"E:\Repositories\BenchmarkDotNet", Name = "BenchmarkDotNet" },
            //new Project{ Path = @"E:\Repositories\Umbraco-CMS", Name = "UmbracoCms" },
            //new Project{ Path = @"E:\Repositories\cli", Name = "Cli" },
            //new Project{ Path = @"E:\Repositories\coreclr", Name = "CoreClr" },
            //new Project{ Path = @"E:\Repositories\corefx", Name = "CoreFx" },
            //new Project{ Path = @"E:\Repositories\mono", Name = "mono" },
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
            // Deploying the projects...
            var deployer = new FromLocalGitToSqlDbDeployment();
            foreach (var project in Projects)
            {
                deployer.Warnings = new StringBuilder();

                var localRepository = new Repository(project.Path);
                var dbRepository = new GitRepository(project.Name) { Name = project.Name };

                deployer.Deploy(localRepository, dbRepository);

                System.IO.File.WriteAllText($@"E:\Repositories\{project.Name}Warnings.txt", deployer.Warnings.ToString());
            }

            //int i = 0; // the warning reports!!!
            System.Console.ReadKey();
        }
    }
}
