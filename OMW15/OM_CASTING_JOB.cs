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
    
    public partial class OM_CASTING_JOB
    {
        public bool ISCANCEL { get; set; }
        public bool ISREWORKS { get; set; }
        public int STATUS { get; set; }
        public string STATUSNAME { get; set; }
        public int JOBNO { get; set; }
        public string CUSTCODE { get; set; }
        public string CUSTNAME { get; set; }
        public Nullable<int> STARTYEAR { get; set; }
        public Nullable<int> STARTPERIOD { get; set; }
        public Nullable<System.DateTime> ORDERDATE { get; set; }
        public Nullable<System.DateTime> START { get; set; }
        public Nullable<System.DateTime> DUE { get; set; }
        public Nullable<int> RD { get; set; }
        public Nullable<System.DateTime> FINISH { get; set; }
        public Nullable<int> ITEMID { get; set; }
        public string PREFIX { get; set; }
        public string ITEMNO { get; set; }
        public string ITEMNAME { get; set; }
        public int MATERIALTYPE { get; set; }
        public string MATERIAL { get; set; }
        public int ITEMSTYLE { get; set; }
        public string STYLE { get; set; }
        public string ORDERUNIT { get; set; }
        public decimal ORDERQTY { get; set; }
        public decimal DELIVERYQTY { get; set; }
        public Nullable<decimal> BACKORDQTY { get; set; }
        public decimal CASTINGPRICE { get; set; }
        public decimal UNITPRICE { get; set; }
        public string IMAGE_LOCATION { get; set; }
        public string REMARK { get; set; }
    }
}
