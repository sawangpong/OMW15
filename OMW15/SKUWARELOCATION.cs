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
    
    public partial class SKUWARELOCATION
    {
        public int SKUWL_KEY { get; set; }
        public int SKUWL_SKU { get; set; }
        public int SKUWL_WL { get; set; }
        public int SKUWL_SEQ { get; set; }
        public int SKUWL_GOODS { get; set; }
        public decimal SKUWL_USED_QTY { get; set; }
        public int SKUWL_FREQUENCY { get; set; }
        public int SKUWL_MIN_QTY { get; set; }
        public int SKUWL_MAX_QTY { get; set; }
        public int SKUWL_DT { get; set; }
        public int SKUWL_RPLN_FROM { get; set; }
        public int SKUWL_RPLN_WL { get; set; }
        public int SKUWL_RPLN_WHEN { get; set; }
        public int SKUWL_RPLN_QTY { get; set; }
        public int SKUWL_RPLN_ROUND { get; set; }
        public int SKUWL_TOPV_ABC { get; set; }
        public int SKUWL_TOPQ_ABC { get; set; }
        public int SKUWL_UPRC_ABC { get; set; }
        public string SKUWL_LASTUPD { get; set; }
    
        public virtual SKUMASTER SKUMASTER { get; set; }
        public virtual DOCTYPE DOCTYPE { get; set; }
        public virtual GOODSMASTER GOODSMASTER { get; set; }
    }
}