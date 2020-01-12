Classes generation starting from Xsd (Linq to Xsd)
a) Open cmd.exe in CodePlex.LinqToXsd.2.0.2's build folder (e.g., E:\MyRepositories\Change-Detection-Foundation\packages\CodePlex.LinqToXsd.2.0.2\build).
b) Type LinqToXsd <Path>\<XsdName>.xsd (by default, the .cs is saved in <Path>) e.g., LinqToXsd E:\MyRepositories\Change-Detection-Foundation\Jawilliam.CDF.XObjects\XNodeTypeSystem.xsd
c) Perhaps, you have to replace "tempuri.org.XNodeTypeSystem.xsd.Syntax." by "Syntax.", and "tempuri.org.XNodeTypeSystem.xsd." by "Jawilliam.CDF.XObjects.RDSL."

To execute srcml the command is "srcml filepath\filename"

To execute gumtree in console
a) cd {args.GumTreePath}\bin
b) set PATH=%PATH%;C:\Program Files (x86)\srcML 0.9.5\bin 


gumtree detect D:\ExperimentLogs\RunningOriginal.cs D:\ExperimentLogs\RunningModified.cs gumtree_RoslynML NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_RoslynML_BasicPruning_NoTrivia.txt -runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia -name:gumtree_RoslynML_BasicPruning_NoTrivia_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruning -direction:Forward -runtime=D:\GT_Runtimes\gumtree_Roslynml_BasicPruning_NoTrivia -name:gumtree_RoslynML_BasicPruning_NoTrivia_backward -approach:InverseNativeGTtreefiedRoslynMLWithBasicPruning -direction:Backward

// Between symptoms
gumtree compare NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Forward NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia 28 -trace=D:\ExperimentLogs\BetweenSymptoms.txt -name=NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia_Backward -approach=InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia -fileFormat=28 -direction=Backward -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithBasicPruning_Forward -approach=NativeGTtreefiedRoslynMLWithBasicPruning -fileFormat=12 -direction=Forward -from=1 -to=25

Jawilliam.Tools.CCL.exe gumtree detect D:\ExperimentLogs\RunningOrigina50to57.cs D:\ExperimentLogs\RunningModified50to57.cs NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_generate_50to57.txt -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_NT_De_TBL_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling -direction:Forward -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_TBL_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling -direction:Forward -from=22 -to=25

Jawilliam.Tools.CCL.exe gumtree detect D:\ExperimentLogs\RunningOrigina50to57.cs D:\ExperimentLogs\RunningModified50to57.cs NativeGTtreefiedRoslynML -trace=D:\ExperimentLogs\gumtree_generate_50to57.txt -runtime=D:\GT_Runtimes\gumtree_RML_BP_IT_De_TBL_1mh -name:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling_forward -approach:NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling -direction:Forward -from=22 -to=22