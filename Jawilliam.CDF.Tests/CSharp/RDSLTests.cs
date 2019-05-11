using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Jawilliam.CDF.XObjects.RDSL;

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
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var keywordProperties = (from t in concreteTypes
                                     from p in t.Properties?.Property
                                     where p.keyword ?? false
                                     select new { Type = t, Property = p }).ToArray();

            var keywordTermProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.name.Contains("Keyword")
                                         select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(keywordTermProperties.Except(keywordProperties).ToArray().Length, 0);

            var plusTheseTwoProperties = keywordProperties.Except(keywordTermProperties).ToArray();
            Assert.AreEqual(plusTheseTwoProperties.Length, 2);
            Assert.AreEqual(plusTheseTwoProperties[0].Type.name, "ThisExpressionSyntax");
            Assert.AreEqual(plusTheseTwoProperties[1].Type.name, "BaseExpressionSyntax");
        }

        [TestMethod]
        public void DefinitionOfOperatorProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
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
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
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
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var punctuationProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.puntuaction ?? false
                                      select new { Type = t, Property = p }).ToArray();

            var punctuationTermProperties = (from t in concreteTypes
                                          from p in t.Properties?.Property
                                          where (p.kind == "Token" && p.readOnly &&
                                                !(p.keyword ?? false) &&
                                                !(p.@operator ?? false) &&
                                                !(p.keyword ?? false) &&
                                                !(p.Rules?.Name?.Equality?.full ?? false) &&
                                                !(p.Rules?.Signature?.Equality?.full ?? false) &&
                                                !p.invisible) || 
                                                p.name == "StartQuoteToken" || 
                                                p.name == "EndQuoteToken" ||
                                                p.name == "StringStartToken"
                                          select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(punctuationTermProperties.Except(punctuationProperties).ToArray().Length, 0);
            Assert.AreEqual(punctuationProperties.Except(punctuationTermProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfEnumerationProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var enumerationProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.Enumeration()
                                         select new { Type = t, Property = p }).ToArray();

            var containsOrTermProperties = (from t in concreteTypes
                                            from p in t.Properties?.Property
                                            where (p.keyword ?? false) && p.name.Contains("Or") && !p.name.StartsWith("Or")
                                            select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(containsOrTermProperties.Except(enumerationProperties).Count(), 0);

            var operatorsProperties = (from t in concreteTypes
                                       from p in t.Properties?.Property
                                       where (p.@operator ?? false) && 
                                             !(p.name == "OperatorToken" && t.name == "ConditionalAccessExpressionSyntax") &&
                                             !(p.name == "OperatorToken" && t.name == "MemberBindingExpressionSyntax")
                                       select new { Type = t, Property = p }).ToArray();
           Assert.AreEqual(operatorsProperties.Except(enumerationProperties).Count(), 0);

            var operatorDeclarationProperties = (from t in concreteTypes
                                                 from p in t.Properties?.Property
                                                 where p.name.Contains("Operator") &&
                                                       !(p.keyword ?? false) && 
                                                       !(p.@operator ?? false)
                                                 select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operatorDeclarationProperties.Except(enumerationProperties).Count(), 0);

            var startOrEndQuoteTokenProperties = (from t in concreteTypes
                                                  from p in t.Properties?.Property
                                                  where p.name == "StartQuoteToken" || p.name == "EndQuoteToken"
                                                  select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(startOrEndQuoteTokenProperties.Except(enumerationProperties).Count(), 0);

            var plusTheseOtherProperties = (from t in concreteTypes
                                            from p in t.Properties?.Property
                                            where (p.name == "Token" && t.name == "LiteralExpressionSyntax") ||
                                                  (p.name == "Keyword" && t.name == "CheckedExpressionSyntax") ||
                                                  (p.name == "StringStartToken" && t.name == "InterpolatedStringExpressionSyntax") ||
                                                  (p.name == "RefKindKeyword" && t.name == "ArgumentSyntax") ||
                                                  (p.name == "Keyword" && t.name == "PredefinedTypeSyntax") ||
                                                  (p.name == "Identifier" && t.name == "IdentifierNameSyntax") ||
                                                  (p.name == "Keyword" && t.name == "CheckedStatementSyntax") ||
                                                  (p.name == "VarianceKeyword" && t.name == "TypeParameterSyntax") ||
                                                  (p.name == "Keyword" && t.name == "AccessorDeclarationSyntax") ||
                                                  (p.name == "Identifier" && t.name == "ParameterSyntax") ||
                                                  (p.name == "Line" && t.name == "LineDirectiveTriviaSyntax") ||
                                                  (p.name == "RefKindKeyword" && t.name == "CrefParameterSyntax") ||
                                                  (p.name == "Designation" && t.name == "DeclarationPatternSyntax")
                                            select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(plusTheseOtherProperties.Except(enumerationProperties).Count(), 0);

            var theseAreTheEnumerationProperties = containsOrTermProperties
                .Union(operatorsProperties)
                .Union(operatorDeclarationProperties)
                .Union(startOrEndQuoteTokenProperties)
                .Union(plusTheseOtherProperties);
            Assert.AreEqual(theseAreTheEnumerationProperties.Except(enumerationProperties).ToArray().Length, 0);
            Assert.AreEqual(enumerationProperties.Except(theseAreTheEnumerationProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfLabelingEnumerationProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var labelingEnumerationProperties = (from t in concreteTypes
                                                 from p in t.Properties?.Property
                                                 where p.Enumeration() && p.Options.labeling
                                                 select new { Type = t, Property = p }).ToArray();

            var flagProperties = (from t in concreteTypes
                                  from p in t.Properties?.Property
                                  where p.Enumeration() && (p.Options?.Kind.Any(k => k.type != null) ?? false)
                                 select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(labelingEnumerationProperties.Except(flagProperties).ToArray().Length, 0);
            Assert.AreEqual(flagProperties.Except(labelingEnumerationProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfReadOnlyProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var readOnlyProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.readOnly
                                      select new { Type = t, Property = p }).ToArray();

            // All operator property is topologically relevant.
            var allKeywordsExceptThese6 = (from t in concreteTypes
                                           from p in t.Properties?.Property
                                           where ((p.keyword ?? false) && !p.Enumeration()) || (p.name == "Keyword" && t.name == "PredefinedTypeSyntax")  /*&& !p.Labeling()
                                                 !(p.name == "RefKindKeyword" && t.name == "ArgumentSyntax") &&
                                                 !(p.name == "RefKindKeyword" && t.name == "CrefParameterSyntax") &&
                                                 !(p.name == "VarianceKeyword" && t.name == "TypeParameterSyntax") &&
                                                 !(p.name == "ImplicitOrExplicitKeyword" && t.name == "ConversionOperatorDeclarationSyntax") &&
                                                 !(p.name == "ImplicitOrExplicitKeyword" && t.name == "ConversionOperatorMemberCrefSyntax") &&
                                                 !(p.name == "DisableOrRestoreKeyword" && t.name == "PragmaWarningDirectiveTriviaSyntax")*/
                                           select new { Type = t, Property = p }).ToArray();
            var a = allKeywordsExceptThese6.Except(readOnlyProperties).ToArray();
            var b = readOnlyProperties.Except(allKeywordsExceptThese6).ToArray();
            //Assert.AreEqual(allKeywordsExceptThese6.Except(readOnlyProperties).ToArray().Length, 0);

            var operators = (from t in concreteTypes
                             from p in t.Properties?.Property
                             where p.@operator ?? false
                             select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operators.Except(readOnlyProperties).ToArray().Length, 0);

            var allNotEnumeratedPunctuation = (from t in concreteTypes
                                               from p in t.Properties?.Property
                                               where (p.puntuaction ?? false) && !p.Enumeration() //p.name != "StartQuoteToken" && p.name != "EndQuoteToken" //&& !p.Enumeration()
                                               select new { Type = t, Property = p }).ToArray();
            //Assert.AreEqual(allNotEnumeratedPunctuation.Except(readOnlyProperties).ToArray().Length, 0);

            var symbolicProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.invisible
                                      select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(symbolicProperties.Except(readOnlyProperties).ToArray().Length, 0);

            var flagProperties2 = (from t in concreteTypes
                                   from p in t.Properties?.Property
                                   where p.Labeling() && !(p.name == "Token" && t.name == "LiteralExpressionSyntax")
                                   select new { Type = t, Property = p }).ToArray();

            var plus2 = (from t in concreteTypes
                         from p in t.Properties?.Property
                         where (p.name == "OperatorToken" && t.name == "OperatorDeclarationSyntax") ||
                               (p.name == "Modifiers" && t.name == "DestructorDeclarationSyntax") ||
                               (p.name == "ParameterList" && t.name == "DestructorDeclarationSyntax") ||
                               (p.name == "Name" && t.name == "XmlCrefAttributeSyntax") ||
                               (p.name == "Name" && t.name == "XmlNameAttributeSyntax")
                         select new { Type = t, Property = p }).ToArray();

            var a45 = allKeywordsExceptThese6
                .Union(operators)
                .Union(allNotEnumeratedPunctuation)
                .Union(symbolicProperties)
                .Union(flagProperties2)
                .Union(plus2)
            .ToArray();

            var a46 = readOnlyProperties.Except(a45).ToArray();
            var a47 = a45.Except(readOnlyProperties).ToArray();
            Assert.AreEqual(readOnlyProperties.Except(a45).ToArray().Length, 0);
            Assert.AreEqual(a45.Except(readOnlyProperties).ToArray().Length, 0);
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
            var a = typesWithJustReadOnlyProperties.Except(readonlyTypes).ToArray();
            var b = readonlyTypes.Except(typesWithJustReadOnlyProperties).ToArray();

            Assert.AreEqual(typesWithJustReadOnlyProperties.Except(readonlyTypes).Count(), 0);
            Assert.AreEqual(readonlyTypes.Except(typesWithJustReadOnlyProperties).Count(), 0);
        }
    }
}
