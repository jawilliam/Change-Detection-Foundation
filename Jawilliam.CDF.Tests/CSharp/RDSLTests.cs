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
        public void GuidelinesForTopologicalProperties()
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
    }
}
