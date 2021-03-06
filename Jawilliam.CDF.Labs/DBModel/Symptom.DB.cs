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
    
    public abstract partial class Symptom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Symptom()
        {
            this.Symptoms = new HashSet<Symptom>();
            this.Certainty = new Certainty();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<SymptomNotes> Notes { get; set; }
        public Nullable<bool> IsTop { get; set; }
    
        public Certainty Certainty { get; set; }
    
        public virtual Delta Delta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Symptom> Symptoms { get; set; }
        public virtual Symptom Parent { get; set; }
    }
}
