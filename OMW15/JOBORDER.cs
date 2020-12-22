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
    
    public partial class JOBORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOBORDER()
        {
            this.JOBINFOS = new HashSet<JOBINFO>();
        }
    
        public int JOBNO { get; set; }
        public decimal JOBDATE { get; set; }
        public int PRIORITY { get; set; }
        public int STATUS { get; set; }
        public bool ISREWORKS { get; set; }
        public bool ISCANCEL { get; set; }
        public bool ISPRINTED { get; set; }
        public decimal RELEASEDATE { get; set; }
        public decimal STARTDATE { get; set; }
        public decimal FINISHDATE { get; set; }
        public int CUSTID { get; set; }
        public string CUSTCODE { get; set; }
        public int MATERIALTYPE { get; set; }
        public decimal SI { get; set; }
        public string CUSTPO { get; set; }
        public decimal PODATE { get; set; }
        public decimal DUEDATE { get; set; }
        public Nullable<int> REMAINDAY { get; set; }
        public Nullable<int> ITEMID { get; set; }
        public string PREFIX { get; set; }
        public string ITEMNO { get; set; }
        public string ITEMNAME { get; set; }
        public int ITEMSTYLE { get; set; }
        public string FLASK_TEMP { get; set; }
        public string CAST_TEMP { get; set; }
        public string ORDERUNIT { get; set; }
        public decimal ORDERQTY { get; set; }
        public decimal FINISHEDQTY { get; set; }
        public Nullable<decimal> BACKORDQTY { get; set; }
        public Nullable<decimal> ACTUALPRODUCTIONQTY { get; set; }
        public bool ISPRICEWITHMAT { get; set; }
        public decimal CASTINGPRICE { get; set; }
        public decimal TOTALCASTINGPRICE { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal TOTALPRICE { get; set; }
        public decimal UNITWEIGHT { get; set; }
        public decimal TOTALWEIGHT { get; set; }
        public decimal WAXUNITWEIGHT { get; set; }
        public decimal TOTALWAXWEIGHT { get; set; }
        public bool MAKEBLOCK { get; set; }
        public bool WAX { get; set; }
        public bool CASTING { get; set; }
        public decimal DELIVERYQTY { get; set; }
        public decimal DELIVERYDATE { get; set; }
        public string DOCNUM { get; set; }
        public string REMARK { get; set; }
        public string WAXWORKER { get; set; }
        public string FINISHINGWORKER { get; set; }
        public string AUDITUSER { get; set; }
        public Nullable<decimal> AUDITDATE { get; set; }
        public string MODIUSER { get; set; }
        public Nullable<decimal> MODIDATE { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOBINFO> JOBINFOS { get; set; }
    }
}
