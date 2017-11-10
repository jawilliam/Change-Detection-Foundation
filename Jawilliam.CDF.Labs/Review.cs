//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jawilliam.CDF.Labs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public System.Guid Id { get; set; }
        public ReviewKind Kind { get; set; }
        public ReviewSeverity Severity { get; set; }
        public string Subject { get; set; }
        public string Comments { get; set; }
        public Topics Topics { get; set; }
        public string Annotations { get; set; }
        public CaseKind CaseKind { get; set; }
        public Nullable<bool> SpuriousMatch { get; set; }
        public Nullable<bool> UnnaturalMatch { get; set; }
        public Nullable<bool> GhostMatch { get; set; }
        public Nullable<bool> MissedMatch { get; set; }
        public Nullable<bool> ArbitraryMatch { get; set; }
        public Nullable<bool> RedundantChanges { get; set; }
        public Nullable<bool> GhostChanges { get; set; }
        public Nullable<bool> SpuriousChanges { get; set; }
    
        public virtual FileRevisionPair RevisionPair { get; set; }
    }
}
