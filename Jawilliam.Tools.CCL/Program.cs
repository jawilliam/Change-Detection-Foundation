using CommandDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.Tools.CCL
{
    class Program
    {
        static int Main(string[] args)
        {
            //args = new[] {
            //    "gumtree", "detect",
            //    @"D:\ExperimentLogs\InverseForMultipleConfigurationsOriginal.cs",
            //    @"D:\ExperimentLogs\InverseForMultipleConfigurationsModified.cs",
            //    "gumtree_RoslynML",
            //    "NativeGTtreefiedRoslynML",
            //    //@"-skipThese=D:\ExperimentLogs\SkipThese.xml",
            //    @"-trace=D:\ExperimentLogs\gumtree_RoslynML_BasicPruning_NoTrivia.txt",
            //    @"-runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia",
            //    "-name:gumtree_RoslynML_BasicPruning_NoTrivia_forward",
            //    "-approach:NativeGTtreefiedRoslynMLWithBasicPruning",
            //    "-direction:Forward",
            //    @"-runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia",
            //    "-name:gumtree_RoslynML_BasicPruning_NoTrivia_backward",
            //    "-approach:InverseNativeGTtreefiedRoslynMLWithBasicPruning",
            //    "-direction:Backward"
            //};
            //args = new[] {
            //    "gumtree" + " " +
            //    "detect" + " " +
            //    @"D:\ExperimentLogs\InverseForMultipleConfigurationsOriginal.cs" + " " +
            //    @"D:\ExperimentLogs\InverseForMultipleConfigurationsModified.cs" + " " +
            //    "gumtree_RoslynML" + " " +
            //    "NativeGTtreefiedRoslynML" + " " +
            //    //@"-skipThese=D:\ExperimentLogs\SkipThese.xml",
            //    @"-trace=D:\ExperimentLogs\gumtree_RoslynML_BasicPruning_NoTrivia.txt" + " " +
            //    @"-runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia" + " " +
            //    "-name:gumtree_RoslynML_BasicPruning_NoTrivia_forward" + " " +
            //    "-approach:NativeGTtreefiedRoslynMLWithBasicPruning" + " " +
            //    "-direction:Forward" + " " +
            //    @"-runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia" + " " +
            //    "-name:gumtree_RoslynML_BasicPruning_NoTrivia_backward" + " " +
            //    "-approach:InverseNativeGTtreefiedRoslynMLWithBasicPruning" + " " +
            //    "-direction:Backward"
            //};
            //args = new[] { @"RoslynML E:\F.txt --includeTrivia" };
            //args = new[] { @"savetrees E:\SourceCode\RBPNT_Original.cs E:\SourceCode\RBPNT_Modified.cs NativeGTtreefiedRoslynML 28 -trace=D:\ExperimentLogs\savetrees_RoslynML_BasicPruning_NoTrivia.txt --pruning:Basic --includeTrivia" };
            //args = new[] { "gumtree compare " +
            //               "NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward " +
            //               "NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia " +
            //               "28 " +
            //               @"-trace=D:\ExperimentLogs\NativeGumtree_RMBPITF_VsRMBPITB_VsRMNPITF_VsRMBPNTF.txt " +
            //               "-name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward " +
            //               "-approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia " +
            //               "-fileFormat=28 " +
            //               "-direction=Backward " +
            //               "-name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward " +
            //               "-approach=NativeGTtreefiedRoslynMLWithIncludeTrivia " +
            //               "-fileFormat=20 " +
            //               "-direction=Forward " +
            //               "-name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward " +
            //               "-approach=NativeGTtreefiedRoslynMLWithBasicPruning " +
            //               "-fileFormat=12 " +
            //               "-direction=Forward " +
            //               "-to=25" };
            //args = new[] { "gumtree compare NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\\ExperimentLogs\\BetweenSymptoms.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=23 -to=23" };
            //args = new[] { "Compare stats NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\\ExperimentLogs\\BetweenSymptomsStats2.txt -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward -approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia -fileFormat=28 -direction=Backward -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=1 -to=25" };
            args = args?.Count() == 1 ? args[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries) : args;
            AppRunner<CCL> appRunner = new AppRunner<CCL>();
            return appRunner.Run(args);
        }
    }
}
