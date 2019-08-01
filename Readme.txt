Classes generation starting from Xsd (Linq to Xsd)
a) Open cmd.exe in CodePlex.LinqToXsd.2.0.2's build folder (e.g., E:\MyRepositories\Change-Detection-Foundation\packages\CodePlex.LinqToXsd.2.0.2\build).
b) Type LinqToXsd <Path>\<XsdName>.xsd (by default, the .cs is saved in <Path>) e.g., LinqToXsd E:\MyRepositories\Change-Detection-Foundation\Jawilliam.CDF.XObjects\XNodeTypeSystem.xsd
c) Perhaps, you have to replace "tempuri.org.XNodeTypeSystem.xsd.Syntax." by "Syntax.", and "tempuri.org.XNodeTypeSystem.xsd." by "Jawilliam.CDF.XObjects.RDSL."

To execute srcml the command is "srcml filepath\filename"

To execute gumtree in console
a) cd {args.GumTreePath}\bin
b) set PATH=%PATH%;C:\Program Files (x86)\srcML 0.9.5\bin 