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
    
    public partial class FileFormat
    {
        public System.Guid Id { get; set; }
        public FileFormatKind Kind { get; set; }
        public Nullable<FileFormatError> Error { get; set; }
        public string XmlTree { get; set; }
        public string XTextTree { get; set; }
        public string TextTree { get; set; }
        public string Annotations { get; set; }
    
        public virtual FileVersion FileVersion { get; set; }
    }
}
