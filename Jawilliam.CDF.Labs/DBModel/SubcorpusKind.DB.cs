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
    
    [Flags]
    public enum SubcorpusKind : int
    {
        RatioLvGtHigherOutlier = 2,
        RatioLvGtLowerOutlier = 4,
        RatioLvGtRandom = 1,
        None = 0,
        RatioLvGtMedianCloserExact = 16,
        RatioLvGtMedianCloserHigh = 32,
        RatioLvGtMedianCloserLow = 64,
        NotAssigned = 512,
        RatioLvGtOutlierRandom = 8,
        RatioLvGtMedianCloserRandom = 128
    }
}
