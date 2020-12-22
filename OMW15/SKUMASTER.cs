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
    
    public partial class SKUMASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SKUMASTER()
        {
            this.SKUBALANCEs = new HashSet<SKUBALANCE>();
            this.SKUWARELOCATIONs = new HashSet<SKUWARELOCATION>();
            this.GOODSMASTERs = new HashSet<GOODSMASTER>();
            this.SKUMOVEs = new HashSet<SKUMOVE>();
        }
    
        public int SKU_KEY { get; set; }
        public string SKU_CODE { get; set; }
        public string SKU_NAME { get; set; }
        public string SKU_E_NAME { get; set; }
        public string SKU_BARCODE { get; set; }
        public int SKU_BRN { get; set; }
        public int SKU_ICCAT { get; set; }
        public int SKU_S_UTQ { get; set; }
        public int SKU_T_UTQ { get; set; }
        public int SKU_K_UTQ { get; set; }
        public short SKU_VAT_TY { get; set; }
        public decimal SKU_VAT { get; set; }
        public short SKU_COST_TY { get; set; }
        public decimal SKU_STD_COST { get; set; }
        public short SKU_STOCK { get; set; }
        public int SKU_SKUALT { get; set; }
        public short SKU_WH_TY { get; set; }
        public decimal SKU_WH_RATE { get; set; }
        public string SKU_MSG_1 { get; set; }
        public string SKU_MSG_2 { get; set; }
        public string SKU_MSG_3 { get; set; }
        public int SKU_MIXCOLOR { get; set; }
        public int SKU_ICCOLOR { get; set; }
        public int SKU_ICSIZE { get; set; }
        public int SKU_ICDEPT { get; set; }
        public int SKU_ICGL { get; set; }
        public int SKU_ICPRT { get; set; }
        public int SKU_WL { get; set; }
        public string SKU_ENABLE { get; set; }
        public string SKU_P_ENABLE { get; set; }
        public decimal SKU_MIN_QTY { get; set; }
        public decimal SKU_MAX_QTY { get; set; }
        public decimal SKU_MIN_ORDER { get; set; }
        public decimal SKU_MAX_ORDER { get; set; }
        public decimal SKU_LEAD_TIME { get; set; }
        public decimal SKU_SATISFY { get; set; }
        public decimal SKU_SAFTY { get; set; }
        public Nullable<int> SKU_FREQUENCY { get; set; }
        public short SKU_ACCESS { get; set; }
        public Nullable<int> SKU_ABC { get; set; }
        public decimal SKU_EOQ_A { get; set; }
        public decimal SKU_EOQ_P { get; set; }
        public decimal SKU_EOQ_C { get; set; }
        public decimal SKU_EOQ_NO { get; set; }
        public string SKU_SPEC { get; set; }
        public string SKU_USAGE { get; set; }
        public string SKU_REMARK { get; set; }
        public System.DateTime SKU_LAST_O { get; set; }
        public System.DateTime SKU_LAST_R { get; set; }
        public decimal SKU_LAST_RCOST { get; set; }
        public decimal SKU_LAST_RQTY { get; set; }
        public Nullable<System.DateTime> SKU_LAST_COMMIT { get; set; }
        public Nullable<int> SKU_SENSITIVITY { get; set; }
        public Nullable<int> SKU_SENS_POS { get; set; }
        public decimal SKU_LAST_UBCOST { get; set; }
        public decimal SKU_LAST_UCCOST { get; set; }
        public short SKU_ALERT { get; set; }
        public string SKU_ALERT_MSG { get; set; }
        public Nullable<int> SKU_PRICE { get; set; }
        public string SKU_EQ_FACTOR { get; set; }
        public string SKU_EQ_NAME { get; set; }
        public decimal SKU_UDF_1 { get; set; }
        public decimal SKU_UDF_2 { get; set; }
        public decimal SKU_UDF_3 { get; set; }
        public decimal SKU_UDF_4 { get; set; }
        public decimal SKU_UDF_5 { get; set; }
        public decimal SKU_UDF_6 { get; set; }
        public string SKU_LASTUPD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKUBALANCE> SKUBALANCEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKUWARELOCATION> SKUWARELOCATIONs { get; set; }
        public virtual UOFQTY UOFQTY { get; set; }
        public virtual UOFQTY UOFQTY1 { get; set; }
        public virtual UOFQTY UOFQTY2 { get; set; }
        public virtual ICCAT ICCAT { get; set; }
        public virtual ICDEPT ICDEPT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOODSMASTER> GOODSMASTERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SKUMOVE> SKUMOVEs { get; set; }
    }
}
