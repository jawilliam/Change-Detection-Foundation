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
    
    public partial class Project
    {
        public System.Guid Id { get; set; }
        public string FullName { get; set; }
        public string AbbreviatedName { get; set; }
        public System.DateTime From { get; set; }
        public System.DateTime To { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Annotations { get; set; }
    }
}
