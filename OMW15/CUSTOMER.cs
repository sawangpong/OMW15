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
    
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.CUSTPRICELISTs = new HashSet<CUSTPRICELIST>();
            this.JOBORDERS = new HashSet<JOBORDER>();
            this.MATRECEIVEs = new HashSet<MATRECEIVE>();
            this.SALEORDERS = new HashSet<SALEORDER>();
        }
    
        public bool ISDELETE { get; set; }
        public bool ISWARNING { get; set; }
        public string CUSTTAXID { get; set; }
        public bool VATABLE { get; set; }
        public string VATRATE { get; set; }
        public string CUSTGROUPKEY { get; set; }
        public Nullable<bool> ISHEADQUARTERS { get; set; }
        public Nullable<int> BRANCHNUMBER { get; set; }
        public int CUSTID { get; set; }
        public string CUSTCODE { get; set; }
        public string CUSTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string DISTRICT { get; set; }
        public string PROVINCE { get; set; }
        public string POSTAL { get; set; }
        public string COUNTRY { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string CUSTEMAIL { get; set; }
        public string CUSTWWW { get; set; }
        public string CONTACTPERSON { get; set; }
        public string CELLPHONE1 { get; set; }
        public string SALEPERSON { get; set; }
        public decimal MATERIALLIMIT { get; set; }
        public decimal CREDITLIMIT { get; set; }
        public string CURRENCY { get; set; }
        public string CREDITCODE { get; set; }
        public int DATEBILL { get; set; }
        public int DATEPAY { get; set; }
        public string BILLINGPOINT { get; set; }
        public string PAYMENTPOINT { get; set; }
        public string CUSTREMARK { get; set; }
        public string AUDITUSER { get; set; }
        public Nullable<System.DateTime> AUDITDATE { get; set; }
        public string MODIUSER { get; set; }
        public System.DateTime MODIDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTPRICELIST> CUSTPRICELISTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOBORDER> JOBORDERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATRECEIVE> MATRECEIVEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALEORDER> SALEORDERS { get; set; }
    }
}
