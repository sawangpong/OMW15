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
    
    public partial class DOCTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTYPE()
        {
            this.DOCINFOes = new HashSet<DOCINFO>();
            this.SKUWARELOCATIONs = new HashSet<SKUWARELOCATION>();
        }
    
        public int DT_KEY { get; set; }
        public string DT_DOCCODE { get; set; }
        public string DT_THAIDESC { get; set; }
        public string DT_ENGDESC { get; set; }
        public Nullable<int> DT_PROPERTIES { get; set; }
        public short DT_RUNTYPE { get; set; }
        public string DT_PREFIX { get; set; }
        public short DT_DIGIT { get; set; }
        public Nullable<int> DT_BOOKSIZE { get; set; }
        public short DT_ACCESS { get; set; }
        public string DT_CANEDIT { get; set; }
        public Nullable<int> DT_DUPTYPE { get; set; }
        public string DT_RPF_CODE { get; set; }
        public Nullable<int> DT_SHOW_SINCE { get; set; }
        public Nullable<int> DT_SHOW_NEXT { get; set; }
        public Nullable<int> DT_NEW_SINCE { get; set; }
        public Nullable<int> DT_NEW_NEXT { get; set; }
        public string DT_ENABLE { get; set; }
        public Nullable<int> DT_PREVIEW { get; set; }
        public Nullable<int> DT_NEED_APV { get; set; }
        public Nullable<int> DT_SELECT_PRT { get; set; }
        public Nullable<int> DT_APV_POS { get; set; }
        public Nullable<int> DT_EDIT_AF_POS { get; set; }
        public Nullable<int> DT_EDIT_PRT_POS { get; set; }
        public Nullable<int> DT_CHANGE_POS { get; set; }
        public Nullable<int> DT_CANCEL_POS { get; set; }
        public Nullable<int> DT_REPRT_POS { get; set; }
        public string DT_REF_B4_PRINT { get; set; }
        public string DT_PRINT_CANCEL { get; set; }
        public string DT_REPRT_MSG { get; set; }
        public string DT_VAT_PREFIX { get; set; }
        public string DT_BRANCH { get; set; }
        public string DT_LASTUPD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCINFO> DOCINFOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKUWARELOCATION> SKUWARELOCATIONs { get; set; }
    }
}
