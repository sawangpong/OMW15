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
    
    public partial class PRODUCTIONJOB
    {
        public int PDJOBID { get; set; }
        public int STATUS { get; set; }
        public string CUSTCODE { get; set; }
        public string CUSTOMERNAME { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> RELEASEDATE { get; set; }
        public Nullable<System.DateTime> DUEDATE { get; set; }
        public Nullable<int> DAYREMAIN { get; set; }
        public Nullable<System.DateTime> COMPLETEDATE { get; set; }
        public int JOBYEAR { get; set; }
        public int ERP_DI { get; set; }
        public string ERP_ORDER { get; set; }
        public string ERP_ORDERINFO { get; set; }
        public Nullable<int> FORMULA_ID { get; set; }
        public string FORMULA_NUMBER { get; set; }
        public string ERP_ISSUE { get; set; }
        public int ISSUE_ID { get; set; }
        public string JOBTYPE { get; set; }
        public string DRAWINGNO { get; set; }
        public string DRAWINGREV { get; set; }
        public string ITEMNO { get; set; }
        public string ITEMNAME { get; set; }
        public string ITEMNOTE { get; set; }
        public string SN { get; set; }
        public string UNITORDER { get; set; }
        public decimal QORDER { get; set; }
        public decimal SHIPQTY { get; set; }
        public Nullable<decimal> REMAINQTY { get; set; }
        public string RECEIVEDBY { get; set; }
        public Nullable<System.DateTime> RECEIVEDDATE { get; set; }
        public decimal STD_MATCOST { get; set; }
        public decimal STD_UNITHOUR { get; set; }
        public decimal TOTAL_OUTSOURCE_COST { get; set; }
        public decimal TOTAL_MAT_COST { get; set; }
        public decimal TOTAL_HOURS { get; set; }
        public decimal TOTAL_HOUR_COST { get; set; }
        public decimal TOTAL_PRODUCTION_COST { get; set; }
        public decimal LABOUR_HR_COST { get; set; }
        public string AUDITUSER { get; set; }
        public string MODIUSER { get; set; }
        public Nullable<System.DateTime> LASTMODIFY { get; set; }
    }
}
