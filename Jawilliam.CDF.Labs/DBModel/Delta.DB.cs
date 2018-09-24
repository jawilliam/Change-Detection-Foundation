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
    
    public partial class Delta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delta()
        {
            this.Symptoms = new HashSet<Symptom>();
        }
    
        public System.Guid Id { get; set; }
        public string Matching { get; set; }
        public string Differencing { get; set; }
        public string Report { get; set; }
        public string Annotations { get; set; }
        public ChangeDetectionApproaches Approach { get; set; }
        public string OriginalTree { get; set; }
        public string ModifiedTree { get; set; }
        public Nullable<SubcorpusKind> GlobalSubcorpus { get; set; }
        public Nullable<SubcorpusKind> GlobalInsertPorcentageSubcorpus { get; set; }
        public Nullable<SubcorpusKind> GlobalDeletePorcentageSubcorpus { get; set; }
        public Nullable<SubcorpusKind> GlobalUpdatePorcentageSubcorpus { get; set; }
        public Nullable<SubcorpusKind> GlobalMovePorcentageSubcorpus { get; set; }
    
        public virtual FileModifiedChange RevisionPair { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Symptom> Symptoms { get; set; }
        public virtual DeltaContentSummary ContentSummary { get; set; }
    }
}
