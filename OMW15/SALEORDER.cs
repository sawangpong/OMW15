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
    
    public partial class SALEORDER
    {
        public bool ISDELETE { get; set; }
        public bool ISCANCEL { get; set; }
        public decimal SOCANCELDATE { get; set; }
        public bool ISCOMPLETE { get; set; }
        public bool ISPRINTED { get; set; }
        public bool ISVAT { get; set; }
        public int VATCAL { get; set; }
        public int SALETYPE { get; set; }
        public bool ISAUTONUMBER { get; set; }
        public int SOLINECOUNT { get; set; }
        public int SALEMATID { get; set; }
        public Nullable<System.Guid> SO_GUID { get; set; }
        public int SOSEQ { get; set; }
        public int RUNNINGNO { get; set; }
        public string SONO { get; set; }
        public decimal SODATE { get; set; }
        public decimal ACTUALDELIVERDT { get; set; }
        public decimal DUEDATE { get; set; }
        public string SALEDETAILS { get; set; }
        public int FISCYEAR { get; set; }
        public int FISCPERIOD { get; set; }
        public int CUSTID { get; set; }
        public string CUSTCODE { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string CREDITCODE { get; set; }
        public int CREDITTERM { get; set; }
        public decimal TOTALVALUE { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal NETVALUE { get; set; }
        public string VATPERCENT { get; set; }
        public decimal VATVALUE { get; set; }
        public decimal TOTALAMOUNT { get; set; }
        public string TOTALAMOUNTTEXT { get; set; }
        public int BILLSEQ { get; set; }
        public string BILLNO { get; set; }
        public decimal BILLDATE { get; set; }
        public decimal BILLDUEDATE { get; set; }
        public int INVSEQ { get; set; }
        public string INVOICENO { get; set; }
        public decimal INVOICEDATE { get; set; }
        public string MATDOCNO { get; set; }
        public int DELIVERMAT { get; set; }
        public decimal DELIVERWEIGHT { get; set; }
        public decimal RECEIVEWEIGHT { get; set; }
        public decimal OUTSTANDWEIGHT { get; set; }
        public decimal SI { get; set; }
        public decimal SIWEIGHT { get; set; }
        public string REMARK { get; set; }
        public string AUDITUSER { get; set; }
        public System.DateTime AUDITTIME { get; set; }
        public string MODIUSER { get; set; }
        public System.DateTime MODIFYTIME { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}