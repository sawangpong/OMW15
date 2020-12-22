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
    
    public partial class PMCONTRACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PMCONTRACT()
        {
            this.PMMCs = new HashSet<PMMC>();
        }
    
        public int ID { get; set; }
        public int PM_STATUS { get; set; }
        public string PMY { get; set; }
        public int RUNNUM { get; set; }
        public string PM_CONTRACT_KEY { get; set; }
        public System.DateTime PM_CONTRACT_DATE { get; set; }
        public string PM_CUSTCODE { get; set; }
        public string PM_CUSTOMER { get; set; }
        public System.DateTime PM_START { get; set; }
        public System.DateTime PM_END { get; set; }
        public string AUDIUSER { get; set; }
        public string MODIUSER { get; set; }
        public Nullable<System.DateTime> MODIDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PMMC> PMMCs { get; set; }
    }
}
