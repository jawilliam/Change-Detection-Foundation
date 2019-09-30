using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Jawilliam.CDF.XObjects.RDSL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;

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
                                     where p.hashtags.Contains("#KEYWORD")
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
                                      where p.hashtags.Contains("#OPERATOR")
                                      select new { Type = t, Property = p }).ToArray();

            var operatorTermProperties = (from t in concreteTypes
                                          from p in t.Properties?.Property
                                          where p.name.Contains("Operator") &&
                                                !p.hashtags.Contains("#KEYWORD") &&
                                                !(p.name == "OperatorToken" && t.name == "OperatorDeclarationSyntax") &&
                                                !(p.name == "OperatorToken" && t.name == "OperatorMemberCrefSyntax")
                                          select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(operatorTermProperties.Except(operatorProperties).ToArray().Length, 0);
            Assert.AreEqual(operatorProperties.Except(operatorTermProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfSymbolicProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var symbolicTypes = (from t in concreteTypes
                                 from p in t.Properties?.Property
                                 where p.hashtags.Contains("#SYMBOLIC")
                                 select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(symbolicTypes.Length, 2);
            Assert.AreEqual(symbolicTypes[0].Property.name, "OmittedTypeArgumentToken");
            Assert.AreEqual(symbolicTypes[0].Type.name, "OmittedTypeArgumentSyntax");
            Assert.AreEqual(symbolicTypes[1].Property.name, "OmittedArraySizeExpressionToken");
            Assert.AreEqual(symbolicTypes[1].Type.name, "OmittedArraySizeExpressionSyntax");
        }

        [TestMethod]
        public void DefinitionOfPunctuationProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var punctuationProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.hashtags.Contains("#PUNTUACTION")
                                         select new { Type = t, Property = p }).ToArray();

            var punctuationTermProperties = (from t in concreteTypes
                                             from p in t.Properties?.Property
                                             where (p.type == "SyntaxToken" && p.readOnly &&
                                                   !p.hashtags.Contains("#KEYWORD") &&
                                                   !p.hashtags.Contains("#OPERATOR") &&
                                                   !p.hashtags.Contains("#SYMBOLIC") &&
                                                   !(p.name == "OperatorToken" && t.name == "OperatorDeclarationSyntax")) ||
                                                   p.name == "StartQuoteToken" ||
                                                   p.name == "EndQuoteToken" ||
                                                   (p.name == "StringStartToken" && t.name == "InterpolatedStringExpressionSyntax")
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
                                            where p.hashtags.Contains("#KEYWORD") && p.name.Contains("Or") && !p.name.StartsWith("Or")
                                            select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(containsOrTermProperties.Except(enumerationProperties).Count(), 0);

            var operatorsProperties = (from t in concreteTypes
                                       from p in t.Properties?.Property
                                       where p.hashtags.Contains("#OPERATOR") &&
                                             !(p.name == "OperatorToken" && t.name == "ConditionalAccessExpressionSyntax") &&
                                             !(p.name == "OperatorToken" && t.name == "MemberBindingExpressionSyntax")
                                       select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operatorsProperties.Except(enumerationProperties).Count(), 0);

            var operatorDeclarationProperties = (from t in concreteTypes
                                                 from p in t.Properties?.Property
                                                 where p.name.Contains("Operator") &&
                                                       !p.hashtags.Contains("#KEYWORD") &&
                                                       !p.hashtags.Contains("#OPERATOR")
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

            var labelingProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.Enumeration() && p.Options.labeling
                                      select new { Type = t, Property = p }).ToArray();

            var flagProperties = (from t in concreteTypes
                                  from p in t.Properties?.Property
                                  where p.Enumeration() && (p.Options?.Kind.Any(k => k.type != null) ?? false)
                                  select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(labelingProperties.Except(flagProperties).ToArray().Length, 0);
            Assert.AreEqual(flagProperties.Except(labelingProperties).ToArray().Length, 0);

            var flagProperties2 = (from t in concreteTypes
                                   from p in t.Properties?.Property
                                   where (p.name == "AscendingOrDescendingKeyword" && t.name == "OrderingSyntax") ||
                                         (p.name == "CaseOrDefaultKeyword" && t.name == "GotoStatementSyntax") ||
                                         (p.name == "ReturnOrBreakKeyword" && t.name == "YieldStatementSyntax") ||
                                         (p.name == "ClassOrStructKeyword" && t.name == "ClassOrStructConstraintSyntax") ||
                                         (p.name == "ThisOrBaseKeyword" && t.name == "ConstructorInitializerSyntax") ||
                                         (p.name == "OperatorToken" && t.name == "PrefixUnaryExpressionSyntax") ||
                                         (p.name == "OperatorToken" && t.name == "PostfixUnaryExpressionSyntax") ||
                                         (p.name == "OperatorToken" && t.name == "MemberAccessExpressionSyntax") ||
                                         (p.name == "OperatorToken" && t.name == "BinaryExpressionSyntax") ||
                                         (p.name == "OperatorToken" && t.name == "AssignmentExpressionSyntax") ||
                                         (p.name == "Token" && t.name == "LiteralExpressionSyntax") ||
                                         (p.name == "Keyword" && t.name == "CheckedExpressionSyntax") ||
                                         (p.name == "Keyword" && t.name == "CheckedStatementSyntax") ||
                                         (p.name == "Keyword" && t.name == "AccessorDeclarationSyntax")
                                   select new { Type = t, Property = p }).ToArray();

            Assert.AreEqual(labelingProperties.Except(flagProperties2).ToArray().Length, 0);
            Assert.AreEqual(flagProperties2.Except(labelingProperties).ToArray().Length, 0);
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

            // all the not enumerated keywords, except 1 case.
            var allKeywordsExceptThese6 = (from t in concreteTypes
                                           from p in t.Properties?.Property
                                           where (p.hashtags.Contains("#KEYWORD") && !p.Enumeration()) ||
                                                 (p.name == "Keyword" && t.name == "PredefinedTypeSyntax")
                                           select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(allKeywordsExceptThese6.Except(readOnlyProperties).ToArray().Length, 0);

            var operators = (from t in concreteTypes
                             from p in t.Properties?.Property
                             where p.hashtags.Contains("#OPERATOR")
                             select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operators.Except(readOnlyProperties).ToArray().Length, 0);

            var allNotEnumeratedPunctuation = (from t in concreteTypes
                                               from p in t.Properties?.Property
                                               where p.hashtags.Contains("#PUNTUACTION") && !p.Enumeration() //p.name != "StartQuoteToken" && p.name != "EndQuoteToken" //&& !p.Enumeration()
                                               select new { Type = t, Property = p }).ToArray();
            //Assert.AreEqual(allNotEnumeratedPunctuation.Except(readOnlyProperties).ToArray().Length, 0);

            var symbolicProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.hashtags.Contains("#SYMBOLIC")
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

            var topologicallyRelevantProperties = (from t in concreteTypes
                                                   from p in t.Properties?.Property
                                                   where p.Rules?.Topology?.relevant ?? false
                                                   select new { Type = t, Property = p }).ToArray();

            var theseProperties = (from t in concreteTypes
                                   from p in t.Properties?.Property
                                   where (!p.hashtags.Contains("#KEYWORD") || (p.name == "DisableOrRestoreKeyword" && t.name == "PragmaWarningDirectiveTriviaSyntax")) &&
                                         !p.hashtags.Contains("#PUNTUACTION") &&
                                         !p.hashtags.Contains("#OPERATOR") &&
                                         !p.hashtags.Contains("#SYMBOLIC")
                                   select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(theseProperties.Except(topologicallyRelevantProperties).ToArray().Length, 0);
            Assert.AreEqual(topologicallyRelevantProperties.Except(theseProperties).ToArray().Length, 0);
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

        [TestMethod]
        public void DefinitionOfCollectionProperties()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = concreteTypes.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var collectionProperties = (from t in concreteTypes
                                        from p in t.Properties?.Property
                                        where p.Rules?.collection ?? false
                                        select new { Type = t, Property = p }).ToArray();

            var expectedCollectionProperties = (from t in concreteTypes
                                                from p in t.Properties?.Property
                                                let typeInfo = typeInfos.Any(ti => ti.Value.Type == t) ? typeInfos.Single(ti => ti.Value.Type == t).Value.Class : null
                                                let propertyInfo = typeInfo?.GetProperty(p.name)
                                                let propertyGenericTypeInfo = propertyInfo.PropertyType.IsGenericType
                                                    ? propertyInfo.PropertyType.GetGenericTypeDefinition()
                                                    : null
                                                let propertyElementType = typeInfos.Any(ti => ti.Value.Class == propertyInfo.PropertyType)
                                                    ? typeInfos.Single(ti => ti.Value.Class == propertyInfo.PropertyType).Value.Type
                                                    : null
                                                where p.type != "SyntaxToken" &&
                                                      (propertyInfo.PropertyType == typeof(SyntaxTokenList) ||
                                                       propertyGenericTypeInfo == typeof(SyntaxList<>) ||
                                                       propertyGenericTypeInfo == typeof(SeparatedSyntaxList<>) ||
                                                       (propertyElementType?.Rules?.collection ?? false))
                                                select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(expectedCollectionProperties.Except(collectionProperties).ToArray().Length, 0);
            Assert.AreEqual(collectionProperties.Except(expectedCollectionProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfCollectionTypes()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = concreteTypes.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var collectionTypes = (from t in concreteTypes
                                   where t.Rules?.collection ?? false
                                   select t).ToArray();

            var expectedCollectionTypes = (from t in concreteTypes
                                           where t.name == "VariableDeclarationSyntax" ||
                                                 (t.Properties?.Property.Any(pi => (pi.Rules?.collection ?? false) &&
                                                                                   (t.Properties?.Property.All(pj => pi == pj || pj.hashtags.Contains("#PUNTUACTION") || pj.hashtags.Contains("#KEYWORD")) ?? false))
                                                  ?? false)
                                           select t).ToArray();
            Assert.AreEqual(expectedCollectionTypes.Except(collectionTypes).ToArray().Length, 0);
            Assert.AreEqual(collectionTypes.Except(expectedCollectionTypes).ToArray().Length, 0);
        }

        [TestMethod]
        public void DefinitionOfExprDeclStatmnt()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var declarationTypes = (from t in concreteTypes
                                    where t.name.Contains("Declaration")
                                    select t).ToArray();

            var statementTypes = (from t in concreteTypes
                                    where t.name.Contains("Statement")
                                    select t).ToArray();

            var expressionTypes = (from t in concreteTypes
                                    where t.name.Contains("Expression")
                                    select t).ToArray();

            var a = declarationTypes.Intersect(statementTypes).ToArray();
            var b = declarationTypes.Intersect(expressionTypes).ToArray();
            var c = statementTypes.Intersect(expressionTypes).ToArray();
        }

        //[TestMethod]
        //public void DefinitionOf()
        //{
        //    var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
        //    var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

        //    var typeInfos = concreteTypes.Select(t => new
        //    {
        //        Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
        //        Type = t
        //    })
        //    .ToDictionary(m => m.Type.name);

        //    var allProperties = (from t in concreteTypes
        //                         from p in t.Properties?.Property
        //                         select new { Type = t, Property = p }).ToArray();

        //    var allNames = allProperties.Select(p => p.Property.name).Distinct();

        //    var nameFrequencies = (from n in allNames
        //                          let c = allProperties.Count(p => p.Property.name == n)
        //                          orderby c descending
        //                          select new { Name = n, Count = c }).ToArray();
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var nf in nameFrequencies)
        //    {
        //        int i = 0;
        //        foreach (var prop in allProperties.Where(p => p.Property.name == nf.Name))
        //        {
        //            sb.AppendLine($"#{++i} {prop.Property.name} in {prop.Type.name}");
        //        }

        //    }
        //    System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());

        //}

        [TestMethod]
        public void CommonTermsInElementTypeNames()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var words = (from t in concreteTypes
                         select Regex.Split(t.name, @"(?<!^)(?=[A-Z])").Where(s => s != "Syntax")).ToArray();
            //StringBuilder sb = new StringBuilder();
            //foreach (var wf in words)
            //{
            //    sb.AppendLine(wf.Aggregate("", (acc, s) => acc == "" ? s : $"{acc} {s}"));
            //}
            //System.IO.File.WriteAllText(@"D:\Reports\TypeNameWordsForWordsCloud.txt", sb.ToString());
        }

        [TestMethod]
        public void InheritanceRelationsAmongElementTypes()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var abstractTypeFrequencies = (from t in rdsl.Nodes.Type.Where(t1 => t1.@abstract).Select(t1 => typeInfos.Single(ti => ti.Value.Type == t1))
                                           let descendants = typeInfos.Values.Where(v => !v.Type.@abstract && t.Value.Class.IsAssignableFrom(v.Class)).ToArray()
                                           orderby descendants.Length descending
                                           select new { AbstractType = t, Descendants = descendants }).ToArray();
            //StringBuilder sb = new StringBuilder();
            //foreach (var atf in abstractTypeFrequencies)
            //{
            //    int i = 0;
            //    foreach (var type in atf.Descendants)
            //    {
            //        sb.AppendLine($"#{++i} {atf.AbstractType.Value.Class.Name} ---- {type.Class.Name}");
            //    }

            //}
            //System.IO.File.WriteAllText(@"D:\Reports\DescendantTypesPerAbstractTypes.txt", sb.ToString());
        }

        [TestMethod]
        public void InPersuitOfMeaningfulElementPropertyDefinitions()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var typesAndProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      let typeInfo = typeInfos.Single(ti => ti.Value.Type == t).Value.Class
                                      select new
                                      {
                                          Type = t,
                                          Property = p,
                                          TypeInfo = typeInfo,
                                          PropertyInfo = typeInfo.GetProperty(p.name)
                                      }).ToArray();

            var meaningfulProperties = (from t in typesAndProperties
                                        let propertyGenericTypeInfo = t.PropertyInfo.PropertyType.IsGenericType
                                                    ? t.PropertyInfo.PropertyType.GetGenericTypeDefinition()
                                                    : null
                                        let propertyElementType = typeInfos.Any(ti => ti.Value.Class == t.PropertyInfo.PropertyType)
                                                    ? typeInfos.Single(ti => ti.Value.Class == t.PropertyInfo.PropertyType).Value.Type
                                                    : null
                                        where t.PropertyInfo.PropertyType != typeof(SyntaxToken) &&
                                              t.PropertyInfo.PropertyType != typeof(CSharpSyntaxNode) &&
                                              t.PropertyInfo.PropertyType != typeof(ExpressionSyntax) &&
                                              propertyGenericTypeInfo != typeof(SyntaxList<>) &&
                                              propertyGenericTypeInfo != typeof(SeparatedSyntaxList<>) &&
                                              (!propertyElementType?.hashtags.Contains("#list") ?? false)
                                        select t).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var mp in meaningfulProperties)
            {
                sb.AppendLine($"{mp.Property.name} ({mp.PropertyInfo.PropertyType.Name}) ---- {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\MeaningfulElementPropertyDefinitions.txt", sb.ToString());

            sb = new StringBuilder();
            foreach (var mp in meaningfulProperties.OrderBy(m => m.Property.name))
            {
                sb.AppendLine($"{mp.Property.name} ({mp.PropertyInfo.PropertyType.Name}) ---- {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\MeaningfulElementPropertyDefinitions2.txt", sb.ToString());

            sb = new StringBuilder();
            foreach (var mp in meaningfulProperties.OrderBy(m => m.PropertyInfo.PropertyType.Name))
            {
                sb.AppendLine($"{mp.Property.name} ({mp.PropertyInfo.PropertyType.Name}) ---- {mp.Type.name}");
            }
            System.IO.File.WriteAllText(@"D:\Reports\MeaningfulElementPropertyDefinitions3.txt", sb.ToString());
        }

        private void ReportSuitableProperties(
            Func<Syntax.NodesLocalType.TypeLocalType, bool> suitableType,
            Func<Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType, bool> suitableProperty,
            string reportName)
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var existingProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      select new { Type = t, Property = p }).ToArray();

            var suitableTypes = (from info in concreteTypes
                                 where suitableType(info)
                                 select info).ToArray();

            var suitableProperties = (from info in existingProperties
                                      where suitableProperty(info.Property)
                                      select info).ToArray();

            var candidateHashtagsForProperties = suitableProperties.SelectMany(info => info.Property.hashtags).Where(ht => ht != "").Distinct().ToArray();
            var candidateHashtagsForTypes = suitableProperties.SelectMany(info => info.Property.hashtags).Where(ht => ht != "").Distinct().ToArray();

            var sb = new StringBuilder();
            var lineBuilder = new StringBuilder();
            lineBuilder.Append("Property;Type");
            foreach (var candidateHashtag in candidateHashtagsForProperties)
            {
                lineBuilder.Append($";{candidateHashtag}");
            }
            foreach (var candidateHashtag in candidateHashtagsForTypes)
            {
                lineBuilder.Append($";T{candidateHashtag}");
            }
            lineBuilder.Append(";SUITABLE");
            sb.AppendLine(lineBuilder.ToString());

            foreach (var info in existingProperties)
            {
                lineBuilder = new StringBuilder();
                lineBuilder.Append($"{info.Property.name};{info.Type.name}");
                foreach (var candidateHashtag in candidateHashtagsForProperties)
                {
                    lineBuilder.Append(info.Property.hashtags.Contains(candidateHashtag) ? ";t" : ";f");
                }
                foreach (var candidateHashtag in candidateHashtagsForTypes)
                {
                    lineBuilder.Append(info.Type.hashtags.Contains(candidateHashtag) ? ";t" : ";f");
                }
                lineBuilder.Append(suitableProperties.Any(i => i == info) ? ";t" : ";f");
                sb.AppendLine(lineBuilder.ToString());
            }
            System.IO.File.WriteAllText($@"D:\Reports\{reportName}.csv", sb.ToString());
        }

        [TestMethod]
        public void ReportForNameBasedSuitableProperties()
        {           
            this.ReportSuitableProperties(t => t.Rules?.Name?.suitability == "Key", 
                                          p => (p.Rules?.Name?.Count(n => n.suitability == "Key") ?? 0) > 0,
                                          "NameBasedSuitableProperties");
        }

        [TestMethod]
        public void DefinitionOf_IDENTIFIER_Property()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var suitableProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.hashtags.Contains("#IDENTIFIER")
                                      select new { Type = t, Property = p }).ToArray();

            var identifierProperties = (from t in concreteTypes
                                        from p in t.Properties?.Property
                                        where p.name == "Identifier" && t.name != "AttributeTargetSpecifierSyntax"
                                        select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(identifierProperties.Except(suitableProperties).ToArray().Length, 0);

            //var nameProperties = (from t in concreteTypes
            //                      from p in t.Properties?.Property
            //                      where p.name == "Name" && !p.readOnly //t.name != "XmlCrefAttributeSyntax" && t.name != "XmlNameAttributeSyntax"
            //                      select new { Type = t, Property = p }).ToArray();
            //Assert.AreEqual(nameProperties.Except(suitableProperties).ToArray().Length, 0);

            var thisKeywordProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.name == "ThisKeyword"
                                         select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(thisKeywordProperties.Except(suitableProperties).ToArray().Length, 0);

            var operatorTokenProperties = (from t in concreteTypes
                                           from p in t.Properties?.Property
                                           where p.name == "OperatorToken" && t.name.Contains("Operator")
                                           select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operatorTokenProperties.Except(suitableProperties).ToArray().Length, 0);

            var nameProperties = (from t in concreteTypes
                                                    from p in t.Properties?.Property
                                                    where p.name == "NameEquals" || 
                                                          p.name == "NameColon" || 
                                                          (p.name == "Name" && t.name == "AttributeSyntax")
                                                    select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(thisKeywordProperties.Except(suitableProperties).ToArray().Length, 0);

            //var prefixProperties = (from t in concreteTypes
            //                        from p in t.Properties?.Property
            //                        where p.name == "Prefix"
            //                        select new { Type = t, Property = p }).ToArray();
            //Assert.AreEqual(prefixProperties.Except(suitableProperties).ToArray().Length, 0);

            //var specialCases = (from t in concreteTypes
            //                    from p in t.Properties?.Property
            //                    where (p.name == "LocalName" && t.name == "XmlNameSyntax") ||
            //                          (p.name == "Variables" && t.name == "VariableDeclarationSyntax") ||
            //                          (p.name == "Cref" && t.name == "XmlCrefAttributeSyntax") ||
            //                          (p.name == "Expression" && t.name == "MemberAccessExpressionSyntax")
            //                    select new { Type = t, Property = p }).ToArray();
            //Assert.AreEqual(specialCases.Except(suitableProperties).ToArray().Length, 0);

            var propertiesSuitableSoFar = identifierProperties
                //.Union(nameProperties)
                .Union(thisKeywordProperties)
                .Union(operatorTokenProperties)
                .Union(nameProperties)
                //.Union(prefixProperties)
                //.Union(specialCases)
            .ToArray();

            var b1 = propertiesSuitableSoFar.Except(suitableProperties).ToArray();
            var b2 = suitableProperties.Except(propertiesSuitableSoFar).ToArray();

            var typeInfos = concreteTypes.Select(t => new
            {
                Class = typeof(CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var propertyTypeIsSuitableProperties = (from t in concreteTypes
                                                    from p in t.Properties?.Property
                                                    let typeInfo = typeInfos.Any(ti => ti.Value.Type == t) ? typeInfos.Single(ti => ti.Value.Type == t).Value.Class : null
                                                    let propertyInfo = typeInfo?.GetProperty(p.name)
                                                    let propertyGenericTypeInfo = propertyInfo?.PropertyType.IsGenericType ?? false
                                                        ? propertyInfo.PropertyType.GetGenericTypeDefinition()
                                                        : null
                                                    let collectionOf = propertyGenericTypeInfo == typeof(SyntaxList<>) || propertyGenericTypeInfo == typeof(SeparatedSyntaxList<>)
                                                        ? propertyInfo.PropertyType.GetGenericArguments().Single()
                                                        : null
                                                    let collectionOfType = collectionOf != null && typeInfos.Any(ti => ti.Value.Class == collectionOf)
                                                        ? typeInfos.Single(ti => ti.Value.Class == collectionOf).Value.Type
                                                        : null
                                                    let propertyElementType = typeInfos.Any(ti => ti.Value.Class == propertyInfo.PropertyType)
                                                        ? typeInfos.Single(ti => ti.Value.Class == propertyInfo.PropertyType).Value.Type
                                                        : null
                                                    where !p.readOnly &&
                                                          (typeof(NameSyntax).IsAssignableFrom(propertyInfo?.PropertyType) ||
                                                          (propertyElementType != null && propertiesSuitableSoFar.Any(psf => psf.Type == propertyElementType)))
                                                    select new { Type = t, Property = p }).ToArray();

            var a = propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray();
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //foreach (var prop in suitableProperties)
            //{
            //    int i = 0;
            //    sb.AppendLine($"#{++i} {prop.Property.name} in {prop.Type.name}");

            //}
            //System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());
            var b = suitableProperties.Except(propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties)).ToArray();
            Assert.AreEqual(propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray().Length, 0);
            Assert.AreEqual(suitableProperties.Except(propertyTypeIsSuitableProperties).ToArray().Length, 0);
        }

        [TestMethod]
        public void NameBasedSuitableProperties()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var existingProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      select new { Type = t, Property = p }).ToArray();

            var suitableProperties = (from info in existingProperties
                                      where (info.Property.Rules?.Name?.Count(n => n.suitability == "Key") ?? 0) > 0
                                      select info).ToArray();

            var declarationIdentifiers = (from info in existingProperties
                                          where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#DECLARATION#Member")
                                          select info).ToArray();
            var d1 = declarationIdentifiers.Except(suitableProperties).ToArray();
            var d2 = suitableProperties.Except(declarationIdentifiers).ToArray();
            Assert.IsTrue(suitableProperties.Count() > suitableProperties.Except(declarationIdentifiers).Count());

            var explicitInterfaceSpecifiers = (from info in existingProperties
                                               where info.Property.name == "ExplicitInterfaceSpecifier"
                                               select info).ToArray();
            var discoveredProperties1 = declarationIdentifiers.Union(explicitInterfaceSpecifiers).ToArray();
            var d3 = discoveredProperties1.Except(suitableProperties).ToArray();
            var d4 = suitableProperties.Except(discoveredProperties1).ToArray();
            Assert.IsTrue(suitableProperties.Except(declarationIdentifiers).Count() > suitableProperties.Except(discoveredProperties1).Count());

            var DECLARATIONIdentifiers = (from info in existingProperties
                                          where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#DECLARATION")
                                          select info).ToArray();
            var discoveredProperties2 = discoveredProperties1.Union(DECLARATIONIdentifiers).ToArray();
            var d5 = discoveredProperties2.Except(suitableProperties).ToArray();
            var d6 = suitableProperties.Except(discoveredProperties2).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties1).Count() > suitableProperties.Except(discoveredProperties2).Count());

            var directiveIdentifiers = (from info in existingProperties
                                          where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#directive")
                                          select info).ToArray();
            var discoveredProperties3 = discoveredProperties2.Union(directiveIdentifiers).ToArray();
            var d7 = discoveredProperties3.Except(suitableProperties).ToArray();
            var d8 = suitableProperties.Except(discoveredProperties3).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties2).Count() > suitableProperties.Except(discoveredProperties3).Count());

            var QUERYIdentifiers = (from info in existingProperties
                                    where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#QUERY")
                                    select info).ToArray();
            var discoveredProperties4 = discoveredProperties3.Union(QUERYIdentifiers).ToArray();
            var d9 = discoveredProperties4.Except(suitableProperties).ToArray();
            var d10 = suitableProperties.Except(discoveredProperties4).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties3).Count() > suitableProperties.Except(discoveredProperties4).Count());

            var crefIdentifiers = (from info in existingProperties
                                               where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#Cref")
                                               select info).ToArray();
            var discoveredProperties5 = discoveredProperties4.Union(crefIdentifiers).ToArray();
            var d11 = discoveredProperties5.Except(suitableProperties).ToArray();
            var d12 = suitableProperties.Except(discoveredProperties5).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties4).Count() > suitableProperties.Except(discoveredProperties5).Count());

            var XMLIdentifiers = (from info in existingProperties
                                   where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#xml")
                                   select info).ToArray();
            var discoveredProperties6 = discoveredProperties5.Union(XMLIdentifiers).ToArray();
            var d13 = discoveredProperties6.Except(suitableProperties).ToArray();
            var d14 = suitableProperties.Except(discoveredProperties6).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties5).Count() > suitableProperties.Except(discoveredProperties6).Count());

            var argumentIdentifiers = (from info in existingProperties
                                  where info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.hashtags.Contains("#argument")
                                  select info).ToArray();
            var discoveredProperties7 = discoveredProperties6.Union(argumentIdentifiers).ToArray();
            var d15 = discoveredProperties7.Except(suitableProperties).ToArray();
            var d16 = suitableProperties.Except(discoveredProperties7).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties6).Count() > suitableProperties.Except(discoveredProperties7).Count());

            var specialCases = (from info in existingProperties
                                where //(info.Property.name == "Continuation" && info.Property.name == "QueryBodySyntax") &&
                                      (info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.name == "TupleElementSyntax") ||
                                      (info.Property.hashtags.Contains("#IDENTIFIER") && info.Type.name == "SingleVariableDesignationSyntax")
                                select info).ToArray();
            var discoveredProperties8 = discoveredProperties7.Union(specialCases).ToArray();
            var d17 = discoveredProperties8.Except(suitableProperties).ToArray();
            var d18 = suitableProperties.Except(discoveredProperties8).ToArray();
            Assert.IsTrue(suitableProperties.Except(discoveredProperties7).Count() > suitableProperties.Except(discoveredProperties8).Count());

            Assert.AreEqual(discoveredProperties8.Except(suitableProperties).ToArray().Length, 0);
            Assert.AreEqual(suitableProperties.Except(discoveredProperties8).ToArray().Length, 0);
        }

        [TestMethod]
        public void PropertyTypesAreWellDefined()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var expressionTypes = (from t in concreteTypes
                                   from p in t.Properties.Property
                                   let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
                                   select new
                                   {
                                       TypeInfo = typeInfo,
                                       PropertyInfo = typeInfo.Value.Class.GetProperty(p.name),
                                       Property = p
                                   }).ToArray();
            foreach (var et in expressionTypes)
            {
                Assert.AreEqual(et.Property.type, et.PropertyInfo.PropertyType.Name.Split(new[] { "`" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }
        }

        [TestMethod]
        public void DefinitionOf()
        {
            var rdsl = Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var typeInfos = rdsl.Nodes.Type.Select(t => new
            {
                Class = typeof(CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var expressionTypes = (from t in concreteTypes
                                   from p in t.Properties.Property
                                   let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
                                   select new
                                   {
                                       TypeInfo = typeInfo,
                                       PropertyInfo = typeInfo.Value.Class.GetProperty(p.name),
                                       Property = p
                                   }).ToArray();
            foreach (var et in expressionTypes)
            {
                Assert.AreEqual(et.Property.type, et.PropertyInfo.PropertyType.Name.Split(new[] { "`" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            //var words = (from t in concreteTypes
            //             from word in Regex.Split(t.name, @"(?<!^)(?=[A-Z])")
            //             select word).Distinct().ToArray();

            ////var allNames = allProperties.Select(p => p.Property.name).Distinct();

            //var wordFrequencies = (from w in words
            //                       where w != "Syntax" && w != "C"
            //                       let c = concreteTypes.Count(t => t.name.Contains(w))
            //                       orderby c descending
            //                       select new { Word = w, Count = c }).ToArray();

            var words = (from t in concreteTypes
                             //from word in Regex.Split(t.name, @"(?<!^)(?=[A-Z])")
                         select Regex.Split(t.name, @"(?<!^)(?=[A-Z])").Where(s => s != "Syntax")).ToArray();
            //StringBuilder sb = new StringBuilder();
            //foreach (var wf in wordFrequencies)
            //{
            //    int i = 0;
            //    foreach (var type in concreteTypes.Where(t => t.name.Contains(wf.Word)))
            //    {
            //        sb.AppendLine($"#{++i} {wf.Word} in {type.name}");
            //    }
            //}
            //var expressionTypes = (from t in concreteTypes
            //                       from p in t.Properties.Property
            //                       let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
            //                       let result = new
            //                       {
            //                           TypeInfo = typeInfo,
            //                           PropertyInfo = typeInfo.Value.Class.GetProperty(p.name),
            //                           PropertyGenericTypeInfo = typeInfo.Value.Class.GetProperty(p.name).PropertyType.IsGenericType
            //                            ? typeInfo.Value.Class.GetProperty(p.name).PropertyType.GetGenericTypeDefinition()
            //                            : null
            //                       }
            //                       where result.PropertyInfo.PropertyType == typeof(CSharpSyntaxNode)
            //                       //let propertyInfos = 
            //                       //where typeof(ExpressionSyntax).IsAssignableFrom(typeInfo.Value.Class)
            //                       select result).ToArray();
            //foreach (var wf in words)
            //{
            //    sb.AppendLine(wf.Aggregate("", (acc, s) => acc == "" ? s : $"{acc} {s}"));
            //}
            //System.IO.File.WriteAllText(@"D:\Reports\TypeNameWordsForWordsCloud.txt", sb.ToString());

            //var declarationTypes = (from t in concreteTypes
            //                        let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
            //                        where typeof(declara)
            //                        select t).ToArray();

            //var abstractTypeFrequencies = (from t in rdsl.Nodes.Type.Where(t1 => t1.@abstract).Select(t1 => typeInfos.Single(ti => ti.Value.Type == t1))
            //                               let descendants = typeInfos.Values.Where(v => !v.Type.@abstract && t.Value.Class.IsAssignableFrom(v.Class)).ToArray()
            //                               orderby descendants.Length descending
            //                               select new { AbstractType = t, Descendants = descendants}).ToArray();
            //StringBuilder sb = new StringBuilder();
            //foreach (var atf in expressionTypes)
            //{
            //    sb.AppendLine($"{atf.PropertyInfo.Name} ---- {atf.TypeInfo.Value.Type.name}");
            //    //foreach (var type in atf.Descendants)
            //    //{
            //    //    sb.AppendLine($"#{++i} {atf.AbstractType.Value.Class.Name} ---- {type.Class.Name}");
            //    //}

            //    //int i = 0;
            //    //foreach (var type in atf.Descendants)
            //    //{
            //    //    sb.AppendLine($"#{++i} {atf.AbstractType.Value.Class.Name} ---- {type.Class.Name}");
            //    //}

            //}
            //System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());

            //var statementTypes = (from t in concreteTypes
            //                      let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
            //                      where typeof(StatementSyntax).IsAssignableFrom(typeInfo.Value.Class)
            //                      select t).ToArray();

            //var expressionTypes = (from t in concreteTypes
            //                       let typeInfo = typeInfos.Single(ti => ti.Value.Type == t)
            //                       where typeof(ExpressionSyntax).IsAssignableFrom(typeInfo.Value.Class)
            //                       select t).ToArray();

        }
    }
}
