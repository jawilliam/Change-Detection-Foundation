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
    
    public partial class FileVersion : RepositoryObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileVersion()
        {
            this.Changes = new HashSet<FileChange>();
            this.BackwardModifiedChanges = new HashSet<FileModifiedChange>();
            this.Formats = new HashSet<FileFormat>();
        }
    
        public string Path { get; set; }
    
        public virtual FileContent Content { get; set; }
        public virtual File File { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileChange> Changes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileModifiedChange> BackwardModifiedChanges { get; set; }
        public virtual FileContentSummary ContentSummary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileFormat> Formats { get; set; }
    }
}