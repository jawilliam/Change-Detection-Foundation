using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Jawilliam.CDF.Tests.CSharp
{
    /// <summary>
    /// Descripción resumida de RDSLTests
    /// </summary>
    [TestClass]
    public class RDSLTests
    {
        [TestMethod]
        public void DefinitionOfKeywordProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var keywordProperties = (from t in concreteTypes
                                     from p in t.Properties?.Property
                                     where p.keyword ?? false
                                     select new { Type = t, Property = p }).ToArray();

            var keywordTermProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.name.Contains("Keyword")
                                         select new { Type = t, Property = p }).ToArray();

            var allKeywordTermAreKeywordProperties = keywordTermProperties.Except(keywordProperties).ToArray();
            Assert.AreEqual(allKeywordTermAreKeywordProperties.Length, 0);

            var plusTheseTwoProperties = keywordProperties.Except(keywordTermProperties).ToArray();
            Assert.AreEqual(plusTheseTwoProperties.Length, 2);
            Assert.AreEqual(plusTheseTwoProperties[0].Type.name, "ThisExpressionSyntax");
            Assert.AreEqual(plusTheseTwoProperties[1].Type.name, "BaseExpressionSyntax");
        }

        [TestMethod]
        public void DefinitionOfOperatorProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var operatorProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.@operator ?? false
                                      select new { Type = t, Property = p }).ToArray();

            var operatorTermProperties = (from t in concreteTypes
                                          from p in t.Properties?.Property
                                          where p.name.Contains("Operator") && 
                                                !(p.keyword ?? false) && 
                                                !(p.Rules?.Name?.Equality?.full ?? false) &&
                                                !(p.Rules?.Signature?.Equality?.full ?? false)
                                          select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(operatorTermProperties.Except(operatorProperties).ToArray().Length, 0);
            Assert.AreEqual(operatorProperties.Except(operatorTermProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfInvisibleProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var invisibleTypes = (from t in concreteTypes
                                  from p in t.Properties?.Property
                                  where p.invisible
                                  select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(invisibleTypes.Length, 2);
            Assert.AreEqual(invisibleTypes[0].Property.name, "OmittedTypeArgumentToken");
            Assert.AreEqual(invisibleTypes[0].Type.name, "OmittedTypeArgumentSyntax");
            Assert.AreEqual(invisibleTypes[1].Property.name, "OmittedArraySizeExpressionToken");
            Assert.AreEqual(invisibleTypes[1].Type.name, "OmittedArraySizeExpressionSyntax");
        }

        [TestMethod]
        public void DefinitionOfPunctuationProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var punctuationProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.puntuaction ?? false
                                      select new { Type = t, Property = p }).ToArray();

            var punctuationTermProperties = (from t in concreteTypes
                                          from p in t.Properties?.Property
                                          where p.kind == "Token" && p.readOnly &&
                                                !(p.keyword ?? false) &&
                                                !(p.@operator ?? false) &&
                                                !(p.keyword ?? false) &&
                                                !(p.Rules?.Name?.Equality?.full ?? false) &&
                                                !(p.Rules?.Signature?.Equality?.full ?? false) &&
                                                !p.invisible
                                          select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(punctuationTermProperties.Except(punctuationProperties).ToArray().Length, 0);
            Assert.AreEqual(punctuationProperties.Except(punctuationTermProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfMutuallyExclusiveOptionProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            //var punctuationProperties = (from t in concreteTypes
            //                             from p in t.Properties?.Property
            //                             where p.puntuaction ?? false
            //                             select new { Type = t, Property = p }).ToArray();

            var mutuallyExclusiveOptionTermProperties = (from t in concreteTypes
                                                         from p in t.Properties?.Property
                                                         where (p.keyword ?? false) && p.name.Contains("Or") && !p.name.StartsWith("Or")
                                                         select new { Type = t, Property = p }).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var mp in mutuallyExclusiveOptionTermProperties)
            {
                sb.AppendLine($"{mp.Property.name} in {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());

            //Assert.AreEqual(punctuationTermProperties.Except(punctuationProperties).ToArray().Length, 0);
            //Assert.AreEqual(punctuationProperties.Except(punctuationTermProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfTopologicallyRelevantProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var topologicalProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.Rules?.Topology?.relevant ?? false
                                         select new { Type = t, Property = p }).ToArray();

            var expressionProperties = (from t in concreteTypes
                                        from p in t.Properties?.Property
                                        where p.kind == "Expression"
                                        select new { Type = t, Property = p }).ToArray();

            // All expression property is topologically relevant.
            var expressionButNonTopologicalProperties = expressionProperties.Except(topologicalProperties).ToArray();
            Assert.AreEqual(expressionButNonTopologicalProperties.Length, 0);

            var operatorProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.@operator ?? false
                                      select new { Type = t, Property = p }).ToArray();

            // All operator property is topologically relevant.
            var operatorButNonTopologicalProperties = operatorProperties.Except(topologicalProperties).ToArray();
            Assert.AreEqual(operatorButNonTopologicalProperties.Length, 0);

            var identifierTokenProperties = (from t in concreteTypes
                                             from p in t.Properties?.Property
                                             where p.kind == "Token" && (p.Rules?.Name?.Equality.full ?? false) &&
                                                   !(p.name == "ThisKeyword" && t.name == "IndexerDeclarationSyntax") &&
                                                   !(p.name == "ThisKeyword" && t.name == "IndexerMemberCrefSyntax")
                                             select new { Type = t, Property = p }).ToArray();

            // All identifier token property is topologically relevant.
            var identifierTokenButNonTopologicalProperties = identifierTokenProperties.Except(topologicalProperties).ToArray();
            Assert.AreEqual(identifierTokenButNonTopologicalProperties.Length, 0);

            // Exceptions
            var otherProperties = (from t in concreteTypes
                                   from p in t.Properties?.Property
                                   where (p.name == "Token" && t.name == "LiteralExpressionSyntax") ||
                                         (p.name == "TextToken" && t.name == "InterpolatedStringTextSyntax") ||
                                         (p.name == "FormatStringToken" && t.name == "InterpolationFormatClauseSyntax") ||
                                         (p.name == "Keyword" && t.name == "PredefinedTypeSyntax") ||
                                         (p.name == "CaseOrDefaultKeyword" && t.name == "GotoStatementSyntax") ||
                                         (p.name == "VarianceKeyword" && t.name == "TypeParameterSyntax") ||
                                         (p.name == "Line" && t.name == "LineDirectiveTriviaSyntax") ||
                                         (p.name == "File" && t.name == "LineDirectiveTriviaSyntax") ||
                                         (p.name == "DisableOrRestoreKeyword" && t.name == "PragmaWarningDirectiveTriviaSyntax") ||
                                         (p.name == "File" && t.name == "PragmaChecksumDirectiveTriviaSyntax") ||
                                         (p.name == "Guid" && t.name == "PragmaChecksumDirectiveTriviaSyntax") ||
                                         (p.name == "Bytes" && t.name == "PragmaChecksumDirectiveTriviaSyntax") ||
                                         (p.name == "File" && t.name == "ReferenceDirectiveTriviaSyntax") ||
                                         (p.name == "File" && t.name == "LoadDirectiveTriviaSyntax")
                                   select new { Type = t, Property = p }).ToArray();
            var otherPropertiesButNonTopologicalProperties = otherProperties.Except(topologicalProperties).ToArray();
            Assert.AreEqual(otherPropertiesButNonTopologicalProperties.Length, 0);

            var topologicalButNonExpressionProperties = topologicalProperties.Except(
                expressionProperties.Union(operatorProperties).Union(identifierTokenProperties).Union(otherProperties)
            ).ToArray();
            Assert.AreEqual(topologicalButNonExpressionProperties.Length, 0);
        }

        [TestMethod]
        public void DefinitionOfReadOnlyTypes()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var readonlyTypes = (from t in concreteTypes
                                 where t.@readonly
                                 select t).ToArray();

            var typesWithJustReadOnlyProperties = (from t in concreteTypes
                                                   where t.Properties?.Property.All(p => p.readOnly) ?? false
                                                   select t).ToArray();

            Assert.AreEqual(typesWithJustReadOnlyProperties.Except(readonlyTypes).Count(), 0);
            Assert.AreEqual(readonlyTypes.Except(typesWithJustReadOnlyProperties).Count(), 0);

            //var allProperties = (from t in concreteTypes
            //                          from p in t.Properties?.Property
            //                          select new { Type = t, Property = p }).ToArray();

            var readOnlyProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.readOnly
                                      select new { Type = t, Property = p }).ToArray();

            // All operator property is topologically relevant.
            var keywords = (from t in concreteTypes
                            from p in t.Properties?.Property
                            where p.keyword ?? false
                            select new { Type = t, Property = p }).ToArray();

            var operators = (from t in concreteTypes
                             from p in t.Properties?.Property
                             where p.@operator ?? false
                             select new { Type = t, Property = p }).ToArray();

            var punctuations = (from t in concreteTypes
                                from p in t.Properties?.Property
                                where p.puntuaction ?? false
                                select new { Type = t, Property = p }).ToArray();

            var propertiesOfInvisibleTypes = (from t in concreteTypes
                                              from p in t.Properties?.Property
                                              where p.invisible
                                              select new { Type = t, Property = p }).ToArray();

            var a4 = (from t in concreteTypes
                      from p in t.Properties?.Property
                      where p.readOnly && p.optional
                      select new { Type = t, Property = p }).ToArray();

            var a1 = operators.Except(readOnlyProperties).ToArray();
            var a2 = keywords.Except(readOnlyProperties).ToArray();
            var a3 = punctuations.Except(readOnlyProperties).ToArray();

            var a5 = readOnlyProperties.Except(
                keywords.Union(operators).Union(punctuations)
            ).ToArray();
            Assert.AreEqual(a5.Length, 0);

            //StringBuilder sb = new StringBuilder();
            //foreach (var mp in a2)
            //{
            //    sb.AppendLine($"{mp.Property.name} in {mp.Type.name}");
            //}
            //System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());

            //Assert.AreEqual(a.Length, 0);
        }
    }
}
