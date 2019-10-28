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
            //args = new[] { @"RoslynML C:\Users\gdelator\AppData\Local\Temp\gumtree9036915333579494655.cs --gumtreefy --pruning=Basic --includeTrivia --defoliate" };
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
            //args = new[] { @"Jawilliam.Tools.CCL.exe Compare stats NativeGTtreefiedRoslynMLWithBasicPruning_Forward NativeGTtreefiedRoslynMLWithBasicPruning 12 -trace=D:\ExperimentLogs\BetweenSymptomsStats_28Vs32.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=18 -direction=Forward -from=1 -to=25" };
            //args = new[] { @"gumtree compare NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\ExperimentLogs\BetweenSymptoms.txt -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward -approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia -fileFormat=28 -direction=Backward -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=1 -to=25" }; 
            //args = new[] { @"gumtree compare NativeGumTree_Forward NativeGumTree 1 -trace=D:\ExperimentLogs\BetweenSymptoms_2_5_10.txt -name=NativeGumTree_Backward -approach=InverseOfNativeGumTree -fileFormat=1 -direction=Backward -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward --limited -from=1 -to=25" };
            //args = new[] { @"gumtree compare NativeGTtreefiedRoslynML_Forward NativeGumTree 5 -trace=D:\ExperimentLogs\BetweenSymptoms_10_11.txt -name=NativeGTtreefiedRoslynML_Backward -approach=InverseNativeGTtreefiedRoslynML -fileFormat=5 -direction=Backward --limited -from=1 -to=25" };
            //args = new[] { @"gumtree compare NativeGTtreefiedRoslynML_Forward NativeGTtreefiedRoslynML 5 -trace=D:\ExperimentLogs\BetweenSymptoms_10_11.txt -name=NativeGTtreefiedRoslynML_Backward -approach=InverseNativeGTtreefiedRoslynML -fileFormat=5 -direction=Backward -from=1 -to=25" };
            //args = new[] { @"gumtree detect D:\ExperimentLogs\RunningOriginal34.cs D:\ExperimentLogs\RunningModified34.cs gumtree_RoslynML NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_RoslynML_BasicPruning_Defoliation.txt -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_0mh -name:gumtree_RoslynML_BasicPruning_Defoliation_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliation -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_0mh -name:gumtree_RoslynML_BasicPruning_Defoliation_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliation -direction:Backward -onThese=D:\ExperimentLogs\CoreClr.csv -from=23 -to=23" };
            //args = new []{ @"GumTree download AjaxControlToolkit c2b1942f-1aae-497d-8505-e4678ce429ab -originalPath=D:\ExperimentLogs\ExploreOriginal1.cs -modifiedPath=D:\ExperimentLogs\ExploreModified1.cs -runtime=D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia -direction=Forward -originalPath=D:\ExperimentLogs\ExploreOriginal2.cs -modifiedPath=D:\ExperimentLogs\ExploreModified2.cs -runtime=D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia -direction=Backward" };
            args = args?.Count() == 1 ? args[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries) : args;
            AppRunner<CCL> appRunner = new AppRunner<CCL>();
            /*return*/ appRunner.Run(args);
            Console.ReadLine();
            return 0;
        }
    }
}
