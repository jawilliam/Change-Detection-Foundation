//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ElementTypeRevisionPairSummary : DeltaContentSummary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ElementTypeRevisionPairSummary()
        {
            this.Commonalities = new HashSet<CommonElementTypeSummary>();
        }
    
        public int ElementType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommonElementTypeSummary> Commonalities { get; set; }
    }
}