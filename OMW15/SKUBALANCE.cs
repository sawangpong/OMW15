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
    
    public partial class SKUBALANCE
    {
        public int SKB_KEY { get; set; }
        public int SKB_SKU { get; set; }
        public System.DateTime SKB_DATE { get; set; }
        public int SKB_WL { get; set; }
        public Nullable<int> SKB_FIFO { get; set; }
        public string SKB_LOT_NO { get; set; }
        public string SKB_SERIAL { get; set; }
        public int SKB_UTQ { get; set; }
        public decimal SKB_UTQQTY { get; set; }
        public decimal SKB_U_PRC { get; set; }
        public decimal SKB_QTY { get; set; }
        public decimal SKB_COST { get; set; }
        public Nullable<System.DateTime> SKB_EXP_D { get; set; }
        public Nullable<System.DateTime> SKB_MAN_D { get; set; }
        public int SKB_DI { get; set; }
        public Nullable<int> SKB_CREATOR { get; set; }
        public string SKB_LASTUPD { get; set; }
    
        public virtual SKUMASTER SKUMASTER { get; set; }
        public virtual DOCINFO DOCINFO { get; set; }
        public virtual UOFQTY UOFQTY { get; set; }
    }
}
