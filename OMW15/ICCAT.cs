//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMW15
{
    using System;
    using System.Collections.Generic;
    
    public partial class ICCAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ICCAT()
        {
            this.SKUMASTERs = new HashSet<SKUMASTER>();
        }
    
        public int ICCAT_KEY { get; set; }
        public string ICCAT_CODE { get; set; }
        public string ICCAT_NAME { get; set; }
        public short ICCAT_ACCESS { get; set; }
        public decimal ICCAT_UDF_1 { get; set; }
        public decimal ICCAT_UDF_2 { get; set; }
        public decimal ICCAT_UDF_3 { get; set; }
        public decimal ICCAT_UDF_4 { get; set; }
        public decimal ICCAT_UDF_5 { get; set; }
        public decimal ICCAT_UDF_6 { get; set; }
        public string ICCAT_LASTUPD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKUMASTER> SKUMASTERs { get; set; }
    }
}