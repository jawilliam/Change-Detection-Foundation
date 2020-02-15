//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jawilliam.CDF.Labs.DBModel
{
    using System;
    
    public enum ChangeDetectionApproaches : int
    {
        Manually = 0,
        Simetrics = 1,
        NativeGumTree = 2,
        NativeGumTreeWithoutComments = 3,
        NativeGumTreeMethodsWithoutComments = 4,
        InverseOfNativeGumTree = 5,
        NativeGumTreeWithChangeDistillerMatcher = 6,
        InverseOfNativeGumTreeWithChangeDistillerMatcher = 7,
        NativeGumTreeWithXyMatcher = 8,
        InverseOfNativeGumTreeWithXyMatcher = 9,
        NativeGTtreefiedRoslynML = 10,
        InverseNativeGTtreefiedRoslynML = 11,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 = 12,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 = 13,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 = 14,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 = 15,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 = 16,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 = 17,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 = 18,
        NativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 = 19,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size100 = 20,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size325 = 21,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size550 = 22,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size775 = 23,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1225 = 24,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1450 = 25,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1675 = 26,
        InverseNativeGTtreefiedRoslynMLWithMinH2Sim0d5Size1900 = 27,
        NativeGTtreefiedRoslynMLWithBasicPruning = 28,
        InverseNativeGTtreefiedRoslynMLWithBasicPruning = 29,
        NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia = 30,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia = 31,
        NativeGTtreefiedRoslynMLWithIncludeTrivia = 32,
        InverseNativeGTtreefiedRoslynMLWithIncludeTrivia = 33,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliation = 34,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliation = 35,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTrivia = 36,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTrivia = 37,
        NativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling = 38,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling = 39,
        NativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling = 40,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling = 41,
        NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling = 42,
        InverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling = 43,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling = 44,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling = 45,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling = 46,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling = 47,
        NativeGTtreefiedRoslynMLAndPermissiveLabeling = 48,
        InverseNativeGTtreefiedRoslynMLAndPermissiveLabeling = 49,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 = 50,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 = 51,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia = 52,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia = 53,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling = 54,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling = 55,
        NativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling = 56,
        InverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling = 57,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruning = 1028,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruning = 1029,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia = 1030,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia = 1031,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliation = 1034,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliation = 1035,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTrivia = 1036,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTrivia = 1037,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling = 1038,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling = 1039,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling = 1040,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling = 1041,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling = 1044,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndPermissiveLabeling = 1045,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling = 1046,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationAndIncludeTriviaAndPermissiveLabeling = 1047,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 = 1050,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1 = 1051,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia = 1052,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia = 1053,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling = 1054,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling = 1055,
        ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling = 1056,
        ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling = 1057,
        RepairedNativeGTtreefiedRoslynML = 2010,
        RepairedNativeGTtreefiedRoslynMLWithIncludeTrivia = 2032,
        RepairedNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling = 2042,
        RepairedNativeGTtreefiedRoslynMLAndPermissiveLabeling = 2048
    }
}
