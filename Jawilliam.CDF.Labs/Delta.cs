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
    
    public partial class Delta
    {
        public System.Guid Id { get; set; }
        public string Matching { get; set; }
        public string Differencing { get; set; }
        public string Report { get; set; }
        public string Annotations { get; set; }
        public ChangeDetectionApproaches Approach { get; set; }
        public string OriginalTree { get; set; }
        public string ModifiedlTree { get; set; }
    
        public virtual FileModifiedChange RevisionPair { get; set; }
    }
}
