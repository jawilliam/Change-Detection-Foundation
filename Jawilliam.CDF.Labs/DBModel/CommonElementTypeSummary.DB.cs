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
    using System.Collections.Generic;
    
    public partial class CommonElementTypeSummary : DeltaContentSummary
    {
        public int ElementType { get; set; }
        public Nullable<long> Tf { get; set; }
        public Nullable<long> Idf { get; set; }
        public Nullable<long> Tf_Idf { get; set; }
    
        public virtual ElementTypeRevisionPairSummary CommonAncestor { get; set; }
    }
}