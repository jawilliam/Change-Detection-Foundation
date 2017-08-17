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
    
    public partial class FileRevisionPair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileRevisionPair()
        {
            this.Copies = new HashSet<FileModifiedChange>();
            this.Reviews = new HashSet<Review>();
            this.Versioning = new PairRevisionInfo();
        }
    
        public System.Guid Id { get; set; }
        public string Annotations { get; set; }
        public Nullable<RevisionPairFlags> Flags { get; set; }
    
        public PairRevisionInfo Versioning { get; set; }
    
        public virtual FileModifiedChange Principal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileModifiedChange> Copies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
