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
    
    public partial class OM_CASTING_SO
    {
        public int SOSEQ { get; set; }
        public bool ISPRINTED { get; set; }
        public string STATUS { get; set; }
        public int SALETYPE { get; set; }
        public string SALE_TYPE { get; set; }
        public string CUSTCODE { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string SONO { get; set; }
        public Nullable<System.DateTime> SALE_DATE { get; set; }
        public Nullable<System.DateTime> DELIVERY_DATE { get; set; }
        public Nullable<System.DateTime> DUE_DATE { get; set; }
        public Nullable<int> FISCYEAR { get; set; }
        public Nullable<int> FISCPERIOD { get; set; }
        public string CREDITCODE { get; set; }
        public int CREDITTERM { get; set; }
        public decimal TOTALVALUE { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal NETVALUE { get; set; }
        public string VATPERCENT { get; set; }
        public decimal VATVALUE { get; set; }
        public decimal TOTALAMOUNT { get; set; }
        public string TOTALAMOUNTTEXT { get; set; }
        public int DELIVERMAT { get; set; }
        public string CATEGORY { get; set; }
        public string MATERIAL { get; set; }
        public decimal DELIVERWEIGHT { get; set; }
        public decimal RECEIVEWEIGHT { get; set; }
        public decimal OUTSTANDWEIGHT { get; set; }
        public decimal SI { get; set; }
        public decimal SIWEIGHT { get; set; }
        public int BILLSEQ { get; set; }
        public string BILLNO { get; set; }
        public Nullable<System.DateTime> BILL_DATE { get; set; }
        public Nullable<System.DateTime> BILL_DUE_DATE { get; set; }
    }
}