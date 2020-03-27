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
            //args = new[] { @"RoslynML C:\OriginalAbstractBoardGame.cs --gumtreefy --typeBasedLabels --includeTrivia" };
            //args = new[] { "gumtree compare NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\\ExperimentLogs\\BetweenSymptoms.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=23 -to=23" };
            //args = new[] { @"Jawilliam.Tools.CCL.exe Compare stats NativeGTtreefiedRoslynMLWithBasicPruning_Forward NativeGTtreefiedRoslynMLWithBasicPruning 12 -trace=D:\ExperimentLogs\BetweenSymptomsStats_28Vs32.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=18 -direction=Forward -from=1 -to=25" };
            //args = new[] { @"Compare stats NativeGumTree_Forward NativeGumTree 1 -trace=D:\ExperimentLogs\BetweenSymptomsStats_2_5.txt -name=NativeGumTree_Backward -approach=InverseOfNativeGumTree -fileFormat=1 -direction=Backward -from=1 -to=25" }; 
            //args = new[] { @"gumtree compare NativeGumTree_Forward NativeGumTree 1 -trace=D:\ExperimentLogs\BetweenSymptoms_2_5_10.txt -name=NativeGumTree_Backward -approach=InverseOfNativeGumTree -fileFormat=1 -direction=Backward -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward --limited -from=1 -to=25" };
            //args = new[] { @"gumtree compare NativeGTtreefiedRoslynML_Forward NativeGumTree 5 -trace=D:\ExperimentLogs\BetweenSymptoms_10_11.txt -name=NativeGTtreefiedRoslynML_Backward -approach=InverseNativeGTtreefiedRoslynML -fileFormat=5 -direction=Backward --limited -from=1 -to=25" };
            //args = new[] { @"gumtree compare NativeGTtreefiedRoslynML_Forward NativeGTtreefiedRoslynML 5 -trace=D:\ExperimentLogs\BetweenSymptoms_10_11.txt -name=NativeGTtreefiedRoslynML_Backward -approach=InverseNativeGTtreefiedRoslynML -fileFormat=5 -direction=Backward -from=1 -to=25" };
            //args = new[] { @"gumtree detect D:\ExperimentLogs\RunningOrigina50to57.cs D:\ExperimentLogs\RunningModified50to57.cs NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_generate_50to57.txt -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_TBL_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling -direction:Backward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_TBL_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling -direction:Backward -from=25 -to=25" };
            //args = new []{ @"GumTree download AjaxControlToolkit c2b1942f-1aae-497d-8505-e4678ce429ab -originalPath=D:\ExperimentLogs\ExploreOriginal1.cs -modifiedPath=D:\ExperimentLogs\ExploreModified1.cs -runtime=D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia -direction=Forward -originalPath=D:\ExperimentLogs\ExploreOriginal2.cs -modifiedPath=D:\ExperimentLogs\ExploreModified2.cs -runtime=D:\GT_Runtimes\gumtree_RML_BasicPruning_NoTrivia -direction=Backward" };
            //args = new[] { @"rate AjaxControlToolkit 16BC2280-A2EF-4D24-9773-0A5032E8D049 75AAAADA-DA19-4FAD-8565-CB7C0660C88B -originalPath=D:\ExperimentLogs\RatingOriginal.cs -modifiedPath=D:\ExperimentLogs\RatingModified.cs 20 -trace=D:\ExperimentLogs\RatingTrace.txt" };
            //args = new[] { @"GumTree compare-on-fly srcml NativeGumTree D:\GT_Runtimes\gumtree-20171016-2.1.0 1 roslynml NativeGTtreefiedRoslynML " };
            //args = new[] { @"Compare stats ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling_Forward ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling 12  -trace=D:\ExperimentLogs\BetweenSymptomsStats_38_44.txt -name=ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling_Forward  -approach=ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling  -fileFormat=44 -direction=Forward -from=1 -to=25" };
            //args = new[] { @"gumtree repaired-expand Backward 20 -trace=D:\ExperimentLogs\gumtree_repairedexpansion_43_49.txt -name=NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling_Backward -approach=InverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling -fileFormat=20 -direction=Backward -name=NativeGTtreefiedRoslynMLAndPermissiveLabeling_Backward -approach=InverseNativeGTtreefiedRoslynMLAndPermissiveLabeling -fileFormat=5 -direction=Backward -from=24 -to=24" };
            //args = new[] { @"gumtree repaired-expand Forward 20 -trace=D:\ExperimentLogs\gumtree_repairedexpansion_32_42_48_10.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLAndPermissiveLabeling_Forward -approach=NativeGTtreefiedRoslynMLAndPermissiveLabeling -fileFormat=5 -direction=Forward -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward -from=1 -to=25" };
            //args = new[] { @"gumtree compare RepairedNativeGTtreefiedRoslynML_Forward RepairedNativeGTtreefiedRoslynML 5 -trace=D:\ExperimentLogs\BetweenSymptoms_2010_10_2032_2048.txt -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward -name=RepairedNativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=RepairedNativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=RepairedNativeGTtreefiedRoslynMLAndPermissiveLabeling_Forward -approach=RepairedNativeGTtreefiedRoslynMLAndPermissiveLabeling -fileFormat=5 -direction=Forward -from=1 -to=25" };
            //args = new[] { @"Compare stats RepairedNativeGTtreefiedRoslynML_Forward RepairedNativeGTtreefiedRoslynML 5 -trace=D:\ExperimentLogs\BetweenSymptomsStats_2010_10.txt -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward -from=1 -to=25" };
            args = args?.Count() == 1 ? args[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries) : args;
            AppRunner<CCL> appRunner = new AppRunner<CCL>();
            var r = appRunner.Run(args);
            //Console.ReadLine();
            return r;
        }
    }
}
